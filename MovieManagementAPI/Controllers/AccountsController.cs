using BAL.DAOs.Authentication;
using BAL.DAOs.Interfaces;
using BAL.DTOs.AccountTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Options;

namespace MovieManagementAPI.Controllers
{
    public class AccountsController : ODataController
    {
        private readonly IAccountTypesDAOs _memAccountDAO;
        private IOptions<JWTAuth> _jwtAuthOptions;
        public AccountsController(IAccountTypesDAOs memberAccountDAO, IOptions<JWTAuth> jwtAuthOptions)
        {
            this._memAccountDAO = memberAccountDAO;
            this._jwtAuthOptions = jwtAuthOptions;
        }

        public IActionResult Post([FromBody] Accounts account)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                GetAccounts getAccounts = this._memAccountDAO.Login(account, this._jwtAuthOptions.Value);
                return Ok(new
                {
                    Data = getAccounts
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                });
            }
        }
    }
}

