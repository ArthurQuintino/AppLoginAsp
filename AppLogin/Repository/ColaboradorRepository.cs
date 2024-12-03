using AppLogin.Models;
using AppLogin.Models.Constants;
using AppLogin.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace AppLogin.Repository
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        // Propriedade privada para a injeção do banco de dados
        private readonly string _conexaoMySQL;

        // Metodo Construtor da clase Colaborador Repository
        public ColaboradorRepository(IConfiguration conf) 
        {
            // Injeção da dependencia do banco de dados 
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }

        public void AtualizarSenha(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            // string para colocar o insert do Tipo para comum no BD
            string TipoColaborador = ColaboradorTipoConstant.Comum;
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into Colaborador(Nome, CPF, Telefone, Email, Senha, Tipo)" +
                 "values (@Nome, @CPF, @Telefone, @Email, @Senha, @Tipo", conexao);

                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = colaborador.Nome;
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = colaborador.CPF;
                cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = colaborador.Telefone;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = colaborador.Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = colaborador.Senha;
                cmd.Parameters.Add("@Tipo", MySqlDbType.VarChar).Value = TipoColaborador; //adicionando a string como parametro


                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }
        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Colaborador Login(string Email, string Senha)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL)) 
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("select * from colaborador where Email = @Email and Senha = @Senha", conexao);

                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;
                
                Colaborador colaborador = new Colaborador();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read()) ;
                {
                    colaborador.Id = (Int32)(dr["Id"]);
                    colaborador.Nome = (string)(dr["Nome"]);
                    colaborador.Senha = (string)(dr["Senha"]);
                    colaborador.Tipo = (string)(dr["Tipo"]);

                }
                return colaborador;

            }
        }

        public Colaborador ObterColaborador(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Colaborador> ObterColaboradorPorEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Colaborador> ObterTodosColaboradores()
        {
            throw new NotImplementedException();
        }
    }
}
