using GGPApi.Data;
using GGPApi.Dto.Despesa;
using GGPApi.Dto.Receita;
using GGPApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GGPApi.Services.Despesa
{
    public class DespesaService : IDespesaInterface
    {
        private readonly AppDbContext _context;
        public DespesaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<DespesaModel>> BuscarDespesaPorId(int idDespesa)
        {
            ResponseModel<DespesaModel> resposta = new ResponseModel<DespesaModel>();
            try
            {
                var despesa = await _context.Despesas.Include(u => u.User).FirstOrDefaultAsync(despesaBd => despesaBd.Id == idDespesa);

                if (despesa == null)
                {
                    resposta.Mensagem = "Despesa não encontrada!";
                    return resposta;
                }

                resposta.Dados = despesa;
                resposta.Mensagem = "Despesa encontrada com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<DespesaModel>>> BuscarDespesasPorIdUser(int idUser)
        {
            ResponseModel<List<DespesaModel>> resposta = new ResponseModel<List<DespesaModel>>();
            try
            {
                var despesas = await _context.Despesas.Include(u => u.User).Where(despesaBd => despesaBd.UserId == idUser).ToListAsync();
                if (despesas == null)
                {
                    resposta.Mensagem = "Despesas não encontradas!";
                    return resposta;
                }

                resposta.Dados = despesas;
                resposta.Mensagem = "Despesas encontradas com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<DespesaModel>>> CriarDespesas(DespesaCriacaoDto despesaCriacaoDto)
        {
            ResponseModel<List<DespesaModel>> resposta = new ResponseModel<List<DespesaModel>>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(userBd => userBd.Id == despesaCriacaoDto.UserId);
                if (user == null)
                {
                    resposta.Mensagem = "Usuário não encontrado!";
                    return resposta;
                }

                var despesa = new DespesaModel
                {
                    Descricao = despesaCriacaoDto.Descricao,
                    Valor = despesaCriacaoDto.Valor,
                    Data = DateTime.Now,
                    UserId = user.Id,
                    User = user
                };

                _context.Despesas.Add(despesa);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Despesas.Include(u => u.User).ToListAsync();
                resposta.Mensagem = "Despesa criada com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<DespesaModel>>> DeletarDespesas(int idDespesa)
        {
            ResponseModel<List<DespesaModel>> resposta = new ResponseModel<List<DespesaModel>>();
            try
            {
                var despesa = await _context.Despesas.FirstOrDefaultAsync(despesaBd => despesaBd.Id == idDespesa);

                if (despesa == null)
                {
                    resposta.Mensagem = "Despesa não encontrada!";
                    return resposta;
                }

                _context.Remove(despesa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Despesas.ToListAsync();
                resposta.Mensagem = "Despesa deletada com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<DespesaModel>>> EditarDespesas(DespesaEdicaoDto despesaEdicaoDto)
        {
            ResponseModel<List<DespesaModel>> resposta = new ResponseModel<List<DespesaModel>>();
            try
            {
                var despesa = await _context.Despesas.Include(u => u.User).FirstOrDefaultAsync(despesaBd => despesaBd.Id == despesaEdicaoDto.Id);
                if (despesa == null)
                {
                    resposta.Mensagem = "Despesa não encontrada!";
                    return resposta;
                }

                var user = await _context.Users.FirstOrDefaultAsync(userBd => userBd.Id == despesaEdicaoDto.UserId);
                if (user == null)
                {
                    resposta.Mensagem = "Usuário não encontrado!";
                    return resposta;
                }

                despesa.Descricao = despesaEdicaoDto.Descricao;
                despesa.Valor = despesaEdicaoDto.Valor;
                despesa.UserId = user.Id;
                despesa.User = user;

                _context.Despesas.Update(despesa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Despesas.ToListAsync();
                resposta.Mensagem = "Despesa editada com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<DespesaModel>>> ListarDespesas()
        {
            ResponseModel<List<DespesaModel>> resposta = new ResponseModel<List<DespesaModel>>();
            try
            {
                var despesas = await _context.Despesas.Include(u => u.User).ToListAsync();
                resposta.Dados = despesas;
                resposta.Mensagem = "Despesas listadas com sucesso!";
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
