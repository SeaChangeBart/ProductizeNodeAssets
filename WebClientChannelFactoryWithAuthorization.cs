using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace MakeSomeFoldersFree
{
    public class WebClientChannelFactoryWithAuthorization<T> : IClientInstanceFactory<T>
        where T : class
    {
        private WebChannelFactory<T> _webChannelFactory;

        public WebClientChannelFactoryWithAuthorization(string listenAddress, string authorizationHeaderValue)
        {
            var binding = new WebHttpBinding {MaxReceivedMessageSize = Int32.MaxValue};
            _webChannelFactory = new WebChannelFactory<T>(binding, new Uri(listenAddress));
            if (!string.IsNullOrWhiteSpace(authorizationHeaderValue))
            {
                _webChannelFactory.Endpoint.Behaviors.Add(
                    new HttpAuthorizationInserterEndpointBehavior(authorizationHeaderValue));
            }
        }

        public T CreateInstance()
        {
            if (_webChannelFactory == null)
                throw new InvalidOperationException();
            return _webChannelFactory.CreateChannel();
        }

        public void Close()
        {
            _webChannelFactory.Close();
            _webChannelFactory = null;
        }

        class HttpAuthorizationInserterEndpointBehavior : IEndpointBehavior
        {
            private readonly string _authorizationHeaderValue;

            public HttpAuthorizationInserterEndpointBehavior(string authorizationHeaderValue)
            {
                _authorizationHeaderValue = authorizationHeaderValue;
            }

            #region IEndpointBehavior Members

            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }

            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
                var inspector = new HttpAuthorizationInserter(_authorizationHeaderValue);
                clientRuntime.MessageInspectors.Add(inspector);
            }

            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
            }

            public void Validate(ServiceEndpoint endpoint)
            {
            }

            #endregion

            class HttpAuthorizationInserter : IClientMessageInspector
            {
                private const string AuthorizationHttpHeader = "Authorization";
                private readonly string _authorizationHeaderValue;

                public HttpAuthorizationInserter(string authorizationHeaderValue)
                {
                    _authorizationHeaderValue = authorizationHeaderValue;
                }

                public object BeforeSendRequest(ref Message request, IClientChannel channel)
                {
                    HttpRequestMessageProperty httpRequestMessage;
                    object httpRequestMessageObject;
                    if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
                    {
                        httpRequestMessage = (HttpRequestMessageProperty) httpRequestMessageObject;
                        httpRequestMessage.Headers[AuthorizationHttpHeader] = _authorizationHeaderValue;
                    }
                    else
                    {
                        httpRequestMessage = new HttpRequestMessageProperty();
                        httpRequestMessage.Headers.Add(AuthorizationHttpHeader, _authorizationHeaderValue);
                        request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
                    }
                    return null;
                }

                public void AfterReceiveReply(ref Message reply, object correlationState)
                {
                }
            }

        }
    }
}