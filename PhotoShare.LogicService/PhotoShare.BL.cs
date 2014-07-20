using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using PhotoShare.Service;
using PhotoShare.Service.Entities;
using PhotoShare.Service.Repository;

namespace PhotoShare.LogicService
{
    public class PhotoShareBl : IPhotoShareBl
    {

        public Repository<Administrator> AdministratorRepository;
        public Repository<AuthorizedUser> AuthorizedUserRepository;
        public Repository<Comment> CommentRepository;
        public Repository<Photo> PhotoRepository;

        public PhotoShareBl()
        {
            var context = new PhotoShareContext();
            AdministratorRepository = new Repository<Administrator>(context);
            AuthorizedUserRepository = new Repository<AuthorizedUser>(context);
            CommentRepository = new Repository<Comment>(context);
            PhotoRepository = new Repository<Photo>(context);
        }


        #region Administrator

        public int CreateAdministrator(string name, string surname, string email)
        {
            try
            {
                var administrator = new Administrator(name, surname, email);
                AdministratorRepository.Insert(administrator);
                return administrator.Id;
            }

            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to create administrator");
            }
        }

        public void DeleteAdministrator(int id)
        {
            try
            {
                Administrator administrator = AdministratorRepository.GetById(id);
                AdministratorRepository.Delete(administrator);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to delete administrator");
            }
        }

        public Administrator GetAdministratorById(int id)
        {
            try
            {
                Administrator administrator = AdministratorRepository.GetById(id);
                return administrator;
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get administrator by id");
            }
        }

        public Administrator UpdateAdministrator(int id, string name, string surname, string email)
        {
            try
            {
                Administrator administrator = AdministratorRepository.GetById(id);
                administrator.Name = name;
                administrator.Surname = surname;
                administrator.Email = email;

                return administrator;
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to update administrator");
            }
        }

        public List<Administrator> GetAllAdministrators()
        {
            try
            {
                return AdministratorRepository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get all administrators");
            }
        }

        #endregion Administrator

        #region AuthorizedUser

        public int CreateAuthorizedUser(string name, string surname, string email)
        {
            try
            {
                var user = new AuthorizedUser(name, surname, email);
                AuthorizedUserRepository.Insert(user);
                return user.Id;
                //todo pass id from mvc table
            }
            catch (Exception e)
            {

                throw new Exception("Error in BL while attempts to create an authorized user");
            }
        }

        public void DeleteAuthorizedUser(int id)
        {
            try
            {
                var user = AuthorizedUserRepository.GetById(id);
                AuthorizedUserRepository.Delete(user);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to delete an authorized user");
            }
        }

        public AuthorizedUser GetAuthorizedUserById(int id)
        {
            try
            {
                var user = AuthorizedUserRepository.GetById(id);
                return user;
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get an authorized user by id");
            }
        }

        public AuthorizedUser UpdateAuthorizedUser(int id, string name, string surname, string email)
        {
            try
            {
                var user = AuthorizedUserRepository.GetById(id);
                user.Name = name;
                user.Surname = surname;
                user.Email = email;
                AuthorizedUserRepository.Update(user);
                return user;
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to update an authorized user");
            }
        }

        public List<AuthorizedUser> GetAllAuthorizedUsers()
        {
            try
            {
                var users = AuthorizedUserRepository.GetAll().ToList();
                return users;
            }
            catch (TargetInvocationException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception exception)
            {
                throw new Exception("Error in BL while attempts to get all authorized users");
            }
        }

        public void AddFriend(int userId, int friendId)
        {
            try
            {
                //todo get curent user id(Membership)
                //todo move to seperate method
                var user = AuthorizedUserRepository.GetById(userId);
                var friend = AuthorizedUserRepository.GetById(friendId);
                user.Friends.Add(friend);
                AuthorizedUserRepository.Update(user);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to add friend");
            }
        }

        public void DeleteFriend(int userId, int friendId)
        {
            try
            {
                var user = AuthorizedUserRepository.GetById(userId);
                var friend = AuthorizedUserRepository.GetById(friendId);
                user.Friends.Remove(friend);
                AuthorizedUserRepository.Update(user);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to delete friend");
            }
        }

        public AuthorizedUser ConfirmPassword(int id)
        {
            try
            {
                var user = AuthorizedUserRepository.GetById(id);
                user.ConfirmPassword = true;
                AuthorizedUserRepository.Update(user);
                return user;
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to confirm password");
            }
        }

        public List<Photo> GetUserPhotos(int id)
        {
            try
            {
                var user = AuthorizedUserRepository.GetById(id);
                var photos = user.Photos;
                return photos;//todo
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get all user's photos");
            }
        }

        private void AddUserPhoto(int id, Photo photo)
        {
            try
            {
                var user = AuthorizedUserRepository.GetById(id);
                var photos = user.Photos;
                photos.Add(photo);
                AuthorizedUserRepository.Update(user);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to add user's photo");
            }
        }

        private void DeleteUserPhoto(int id, Photo photo)
        {
            try
            {
                var user = AuthorizedUserRepository.GetById(id);
                var photos = user.Photos;
                if (!photos.Contains(photo)) return;
                user.Photos.Remove(photo);
                AuthorizedUserRepository.Update(user);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to delete user's photo");
            }
        }

        public AuthorizedUser ChangeAvatar(int id, Photo photo)
        {
            try
            {
                var user = AuthorizedUserRepository.GetById(id);
                user.Avatar = photo;
                AuthorizedUserRepository.Update(user);
                return user;
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to change avatar");
            }
        }

        public AuthorizedUser GetUserByName(string name)
        {
            try
            {
                var users = AuthorizedUserRepository.GetAll();

                return !users.Any() ? null : Enumerable.FirstOrDefault(users, user => user.Name == name);
            }
            catch (Exception)
            {

                throw new Exception("Error in BL while attempts to get user by name");
            }

        }
    #endregion AuthorizedUser

        #region Comment
        public int CreateComment(string text, AuthorizedUser ownerComment, Photo photo)
        {
            //todo onwerComment
            try
            {
                var comment = new Comment(text, ownerComment, photo);
                AddCommentToPhoto(comment, photo.Id);
                CommentRepository.Insert(comment);
                return comment.Id;
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to create comment");
            }
        }

        public void DeleteComment(int id)
        {
            try
            {
                var comment = CommentRepository.GetById(id);
                RemoveCommentFromPhoto(comment, comment.Photo.Id);
               //todo delete
                CommentRepository.Delete(comment);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to delete comment");
            }
        }

        public Comment GetCommentById(int id)
        {
            try
            {
                var comment = CommentRepository.GetById(id);
                return comment;//todo
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get comment by id");
            }
        }

        public Comment UpdateComment(int id, string text)
        {
            try
            {
                var comment = CommentRepository.GetById(id);
                comment.CommentText = text;
                return comment;
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to update comment");
            }
        }

        public List<Comment> GetAllComments()
        {
            try
            {
                return CommentRepository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get all comments");
            }
        }

        #endregion Comment

        #region Photo

        public int CreatePhoto(int userId, byte[] image)
        {
            try
            {
                var photo = new Photo(userId, image);
                AddUserPhoto(userId, photo);
                PhotoRepository.Insert(photo);
                return photo.Id;
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to create photo");
            }
        }

        public void DeletePhoto(int id)
        {
            try
            {
                var photo = PhotoRepository.GetById(id);
                DeleteUserPhoto(photo.UserId, photo);
                PhotoRepository.Delete(photo);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to delete photo");
            }
        }

        public Photo GetPhotoById(int id)
        {
            try
            {
                var photo = PhotoRepository.GetById(id);
                return photo;
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get photo by id");
            }
        }

        public List<Photo> GetAllPhotos()
        {
            try
            {
                return PhotoRepository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get all photos");
            }
        }

        public Photo EditDescription(string text, int id)
        {
            try
            {
                var photo = PhotoRepository.GetById(id);
                photo.Description = text;
                PhotoRepository.Update(photo);
                return photo;
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to edit description");
            }
        }

        private void AddCommentToPhoto(Comment comment, int id)
        {
            try
            {
                var photo = PhotoRepository.GetById(id);
                photo.Comments.Add(comment);
                PhotoRepository.Update(photo);
            }
            catch (Exception)
            {

                throw new Exception("Error in BL while attempts to add comment to photo");
            }
        }

        private void RemoveCommentFromPhoto(Comment comment, int id)
        {
            try
            {
                var photo = PhotoRepository.GetById(id);
                if (!photo.Comments.Contains(comment)) return;
                photo.Comments.Remove(comment);
                PhotoRepository.Update(photo);
            }
            catch (Exception)
            {

                throw new Exception("Error in BL while attempts to remove comment from photo");
            }
        }

        #endregion Photo
    }
}
