using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Eventis.Prodis.OnlineApi.Version_2_0
{
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IOnlineApi
    {
        #region Version

        [OperationContract]
        [WebGet(UriTemplate = "/Version")]
        VersionType GetVersion();

        #endregion

        #region Supported Features

        [OperationContract]
        [WebGet(UriTemplate = "/SupportedFeatures")]
        Features GetSupportedFeatures();

        #endregion

        #region Products

        [OperationContract]
        [WebGet(UriTemplate = "/Products")]
        Products GetProducts();

        [OperationContract]
        [WebGet(UriTemplate = "/Products/Filter?FilterName={filterName}")]
        Products GetProductsByFilter(string filterName);

        [OperationContract]
        [WebGet(UriTemplate = "/Products/FilterCount?FilterName={filterName}")]
        ResultCountType GetProductCountByFilter(string filterName);

        [OperationContract]
        [WebGet(UriTemplate = "/Products/{vodBackOfficeId}")]
        ProductType GetProduct(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Products/{alias}?Alias={aliasSpecifier}")]
        ProductType GetProductByAlias(string alias, string aliasSpecifier);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Products")]
        ProductType CreateProduct(ProductType productType);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Products/{vodBackOfficeId}")]
        ProductType UpdateProduct(string vodBackOfficeId, ProductType productType);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Products/{alias}?Alias={aliasSpecifier}")]
        ProductType UpdateProductByAlias(string alias, string aliasSpecifier, ProductType productType);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Products/{vodBackOfficeId}")]
        void DeleteProduct(string vodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Products/{alias}?Alias={aliasSpecifier}")]
        void DeleteProductByAlias(string alias, string aliasSpecifier);

        #endregion

        #region Advanced Product Properties

        [OperationContract]
        [WebGet(UriTemplate = "/Products/{vodBackOfficeId}/AdvancedProductProperties")]
        AdvancedProductProperties GetAdvancedProductProperties(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Products/{vodBackOfficeId}/AdvancedProductProperties/{propertyName}")]
        AdvancedProductPropertyType GetAdvancedProductProperty(string vodBackOfficeId, string propertyName);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Products/{vodBackOfficeId}/AdvancedProductProperties/{propertyName}")
        ]
        AdvancedProductPropertyType CreateOrUpdateAdvancedProductProperty(string vodBackOfficeId, string propertyName,
                                                                          AdvancedProductPropertyType
                                                                              advancedProductProperty);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/Products/{vodBackOfficeId}/AdvancedProductProperties/{propertyName}")]
        void DeleteAdvancedProductProperty(string vodBackOfficeId, string propertyName);

        #endregion

        #region Assets

        [OperationContract]
        [WebGet(UriTemplate = "/Assets")]
        Assets GetAssets();

        // TODO return object instead of stream
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Assets")]
        Stream CreateAsset(CreateAssetType createAssetType);

        [OperationContract]
        [WebGet(UriTemplate = "/Assets?ModifiedSince={modificationTimestamp}")]
        Assets GetModifiedAssets(string modificationTimestamp);

        [OperationContract]
        [WebGet(UriTemplate = "/Assets/{vodBackOfficeId}")]
        AssetType GetAsset(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Assets/{alias}?Alias={aliasSpecifier}")]
        AssetType GetAssetByAlias(string alias, string aliasSpecifier);

        [OperationContract]
        [WebGet(UriTemplate = "/Assets/Filter?FilterName={filterName}")]
        Assets GetAssetsByFilter(string filterName);

        [OperationContract]
        [WebGet(UriTemplate = "/Assets/FilterCount?FilterName={filterName}")]
        ResultCountType GetAssetCountByFilter(string filterName);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Assets/{vodBackOfficeId}")]
        void DeleteAsset(string vodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Assets/{alias}?Alias={aliasSpecifier}")]
        void DeleteAssetByAlias(string alias, string aliasSpecifier);

        [OperationContract]
        [WebGet(UriTemplate = "/Assets/{vodBackOfficeId}/EventInfo")]
        EventInfoType GetEventInfoForAsset(string vodBackOfficeId);

        #endregion

        #region Advanced Asset Properties

        [OperationContract]
        [WebGet(UriTemplate = "/Assets/{vodBackOfficeId}/AdvancedAssetProperties")]
        AdvancedAssetProperties GetAdvancedAssetProperties(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Assets/{vodBackOfficeId}/AdvancedAssetProperties/{propertyName}")]
        AdvancedAssetProperties GetAdvancedAssetProperty(string vodBackOfficeId, string propertyName);

        #endregion

        #region Product Asset Associations

        [OperationContract]
        [WebGet(UriTemplate = "/Assets/{assetVodBackOfficeId}/Products")]
        ProductAssetAssociations GetProductAssetAssociationsByAssetId(string assetVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Products/{productVodBackOfficeId}/Assets")]
        ProductAssetAssociations GetProductAssetAssociationsByProductId(string productVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Assets/{assetVodBackOfficeId}/Products/{productVodBackOfficeId}")]
        ProductAssetAssociationType GetProductAssetAssociationByAssetAndProduct(string assetVodBackOfficeId,
                                                                                string productVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Products/{productVodBackOfficeId}/Assets/{assetVodBackOfficeId}")]
        ProductAssetAssociationType GetProductAssetAssociationByProductAndAsset(string productVodBackOfficeId,
                                                                                string assetVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Assets/{assetVodBackOfficeId}/Products/{productVodBackOfficeId}")]
        ProductAssetAssociationType CreateOrUpdateProductAssetAssociationByAssetAndProduct(string assetVodBackOfficeId,
                                                                                           string productVodBackOfficeId,
                                                                                           ProductAssetAssociationType
                                                                                               productAssetAssociation);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Products/{productVodBackOfficeId}/Assets/{assetVodBackOfficeId}")]
        ProductAssetAssociationType CreateOrUpdateProductAssetAssociationByProductAndAsset(
            string productVodBackOfficeId, string assetVodBackOfficeId,
            ProductAssetAssociationType productAssetAssociation);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Assets/{assetVodBackOfficeId}/Products/{productVodBackOfficeId}")]
        void DeleteProductAssetAssociationByAssetAndProduct(string assetVodBackOfficeId, string productVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Products/{productVodBackOfficeId}/Assets/{assetVodBackOfficeId}")]
        void DeleteProductAssetAssociationByProductAndAsset(string productVodBackOfficeId, string assetVodBackOfficeId);

        #endregion

        #region Node Title Associations

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{titleVodBackOfficeId}/Nodes")]
        NodeTitleAssociations GetNodeTitleAssociationsByTitleId(string titleVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{nodeVodBackOfficeId}/Titles")]
        NodeTitleAssociations GetNodeTitleAssociationsByNodeId(string nodeVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{titleVodBackOfficeId}/Nodes/{nodeVodBackOfficeId}")]
        NodeTitleAssociationType GetNodeTitleAssociationByTitleAndNode(string titleVodBackOfficeId,
                                                                       string nodeVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{nodeVodBackOfficeId}/Titles/{titleVodBackOfficeId}")]
        NodeTitleAssociationType GetNodeTitleAssociationByNodeAndTitle(string nodeVodBackOfficeId,
                                                                       string titleVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Titles/{titleVodBackOfficeId}/Nodes/{nodeVodBackOfficeId}")]
        NodeTitleAssociationType CreateOrUpdateNodeTitleAssociationByTitleAndNode(string titleVodBackOfficeId,
                                                                                  string nodeVodBackOfficeId,
                                                                                  NodeTitleAssociationType
                                                                                      nodeTitleAssociation);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Nodes/{nodeVodBackOfficeId}/Titles/{titleVodBackOfficeId}")]
        NodeTitleAssociationType CreateOrUpdateNodeTitleAssociationByNodeAndTitle(string nodeVodBackOfficeId,
                                                                                  string titleVodBackOfficeId,
                                                                                  NodeTitleAssociationType
                                                                                      nodeTitleAssociation);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Titles/{titleVodBackOfficeId}/Nodes/{nodeVodBackOfficeId}")]
        void DeleteNodeTitleAssociationByTitleAndNode(string titleVodBackOfficeId, string nodeVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Nodes/{nodeVodBackOfficeId}/Titles/{titleVodBackOfficeId}")]
        void DeleteNodeTitleAssociationByNodeAndTitle(string nodeVodBackOfficeId, string titleVodBackOfficeId);

        #endregion

        #region Node Product Associations

        [OperationContract]
        [WebGet(UriTemplate = "/Products/{productVodBackOfficeId}/Nodes")]
        NodeProductAssociations GetNodeProductAssociationsByProductId(string productVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{nodeVodBackOfficeId}/Products")]
        NodeProductAssociations GetNodeProductAssociationsByNodeId(string nodeVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Products/{productVodBackOfficeId}/Nodes/{nodeVodBackOfficeId}")]
        NodeProductAssociationType GetNodeProductAssociationByProductAndNode(string productVodBackOfficeId,
                                                                             string nodeVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{nodeVodBackOfficeId}/Products/{productVodBackOfficeId}")]
        NodeProductAssociationType GetNodeProductAssociationByNodeAndProduct(string nodeVodBackOfficeId,
                                                                             string productVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Products/{productVodBackOfficeId}/Nodes/{nodeVodBackOfficeId}")]
        NodeProductAssociationType CreateOrUpdateNodeProductAssociationByProductAndNode(string productVodBackOfficeId,
                                                                                        string nodeVodBackOfficeId,
                                                                                        NodeProductAssociationType
                                                                                            nodeProductAssociation);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Nodes/{nodeVodBackOfficeId}/Products/{productVodBackOfficeId}")]
        NodeProductAssociationType CreateOrUpdateNodeProductAssociationByNodeAndProduct(string nodeVodBackOfficeId,
                                                                                        string productVodBackOfficeId,
                                                                                        NodeProductAssociationType
                                                                                            nodeProductAssociation);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Products/{productVodBackOfficeId}/Nodes/{nodeVodBackOfficeId}")]
        void DeleteNodeProductAssociationByProductAndNode(string productVodBackOfficeId, string nodeVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Nodes/{nodeVodBackOfficeId}/Products/{productVodBackOfficeId}")]
        void DeleteNodeProductAssociationByNodeAndProduct(string nodeVodBackOfficeId, string productVodBackOfficeId);

        #endregion

        #region Nodes

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes")]
        Nodes GetNodes();

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes?Catalog={catalogCode}")]
        Nodes GetNodesForCatalog(string catalogCode);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/Filter?FilterName={filterName}")]
        Nodes GetNodesByFilter(string filterName);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/FilterCount?FilterName={filterName}")]
        ResultCountType GetNodeCountByFilter(string filterName);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{vodBackOfficeId}")]
        NodeType GetNode(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{alias}?Alias={aliasSpecifier}")]
        NodeType GetNodeByAlias(string alias, string aliasSpecifier);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Nodes")]
        NodeType CreateNode(NodeType nodeType);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Nodes/{vodBackOfficeId}")]
        NodeType UpdateNode(string vodBackOfficeId, NodeType nodeType);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Nodes/{alias}?Alias={aliasSpecifier}")]
        NodeType UpdateNodeByAlias(string alias, string aliasSpecifier, NodeType nodeType);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Nodes/{vodBackOfficeId}")]
        void DeleteNode(string vodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Nodes/{alias}?Alias={aliasSpecifier}")]
        void DeleteNodeByAlias(string alias, string aliasSpecifier);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{vodBackOfficeId}/Parent")]
        Nodes GetParentNode(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{vodBackOfficeId}/Nodes")]
        Nodes GetSubNodes(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{vodBackOfficeId}/Tree")]
        HierarchicalNodeType GetSubNodeTree(string vodBackOfficeId);

        #endregion

        #region Node Image Stream

        [OperationContract]
        [WebGet(
            UriTemplate =
                "/Nodes/{vodBackOfficeId}/Image?ImageEncoding={imageEncoding}&Height={height}&Width={width}&imageProfile={imageProfile}"
            )]
        Stream GetNodeImage(string vodBackOfficeId, string imageEncoding, string height, string width,
                            string imageProfile);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Nodes/{vodBackOfficeId}/Image/{imageFileName}")]
        void CreateNodeImage(string vodBackOfficeId, string imageFileName, Stream imageStream);

        #endregion

        #region Smart Node Definition

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{vodBackOfficeId}/SharedSmartNodeDefinition")]
        SharedSmartNodeDefinitionType GetSharedSmartNodeDefinition(string vodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Nodes/{vodBackOfficeId}/SharedSmartNodeDefinition")]
        SharedSmartNodeDefinitionType CreateOrUpdateSharedSmartNodeDefinition(string vodBackOfficeId,
                                                                              SharedSmartNodeDefinitionType
                                                                                  sharedSmartNodeDefinition);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Nodes/{vodBackOfficeId}/SharedSmartNodeDefinition")]
        void DeleteSharedSmartNodeDefinition(string vodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/SharedSmartNodeDefinitionPreview")]
        SharedSmartNodePreviewType GetSharedSmartNodeDefinitionPreview(
            SharedSmartNodeDefinitionType sharedSmartNodeDefinition);

        #endregion

        #region Advanced Node Properties

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{vodBackOfficeId}/AdvancedNodeProperties")]
        AdvancedNodeProperties GetAdvancedNodeProperties(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{vodBackOfficeId}/AdvancedNodeProperties/{propertyName}")]
        AdvancedNodePropertyType GetAdvancedNodeProperty(string vodBackOfficeId, string propertyName);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Nodes/{vodBackOfficeId}/AdvancedNodeProperties/{propertyName}")]
        AdvancedNodePropertyType CreateOrUpdateAdvancedNodeProperty(string vodBackOfficeId, string propertyName,
                                                                    AdvancedNodePropertyType advancedNodeProperty);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Nodes/{vodBackOfficeId}/AdvancedNodeProperties/{propertyName}")]
        void DeleteAdvancedNodeProperty(string vodBackOfficeId, string propertyName);

        #endregion

        #region Custom Node Properties

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{vodBackOfficeId}/CustomProperties")]
        CustomNodeProperties GetCustomNodeProperties(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{vodBackOfficeId}/CustomProperties/{customPropertyVodBackOfficeId}")]
        CustomPropertyType GetCustomNodeProperty(string vodBackOfficeId, string customPropertyVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Nodes/{vodBackOfficeId}/CustomProperties")]
        CustomPropertyType CreateCustomNodeProperty(string vodBackOfficeId, CustomPropertyType customProperty);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/Nodes/{vodBackOfficeId}/CustomProperties/{customPropertyVodBackOfficeId}")]
        CustomPropertyType UpdateCustomNodeProperty(string vodBackOfficeId, string customPropertyVodBackOfficeId,
                                                    CustomPropertyType customProperty);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/Nodes/{vodBackOfficeId}/CustomProperties/{customPropertyVodBackOfficeId}")]
        void DeleteCustomNodeProperty(string vodBackOfficeId, string customPropertyVodBackOfficeId);

        #endregion

        #region Catalogs

        [OperationContract]
        [WebGet(UriTemplate = "/Catalogs")]
        Catalogs GetCatalogs();

        [OperationContract]
        [WebGet(UriTemplate = "/Catalogs/{catalogCode}")]
        CatalogType GetCatalog(string catalogCode);

        [OperationContract]
        [WebGet(UriTemplate = "/Catalogs/{catalogCode}/Tree")]
        CatalogTreeType GetCatalogTree(string catalogCode);

        #endregion

        #region Tariffs

        [OperationContract]
        [WebGet(UriTemplate = "/Tariffs")]
        Tariffs GetTariffs();

        [OperationContract]
        [WebGet(UriTemplate = "/Tariffs/{tariffName}")]
        TariffType GetTariff(string tariffName);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Tariffs/{tariffName}")]
        TariffType CreateOrUpdateTariff(string tariffName, TariffType tariffType);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Tariffs/{tariffName}")]
        void DeleteTariff(string tariffName);

        #endregion

        #region Product Tags

        [OperationContract]
        [WebGet(UriTemplate = "/ProductTags")]
        ProductTags GetProductTags();

        [OperationContract]
        [WebGet(UriTemplate = "/ProductTags/{vodBackOfficeId}")]
        ProductTagType GetProductTag(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/ProductTags/{alias}?Alias={aliasSpecifier}")]
        ProductTagType GetProductTagByAlias(string alias, string aliasSpecifier);

        #endregion

        #region Product ProductTag Associations

        [OperationContract]
        [WebGet(UriTemplate = "/ProductTags/{productTagVodBackOfficeId}/Products")]
        ProductProductTagAssociations GetProductTagAssociationsByProductTagId(string productTagVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Products/{productVodBackOfficeId}/ProductTags")]
        ProductProductTagAssociations GetProductTagAssociationsByProductId(string productVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/ProductTags/{productTagVodBackOfficeId}/Products/{productVodBackOfficeId}")]
        ProductProductTagAssociationType GetProductProductTagAssociationByProductTagAndProduct(
            string productTagVodBackOfficeId, string productVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Products/{productVodBackOfficeId}/ProductTags/{productTagVodBackOfficeId}")]
        ProductProductTagAssociationType GetProductProductTagAssociationByProductAndProductTag(
            string productVodBackOfficeId, string productTagVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/ProductTags/{productTagVodBackOfficeId}/Products/{productVodBackOfficeId}")]
        ProductProductTagAssociationType CreateOrUpdateProductProductTagAssociationByProductTagAndProduct(
            string productTagVodBackOfficeId, string productVodBackOfficeId,
            ProductProductTagAssociationType productProductTagAssociation);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/Products/{productVodBackOfficeId}/ProductTags/{productTagVodBackOfficeId}")]
        ProductProductTagAssociationType CreateOrUpdateProductProductTagAssociationByProductAndProductTag(
            string productVodBackOfficeId, string productTagVodBackOfficeId,
            ProductProductTagAssociationType productProductTagAssociation);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/ProductTags/{productTagVodBackOfficeId}/Products/{productVodBackOfficeId}")]
        void DeleteProductProductTagAssociationByProductTagAndProduct(string productTagVodBackOfficeId,
                                                                      string productVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/Products/{productVodBackOfficeId}/ProductTags/{productTagVodBackOfficeId}")]
        void DeleteProductProductTagAssociationByProductAndProductTag(string productVodBackOfficeId,
                                                                      string productTagVodBackOfficeId);

        #endregion

        #region Asset Tags

        [OperationContract]
        [WebGet(UriTemplate = "/AssetTags")]
        AssetTags GetAssetTags();

        [OperationContract]
        [WebGet(UriTemplate = "/AssetTags/{vodBackOfficeId}")]
        AssetTagType GetAssetTag(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/AssetTags/{alias}?Alias={aliasSpecifier}")]
        AssetTagType GetAssetTagByAlias(string alias, string aliasSpecifier);

        #endregion

        #region Asset AssetTag Associations

        [OperationContract]
        [WebGet(UriTemplate = "/AssetTags/{assetTagVodBackOfficeId}/Assets")]
        AssetAssetTagAssociations GetAssetTagAssociationsByAssetTagId(string assetTagVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Assets/{assetVodBackOfficeId}/AssetTags")]
        AssetAssetTagAssociations GetAssetTagAssociationsByAssetId(string assetVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/AssetTags/{assetTagVodBackOfficeId}/Assets/{assetVodBackOfficeId}")]
        AssetAssetTagAssociationType GetAssetAssetTagAssociationByAssetTagAndAsset(string assetTagVodBackOfficeId,
                                                                                   string assetVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Assets/{assetVodBackOfficeId}/AssetTags/{assetTagVodBackOfficeId}")]
        AssetAssetTagAssociationType GetAssetAssetTagAssociationByAssetAndAssetTag(string assetVodBackOfficeId,
                                                                                   string assetTagVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/AssetTags/{assetTagVodBackOfficeId}/Assets/{assetVodBackOfficeId}")]
        AssetAssetTagAssociationType CreateOrUpdateAssetAssetTagAssociationByAssetTagAndAsset(
            string assetTagVodBackOfficeId, string assetVodBackOfficeId,
            AssetAssetTagAssociationType assetAssetTagAssociation);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Assets/{assetVodBackOfficeId}/AssetTags/{assetTagVodBackOfficeId}")]
        AssetAssetTagAssociationType CreateOrUpdateAssetAssetTagAssociationByAssetAndAssetTag(
            string assetVodBackOfficeId, string assetTagVodBackOfficeId,
            AssetAssetTagAssociationType assetAssetTagAssociation);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/AssetTags/{assetTagVodBackOfficeId}/Assets/{assetVodBackOfficeId}"
            )]
        void DeleteAssetAssetTagAssociationByAssetTagAndAsset(string assetTagVodBackOfficeId,
                                                              string assetVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Assets/{assetVodBackOfficeId}/AssetTags/{assetTagVodBackOfficeId}"
            )]
        void DeleteAssetAssetTagAssociationByAssetAndAssetTag(string assetVodBackOfficeId,
                                                              string assetTagVodBackOfficeId);

        #endregion

        #region Titles

        [OperationContract]
        [WebGet(UriTemplate = "/Titles")]
        Titles GetTitles();

        [OperationContract]
        [WebGet(UriTemplate = "/Assets/{vodBackOfficeId}/Title")]
        TitleType GetTitleByAssetId(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{vodBackOfficeId}")]
        TitleType GetTitle(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{alias}?Alias={aliasSpecifier}")]
        TitleType GetTitleByAlias(string alias, string aliasSpecifier);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/Filter?FilterName={filterName}")]
        Titles GetTitlesByFilter(string filterName);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/FilterCount?FilterName={filterName}")]
        ResultCountType GetTitleCountByFilter(string filterName);

        #endregion

        #region Title Metadata

        [OperationContract]
        [WebGet(UriTemplate = "/Assets/{vodBackOfficeId}/Title/Metadata")]
        Stream GetTitleMetadataForAsset(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{vodBackOfficeId}/Metadata")]
        Stream GetTitleMetadataForTitle(string vodBackOfficeId);

        #endregion

        #region Title Images and Title Image Stream

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{vodBackOfficeId}/Images")]
        TitleImages GetTitleImagesByTitleVodBackOfficeId(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{vodBackOfficeId}/Images/{imageClassification}")]
        TitleImageType GetTitleImageByTitleVodBackOfficeId(string vodBackOfficeId, string imageClassification);

        [OperationContract]
        [WebGet(
            UriTemplate =
                "/Titles/{vodBackOfficeId}/Images/{imageClassification}/Image?ImageEncoding={imageEncoding}&Height={height}&Width={width}&imageProfile={imageProfile}"
            )]
        Stream GetTitleImageStreamByTitleVodBackOfficeId(string vodBackOfficeId, string imageClassification,
                                                         string imageEncoding, string height, string width,
                                                         string imageProfile);

        #endregion

        #region Platforms

        [OperationContract]
        [WebGet(UriTemplate = "/Platforms")]
        Platforms GetPlatforms();

        [OperationContract]
        [WebGet(UriTemplate = "/Platforms/{platformCode}")]
        PlatformType GetPlatform(string platformCode);

        #endregion

        #region Platform EncodingProfile Associations

        [OperationContract]
        [WebGet(UriTemplate = "/Platforms/{platformCode}/EncodingProfiles")]
        PlatformEncodingProfileAssociations GetPlatformEncodingProfileAssociationsByPlatformCode(string platformCode);

        [OperationContract]
        [WebGet(UriTemplate = "/EncodingProfiles/{encodingProfileCode}/Platforms")]
        PlatformEncodingProfileAssociations GetPlatformEncodingProfileAssociationsByEncodingProfileCode(
            string encodingProfileCode);

        [OperationContract]
        [WebGet(UriTemplate = "/Platforms/{platformCode}/EncodingProfiles/{encodingProfileCode}")]
        PlatformEncodingProfileAssociationType GetPlatformEncodingProfileAssociationByPlatformCodeAndEncodingProfileCode
            (string platformCode, string encodingProfileCode);

        [OperationContract]
        [WebGet(UriTemplate = "/EncodingProfiles/{encodingProfileCode}/Platforms/{platformCode}")]
        PlatformEncodingProfileAssociationType GetPlatformEncodingProfileAssociationByEncodingProfileCodeAndPlatformCode
            (string encodingProfileCode, string platformCode);

        #endregion

        #region Encoding Profiles

        [OperationContract]
        [WebGet(UriTemplate = "/EncodingProfiles")]
        EncodingProfiles GetEncodingProfiles();

        [OperationContract]
        [WebGet(UriTemplate = "/EncodingProfiles/{encodingProfileCode}")]
        EncodingProfileType GetEncodingProfile(string encodingProfileCode);

        #endregion

        #region GroupDefinitions

        [OperationContract]
        [WebGet(UriTemplate = "/GroupDefinitions")]
        GroupDefinitions GetGroupDefinitions();

        [OperationContract]
        [WebGet(UriTemplate = "/GroupDefinitions/{code}")]
        GroupDefinitions GetGroupDefinitionsByCode(string code);

        #endregion

        #region Groups

        [OperationContract]
        [WebGet(UriTemplate = "/Groups")]
        Groups GetGroups();

        [OperationContract]
        [WebGet(UriTemplate = "/Groups/{vodBackOfficeId}")]
        GroupType GetGroup(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Groups/{alias}?Alias={aliasSpecifier}")]
        GroupType GetGroupByAlias(string alias, string aliasSpecifier);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Groups")]
        GroupType CreateGroup(GroupType groupType);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Groups/{vodBackOfficeId}")]
        GroupType UpdateGroup(string vodBackOfficeId, GroupType groupType);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Groups/{alias}?Alias={aliasSpecifier}")]
        GroupType UpdateGroupByAlias(string alias, string aliasSpecifier, GroupType groupType);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Groups/{vodBackOfficeId}")]
        void DeleteGroup(string vodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Groups/{alias}?Alias={aliasSpecifier}")]
        void DeleteGroupByAlias(string alias, string aliasSpecifier);

        #endregion

        #region Group Title Associations

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{titleVodBackOfficeId}/Groups")]
        GroupTitleAssociations GetGroupTitleAssociationsByTitleId(string titleVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Groups/{groupVodBackOfficeId}/Titles")]
        GroupTitleAssociations GetGroupTitleAssociationsByGroupId(string groupVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{titleVodBackOfficeId}/Groups/{groupVodBackOfficeId}")]
        GroupTitleAssociationType GetGroupTitleAssociationByTitleAndGroup(string titleVodBackOfficeId,
                                                                          string groupVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Groups/{groupVodBackOfficeId}/Titles/{titleVodBackOfficeId}")]
        GroupTitleAssociationType GetGroupTitleAssociationByGroupAndTitle(string groupVodBackOfficeId,
                                                                          string titleVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Titles/{titleVodBackOfficeId}/Groups/{groupVodBackOfficeId}")]
        GroupTitleAssociationType CreateOrUpdateGroupTitleAssociationByTitleAndGroup(string titleVodBackOfficeId,
                                                                                     string groupVodBackOfficeId,
                                                                                     GroupTitleAssociationType
                                                                                         groupTitleAssociation);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Groups/{groupVodBackOfficeId}/Titles/{titleVodBackOfficeId}")]
        GroupTitleAssociationType CreateOrUpdateGroupTitleAssociationByGroupAndTitle(string groupVodBackOfficeId,
                                                                                     string titleVodBackOfficeId,
                                                                                     GroupTitleAssociationType
                                                                                         groupTitleAssociation);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Titles/{titleVodBackOfficeId}/Groups/{groupVodBackOfficeId}")]
        void DeleteGroupTitleAssociationByTitleAndGroup(string titleVodBackOfficeId, string groupVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Groups/{groupVodBackOfficeId}/Titles/{titleVodBackOfficeId}")]
        void DeleteGroupTitleAssociationByGroupAndTitle(string groupVodBackOfficeId, string titleVodBackOfficeId);

        #endregion

        #region Group Group Associations

        [OperationContract]
        [WebGet(UriTemplate = "/Groups/{parentGroupVodBackOfficeId}/ChildGroups")]
        GroupGroupAssociations GetGroupGroupAssociationsByParentGroupId(string parentGroupVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Groups/{childGroupVodBackOfficeId}/ParentGroups")]
        GroupGroupAssociations GetGroupGroupAssociationsByChildGroupId(string childGroupVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Groups/{parentGroupVodBackOfficeId}/ChildGroups/{childGroupVodBackOfficeId}")]
        GroupGroupAssociationType GetGroupGroupAssociationByParentGroupAndChildGroup(string parentGroupVodBackOfficeId,
                                                                                     string childGroupVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Groups/{childGroupVodBackOfficeId}/ParentGroups/{parentGroupVodBackOfficeId}")]
        GroupGroupAssociationType GetGroupGroupAssociationByChildGroupAndParentGroup(string childGroupVodBackOfficeId,
                                                                                     string parentGroupVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/Groups/{parentGroupVodBackOfficeId}/ChildGroups/{childGroupVodBackOfficeId}")]
        GroupGroupAssociationType CreateOrUpdateGroupGroupAssociationByParentGroupAndChildGroup(
            string parentGroupVodBackOfficeId, string childGroupVodBackOfficeId,
            GroupGroupAssociationType groupGroupAssociation);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/Groups/{childGroupVodBackOfficeId}/ParentGroups/{parentGroupVodBackOfficeId}")]
        GroupGroupAssociationType CreateOrUpdateGroupGroupAssociationByChildGroupAndParentGroup(
            string childGroupVodBackOfficeId, string parentGroupVodBackOfficeId,
            GroupGroupAssociationType groupGroupAssociation);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/Groups/{parentGroupVodBackOfficeId}/ChildGroups/{childGroupVodBackOfficeId}")]
        void DeleteGroupGroupAssociationByParentGroupAndChildGroup(string parentGroupVodBackOfficeId,
                                                                   string childGroupVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/Groups/{childGroupVodBackOfficeId}/ParentGroups/{parentGroupVodBackOfficeId}")]
        void DeleteGroupGroupAssociationByChildGroupAndParentGroup(string childGroupVodBackOfficeId,
                                                                   string parentGroupVodBackOfficeId);

        #endregion

        #region Series

        [OperationContract]
        [WebGet(UriTemplate = "/SeriesList")]
        SeriesList GetSeriesList();

        [OperationContract]
        [WebGet(UriTemplate = "/SeriesList/{vodBackOfficeId}")]
        SeriesType GetSeries(string vodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/SeriesList/{alias}?Alias={aliasSpecifier}")]
        SeriesType GetSeriesByAlias(string alias, string aliasSpecifier);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/SeriesList")]
        SeriesType CreateSeries(SeriesType seriesType);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/SeriesList/{vodBackOfficeId}")]
        SeriesType UpdateSeries(string vodBackOfficeId, SeriesType seriesType);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/SeriesList/{alias}?Alias={aliasSpecifier}")]
        SeriesType UpdateSeriesByAlias(string alias, string aliasSpecifier, SeriesType seriesType);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/SeriesList/{vodBackOfficeId}")]
        void DeleteSeries(string vodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/SeriesList/{alias}?Alias={aliasSpecifier}")]
        void DeleteSeriesByAlias(string alias, string aliasSpecifier);

        #endregion

        #region Series Title Associations

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{titleVodBackOfficeId}/SeriesList")]
        SeriesTitleAssociations GetSeriesTitleAssociationsByTitleId(string titleVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/SeriesList/{seriesVodBackOfficeId}/Titles")]
        SeriesTitleAssociations GetSeriesTitleAssociationsBySeriesId(string seriesVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{titleVodBackOfficeId}/SeriesList/{seriesVodBackOfficeId}")]
        SeriesTitleAssociationType GetSeriesTitleAssociationByTitleAndSeries(string titleVodBackOfficeId,
                                                                             string seriesVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/SeriesList/{seriesVodBackOfficeId}/Titles/{titleVodBackOfficeId}")]
        SeriesTitleAssociationType GetSeriesTitleAssociationBySeriesAndTitle(string seriesVodBackOfficeId,
                                                                             string titleVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Titles/{titleVodBackOfficeId}/SeriesList/{seriesVodBackOfficeId}")]
        SeriesTitleAssociationType CreateOrUpdateSeriesTitleAssociationByTitleAndSeries(string titleVodBackOfficeId,
                                                                                        string seriesVodBackOfficeId,
                                                                                        SeriesTitleAssociationType
                                                                                            seriesTitleAssociation);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/SeriesList/{seriesVodBackOfficeId}/Titles/{titleVodBackOfficeId}")]
        SeriesTitleAssociationType CreateOrUpdateSeriesTitleAssociationBySeriesAndTitle(string seriesVodBackOfficeId,
                                                                                        string titleVodBackOfficeId,
                                                                                        SeriesTitleAssociationType
                                                                                            seriesTitleAssociation);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Titles/{titleVodBackOfficeId}/SeriesList/{seriesVodBackOfficeId}")
        ]
        void DeleteSeriesTitleAssociationByTitleAndSeries(string titleVodBackOfficeId, string seriesVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/SeriesList/{seriesVodBackOfficeId}/Titles/{titleVodBackOfficeId}")
        ]
        void DeleteSeriesTitleAssociationBySeriesAndTitle(string seriesVodBackOfficeId, string titleVodBackOfficeId);

        #endregion

        #region Series Series Associations

        [OperationContract]
        [WebGet(UriTemplate = "/SeriesList/{parentSeriesVodBackOfficeId}/ChildSeriesList")]
        SeriesSeriesAssociations GetSeriesSeriesAssociationsByParentSeriesId(string parentSeriesVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/SeriesList/{childSeriesVodBackOfficeId}/ParentSeriesList")]
        SeriesSeriesAssociations GetSeriesSeriesAssociationsByChildSeriesId(string childSeriesVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/SeriesList/{parentSeriesVodBackOfficeId}/ChildSeriesList/{childSeriesVodBackOfficeId}")]
        SeriesSeriesAssociationType GetSeriesSeriesAssociationByParentSeriesAndChildSeries(
            string parentSeriesVodBackOfficeId, string childSeriesVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/SeriesList/{childSeriesVodBackOfficeId}/ParentSeriesList/{parentSeriesVodBackOfficeId}")
        ]
        SeriesSeriesAssociationType GetSeriesSeriesAssociationByChildSeriesAndParentSeries(
            string childSeriesVodBackOfficeId, string parentSeriesVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/SeriesList/{parentSeriesVodBackOfficeId}/ChildSeriesList/{childSeriesVodBackOfficeId}")]
        SeriesSeriesAssociationType CreateOrUpdateSeriesSeriesAssociationByParentSeriesAndChildSeries(
            string parentSeriesVodBackOfficeId, string childSeriesVodBackOfficeId,
            SeriesSeriesAssociationType seriesSeriesAssociation);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/SeriesList/{childSeriesVodBackOfficeId}/ParentSeriesList/{parentSeriesVodBackOfficeId}")]
        SeriesSeriesAssociationType CreateOrUpdateSeriesSeriesAssociationByChildSeriesAndParentSeries(
            string childSeriesVodBackOfficeId, string parentSeriesVodBackOfficeId,
            SeriesSeriesAssociationType seriesSeriesAssociation);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/SeriesList/{parentSeriesVodBackOfficeId}/ChildSeriesList/{childSeriesVodBackOfficeId}")]
        void DeleteSeriesSeriesAssociationByParentSeriesAndChildSeries(string parentSeriesVodBackOfficeId,
                                                                       string childSeriesVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/SeriesList/{childSeriesVodBackOfficeId}/ParentSeriesList/{parentSeriesVodBackOfficeId}")]
        void DeleteSeriesSeriesAssociationByChildSeriesAndParentSeries(string childSeriesVodBackOfficeId,
                                                                       string parentSeriesVodBackOfficeId);

        #endregion

        #region Title Title Associations

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{featureTitleVodBackOfficeId}/Previews")]
        TitleTitleAssociations GetTitleTitleAssociationsByFeatureTitleId(string featureTitleVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{previewTitleVodBackOfficeId}/Features")]
        TitleTitleAssociations GetTitleTitleAssociationsByPreviewTitleId(string previewTitleVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{featureTitleVodBackOfficeId}/Previews/{previewTitleVodBackOfficeId}")]
        TitleTitleAssociationType GetTitleTitleAssociationByFeatureTitleAndPreviewTitle(
            string featureTitleVodBackOfficeId, string previewTitleVodBackOfficeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{previewTitleVodBackOfficeId}/Features/{featureTitleVodBackOfficeId}")]
        TitleTitleAssociationType GetTitleTitleAssociationByPreviewTitleAndFeatureTitle(
            string previewTitleVodBackOfficeId, string featureTitleVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/Titles/{featureTitleVodBackOfficeId}/Previews/{previewTitleVodBackOfficeId}")]
        TitleTitleAssociationType CreateOrUpdateTitleTitleAssociationByFeatureTitleAndPreviewTitle(
            string featureTitleVodBackOfficeId, string previewTitleVodBackOfficeId,
            TitleTitleAssociationType titleTitleAssociation);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/Titles/{previewTitleVodBackOfficeId}/Features/{featureTitleVodBackOfficeId}")]
        TitleTitleAssociationType CreateOrUpdateTitleTitleAssociationByPreviewTitleAndFeatureTitle(
            string previewTitleVodBackOfficeId, string featureTitleVodBackOfficeId,
            TitleTitleAssociationType titleTitleAssociation);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/Titles/{featureTitleVodBackOfficeId}/Previews/{previewTitleVodBackOfficeId}")]
        void DeleteTitleTitleAssociationByFeatureTitleAndPreviewTitle(string featureTitleVodBackOfficeId,
                                                                      string previewTitleVodBackOfficeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/Titles/{previewTitleVodBackOfficeId}/Features/{featureTitleVodBackOfficeId}")]
        void DeleteTitleTitleAssociationByPreviewTitleAndFeatureTitle(string previewTitleVodBackOfficeId,
                                                                      string featureTitleVodBackOfficeId);

        #endregion

        #region Still Images

        [OperationContract]
        [WebGet(UriTemplate = "/StillImages")]
        StillImages GetStillImages();

        [OperationContract]
        [WebGet(
            UriTemplate =
                "/StillImages/{imageId}?IncludeFile={includeFile}&ImageEncoding={imageEncoding}&Height={height}&Width={width}&ImageProfile={imageProfile}"
            )]
        StillImageType GetStillImage(string imageId, bool includeFile, string imageEncoding, string height, string width,
                                     string imageProfile);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/StillImages")]
        StillImageType CreateStillImage(StillImageType stillImageType);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/StillImages/{imageId}")]
        StillImageType UpdateStillImage(string imageId, StillImageType stillImageType);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/StillImages/{imageId}")]
        void DeleteStillImage(string imageId);

        #endregion

        #region Image Classifications

        [OperationContract]
        [WebGet(UriTemplate = "/ImageClassifications")]
        ImageClassifications GetImageClassifications();

        [OperationContract]
        [WebGet(UriTemplate = "/ImageClassifications/{classificationCode}")]
        ImageClassificationType GetImageClassification(string classificationCode);

        #endregion

        #region Product StillImage Associations

        [OperationContract]
        [WebGet(UriTemplate = "/StillImages/{imageId}/Products")]
        ProductStillImageAssociations GetProductStillImageAssociationsByImageId(string imageId);

        [OperationContract]
        [WebGet(UriTemplate = "/Products/{productId}/StillImages")]
        ProductStillImageAssociations GetProductStillImageAssociationsByProductId(string productId);

        [OperationContract]
        [WebGet(UriTemplate = "/Products/{productId}/StillImages/{imageId}")]
        ProductStillImageAssociationType GetProductStillImageAssociationsByProductAndStillImage(string productId,
                                                                                                string imageId);

        [OperationContract]
        [WebGet(UriTemplate = "StillImages/{imageId}/Products/{productId}")]
        ProductStillImageAssociationType GetProductStillImageAssociationsByStillImageAndProduct(string imageId,
                                                                                                string productId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Products/{productId}/StillImages/{imageId}")]
        ProductStillImageAssociationType CreateOrUpdateProductStillImageAssociationByProductAndStillImage(
            string productId, string imageId, ProductStillImageAssociationType productStillImageAssociationType);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/StillImages/{imageId}/Products/{productId}")]
        ProductStillImageAssociationType CreateOrUpdateProductStillImageAssociationByStillImageAndProduct(
            string imageId, string productId, ProductStillImageAssociationType productStillImageAssociationType);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Products/{productId}/StillImages/{imageId}")]
        void DeleteProductStillImageAssociationByProductAndStillImage(string productId, string imageId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/StillImages/{imageId}/Products/{productId}")]
        void DeleteProductStillImageAssociationByStillImageAndProduct(string imageId, string productId);

        #endregion

        #region Node StillImage Associations

        [OperationContract]
        [WebGet(UriTemplate = "/StillImages/{imageId}/Nodes")]
        NodeStillImageAssociations GetNodeStillImageAssociationsByImageId(string imageId);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{nodeId}/StillImages")]
        NodeStillImageAssociations GetNodeStillImageAssociationsByNodeId(string nodeId);

        [OperationContract]
        [WebGet(UriTemplate = "/Nodes/{nodeId}/StillImages/{imageId}")]
        NodeStillImageAssociationType GetNodeStillImageAssociationsByNodeAndStillImage(string nodeId, string imageId);

        [OperationContract]
        [WebGet(UriTemplate = "StillImages/{imageId}/Nodes/{nodeId}")]
        NodeStillImageAssociationType GetNodeStillImageAssociationsByStillImageAndNode(string imageId, string nodeId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Nodes/{nodeId}/StillImages/{imageId}")]
        NodeStillImageAssociationType CreateOrUpdateNodeStillImageAssociationByNodeAndStillImage(string nodeId,
                                                                                                 string imageId,
                                                                                                 NodeStillImageAssociationType
                                                                                                     nodeStillImageAssociationType);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/StillImages/{imageId}/Nodes/{nodeId}")]
        NodeStillImageAssociationType CreateOrUpdateNodeStillImageAssociationByStillImageAndNode(string imageId,
                                                                                                 string nodeId,
                                                                                                 NodeStillImageAssociationType
                                                                                                     nodeStillImageAssociationType);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Nodes/{nodeId}/StillImages/{imageId}")]
        void DeleteNodeStillImageAssociationByNodeAndStillImage(string nodeId, string imageId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/StillImages/{imageId}/Nodes/{nodeId}")]
        void DeleteNodeStillImageAssociationByStillImageAndNode(string imageId, string nodeId);

        #endregion

        #region Series StillImage Associations

        [OperationContract]
        [WebGet(UriTemplate = "/StillImages/{imageId}/SeriesList")]
        SeriesStillImageAssociations GetSeriesStillImageAssociationsByImageId(string imageId);

        [OperationContract]
        [WebGet(UriTemplate = "/SeriesList/{seriesId}/StillImages")]
        SeriesStillImageAssociations GetSeriesStillImageAssociationsBySeriesId(string seriesId);

        [OperationContract]
        [WebGet(UriTemplate = "/SeriesList/{seriesId}/StillImages/{imageId}")]
        SeriesStillImageAssociationType GetSeriesStillImageAssociationsBySeriesAndStillImage(string seriesId,
                                                                                             string imageId);

        [OperationContract]
        [WebGet(UriTemplate = "StillImages/{imageId}/SeriesList/{seriesId}")]
        SeriesStillImageAssociationType GetSeriesStillImageAssociationsByStillImageAndSeries(string imageId,
                                                                                             string seriesId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/SeriesList/{seriesId}/StillImages/{imageId}")]
        SeriesStillImageAssociationType CreateOrUpdateSeriesStillImageAssociationBySeriesAndStillImage(string seriesId,
                                                                                                       string imageId,
                                                                                                       SeriesStillImageAssociationType
                                                                                                           seriesStillImageAssociationType);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/StillImages/{imageId}/SeriesList/{seriesId}")]
        SeriesStillImageAssociationType CreateOrUpdateSeriesStillImageAssociationByStillImageAndSeries(string imageId,
                                                                                                       string seriesId,
                                                                                                       SeriesStillImageAssociationType
                                                                                                           seriesStillImageAssociationType);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/SeriesList/{seriesId}/StillImages/{imageId}")]
        void DeleteSeriesStillImageAssociationBySeriesAndStillImage(string seriesId, string imageId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/StillImages/{imageId}/SeriesList/{seriesId}")]
        void DeleteSeriesStillImageAssociationByStillImageAndSeries(string imageId, string seriesId);

        #endregion

        #region Title StillImage Associations

        [OperationContract]
        [WebGet(UriTemplate = "/StillImages/{imageId}/Titles")]
        TitleStillImageAssociations GetTitleStillImageAssociationsByImageId(string imageId);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{titleId}/StillImages")]
        TitleStillImageAssociations GetTitleStillImageAssociationsByTitleId(string titleId);

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{titleId}/StillImages/{imageId}")]
        TitleStillImageAssociationType GetTitleStillImageAssociationsByTitleAndStillImage(string titleId, string imageId);

        [OperationContract]
        [WebGet(UriTemplate = "StillImages/{imageId}/Titles/{titleId}")]
        TitleStillImageAssociationType GetTitleStillImageAssociationsByStillImageAndTitle(string imageId, string titleId);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Titles/{titleId}/StillImages/{imageId}")]
        TitleStillImageAssociationType CreateOrUpdateTitleStillImageAssociationByTitleAndStillImage(string titleId,
                                                                                                    string imageId,
                                                                                                    TitleStillImageAssociationType
                                                                                                        titleStillImageAssociationType);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/StillImages/{imageId}/Titles/{titleId}")]
        TitleStillImageAssociationType CreateOrUpdateTitleStillImageAssociationByStillImageAndTitle(string imageId,
                                                                                                    string titleId,
                                                                                                    TitleStillImageAssociationType
                                                                                                        titleStillImageAssociationType);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Titles/{titleId}/StillImages/{imageId}")]
        void DeleteTitleStillImageAssociationByTitleAndStillImage(string titleId, string imageId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/StillImages/{imageId}/Titles/{titleId}")]
        void DeleteTitleStillImageAssociationByStillImageAndTitle(string imageId, string titleId);

        #endregion

        #region TitleMetadataValues

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/MetadataValueDefinitions")]
        TitleMetadataValueDefinitions GetTitleMetadataValueDefinitions();

        [OperationContract]
        [WebGet(UriTemplate = "/Titles/{titleId}/Metadata/Values")]
        TitleMetadataValues GetTitleMetadataValuesByTitle(string titleId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Titles/Metadata/Values")]
        TitleMetadataValues CreateTitleMetadataValues(TitleMetadataValues titleMetadataValues);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Titles/Metadata/Values")]
        TitleMetadataValues UpdateTitleMetadataValues(TitleMetadataValues titleMetadataValues);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Titles/Metadata/Values")]
        void DeleteTitleMetadataValues(TitleMetadataValues titleMetadataValues);

        #endregion
    }
}