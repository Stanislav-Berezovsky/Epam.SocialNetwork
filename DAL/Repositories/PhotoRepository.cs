using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DbContext context;

        public PhotoRepository(IUnitOfWork uow)
        {
            this.context = uow.GetContext();
        }
        public void AddPhoto(Photo photo)
        {
            context.Set<Photo>().Add(photo);
        }

        public void DeletePhoto(Photo photo)
        {
            context.Set<Photo>().Remove(photo);
        }

        public List<Photo> GetAllPhotos(int userId)
        {
            return context.Set<Photo>().Where(u => userId == u.User.UserId).ToList();
        }

        public Photo GetPhoto(int key)
        {
            return context.Set<Photo>().Find(key);
        }

        public void UpdatePhoto(Photo photo)
        {
            context.Entry(photo).State = EntityState.Modified;
        }
    }
}
