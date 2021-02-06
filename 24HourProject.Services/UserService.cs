using _24HourProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Services
{
    public class UserService
    {
        private readonly Guid _userID;

        public UserService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity = new User()
            {
                UserID = _userID,
                Name = model.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.User.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<User> GetUsers()
        {
           using (var ctx = new ApplicationDbContext())
            {
                return ctx.User.ToList<User>();
            }
        }

        public User GetUserByID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .User
                        .Single(e => e.UserID == id);
                return entity;
            }
        }

        public bool UpdateUser(UserDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetUserByID(model.ID);

                entity.Name = model.Name;

                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeleteUser(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetUserByID(id);

                ctx.User.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
