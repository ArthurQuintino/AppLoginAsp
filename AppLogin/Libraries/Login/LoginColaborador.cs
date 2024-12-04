using AppLogin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppLogin.Libraries.Login
{
    public class LoginColaborador : Controller
    {
        private string key = "Login.Colaborador";
        private Sessao.Sessao _sessao;
        public LoginColaborador(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Colaborador colaborador) 
        {
            string colaboradorJSONString = JsonConvert.SerializeObject(colaborador);

            _sessao.Cadastrar(key, colaboradorJSONString);
        
        }

        public Colaborador GetColaborador() 
        {

            if (_sessao.Existe(key))
            {
                string colaboradorJSONString = _sessao.Consultar(key);
                return JsonConvert.DeserializeObject<Colaborador>(colaboradorJSONString);
            }
            else {
                return null;
            }
        
        
        
        }

        public void Logout() 
        {
            _sessao.RemoverTodos();
        }
    }
}
