using agroWebSitreAPI.Domain.DTOs;
namespace agroWebSitreAPI.Domain.Model.UserAggregate;


public interface IUserRepository
{
    void Add(User user);

    List<UserDTO> GetAll();

    User FindByEmail(string username, string password);

    UserDTO FindById(int id);
}