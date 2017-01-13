using CarFactoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory.Interfaces
{
    public interface ITokenService
    {
        void SaveRefreshToken(RefreshToken refreshToken);
        RefreshToken GetRefreshToken(string hashedToken);
        void RemoveRefreshToken(string hashedToken);
        void RemoveExpiredRefreshTokens(string userName);
    }
}
