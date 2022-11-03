using Sistema_de_tarefas.Modells;

namespace Sistema_de_tarefas.Repositórios.Interfaces
{
    public interface iUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();

        Task<UsuarioModel> BuscarPorId(int id);

        Task<UsuarioModel> Adicionar(UsuarioModel Usuario);

        Task<UsuarioModel> Atualizar(UsuarioModel Usuario, int id);

        Task<bool> Apagar(int id);
    }
}
