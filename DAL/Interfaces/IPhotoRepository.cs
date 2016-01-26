using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPhotoRepository
    {
        void AddPhoto(Photo photo);
        void DeletePhoto(Photo photo);
        void UpdatePhoto(Photo photo);
        List<Photo> GetAllPhotos(int userId);
        Photo GetPhoto(int key);
    }
}
