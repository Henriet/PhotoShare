using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Security;
using PhotoShare.Domain;
using PhotoShare.Service.Repository;

namespace PhotoShare.LogicService
{
    public class UserBl : IUserBl
    {
        private readonly Repository<User> _userRepository;

        public UserBl()
        {
            _userRepository = new Repository<User>();
        }

        public User AddUser(User user)
        {
            try
            {
                return _userRepository.Insert(user);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to add user");
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                return _userRepository.Delete(id);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to delete user");
            }
        }

        public User GetUserById(Guid id)
        {
            try
            {
                return _userRepository.Get(id);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get user by id");
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                return _userRepository.Update(user);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to updat user");
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _userRepository.All();
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get all users");
            }
        }

        private List<User> GetTwoUsers(Guid friendId)
        {
            var usersList = new List<User> {GetCurrentUser(), _userRepository.Get(friendId)};
            return usersList;
        }

        public bool AddFriend(Guid friendId)
        {
            try
            {
                var users = GetTwoUsers(friendId);
                if (users == null) return false;
                users.First().Friends.Add(users.Last());
                _userRepository.Update(users.First());
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to add friend");
            }
        }

        public bool DeleteFriend(Guid friendId)
        {
            try
            {
                var users = GetTwoUsers(friendId);
                if (users == null) return false;
                if (!users.First().Friends.Contains(users.Last())) return false;
                users.First().Friends.Remove(users.Last());
                _userRepository.Update(users.First());
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to delete friend");
            }
        }

        public User GetCurrentUser()
        {
            try
            {
                //var membershipUser = Membership.GetUser();

                //if (membershipUser == null) return null;
                //if (membershipUser.ProviderUserKey == null) return null;
                //var userId = membershipUser.ProviderUserKey.ToString();
                //Guid userIdGuid;
                //Guid.TryParse(userId, out userIdGuid);

                var userName = System.Web.HttpContext.Current.User.Identity.Name;
                var currentUser = _userRepository.Find(user => user.Name == userName).First();
                return currentUser;
            }
            catch (Exception)
            {

                throw new Exception("Error in BL while attempts to get current user ");
            }

        }

        public List<User> SearchUser(string searchString)
        {
            return _userRepository.Find(user => user.Name.Contains(searchString)).ToList();
        }

        public void GiveAdminRole(Guid id) //todo
        {
            
        }

        public void TakeAdminRole(Guid id) // todo
        {
            
        }
    }
}
