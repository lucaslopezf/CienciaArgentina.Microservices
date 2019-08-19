using System.Threading.Tasks;
using CienciaArgentina.Microservices.Entities.BusinessModel;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace CienciaArgentina.Microservices.Business.Interfaces
{
    public interface IUserBusiness
    {
        //Task<UserData> GetUserById(int userId);
        Task<LoginModel> Add(ApplicationUser user, string password,string uri);

        Task<LoginModel> Login(string userName, string password, string uri, bool isPersistent = false, bool lockoutOnFailure = false);

        Task<LoginModel> SendEmailConfirmationAsync(ApplicationUser user, string uri);

        //Task<UserData> AddUserAsync(UserData user);
    } 
}
