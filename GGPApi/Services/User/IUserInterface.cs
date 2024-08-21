using GGPApi.Dto.User;
using GGPApi.Models;

namespace GGPApi.Services.User
{
    public interface IUserInterface
    {
        Task<ResponseModel<List<UserModel>>> ListarUsers();
        Task<ResponseModel<UserModel>> BuscarUserPorId(int idUser);
        Task<ResponseModel<UserModel>> BuscarUserPorIdReceita(int idReceita);
        Task<ResponseModel<UserModel>> BuscarUserPorIdDespesa(int idDespesa);
        Task<ResponseModel<List<UserModel>>> CriarUser(UserCriacaoDto userCriacaoDto);
        Task<ResponseModel<List<UserModel>>> EditarUser(UserEdicaoDto userEdicaoDto);
        Task<ResponseModel<List<UserModel>>> DeletarUser(int idUser);
    }
}
