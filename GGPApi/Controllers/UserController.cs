using GGPApi.Dto.User;
using GGPApi.Models;
using GGPApi.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GGPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;
        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet("ListarUsers")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> ListarUsers()
        {
            var users = await _userInterface.ListarUsers();
            return Ok(users);
        }

        [HttpGet("BuscarUserPorId/{idUser}")]
        public async Task<ActionResult<ResponseModel<UserModel>>> BuscarUserPorId(int idUser)
        {
            var user = await _userInterface.BuscarUserPorId(idUser);
            return Ok(user);
        }

        [HttpGet("BuscarUserPorIdDespesa/{idDespesa}")]
        public async Task<ActionResult<ResponseModel<UserModel>>> BuscarUserPorIdDespesa(int idDespesa)
        {
            var user = await _userInterface.BuscarUserPorIdDespesa(idDespesa);
            return Ok(user);
        }

        [HttpGet("BuscarUserPorIdReceita/{idReceita}")]
        public async Task<ActionResult<ResponseModel<UserModel>>> BuscarUserPorIdReceita(int idReceita)
        {
            var user = await _userInterface.BuscarUserPorIdDespesa(idReceita);
            return Ok(user);
        }

        [HttpPost("CriarUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> CriarUser(UserCriacaoDto userCriacaoDto)
        {
            var users = await _userInterface.CriarUser(userCriacaoDto);
            return Ok(users);
        }

        [HttpPut("EditarUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> EditarUser(UserEdicaoDto userEdicaoDto)
        {
            var users = await _userInterface.EditarUser(userEdicaoDto);
            return Ok(users);
        }

        [HttpDelete("DeletarUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> DeletarUser(int idUser)
        {
            var users = await _userInterface.DeletarUser(idUser);
            return Ok(users);
        }
    }
}
