using GGPApi.Dto.Receita;
using GGPApi.Models;

namespace GGPApi.Services.Receita
{
    public interface IReceitaInterface
    {
        Task<ResponseModel<List<ReceitaModel>>> ListarReceitas();
        Task<ResponseModel<ReceitaModel>> BuscarReceitasPorId(int idReceita);
        Task<ResponseModel<List<ReceitaModel>>> BuscarReceitasPorIdUser(int idUser);
        Task<ResponseModel<List<ReceitaModel>>> CriarReceitas(ReceitaCriacaoDto receitaCriacaoDto);
        Task<ResponseModel<List<ReceitaModel>>> EditarReceitas(ReceitaEdicaoDto receitaEdicaoDto);
        Task<ResponseModel<List<ReceitaModel>>> DeletarReceitas(int idReceita);
    }
}
