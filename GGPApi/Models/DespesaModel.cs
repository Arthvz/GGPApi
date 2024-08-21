namespace GGPApi.Models
{
    public class DespesaModel
    {
        public int Id { get; set; }
        public required string Descricao { get; set; }
        public required double Valor { get; set; }
        public DateTime Data { get; set; }

        // Chave estrangeira
        public int UserId { get; set; }

        // Relação com o usuário
        public UserModel User { get; set; }
    }
}
