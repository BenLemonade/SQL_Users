using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLUsers
{
    class UsernameAlreadyTakenException : Exception
    {
        private string username;
        public UsernameAlreadyTakenException(string username) : base("Username is already taken: " + username)
        {
            this.username = username;
        }
        public string getUsername()
        {
            return username;
        }
    }
}
