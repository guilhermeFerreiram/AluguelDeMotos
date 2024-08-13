namespace AluguelDeMotos.Models.Usuarios
{
    public class AdminModel : UsuarioModel
    {
        public AdminModel()
        {
        }
        public AdminModel(UsuarioModel usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Email = usuario.Email;
            Perfil = usuario.Perfil;
            Senha = usuario.Senha;
            DataCadastro = usuario.DataCadastro;
            DataAtualizacao = usuario.DataAtualizacao;
        }
    }
}
