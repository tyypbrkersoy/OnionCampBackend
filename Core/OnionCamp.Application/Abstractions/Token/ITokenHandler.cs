using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T = OnionCamp.Application.DTOs;

namespace OnionCamp.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        T.Token CreateAccessToken(int second);
        string CreateRefreshToken();
    }
}
