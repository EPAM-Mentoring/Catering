using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Common.WebClient
{
    public interface IWebApiClient
    {
        public Task DoRequest<TRequest>(HttpMethod httpMethod, TRequest request, Uri uri);

        public Task<TResponse> DoRequest<TRequest, TResponse>(HttpMethod httpMethod, TRequest request, Uri uri);

        public Task DoEmptyRequest(HttpMethod httpMethod, Uri uri);

        public Task<TResponse> DoEmptyRequest<TResponse>(HttpMethod httpMethod, Uri uri);
    }
}
