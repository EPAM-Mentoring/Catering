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

		public async Task<IList<ReserveResponse>> GetFreeBuildings()
		{
			var uri = new Uri(new Uri(_serviceOptions.Url), _serviceOptions.ActionUrl);
			var freeBuilds = await _webApiClient.DoEmptyRequest<IList<ReserveResponse>>(HttpMethod.Get, uri);
			return freeBuilds;
		}

		public async Task<string> GetById(int buildingId)
		{
			var action = string.Format(_serviceOptions.ActionUrlForBuild, buildingId, "TestNameCatering");
			var uri = new Uri(new Uri(_serviceOptions.Url), action);
			var build = await _webApiClient.DoEmptyRequest<string>(HttpMethod.Post, uri);
			return build;
		}
	}
}
