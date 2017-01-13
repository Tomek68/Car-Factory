using CarFactory.Interfaces;
using CarFactoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarFactory.Services
{
    public class TokenService: ITokenService 
    {
        private static readonly List<RefreshToken> RefreshTokens = new List<RefreshToken>();

        public void SaveRefreshToken(RefreshToken refreshToken)
        {
            RefreshTokens.Add(refreshToken);
        }

        public RefreshToken GetRefreshToken(string hashedToken)
        {
            return RefreshTokens.SingleOrDefault(rt => rt.Token == hashedToken);
        }

        public void RemoveRefreshToken(string hashedToken)
        {
            var token = RefreshTokens.SingleOrDefault(rt => rt.Token == hashedToken);
            if (token != null)
            {
                RefreshTokens.Remove(token);
            }
        }

        public void RemoveExpiredRefreshTokens(string userName)
        {
            var expiredTokens =
                RefreshTokens.Where(x => x.UserName == userName && DateTime.UtcNow >= x.ExpiresDate).ToList();
            foreach (var expiredToken in expiredTokens)
            {
                RefreshTokens.Remove(expiredToken);
            }
        }
    }

}