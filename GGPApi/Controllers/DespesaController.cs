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
        private readonly IDespesaInterface _despesaInterface; 

        public DespesaController(IDespesaInterface despesaInterface) 
        {
            _despesaInterface = despesaInterface;
        }

        [HttpGet("ListarDespesas")] 
        public async Task<ActionResult<ResponseModel<List<DespesaModel>>>> ListarDespesas() 
        {
            var despesas = await _despesaInterface.ListarDespesas(); 
            return Ok(despesas);
        }

        [HttpGet("BuscarDespesasPorId/{idDespesa}")] 
        public async Task<ActionResult<ResponseModel<DespesaModel>>> BuscarDespesaPorId(int idDespesa)
        {
            var despesa = await _despesaInterface.BuscarDespesaPorId(idDespesa); 
            return Ok(despesa);
        }

        [HttpGet("BuscarDespesasPorIdUser/{idUser}")] 
        public async Task<ActionResult<ResponseModel<UserModel>>> BuscarDespesasPorIdUser(int idUser) 
        {
            var despesa = await _despesaInterface.BuscarDespesasPorIdUser(idUser); 
            return Ok(despesa);
        }

        [HttpPost("CriarDespesas")] 
        public async Task<ActionResult<ResponseModel<List<DespesaModel>>>> CriarDespesas(DespesaCriacaoDto despesaCriacaoDto) 
        {
            var despesa = await _despesaInterface.CriarDespesas(despesaCriacaoDto);
            return Ok(despesa);
        }

        [HttpPut("EditarDespesas")] 
        public async Task<ActionResult<ResponseModel<List<DespesaModel>>>> EditarDespesas(DespesaEdicaoDto despesaEdicaoDto) 
        {
            var despesa = await _despesaInterface.EditarDespesas(despesaEdicaoDto); 
            return Ok(despesa);
        }

        [HttpDelete("DeletarDespesas")] 
        public async Task<ActionResult<ResponseModel<List<DespesaModel>>>> DeletarDespesas(int idDespesa) 
        {
            var despesa = await _despesaInterface.DeletarDespesas(idDespesa); 
            return Ok(despesa);
        }
    }
}
