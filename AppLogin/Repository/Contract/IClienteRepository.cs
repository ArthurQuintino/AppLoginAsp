using AppLogin.Models;

namespace AppLogin.Repository.Contract
{
    public interface IClienteRepository
    {
        // LOGIN CLIENTE
        Cliente Login(string Email, string Senha);

        //CRUD
        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Ativar(int Id);
        void Desativar(int Id);

        void Excluir(int Id);

        Cliente ObterCliente(int Id);

        IEnumerable<Cliente> ObterTodosClientes();
    }
}
