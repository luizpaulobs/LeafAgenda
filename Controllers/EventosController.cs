using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaLeaf.Models;
using AgendaLeaf.Services;

namespace AgendaLeaf.Controllers
{
    public class EventosController : Controller
    {
        private readonly Context _context;
        private readonly UsuarioIdService _usuarioIdService;

        public EventosController(Context context, UsuarioIdService usuarioIdService)
        {
            _context = context;
            _usuarioIdService = usuarioIdService;
        }

        // GET: Eventos
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Eventos.ToListAsync());
        //}

        // GET: Eventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventos = await _context.Eventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventos == null)
            {
                return NotFound();
            }

            return View(eventos);
        }

        // GET: Eventos/Create
        public IActionResult Create(string data)
        {
            Eventos evento = new Eventos
            {
                Data = data
            };

            return View(evento);
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEvent([Bind("Nome,Descricao,Data,Participantes,Compartilhado,Hora,UsuarioId")] Eventos eventos)
        {
            eventos.UsuarioId = _usuarioIdService.UsuarioId;
            if (ModelState.IsValid)
            {
                _context.Add(eventos);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Agenda");
            }
            return RedirectToAction("Create", "Eventos");
        }

        // GET: Eventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            //return View(evento);
            return View("Edit", evento);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEvent(int id, [Bind("Id,Nome,Descricao,Data,Participantes,Compartilhado,Hora")] Eventos eventos)
        {
            if (id != eventos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventosExists(eventos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Agenda");
            }
            return View(eventos);
        }

        // GET: Eventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventos = await _context.Eventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventos == null)
            {
                return NotFound();
            }

            return View(eventos);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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

        private bool EventosExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
