using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaWS.Models;
using ChamadaWS.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChamadaWS.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CalendarioController : Controller
    {
        private readonly ICalendarioRepositorio _calendarioRepositorio;

        public CalendarioController(ICalendarioRepositorio calendarioRepositorio)
        {
            _calendarioRepositorio = calendarioRepositorio;
        }

        [HttpGet]
        public IEnumerable<Calendario> GetAll()
        {
            return _calendarioRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetCalendario")]
        public IActionResult GetById(long id)
        {
            var calendario = _calendarioRepositorio.Find(id);
            if (calendario == null)
            {
                return NotFound();
            }
            return new ObjectResult(calendario);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Calendario calendario)
        {
            if (calendario == null)
            {
                return BadRequest();
            }

            _calendarioRepositorio.Add(calendario);
            return CreatedAtRoute("GetCalendario", new { id = calendario.DataID }, calendario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]Calendario calendario)
        {
            if (calendario == null || calendario.DataID != id)
            {
                return BadRequest();
            }

            var _calendario = _calendarioRepositorio.Find(id);
            if (_calendario == null)
            {
                return NotFound();
            }

            _calendario.DataNome = calendario.DataNome;
            _calendarioRepositorio.Update(_calendario);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var calendario = _calendarioRepositorio.Find(id);
            if (calendario == null)
            {
                return NotFound();
            }

            _calendarioRepositorio.Remove(id);
            return new NoContentResult();
        }
    }
}