using AutoMapper;
using BAL.DAOs.Authentication;
using BAL.DAOs.Interfaces;
using BAL.DTOs.AccountTypes;
using DAL.Models;
using DAL.Repository.Implement;
using DAL.Repository.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DAOs.Implements
{
    public class AccountTypeDAOs : IAccountTypesDAOs
    {
        private AccountRepository _accountRepository;
        private IMapper _mapper;
        public AccountTypeDAOs(IAccountRepository accountsRepository, IMapper mapper)
        {
            this._accountRepository = (AccountRepository)accountsRepository;
            this._mapper = mapper;
        }
        public GetAccounts Login(Accounts account, JWTAuth jwtAuth)
        {
            try
            {
                Account existedAccount = this._accountRepository.Get(x => x.Email.Equals(account.Email)
                && x.Password.Equals(account.Password)).SingleOrDefault();

                if (existedAccount == null)
                {
                    throw new Exception("Email or Password is in vaild");
                }
                GetAccounts getAccounts = this._mapper.Map<GetAccounts>(existedAccount);
                //Generation Token
                return GenerateToken(getAccounts, jwtAuth);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // To generate token
        private GetAccounts GenerateToken(GetAccounts getAccounts, JWTAuth jwtAuth)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAuth.Key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new ClaimsIdentity(new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub,getAccounts.Email),
                new Claim("role",getAccounts.AccoutRole.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            });

                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(2),
                    SigningCredentials = credentials,
                };

                var token = jwtTokenHandler.CreateToken(tokenDescription);
                string accessToken = jwtTokenHandler.WriteToken(token);

                getAccounts.AccessToken = accessToken;

                return getAccounts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
