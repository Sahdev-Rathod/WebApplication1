using CategoryDAL;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CategoryService : ICategoryService
{
    ICategoryRepository _repo;

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<UserModel> Login(string Email, string Password)
    {
        try
        {
            var user = await _repo.Login(Email, Password);

            if (user == null) return null;

            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                RoleName = user.Role?.Name
            };
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> Regester(UserModel user)
    {
        try
        {
            var newUser = new User
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                RoleId = 2
            };
           await _repo.Regester(newUser);

            return true;
        }
        catch
        {
            return false;
        }
    }
}