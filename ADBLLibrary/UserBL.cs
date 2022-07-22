using MoreADOLibrary;
using MoreADODALibrary;
using System;

namespace ADBLLibrary
{
    public class UserBL
    {
        UserDAL userDAL;
        public UserBL()
        {
            userDAL = new UserDAL();
        }
        public User CheckLogin(User user)
        {
            if (user.Username != null && user.Password != null)
            {
                string result = userDAL.Login(user);
                if (result == "invalid")
                {
                    return null;
                }
                else
                {
                    user.Role = result;
                    user.Password = "";
                    return user;
                }
            }
            return null;
        }
    }
}