using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agroWebSitreAPI.Domain.Model.UserAggregate
{
    [Table("users")]
    public class User
    {
        [Key]
        public int id { get; private set; }
        public string email { get; private set; }
        public string password { get; private set; }
        public bool is_admin { get; private set; }

        public User(string email, string password, bool is_admin)
        {
            this.email = email;
            this.password = password;
            this.is_admin = is_admin;
        }
    }
}
