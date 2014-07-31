using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PhotoShare.Models
{

    public class PlaceHolderAttribute : Attribute, IMetadataAware
    {
        private readonly string _placeholder;

        public PlaceHolderAttribute(string placeholder)
        {
            _placeholder = placeholder;
        }

        public void OnMetadataCreated(System.Web.Mvc.ModelMetadata metadata)
        {
            metadata.AdditionalValues["placeholder"] = _placeholder;
        }
    }
    public class Photo
    {
        public Photo(Guid userId, byte[] image)
        {
            UserId = userId;
            Image = image;
        }
        public Guid UserId { get; private set; }
        public List<Comment> Comments { get; set; }
        public byte[] Image { get; set; }
        [PlaceHolder("Описание")]
         [StringLength(255, ErrorMessage = "First name cannot be longer than 255 characters.")]
        public string Description { get; set; }
        public Guid PhotoId { get; set; }
        public DateTime DateTime { get; set; }
    }
}