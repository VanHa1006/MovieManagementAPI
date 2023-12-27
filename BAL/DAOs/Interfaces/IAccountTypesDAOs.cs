using BAL.DAOs.Authentication;
using BAL.DTOs.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DAOs.Interfaces
{
    public interface IAccountTypesDAOs 
    {
        public GetAccounts Login(Accounts account, JWTAuth jwtAuth);
    }
}
