using GGPApi.Data;
using GGPApi.Dto.Receita;
using GGPApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GGPApi.Services.Receita
{
    public class ReceitaService : IReceitaInterface
    {
        private readonly AppDbContext _context;
        public ReceitaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<ReceitaModel>> BuscarReceitasPorId(int idReceita)
        {
            ResponseModel<ReceitaModel> resposta = new ResponseModel<ReceitaModel>();
            try
            {
                var receita = await _context.Receitas.Include(u => u.User).FirstOrDefaultAsync(receitaBd => receitaBd.Id == idReceita);

                if (receita == null)
                {
                    resposta.Mensagem = "Receita não encontrado!";
                    return resposta;
                }

                resposta.Dados = receita;
                resposta.Mensagem = "Receita encontrada com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ReceitaModel>>> BuscarReceitasPorIdUser(int idUser)
        {
            ResponseModel<List<ReceitaModel>> resposta = new ResponseModel<List<ReceitaModel>>();
            try
            {
                var receita = await _context.Receitas.Include(u => u.User).Where(receitaBd => receitaBd.UserId == idUser).ToListAsync();
                if (receita == null)
                {
                    resposta.Mensagem = "Receitas não encontradas!";
                    return resposta;
                }

                resposta.Dados = receita;
                resposta.Mensagem = "Receitas encontradas com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ReceitaModel>>> CriarReceitas(ReceitaCriacaoDto receitaCriacaoDto)
        {
            ResponseModel<List<ReceitaModel>> resposta = new ResponseModel<List<ReceitaModel>>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(userBd => userBd.Id == receitaCriacaoDto.UserId);
                if (user == null)
                {
                    resposta.Mensagem = "Usuário não encontrado!";
                    return resposta;
                }

                var receita = new ReceitaModel
                {
                    Descricao = receitaCriacaoDto.Descricao,
                    Valor = receitaCriacaoDto.Valor,
                    Data = DateTime.Now,
                    UserId = user.Id,
                    User = user
                };

                _context.Receitas.Add(receita);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Receitas.Include(u => u.User).ToListAsync();
                resposta.Mensagem = "Receita criada com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ReceitaModel>>> DeletarReceitas(int idReceita)
        {
            ResponseModel<List<ReceitaModel>> resposta = new ResponseModel<List<ReceitaModel>>();
            try
            {
                var receita = await _context.Receitas.FirstOrDefaultAsync(receitaBd => receitaBd.Id == idReceita);

                if (receita == null)
                {
                    resposta.Mensagem = "Receita não encontrada!";
                    return resposta;
                }

                _context.Remove(receita);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Receitas.ToListAsync();
                resposta.Mensagem = "Receita deletada com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ReceitaModel>>> EditarReceitas(ReceitaEdicaoDto receitaEdicaoDto)
        {
            ResponseModel<List<ReceitaModel>> resposta = new ResponseModel<List<ReceitaModel>>();
            try
            {
                var receita = await _context.Receitas.Include(u => u.User).FirstOrDefaultAsync(receitaBd => receitaBd.Id == receitaEdicaoDto.Id);
                if (receita == null)
                {
                    resposta.Mensagem = "Receita não encontrada!";
                    return resposta;
                }

                var user = await _context.Users.FirstOrDefaultAsync(userBd => userBd.Id == receitaEdicaoDto.UserId);
                if (user == null)
                {
                    resposta.Mensagem = "Usuário não encontrado!";
                    return resposta;
                }

                receita.Descricao = receitaEdicaoDto.Descricao;
                receita.Valor = receitaEdicaoDto.Valor;
                receita.UserId = user.Id;
                receita.User = user;

                _context.Receitas.Update(receita);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Receitas.ToListAsync();
                resposta.Mensagem = "Receita editada com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ReceitaModel>>> ListarReceitas()
        {
            ResponseModel<List<ReceitaModel>> resposta = new ResponseModel<List<ReceitaModel>>();
            try
            {
                var receitas = await _context.Receitas.Include(u => u.User).ToListAsync();
                resposta.Dados = receitas;
                resposta.Mensagem = "Receitas listadas com sucesso!";
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
