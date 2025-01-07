using Microsoft.AspNetCore.Mvc;
using NHibernate;
using KlerenGen.Infraestructure.CP;
using KlerenGen.Infraestructure.Repository.Kleren;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISession = NHibernate.ISession;

namespace web_kleren.Controllers
{
    public class BasicController:Controller
    {
        private ISession sessionInside;


        protected SessionCPNHibernate session;

        protected BasicController()
        {
        }

        protected void SessionInitialize()
        {
            if (session == null)
            {
                sessionInside = NHibernateHelper.OpenSession();
                session = new SessionCPNHibernate(sessionInside);
            }
        }


        protected void SessionClose()
        {
            if (session != null && sessionInside.IsOpen)
            {
                sessionInside.Close();
                sessionInside.Dispose();
                session = null;
            }
        }
        protected int? GetUsuarioIdFromSession()
        {
            var usuarioId = HttpContext.Session.GetString("UsuarioId");
            return string.IsNullOrEmpty(usuarioId) ? (int?)null : int.Parse(usuarioId);
        }

    }
}


