﻿using System;
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
        public AuthCliente()
        {
            View = "AuthorizeFailed";
        }

        public string View { get; set; }

        /// <summary>  
        /// Check for Authorization  
        /// </summary>  
        /// <param name="filterContext"></param>  
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext);
        }

        /// <summary>  
        /// Method to check if the user is Authorized or not  
        /// if yes continue to perform the action else redirect to error page  
        /// </summary>  
        /// <param name="filterContext"></param>  
        private void IsUserAuthorized(AuthorizationContext filterContext)
        {
            // If the Result returns null then the user is Authorized   
            if (int.Parse(HttpContext.Current.Session["NivelAcesso"].ToString()) == 1)
            {
                filterContext.Result = new RedirectResult("~/Usuario/Teste");
            }

            //If the user is Un-Authorized then Navigate to Auth Failed View   
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {

                // var result = new ViewResult { ViewName = View };  
                var vr = new ViewResult();
                vr.ViewName = View;

                ViewDataDictionary dict = new ViewDataDictionary();
                dict.Add("Message", "Sorry you are not Authorized to View this Page");

                vr.ViewData = dict;

                var result = vr;

                filterContext.Result = result;
            }
        }
    }
}