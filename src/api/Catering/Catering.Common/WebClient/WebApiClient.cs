using Catering.Common.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Common.WebClient
{
    public class WebApiClient : IWebApiClient
    {
        private const string MEDIATYPE = "application/json";

        private readonly IHttpClientFactory _httpClientFactory;

        public WebApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
		private async Task<HttpResponseMessage> DoRequestInternal(HttpMethod httpMethod, Uri uri, object requestContent = null)
		{
			var httpClient = _httpClientFactory.CreateClient();
			httpClient.Timeout = TimeSpan.FromMinutes(10);
			httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(MEDIATYPE));

			var request = new HttpRequestMessage
			{
				Method = httpMethod,
				RequestUri = uri
			};

			string requestbody = string.Empty;
			if (requestContent != null)
			{
				requestbody = SeriliazeFunction.SerializeToJson(requestContent);
				request.Content = new StringContent(SeriliazeFunction.SerializeToJson(requestContent), Encoding.UTF8, MEDIATYPE);
			}

			var response = await httpClient.SendAsync(request);
			
			return response;
		}

		private async Task<T> DeserializeContent<T>(HttpResponseMessage httpResponse)
		{
			var stringContent = await httpResponse.Content.ReadAsStringAsync();
			return SeriliazeFunction.DeserializeFromJson<T>(stringContent);
		}

		public async Task<TResponse> DoRequest<TRequest, TResponse>(HttpMethod httpMethod, TRequest request, Uri uri)
		{
			var response = await DoRequestInternal(httpMethod, uri, request);
			return await DeserializeContent<TResponse>(response);
		}

		public async Task DoRequest<TRequest>(HttpMethod httpMethod, TRequest request, Uri uri)
		{
			await DoRequestInternal(httpMethod, uri, request);
		}

		public async Task DoEmptyRequest(HttpMethod httpMethod, Uri uri)
		{
			await DoRequestInternal(httpMethod, uri);
		}

		public async Task<TResponse> DoEmptyRequest<TResponse>(HttpMethod httpMethod, Uri uri)
		{
			var response = await DoRequestInternal(httpMethod, uri);
			return await DeserializeContent<TResponse>(response);
		}
	}
}
