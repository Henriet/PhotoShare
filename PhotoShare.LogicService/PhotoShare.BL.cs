using System;
using System.Collections.Generic;
using System.Linq;
using PhotoShare.Service;
using PhotoShare.Service.Entities;
using PhotoShare.Service.Repository;

namespace PhotoShare.LogicService
{
    class PhotoShareBl : IPhotoShareBl
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
        public Administrator CreateAdministrator(string name, string surname, string email, string password)
        {
            try
            {
                var administrator = new Administrator(name, surname, email, password);
                AdministratorRepository.Insert(administrator);
                return administrator;
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

        public Administrator UpdateAdministrator(int id, string name, string surname, string email, string password)
        {
            try
            {
                Administrator administrator = AdministratorRepository.GetById(id);
                administrator.Name = name;
                administrator.Surname = surname;
                administrator.Email = email;
                administrator.Password = password;
                
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
        public AuthorizedUser CreateAuthorizedUser(string name, string surname, string email, string password)
        {
            try
            {
                var user = new AuthorizedUser(name, surname, email, password);
                AuthorizedUserRepository.Insert(user);
                return user;
            }
            catch (Exception)
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

        public AuthorizedUser UpdateAuthorizedUser(int id, string name, string surname, string email, string password)
        {
            try
            {
                var user = AuthorizedUserRepository.GetById(id);
                user.Name = name;
                user.Surname = surname;
                user.Email = email;
                user.Password = password;
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
                return AuthorizedUserRepository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get all authorized users"); 
            }
        }

        public void AddFriend(int userId, int friendId)
        {
            try
            {
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
        
        #endregion AuthorizedUser

        #region Comment
        public Comment CreateComment(string text, AuthorizedUser ownerComment)
        {
            try
            {
                var comment = new Comment(text, ownerComment);
                CommentRepository.Insert(comment);
                return comment;
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
                return comment;
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

        public Photo CreatePhoto(int userId, byte[] image)
        {
            try
            {
                var photo = new Photo(userId, image);
                PhotoRepository.Insert(photo);
                return photo;
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

        #endregion Photo
    }
}
