using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool ConfirmPassword { get; set; }
        public List<User> Friends { get; set; } 
        public List<Photo>Photos { get; set; } 
        public Photo Avatar { get; set; }


        public User(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
            ConfirmPassword = false;
        }

        public User()
        {
            
        }

        //public User(User user)
        //{
        //    var photos = new List<Photo>();
        //    if (user.Photos != null)
        //        if (user.Photos.Any())
        //            foreach (var photo in photos)
        //            {
        //                var addingPhoto = new Photo(photo.UserId, photo.Image);
        //                if (photo.Comments != null)
        //                    if (photo.Comments.Any())
        //                    {
        //                        foreach (var addingComment in photo.Comments.Select(comment => new Comment(comment.CommentText, comment.CommentOwnerId)))
        //                        {
        //                            photo.Comments.Add(addingComment);
        //                        }
        //                    }
        //                photos.Add(addingPhoto);
        //            }
        //    var friends = new List<User>();
        //    if (user.Friends == null) return;
        //    if (!user.Friends.Any()) return;
        //    foreach (var addingFriend in friends.Select(friend => new User(friend.Name, friend.Surname, friend.Email)))
        //    {
        //        friends.Add(addingFriend);
        //    }
        //}
    }
}