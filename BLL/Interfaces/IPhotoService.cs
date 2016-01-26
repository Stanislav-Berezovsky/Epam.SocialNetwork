using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPhotoService
    { 
        void AddPhoto(Photo photo);
        void AddAvatarToUser(Photo photo, string email);
        void DeletePhoto(Photo photo);
        void UpdatePhoto(Photo photo);
        List<Photo> GetAllPhotos(int userId);
        Photo GetPhoto(int key);
    }
}
