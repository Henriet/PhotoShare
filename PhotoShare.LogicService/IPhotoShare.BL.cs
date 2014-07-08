using System.Collections.Generic;
using PhotoShare.Service;
using PhotoShare.Service.Entities;

namespace PhotoShare.LogicService
{
    interface IPhotoShareBl
    {
        Administrator CreateAdministrator(string name, string surname, string email, string password);
        void DeleteAdministrator(int id);
        Administrator GetAdministratorById(int id);
        Administrator UpdateAdministrator(int id, string name, string surname, string email, string password);
        List<Administrator> GetAllAdministrators();

        AuthorizedUser CreateAuthorizedUser(string name, string surname, string email, string password);
        void DeleteAuthorizedUser(int id);
        AuthorizedUser GetAuthorizedUserById(int id);
        AuthorizedUser UpdateAuthorizedUser(int id, string name, string surname, string email, string password);
        List<AuthorizedUser> GetAllAuthorizedUsers();
        void AddFriend(int userId, int friendId);
        void DeleteFriend(int userId, int friendId);
        AuthorizedUser ConfirmPassword(int id);

        Comment CreateComment(string text, AuthorizedUser ownerComment);
        void DeleteComment(int id);
        Comment GetCommentById(int id);
        Comment UpdateComment(int id, string text);
        List<Comment> GetAllComments();

        Photo CreatePhoto(int userId, byte[] image);
        void DeletePhoto(int id);
        Photo GetPhotoById(int id);
        List<Photo> GetAllPhotos();
        Photo EditDescription(string text, int id);

    }
}
