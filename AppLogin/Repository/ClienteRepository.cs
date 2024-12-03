using AppLogin.Models;
using AppLogin.Models.Constants;
using AppLogin.Repository.Contract;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Data;

namespace AppLogin.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        // Propriedade Privada para inejtar a conexão com o banco de dados;
        private readonly string _conexaoMySQL;

        //metodo construtor da classe Cliente Repository
        public ClienteRepository(IConfiguration conf) 
        {
              // Injeção de dependencia no banco de dados
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Ativar(int Id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Cliente cliente)
        {
            string Situacao = SituacaoConstant.Ativo;
            using (var conexao = new MySqlConnection(_conexaoMySQL)) 
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("update Cliente set Nome=@Nome, Nascimento=@Nascimento, Sexo=@Sexo, CPF=@CPF, " +
                                                       " Telefone=@Telefone, Email=@Email, Senha=@Senha, Situacao=@Situacao Where Id=@Id ", conexao);
                cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = cliente.Id;
                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.Add("@Nascimento", MySqlDbType.VarChar).Value = cliente.Nascimento;
                cmd.Parameters.Add("@Sexo", MySqlDbType.VarChar).Value = cliente.Sexo;
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = cliente.CPF;
                cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = cliente.Telefone;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
                cmd.Parameters.Add("@Situacao", MySqlDbType.VarChar).Value = cliente.Situacao;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
            
        }

        public void Cadastrar(Cliente cliente)
        {
            string Situacao = SituacaoConstant.Ativo;

            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into Cliente(Nome, Nascimento, Sexo, CPF, Telefone, Email, Senha, Situacao) " +
                                                " values (@Nome, @Nascimento, @Sexo, @CPF, @Telefone, @Email, @Senha, @Situacao)", conexao);

                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.Add("@Nascimento", MySqlDbType.DateTime).Value = cliente.Nascimento;
                cmd.Parameters.Add("@Sexo", MySqlDbType.VarChar).Value = cliente.Sexo;
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = cliente.CPF;
                cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = cliente.Telefone;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
                cmd.Parameters.Add("@Situacao", MySqlDbType.VarChar).Value = cliente.Situacao;

                cmd.ExecuteNonQuery();
                conexao.Close();









            }
        }

        public void Desativar(int Id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL)) 
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from Cliente WHERE Id=@Id ", conexao);
                cmd.Parameters.AddWithValue("@Id", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();    
            }
        }

        public Cliente Login(string Email, string Senha)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from cliente where Email=@Email and Senha=@Senha ", conexao);
                    

                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Cliente cliente = new Cliente();

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                while (dr.Read()) 
                {
                    cliente.Id = Convert.ToInt32(dr["Id"]);
                    cliente.Nome = Convert.ToString(dr["Nome"]);
                    cliente.Nascimento = Convert.ToDateTime(dr["Nascimento"]);
                    cliente.Sexo = Convert.ToString(dr["Sexo"]);
                    cliente.CPF = Convert.ToString(dr["CPF"]);
                    cliente.Telefone = Convert.ToString(dr["Telefone"]);
                    cliente.Situacao = Convert.ToString(dr["Situacao"]);
                    cliente.Email = Convert.ToString(dr["Email"]);
                    cliente.Senha = Convert.ToString(dr["Senha"]);
                }
                return cliente;


            }
        }

        public Cliente ObterCliente(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from cliente where Id=@ID", conexao);
                cmd.Parameters.AddWithValue("@Id", Id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read()) 
                {
                    cliente.Id = (Int32)(dr["Id"]);
                    cliente.Nome = (string)(dr["Nome"]);
                    cliente.Nascimento = (DateTime)(dr["Nascimento"]);
                    cliente.Sexo = (string)(dr["Sexo"]);
                    cliente.CPF = (string)(dr["CPF"]);
                    cliente.Telefone = (string)(dr["Telefone"]);
                    cliente.Email = (string)(dr["Email"]);
                    cliente.Senha = (string)(dr["Senha"]);
                    cliente.Situacao = (string)(dr["Situacao"]);
                }
                return cliente;

            }
        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
           List<Cliente> cliList = new List<Cliente>();

            using (var conexao = new MySqlConnection(_conexaoMySQL)) 
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from Cliente", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows) 
                {
                    cliList.Add(
                        new Cliente
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nome = Convert.ToString(dr["Nome"]),
                            Nascimento = Convert.ToDateTime(dr["Nascimento"]),

                            Sexo = Convert.ToString(dr["Sexo"]),
                            CPF = Convert.ToString(dr["CPF"]),
                            Telefone = Convert.ToString(dr["Telefone"]),
                            Situacao = Convert.ToString(dr["Situacao"]),

                            Email = Convert.ToString(dr["Email"]),
                            Senha = Convert.ToString(dr["Senha"])
                        }
                        );
                
                
                }

                return cliList;
            
            
            }
        }
    }
}
