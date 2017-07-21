using Poker.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Client.Support
{
    public class BaseViewModel 
    {
        IUserServices _service = null;
        public BaseViewModel()
        {
        }
        public IUserServices UserServices
        {
            get;set;
        }
        public string UserName
        {
            get;set;
        }
        public IUserServices GetUserService()
        {
            return _service;
        }
       
    }
}
