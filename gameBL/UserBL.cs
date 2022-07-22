using GameDAL;
using gamelib;

namespace gameBL
{
    public class UserBL
    {
        gameDAL userDAL;
        public UserBL()
        {
            userDAL = new gameDAL();
        }
        public int CheckLogin()
        {
            User user = new User();
            if (user.id != null && user.Password != null)
            {
                int result = userDAL.Login();
                if (result == 0)
                {
                    return null;
                }
                else
                {
                   // user.Password = "";
                    return user;
                }
            }
            return null;
        }

    }
}