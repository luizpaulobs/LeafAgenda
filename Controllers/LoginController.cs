using AgendaLeaf.Models;
using AgendaLeaf.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaLeaf.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;
        private readonly UsuarioIdService _usuarioIdService;

        public LoginController(Context context, UsuarioIdService usuarioIdService)
        {
            _context = context;
            _usuarioIdService = usuarioIdService;
        }
        // GET: LoginController
        public IActionResult Index()
        {
            Usuario usuarios = new Usuario();
            return View(usuarios);
        }

        public IActionResult Cadastrar()
        {
            Usuario usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        async public Task<IActionResult> CadastrarUsuario([Bind("Nome,Email,Senha")] Usuario usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        async public Task<IActionResult> Logar([Bind("Email,Senha")] Usuario usuario)
        {
            if (usuario.Email is not null && usuario.Senha is not null)
            {
                var listUsers = await _context.Usuarios.ToListAsync();
                var user = listUsers.Find(x => x.Email == usuario.Email && x.Senha == usuario.Senha);
                if (user != null)
                {
                    _usuarioIdService.UsuarioId = user.Id;
                    _usuarioIdService.NomeUsuario = user.Nome;
                    return RedirectToAction("Index", "Agenda");
                }
            }

            return RedirectToAction("Index", "Login");
        } 

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
