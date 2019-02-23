using System;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Entities.Models.User;
using CienciaArgentina.Microservices.Repositories.IUoW;

namespace CienciaArgentina.Microservices.Business
{
    public class UserBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserData> GetUser(int userId)
        {
            return await _unitOfWork.Repository<UserData>().GetByIdAsync(userId);
        }

    }
}
