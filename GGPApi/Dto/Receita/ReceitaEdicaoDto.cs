namespace GGPApi.Dto.Receita
{
    public class ReceitaEdicaoDto
    {
        public int Id { get; set; }
        public required string Descricao { get; set; }
        public required double Valor { get; set; }
        public DateTime Data { get; set; }

        // Chave estrangeira
        public int UserId { get; set; }
    }
}
