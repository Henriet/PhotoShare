﻿using System;
using System.Collections.Generic;
using PhotoShare.Domain;

namespace PhotoShare.LogicService
{
    interface IUserBl
    {
        User AddUser(User user);
        bool DeleteUser(Guid id);
        User GetUserById(Guid id);
        bool UpdateUser(User user);
        List<User> GetAllUsers();
        bool AddFriend(Guid friendId);
        bool DeleteFriend(Guid friendId);
        User GetCurrentUser();
        void GiveAdminRole(Guid id); // todo
        void TakeAdminRole(Guid id); // todo
    }
}
