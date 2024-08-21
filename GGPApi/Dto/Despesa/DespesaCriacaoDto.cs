namespace GGPApi.Dto.Despesa
{
    public class DespesaCriacaoDto
    {
        public required string Descricao { get; set; }
        public required double Valor { get; set; }

        // Chave estrangeira
        public int UserId { get; set; }
    }
}
