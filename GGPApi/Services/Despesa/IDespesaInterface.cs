using GGPApi.Dto.Despesa;
using GGPApi.Models;

namespace GGPApi.Services.Despesa
{
    public interface IDespesaInterface
    {
        Task<ResponseModel<List<DespesaModel>>> ListarDespesas();
        Task<ResponseModel<DespesaModel>> BuscarDespesaPorId(int idDespesa);
        Task<ResponseModel<List<DespesaModel>>> BuscarDespesasPorIdUser(int idUser);
        Task<ResponseModel<List<DespesaModel>>> CriarDespesas(DespesaCriacaoDto despesaCriacaoDto);
        Task<ResponseModel<List<DespesaModel>>> EditarDespesas(DespesaEdicaoDto despesaEdicaoDto);
        Task<ResponseModel<List<DespesaModel>>> DeletarDespesas(int idDespesa);
    }
}
