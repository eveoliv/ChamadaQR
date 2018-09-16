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
    public class FrequenciaController : Controller
    {
        private readonly IFrequenciaRepositorio _frequenciaRepositorio;

        public FrequenciaController(IFrequenciaRepositorio frequenciaRepositorio)
        {
            _frequenciaRepositorio = frequenciaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Frequencia> GetAll()
        {
            return _frequenciaRepositorio.GetAll();
        }

        [HttpGet("{id}", Name="GetFrequencia")]
        public IActionResult GetById(long id)
        {
            var frequencia = _frequenciaRepositorio.Find(id);
            if (frequencia == null)
            {
                return NotFound();
            }
            return new ObjectResult(frequencia);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Frequencia frequencia)
        {
            if (frequencia == null)
            {
                return BadRequest();
            }

            _frequenciaRepositorio.Add(frequencia);
            return CreatedAtRoute("GetFrequencia", new { id = frequencia.FrequenciaID }, frequencia);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id,[FromBody]Frequencia frequencia)
        {
            if (frequencia == null || frequencia.FrequenciaID != null)
            {
                return BadRequest();
            }

            var _frequencia = _frequenciaRepositorio.Find(id);
            if (frequencia == null)
            {
                return NotFound();
            }

            _frequencia.FrequenciaID = frequencia.FrequenciaID;
            _frequenciaRepositorio.Update(_frequencia);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var frequencia = _frequenciaRepositorio.Find(id);
            if (frequencia == null)
            {
                return NotFound();
            }

            _frequenciaRepositorio.Remove(id);
            return new NoContentResult();
        }
    }
}