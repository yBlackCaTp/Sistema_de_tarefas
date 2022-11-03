using Microsoft.EntityFrameworkCore;
using Sistema_de_tarefas.Data;
using Sistema_de_tarefas.Modells;
using Sistema_de_tarefas.Repositórios.Interfaces;

namespace Sistema_de_tarefas.Repositórios
{
    public class UsuarioRepositorio : iUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext ) 
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }


        public async Task<UsuarioModel> Adicionar(UsuarioModel Usuario)
        {
            await _dbContext.Usuarios.AddAsync(Usuario);  
            _dbContext.SaveChanges();

            return Usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel Usuario, int id)
        {

            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Cliente com ID:{id} não foi gerado");

            }

            usuarioPorId.name = Usuario.name;
            usuarioPorId.Email = Usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            _dbContext.SaveChanges();

            return usuarioPorId; 

        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($" Cliente de ID: {id}não foi gerado");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            _dbContext.SaveChanges();
            return true;

        }
       
    }
 }

       
