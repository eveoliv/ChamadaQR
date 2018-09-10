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
    [Route("api/Presenca")]
    public class PresencaController : Controller
    {
        private readonly IPresencaRepositorio _presencaRepositorio;

        public PresencaController(IPresencaRepositorio presencaRepositorio)
        {
            _presencaRepositorio = presencaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Presenca> GetAll()
        {
            return _presencaRepositorio.GetAll();
        }

        [HttpGet("{id}", Name="GetPresenca")]
        public IActionResult GetById(long id)
        {
            var presenca = _presencaRepositorio.Find(id);
            if (presenca == null)
            {
                return NotFound();
            }
            return new ObjectResult(presenca);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Presenca presenca)
        {
            if (presenca == null)
            {
                return BadRequest();
            }

            _presencaRepositorio.Add(presenca);
            return CreatedAtRoute("GetPresenca", new { id = presenca.PresencaID }, presenca);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id,[FromBody]Presenca presenca)
        {
            if (presenca == null || presenca.PresencaID != null)
            {
                return BadRequest();
            }

            var _presenca = _presencaRepositorio.Find(id);
            if (presenca == null)
            {
                return NotFound();
            }

            _presenca.Data = presenca.Data;
            _presencaRepositorio.Update(_presenca);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var presenca = _presencaRepositorio.Find(id);
            if (presenca == null)
            {
                return NotFound();
            }

            _presencaRepositorio.Remove(id);
            return new NoContentResult();
        }
    }
}