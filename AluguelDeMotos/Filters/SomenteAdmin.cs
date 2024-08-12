using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AluguelDeMotos.Models.Usuarios;

namespace AluguelDeMotos.Filters
{
    public class SomenteAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary() { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                var usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

                if (usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary() { { "controller", "Login" }, { "action", "Index" } });
                }

                if (usuario.Perfil != Enums.PerfilEnum.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary() { { "controller", "Restrito" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuted(context);
        }
    }
}
