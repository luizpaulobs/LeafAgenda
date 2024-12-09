using AgendaLeaf.Models;
using AgendaLeaf.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgendaLeaf.Controllers
{
    public class AgendaController : Controller
    {
        private readonly Context _context;
        private readonly UsuarioIdService _usuarioIdService;

        public AgendaController(Context context, UsuarioIdService usuarioIdService)
        {
            _context = context;
            _usuarioIdService = usuarioIdService;
        }
        async public Task<IActionResult> Index()
        {
            var userId = _usuarioIdService.UsuarioId;
            ViewData["userId"] =  _usuarioIdService.UsuarioId.ToString();
            ViewData["nomeUsuario"] = _usuarioIdService.NomeUsuario;
            ViewData["listaDatas"] = PegarDatas("");
            ViewData["pesquisaData"] = "";

            var list = await _context.Eventos.ToListAsync();
            var eventos = list.Where(x => (x.Compartilhado == true) || x.Compartilhado == false && x.UsuarioId == userId).ToList();
            return View(eventos);
        }

        public IActionResult LogOut()
        {
            _usuarioIdService.UsuarioId = 0;
            return RedirectToAction("Index", "Login");
        }


        private IEnumerable<AgendaLeaf.Models.DatasViewModel> PegarDatas(string pesquisa)
        {
            if(pesquisa == "")
            {
                DateTime dataAtual = DateTime.Now;
                DateTime dataLimite = DateTime.Now.AddDays(10);
                int qtdDias = 0;
                DatasViewModel data;
                List<DatasViewModel> listDatas = new List<DatasViewModel>();

                while(dataAtual < dataLimite)
                {
                    data = new DatasViewModel();
                    data.Datas = dataAtual.ToShortDateString();
                    data.Identificadores = "collapse" + dataAtual.ToShortDateString().Replace("/", "");
                    listDatas.Add(data);
                    qtdDias++;
                    dataAtual = DateTime.Now.AddDays(qtdDias);
                }

                return listDatas;
            } else
            {
                DateTime dataAtual = DateTime.Parse(pesquisa);
                DatasViewModel data;
                data = new DatasViewModel();
                List<DatasViewModel> listDatas = new List<DatasViewModel>();
                data.Datas = dataAtual.ToShortDateString();
                data.Identificadores = "collapse" + dataAtual.ToShortDateString().Replace("/", "");
                listDatas.Add(data);

                return listDatas;
            }
        }

        // POST: Eventos/Delete/5
        
        public async Task<IActionResult> Delete(int id)
        {
            var eventos = await _context.Eventos.FindAsync(id);
            if (eventos != null)
            {
                _context.Eventos.Remove(eventos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Agenda");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string Pesquisa)
        {
            var userId = _usuarioIdService.UsuarioId;
            ViewData["userId"] = _usuarioIdService.UsuarioId.ToString();
            ViewData["listaDatas"] = PegarDatas(Pesquisa);
            var dataPesquisa = DateTime.Parse(Pesquisa).Date;
            ViewData["pesquisaData"] = dataPesquisa.ToString("yyy-MM-dd");
            var list = await _context.Eventos.ToListAsync();
            var listEventos = list.Where(x => (x.Compartilhado == true) || x.Compartilhado == false && x.UsuarioId == userId).ToList();
            var eventos = listEventos.Where(x => DateTime.Parse(x.Data).Date.Equals(dataPesquisa)).ToList();
            return View(eventos);
        }


    }
}
