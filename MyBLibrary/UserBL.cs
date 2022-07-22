using ModelsLibrary;
using System;

namespace MyBLibrary
{
    public class UserBL
    {
        private Repo<string, User> _repo;

        public UserBL()
        {

        }
        public UserBL(Repo<string, User> repo)
        {
            _repo = repo;
        }
        public bool Login(User user)
        {
            if (_repo.Get(user) == null)
                return false;
            return true;
        }
    }
}