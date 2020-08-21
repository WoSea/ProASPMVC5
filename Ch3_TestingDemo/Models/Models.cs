using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch3_TestingDemo.Models
{
    public class User
    {   
        public string LoginName { get; set; }
    }

    public interface IUserRepository
    {
        void Add(User newUser);
        User FetchByLoginName(string loginName);
        void SubmitChanges();
    }

    public class DefaultUserRepository: IUserRepository
    {
        public void Add(User newUser)
        {

        }
        public User FetchByLoginName(string loginName)
        {
            return new User() { LoginName = loginName };
        }
        public void SubmitChanges()
        {

        }
    }
}