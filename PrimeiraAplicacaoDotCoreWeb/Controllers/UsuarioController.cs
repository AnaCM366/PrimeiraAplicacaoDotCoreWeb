using Microsoft.AspNetCore.Mvc;
using PrimeiraAplicacaoDotCoreWeb.Models.Usuario;
using Service;

namespace PrimeiraAplicacaoDotCoreWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            var db = new Db();

            var listaUsuarioDTO = db.GetUsuarios();

            var listaUsuario = new List<Usuario>();

            foreach (var usuarioDTO in listaUsuarioDTO)
            {
                var usuario = new Usuario();
                usuario.Id = usuario.Id;
                usuario.Nome = usuarioDTO.nome;
                usuario.Sobrenome = usuarioDTO.sobrenome;
                usuario.Email = usuarioDTO.email;
                listaUsuario.Add(usuario);

            }

            return View(listaUsuario);
        }
        public IActionResult NovoUsuario()
        {
            return View();
        }

        public IActionResult PersistirUsuario(string nome, string sobrenome, string email) //persistir(salvar informações)//cadastrar e atualizar o usuario, podemos reutilizar essa função
        {
            return RedirectToAction("Index"); // Redireciona para a ação Index após persistir o usuário
        }
    }
}
