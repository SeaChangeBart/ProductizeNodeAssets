using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Eventis.Prodis.OnlineApi.Version_2_0;
using MakeSomeFoldersFree.Properties;

namespace MakeSomeFoldersFree
{
    internal class Program
    {
        private static void Main()
        {
            var prodis2Baddress = Settings.Default.Prodis2bUri;
            Console.WriteLine("Configuration: Prodis2bUri: '{0}'", prodis2Baddress);
            var prodis2Btoken = Settings.Default.Prodis2bToken;
            Console.WriteLine("Configuration: Prodis2bToken: '{0}'",
                !string.IsNullOrWhiteSpace(prodis2Btoken) ? "******" : "<n/a>");
            var prodis2BClientFactory = new WebClientChannelFactoryWithAuthorization<IOnlineApi>(prodis2Baddress,
                prodis2Btoken);
            var prodisClient = prodis2BClientFactory.CreateInstance();

            var productGuids = Settings.Default.ProductGuids.Split(';');
            var products = productGuids.Select(prodisClient.GetProduct).ToArray();

            var catalogCode = Settings.Default.CatalogCode;
            var tree = prodisClient.GetCatalogTree(catalogCode);
            var nodeDict = tree.Node.SelectMany(Flatten).ToDictionary(hnt => hnt.vodBackOfficeId);
            var nodeGuids = Settings.Default.NodeGuids.Split(';');
            var allNodeGuids =
                nodeGuids.Select(g => nodeDict[g])
                    .SelectMany(Flatten)
                    .Select(hnt => hnt.vodBackOfficeId)
                    .Distinct()
                    .ToArray();
            Console.WriteLine("{0} nodes", allNodeGuids.Length);

            var allNodeTitles =
                allNodeGuids.Select(prodisClient.GetNodeTitleAssociationsByNodeId)
                    .Do(_ => Console.Write('.'))
                    .SelectMany(ntas => ntas.NodeTitleAssociation ?? new NodeTitleAssociationType[0])
                    .Select(nta => nta.titleId).Distinct().ToArray();
            Console.WriteLine("\n{0} titles", allNodeTitles.Length);

            var allNodeAssets =
                allNodeTitles.Select(prodisClient.GetTitle)
                    .Do(_ => Console.Write('.'))
                    .SelectMany(t => t.Assets ?? new TitleAssetType[0])
                    .Select(at => at.vodBackOfficeId)
                    .ToArray();
            Console.WriteLine("\n{0} assets", allNodeAssets.Length);

            foreach (var product in products)
            {
                var buyingWindow = product.BuyingWindow;
                var productizedAssets =
                    prodisClient.GetProductAssetAssociationsByProductId(product.vodBackOfficeId).ProductAssetAssociation ??
                    new ProductAssetAssociationType[0];

                var withCorrectEndDate =
                    productizedAssets.Where(
                        paa => paa.AvailabilityWindow.EndDateSpecified == buyingWindow.EndDateSpecified &&
                               paa.AvailabilityWindow.EndDate.Equals(buyingWindow.EndDate));

                var skipAssetIds = withCorrectEndDate.Select(paa => paa.assetId).ToArray();
                Console.WriteLine("Skipping {0} perfectly productized assets for product {1}", skipAssetIds.Length,
                    product.Name);

                var todoAssetIds = allNodeAssets.Except(skipAssetIds).ToArray();
                if (!todoAssetIds.Any())
                {
                    Console.WriteLine("Nothing to do for this product");
                    continue;
                }
                Console.WriteLine("Press Any Key to start productizing {0} assets (ctrl-break to not)", todoAssetIds.Length);
                Console.ReadLine();

                foreach (var assetId in todoAssetIds)
                {
                    var window = new ProductAssetAssociationType
                    {
                        AvailabilityWindow =
                            new TimeWindowType
                            {
                                StartDate = DateTime.UtcNow,
                                EndDate = buyingWindow.EndDate,
                                EndDateSpecified = buyingWindow.EndDateSpecified
                            },
                    };
                    try
                    {
                        Console.WriteLine("Productizing asset {0}", assetId);
                        prodisClient.CreateOrUpdateProductAssetAssociationByAssetAndProduct(assetId,
                            product.vodBackOfficeId, window);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: {0}", e.Message);
                    }
                }
            }

            Console.WriteLine("Done. Press Any Key to quit.");
            Console.ReadLine();
        }

        private static IEnumerable<HierarchicalNodeType> Flatten(HierarchicalNodeType n)
        {
            return n.SubNodes.SelectMany(Flatten).StartWith(n);
        }
    }
}