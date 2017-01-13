using CarFactory.Interfaces;
using CarFactory.Utils;
using CarFactoryDto;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CarFactory.Providers
{
    public class SimpleRefreshTokenProvider : AuthenticationTokenProvider
    {
        private readonly ITokenService _tokenService;

        public SimpleRefreshTokenProvider(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public override async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            string userName = context.Ticket.Identity.Name;

            string token = Guid.NewGuid().ToString("n");
            var refreshToken = new RefreshToken
            {
                UserName = userName,
                Token = HashProvider.Get(token),
                IssuedDate = DateTime.UtcNow,
                ExpiresDate = DateTime.UtcNow.AddMinutes(AppConfiguration.RefreshTokenExpireTimeInMin)
            };

            context.Ticket.Properties.IssuedUtc = refreshToken.IssuedDate;
            context.Ticket.Properties.ExpiresUtc = refreshToken.ExpiresDate;

            refreshToken.ProtectedTicket = context.SerializeTicket();

            _tokenService.SaveRefreshToken(refreshToken);
            context.SetToken(token);
        }

        public override async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var token = HashProvider.Get(context.Token);

            var refreshToken = _tokenService.GetRefreshToken(token);
            if (refreshToken != null)
            {
                context.DeserializeTicket(refreshToken.ProtectedTicket);
                _tokenService.RemoveRefreshToken(token);
                _tokenService.RemoveExpiredRefreshTokens(refreshToken.UserName);
            }
        }
    }
}