using System.Threading.Tasks;
using CienciaArgentina.Microservices.Entities.Models.User;

namespace CienciaArgentina.Microservices.Business.Interfaces
{
    public interface IUserBusiness
    {
        Task<UserData> GetUserById(int userId);

        Task<UserData> GetUserByUserName(string userName);

        Task<UserData> AddUserAsync(UserData user);
    } 
}
