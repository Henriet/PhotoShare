using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Domain;
using PhotoShare.Service.Repository;

namespace PhotoShare.LogicService
{
    public class PhotoBl : IPhotoBl
    {
        private readonly Repository<Photo> _photoRepository; 
        public PhotoBl()
        {
            _photoRepository = new Repository<Photo>();
        }

        public Photo CreatePhoto(Photo photo)
        {
            try
            {
                return _photoRepository.Insert(photo);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to add photo");
            }
        }

        public bool DeletePhoto(Guid id)
        {
            try
            {
                return _photoRepository.Delete(id);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to delete photo");
            }
        }

        public Photo GetPhotoById(Guid id)
        {
            try
            {
                return _photoRepository.Get(id);
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
                return _photoRepository.All();
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get all photos");
            }
        }

        public bool UpdatePhoto(Photo photo)
        {
            return _photoRepository.Update(photo);
        }
    }
}
