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
    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        [HttpGet]
        public IEnumerable<Aluno> GetAll()
        {
            return _alunoRepositorio.GetAll();
        }

        [HttpGet("{id}", Name ="GetAluno")]
        public IActionResult GetById(long id)
        {
            var aluno = _alunoRepositorio.Find(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return new ObjectResult(aluno);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Aluno aluno)
        {
            if (aluno == null)
            {
                return BadRequest();
            }

            _alunoRepositorio.Add(aluno);
            return CreatedAtRoute("GetAluno", new { id = aluno.AlunoID }, aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id,[FromBody]Aluno aluno)
        {
            if (aluno == null || aluno.AlunoID != id)
            {
                return BadRequest();
            }

            var _aluno = _alunoRepositorio.Find(id);
            if (_aluno == null)
            {
                return NotFound();
            }

            _aluno.Nome = aluno.Nome;
            _alunoRepositorio.Update(_aluno);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var aluno = _alunoRepositorio.Find(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _alunoRepositorio.Remove(id);
            return new NoContentResult();
        }
    }
}