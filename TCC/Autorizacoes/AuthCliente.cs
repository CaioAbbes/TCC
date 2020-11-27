using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace TCC.Autorizacoes
{
    public class AuthCliente : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthentication(System.IdentityModel.Tokens.AuthenticationContext filterContext)
        {
            //deixar em branco
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (int.Parse(HttpContext.Current.Session["nomeUsuarioLogado"].ToString()) == 1)
            {
                filterContext.Result = new RedirectResult("~/Produto/List");
            }
        }
    }
}