using System.Collections.Generic;
using PhotoShare.Service;
using PhotoShare.Service.Entities;

namespace PhotoShare.LogicService
{
    interface IPhotoShareBl
    {
        int CreateAdministrator(string name, string surname, string email, string password);
        void DeleteAdministrator(int id);
        Administrator GetAdministratorById(int id);
        Administrator UpdateAdministrator(int id, string name, string surname, string email, string password);
        List<Administrator> GetAllAdministrators();

        int CreateAuthorizedUser(string name, string surname, string email, string password);
        void DeleteAuthorizedUser(int id);
        AuthorizedUser GetAuthorizedUserById(int id);
        AuthorizedUser UpdateAuthorizedUser(int id, string name, string surname, string email, string password);
        List<AuthorizedUser> GetAllAuthorizedUsers();
        void AddFriend(int userId, int friendId);
        void DeleteFriend(int userId, int friendId);
        AuthorizedUser ConfirmPassword(int id);
        List<Photo> GetUserPhotos(int id);
        List<Photo> AddUserPhoto(int id, Photo photo);
        List<Photo> DeleteUserPhoto(int id, Photo photo);
        AuthorizedUser ChangeAvatar(int id, Photo photo);
            
        int CreateComment(string text, AuthorizedUser ownerComment);
        void DeleteComment(int id);
        Comment GetCommentById(int id);
        Comment UpdateComment(int id, string text);
        List<Comment> GetAllComments();

        int CreatePhoto(int userId, byte[] image);
        void DeletePhoto(int id);
        Photo GetPhotoById(int id);
        List<Photo> GetAllPhotos();
        Photo EditDescription(string text, int id);

    }
}
