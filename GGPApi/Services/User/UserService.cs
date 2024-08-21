using GGPApi.Data;
using GGPApi.Dto.User;
using GGPApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GGPApi.Services.User
{
    public class UserService : IUserInterface
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<UserModel>> BuscarUserPorId(int idUser)
        {
            ResponseModel<UserModel> resposta = new ResponseModel<UserModel>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(userBd => userBd.Id == idUser);

                if (user == null)
                {
                    resposta.Mensagem = "Usuário não encontrado!";
                    return resposta;
                }

                resposta.Dados = user;
                resposta.Mensagem = "Usuário encontrado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<UserModel>> BuscarUserPorIdDespesa(int idDespesa)
        {
            ResponseModel<UserModel> resposta = new ResponseModel<UserModel>();
            try
            {
                var despesa = await _context.Despesas.Include(u => u.User).FirstOrDefaultAsync(despesaBd => despesaBd.Id == idDespesa);
                if (despesa == null)
                {
                    resposta.Mensagem = "Usuário não encontrado!";
                    return resposta;
                }

                resposta.Dados = despesa.User;
                resposta.Mensagem = "Usuário encontrado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<UserModel>> BuscarUserPorIdReceita(int idReceita)
        {
            ResponseModel<UserModel> resposta = new ResponseModel<UserModel>();
            try
            {
                var receita = await _context.Receitas.Include(u => u.User).FirstOrDefaultAsync(receitaBd => receitaBd.Id == idReceita);
                if (receita == null)
                {
                    resposta.Mensagem = "Usuário não encontrado!";
                    return resposta;
                }

                resposta.Dados = receita.User;
                resposta.Mensagem = "Usuário encontrado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> CriarUser(UserCriacaoDto userCriacaoDto)
        {
            ResponseModel<List<UserModel>> resposta = new ResponseModel<List<UserModel>>();

            try
            {
                var user = new UserModel()
                {
                    Nome = userCriacaoDto.Nome,
                    Sobrenome = userCriacaoDto.Sobrenome,
                    Email = userCriacaoDto.Email,
                    CPF = userCriacaoDto.CPF
                };

                _context.Add(user);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Users.ToListAsync();
                resposta.Mensagem = "Usuário criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> DeletarUser(int idUser)
        {
            ResponseModel<List<UserModel>> resposta = new ResponseModel<List<UserModel>>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(userBd => userBd.Id == idUser);

                if (user == null)
                {
                    resposta.Mensagem = "Usuário não encontrado!";
                    return resposta;
                }

                _context.Remove(user);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Users.ToListAsync();
                resposta.Mensagem = "Usuário deletado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> EditarUser(UserEdicaoDto userEdicaoDto)
        {
            ResponseModel<List<UserModel>> resposta = new ResponseModel<List<UserModel>>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(userBd => userBd.Id == userEdicaoDto.Id);
                if (user == null)
                {
                    resposta.Mensagem = "Usuário não encontrado!";
                    return resposta;
                }

                user.Nome = userEdicaoDto.Nome;
                user.Sobrenome = userEdicaoDto.Sobrenome;
                user.Email = userEdicaoDto.Email;
                user.CPF = userEdicaoDto.CPF;

                _context.Update(user);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Users.ToListAsync();
                resposta.Mensagem = "Usuário editado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> ListarUsers()
        {
            ResponseModel<List<UserModel>> resposta = new ResponseModel<List<UserModel>>();
            try 
            {
                var users = await _context.Users.ToListAsync();
                resposta.Dados = users;
                resposta.Mensagem = "Usuários listados com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
