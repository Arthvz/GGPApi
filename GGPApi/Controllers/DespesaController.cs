using GGPApi.Dto.Despesa;
using GGPApi.Models;
using GGPApi.Services.Despesa;
using Microsoft.AspNetCore.Mvc;

namespace GGPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesaInterface _despesaInterface; // Changed from IReceitaInterface to IDespesaInterface

        public DespesaController(IDespesaInterface despesaInterface) // Changed from ReceitaController to DespesaController
        {
            _despesaInterface = despesaInterface;
        }

        [HttpGet("ListarDespesas")] // Changed from ListarReceitas to ListarDespesas
        public async Task<ActionResult<ResponseModel<List<DespesaModel>>>> ListarDespesas() // Changed from ListarReceitas to ListarDespesas
        {
            var despesas = await _despesaInterface.ListarDespesas(); // Changed from ListarReceitas to ListarDespesas
            return Ok(despesas);
        }

        [HttpGet("BuscarDespesasPorId/{idDespesa}")] // Changed from BuscarReceitaPorId to BuscarDespesaPorId
        public async Task<ActionResult<ResponseModel<DespesaModel>>> BuscarDespesaPorId(int idDespesa) // Changed from BuscarReceitasPorId to BuscarDespesaPorId
        {
            var despesa = await _despesaInterface.BuscarDespesaPorId(idDespesa); // Changed from BuscarReceitasPorId to BuscarDespesaPorId
            return Ok(despesa);
        }

        [HttpGet("BuscarDespesasPorIdUser/{idUser}")] // Changed from BuscarReceitaPorIdUser to BuscarDespesaPorIdUser
        public async Task<ActionResult<ResponseModel<UserModel>>> BuscarDespesasPorIdUser(int idUser) // Changed from BuscarReceitasPorIdUser to BuscarDespesaPorIdUser
        {
            var despesa = await _despesaInterface.BuscarDespesasPorIdUser(idUser); // Changed from BuscarReceitasPorIdUser to BuscarDespesaPorIdUser
            return Ok(despesa);
        }

        [HttpPost("CriarDespesas")] // Changed from CriarReceitas to CriarDespesa
        public async Task<ActionResult<ResponseModel<List<DespesaModel>>>> CriarDespesas(DespesaCriacaoDto despesaCriacaoDto) // Changed from CriarReceitas to CriarDespesa
        {
            var despesa = await _despesaInterface.CriarDespesas(despesaCriacaoDto); // Changed from CriarReceitas to CriarDespesa
            return Ok(despesa);
        }

        [HttpPut("EditarDespesas")] // Changed from EditarReceitas to EditarDespesa
        public async Task<ActionResult<ResponseModel<List<DespesaModel>>>> EditarDespesas(DespesaEdicaoDto despesaEdicaoDto) // Changed from EditarReceitas to EditarDespesa
        {
            var despesa = await _despesaInterface.EditarDespesas(despesaEdicaoDto); // Changed from EditarReceitas to EditarDespesa
            return Ok(despesa);
        }

        [HttpDelete("DeletarDespesas")] // Changed from DeletarReceitas to DeletarDespesa
        public async Task<ActionResult<ResponseModel<List<DespesaModel>>>> DeletarDespesas(int idDespesa) // Changed from DeletarReceitas to DeletarDespesa
        {
            var despesa = await _despesaInterface.DeletarDespesas(idDespesa); // Changed from DeletarReceitas to DeletarDespesa
            return Ok(despesa);
        }
    }
}
