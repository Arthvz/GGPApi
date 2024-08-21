using GGPApi.Dto.Receita;
using GGPApi.Dto.User;
using GGPApi.Models;
using GGPApi.Services.Receita;
using GGPApi.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GGPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaInterface _receitaInterface;
        public ReceitaController(IReceitaInterface receitaInterface)
        {
            _receitaInterface = receitaInterface;
        }

        [HttpGet("ListarReceitas")]
        public async Task<ActionResult<ResponseModel<List<ReceitaModel>>>> ListarReceitas()
        {
            var receitas = await _receitaInterface.ListarReceitas();
            return Ok(receitas);
        }

        [HttpGet("BuscarReceitaPorId/{idReceita}")]
        public async Task<ActionResult<ResponseModel<ReceitaModel>>> BuscarReceitasPorId(int idReceita)
        {
            var receita = await _receitaInterface.BuscarReceitasPorId(idReceita);
            return Ok(receita);
        }

        [HttpGet("BuscarReceitaPorIdUser/{idUser}")]
        public async Task<ActionResult<ResponseModel<UserModel>>> BuscarReceitasPorIdUser(int idUser)
        {
            var receita = await _receitaInterface.BuscarReceitasPorIdUser(idUser);
            return Ok(receita);
        }


        [HttpPost("CriarReceitas")]
        public async Task<ActionResult<ResponseModel<List<ReceitaModel>>>> CriarReceitas(ReceitaCriacaoDto receitaCriacaoDto)
        {
            var receita = await _receitaInterface.CriarReceitas(receitaCriacaoDto);
            return Ok(receita);
        }

        [HttpPut("EditarReceitas")]
        public async Task<ActionResult<ResponseModel<List<ReceitaModel>>>> EditarReceitas(ReceitaEdicaoDto receitaEdicaoDto)
        {
            var receita = await _receitaInterface.EditarReceitas(receitaEdicaoDto);
            return Ok(receita);
        }

        [HttpDelete("DeletarReceitas")]
        public async Task<ActionResult<ResponseModel<List<ReceitaModel>>>> DeletarReceitas(int idReceita)
        {
            var receita = await _receitaInterface.DeletarReceitas(idReceita);
            return Ok(receita);
        }
    }
}
