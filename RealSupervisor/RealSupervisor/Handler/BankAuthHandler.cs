using RealSupervisor.Interface;
using System.Net.Http.Headers;

namespace RealSupervisor.Handler
{
    public class BankAuthHandler: DelegatingHandler
    {
        private readonly IBankAuthService _bankAuthService;

        public BankAuthHandler(IBankAuthService bankAuthService)
        {
            _bankAuthService = bankAuthService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var token = await _bankAuthService.RetrieveToken();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
