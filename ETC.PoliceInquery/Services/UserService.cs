using ETC.PoliceInquery.Entities;

namespace ETC.PoliceInquery.Services;

public interface IUserService
{
    Task<User> Authenticate(string username, string password);
    Task<IEnumerable<User>> GetAll();
}

public class UserService : IUserService
{
    // TOTO موقت : بعدا باید جداول مرتبط با کاربران ایجاد و پسورد بصورت هش شده ذخیره گردد
    private List<User> _users = new List<User>
    {
        new User { Id = 1, FirstName = "samanmajid",
                   LastName = "daryaeidejpour", 
                   Username = "samanmajid",
                   Password = "Aa@123456789" }
    };

    public async Task<User> Authenticate(string username, string password)
    {
        var user = await Task
            .Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));
        return user;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        // TODO خواندن از دیتابیس
        return await Task.Run(() => _users);
    }
}
