namespace GGPApi.Dto.Receita
{
    public class ReceitaCriacaoDto
    {
        public required string Descricao { get; set; }
        public required double Valor { get; set; }

        // Chave estrangeira
        public int UserId { get; set; }
    }
}
