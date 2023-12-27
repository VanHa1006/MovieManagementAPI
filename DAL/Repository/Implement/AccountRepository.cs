using DAL.Models;
using DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Implement
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository() { }
    }
}
