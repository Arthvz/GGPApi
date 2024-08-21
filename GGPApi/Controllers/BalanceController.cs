using GGPApi.Data;
using GGPApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GGPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BalanceController(AppDbContext context)
        {
            _context = context;
        }

        // Endpoint para calcular o saldo total de um usuário
        [HttpGet("{userId}/saldo")]
        public ActionResult<BalanceModel> GetSaldo(int userId)
        {
            var totalReceitas = _context.Receitas.Where(r => r.UserId == userId).Sum(r => r.Valor);
            var totalDespesas = _context.Despesas.Where(d => d.UserId == userId).Sum(d => d.Valor);
            var saldo = totalReceitas - totalDespesas;

            var balance = new BalanceModel
            {
                TotalReceitas = totalReceitas,
                TotalDespesas = totalDespesas,
                Saldo = saldo
            };

            return Ok(balance);
        }

        // Endpoint para calcular o balanço mensal de um usuário
        [HttpGet("{userId}/balanco")]
        public ActionResult<BalanceModel> GetBalancoMensal(int userId, int month, int year)
        {
            var totalReceitas = _context.Receitas
                .Where(r => r.UserId == userId && r.Data.Month == month && r.Data.Year == year)
                .Sum(r => r.Valor);

            var totalDespesas = _context.Despesas
                .Where(d => d.UserId == userId && d.Data.Month == month && d.Data.Year == year)
                .Sum(d => d.Valor);

            var saldo = totalReceitas - totalDespesas;

            var balance = new BalanceModel
            {
                TotalReceitas = totalReceitas,
                TotalDespesas = totalDespesas,
                Saldo = saldo
            };

            return Ok(balance);
        }
    }
}
