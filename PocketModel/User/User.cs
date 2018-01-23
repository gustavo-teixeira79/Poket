using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PocketModel.User
{
    [Table("T_User")]
    public class User : Person
    {
        public User()
        {
            Status = UserStatus.PendingActive;
            Type = UserType.Consumer;
        }
        public UserStatus Status { get; set; }
        public UserType Type { get; set; }

    }

    public class AuthenticateRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            Property(x => x.Status).IsRequired();
        }
    }

    public enum UserStatus
    {
        PendingActive,
        Active,
        Suspended,
        Removed
    }

    public enum UserType
    {
        Consumer,
        Provider,
        Admin
    }
}
