using Catering.API.Options;
using Catering.BLL.Contracts.Payment;
using Catering.Common.WebClient;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Catering.API.Integrations
{
    public class PaymentService : IPaymentService
    {
		private PaymentServiceOptions _paymentOptions;

		private readonly IWebApiClient _webApiClient;

		public PaymentService(
			IWebApiClient webApiClient,
			IOptions<PaymentServiceOptions> paymentOptions)
		{
			_webApiClient = webApiClient;
			_paymentOptions = paymentOptions.Value;
		}

		public async Task CreatePayment(PaymentRequest request)
		{
			var uri = new Uri(new Uri(_paymentOptions.Url), _paymentOptions.Action);
			await _webApiClient.DoRequest(HttpMethod.Post, request, uri);
		}
	}
}
