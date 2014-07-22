using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Domain;


namespace PhotoShare.LogicService
{
    interface IPhotoBl
    {
        Photo CreatePhoto(Photo photo);
        bool DeletePhoto(Guid id);
        Photo GetPhotoById(Guid id);
        List<Photo> GetAllPhotos();
    }
}
