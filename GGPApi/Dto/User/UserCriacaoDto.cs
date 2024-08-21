namespace GGPApi.Dto.User
{
    public class UserCriacaoDto
    {
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Email { get; set; }
        public required string CPF { get; set; }
    }
}
