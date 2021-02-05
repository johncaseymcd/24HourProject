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
                Username = model.Username
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<User> GetUsers()
        {
           using (var ctx = new ApplicationDbContext())
            {
                return ctx.Users.ToList<User>();
            }
        }

        public User GetUserByID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.UserID == id);
                return entity;
            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetUserByID(model.ID);

                entity.Username = model.Username;

                return ctx.SaveChanges > 0;
            }
        }

        public bool DeleteUser(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = GetUserByID(id);

                ctx.Users.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
