using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL.Interfaces;

namespace BLL.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork uow;
        private readonly IPhotoRepository photoRepository;
        private readonly IUserService userService;
        public PhotoService(IUnitOfWork uow, IPhotoRepository repository,IUserService userService)
        {
            this.uow = uow;
            this.photoRepository = repository;
            this.userService = userService;
        }
        public void AddPhoto(Photo photo)
        {
            photoRepository.AddPhoto(photo);
            uow.Commit();
        }

        public void DeletePhoto(Photo photo)
        {
            photoRepository.DeletePhoto(photo);
            uow.Commit();
        }

        public List<Photo> GetAllPhotos(int userId)
        {
            return photoRepository.GetAllPhotos(userId);
        }

        public Photo GetPhoto(int key)
        {
            return photoRepository.GetPhoto(key);
        }

        public void UpdatePhoto(Photo photo)
        {
            photoRepository.UpdatePhoto(photo);
            uow.Commit();
        }

        public void AddAvatarToUser(Photo photo, string  email)
        {
            photo.User = userService.GetUserByEmail(email);
            AddPhoto(photo);
            photo.User.UserPhotoId = photo.PhotoId;
            uow.Commit();
        }
    }
}
