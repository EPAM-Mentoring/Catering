using Catering.BLL.Contracts.Reserve;
using Catering.BLL.Interfaces;
using Catering.BLL.Options;
using Catering.Common.WebClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Services
{
    public class BuildingService : IBuildingService
    {
		private ReserveServiceOptions _serviceOptions;
		private readonly IWebApiClient _webApiClient;

		public BuildingService(
			IWebApiClient webApiClient,
			IOptions<ReserveServiceOptions> serviceOptions)
		{
			_webApiClient = webApiClient;
			_serviceOptions = serviceOptions.Value;
		}

		public async Task CreateReserve(ReserveRequest reserveRequest)
        {
			var uri = new Uri(new Uri(_serviceOptions.Url), _serviceOptions.Action);
			await _webApiClient.DoRequest(HttpMethod.Post, reserveRequest, uri);
        }

		public async Task<ReserveResponse> GetFreeBuildings()
		{
			var uri = new Uri(new Uri(_serviceOptions.Url), _serviceOptions.Action);
			var freeBuilds = await _webApiClient.DoEmptyRequest<ReserveResponse>(HttpMethod.Get, uri);
			return freeBuilds;
		}

        public async Task GetStatus(int buildingId)
        {
            
        }
    }
}
