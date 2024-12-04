﻿using AppLogin.Libraries.Login;
using AppLogin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace AppLogin.Libraries.Filtro
{
    public class ClienteAutorizacaoAtributte : Attribute, IAuthorizationFilter
    {
        LoginCliente _loginCliente;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCliente = ((LoginCliente)context.HttpContext.RequestServices.GetService(typeof(LoginCliente)));
            Cliente cliente = _loginCliente.GetCliente();
            if (cliente == null) 
            {
                context.Result = new ContentResult() { Content = "Acesso negado."};
            }
        }

    }
    //[ClienteAutorizacao]

}
