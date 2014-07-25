using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class PhotoModel
    {
        public string UrlPhotoPath { get; set; }

        public string Description { get; set; }
    }
}