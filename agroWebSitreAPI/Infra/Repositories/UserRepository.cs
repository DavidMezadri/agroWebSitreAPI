using agroWebSitreAPI.Domain.DTOs;
using agroWebSitreAPI.Domain.Model.UserAggregate;

namespace agroWebSitreAPI.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public List<UserDTO> GetAll()
        {
            return _context.User
                .Select(b => new UserDTO()
                {
                    Id = b.id,
                    Email = b.email,
                    Is_admin = b.is_admin,
                })
                .ToList();
        }

        public UserDTO? Get(int id)
        {
            var user = _context.User.Find(id);

            if (user == null) return null; //Não existe esse usuário

            return new UserDTO
            {
                Id = user.id,
                Email = user.email,
                Is_admin = user.is_admin
            };
        }

        public User FindByEmail(string email, string password)
        {
            var user = _context.User.FirstOrDefault(u => u.email == email);
            if (user == null || user.password != password)
            {
                return null;
            }

            return user;
        }

        public UserDTO FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
