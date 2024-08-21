using System.Text.Json.Serialization;

namespace GGPApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Email { get; set; }
        public required string CPF { get; set; }

        // Ignora a propriedade "Receitas" durante a serialização para JSON
        [JsonIgnore]
        public ICollection<ReceitaModel> Receitas { get; set; }

        // Ignora a propriedade "Despesas" durante a serialização para JSON
        [JsonIgnore]
        public ICollection<DespesaModel> Despesas { get; set; }
    }
}
