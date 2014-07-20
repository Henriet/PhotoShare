using System.Collections.Generic;
using PhotoShare.Service;
using PhotoShare.Service.Entities;

namespace PhotoShare.LogicService
{
    interface IPhotoShareBl
    {
        int CreateAdministrator(string name, string surname, string email);
        void DeleteAdministrator(int id);
        Administrator GetAdministratorById(int id);
        Administrator UpdateAdministrator(int id, string name, string surname, string email);
        List<Administrator> GetAllAdministrators();
        //todo give take role

        int CreateAuthorizedUser(string name, string surname, string email);
        void DeleteAuthorizedUser(int id);
        AuthorizedUser GetAuthorizedUserById(int id);
        AuthorizedUser UpdateAuthorizedUser(int id, string name, string surname, string email);
        List<AuthorizedUser> GetAllAuthorizedUsers();

        void AddFriend(int userId, int friendId);
        void DeleteFriend(int userId, int friendId);//todo void
        AuthorizedUser ConfirmPassword(int id);
        List<Photo> GetUserPhotos(int id);
        AuthorizedUser ChangeAvatar(int id, Photo photo);
        AuthorizedUser GetUserByName(string name);

        int CreateComment(string text, AuthorizedUser ownerComment, Photo photo);
        void DeleteComment(int id);
        Comment GetCommentById(int id);
        Comment UpdateComment(int id, string text);
        List<Comment> GetAllComments();

        int CreatePhoto(int userId, byte[] image);
        void DeletePhoto(int id);
        Photo GetPhotoById(int id);
        List<Photo> GetAllPhotos();
        //get all follower potos
        Photo EditDescription(string text, int id);

    }
}
