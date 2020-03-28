using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLUsers
{
    class AuthenticationService
    {
        private static User authenticatedUser;
        public static bool authenticate(string username, string password)
        {
            User user = UserService.getUserByUsername(username);
            if (user != null && user.GetPassword().Equals(password))
            {
                authenticatedUser = user;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static User getAuthenticatedUser()
        {
            return authenticatedUser;
        }

        public static bool isAuthenticated()
        {
            return authenticatedUser != null;
        }

        public static void logout()
        {
            authenticatedUser = null;
        }
    }
}
