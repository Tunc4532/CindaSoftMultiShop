using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Concrete
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
