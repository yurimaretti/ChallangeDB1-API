using ChallangeDB1.Api.Asp.Net.Models;
using ChallangeDB1.Api.Asp.Net.Repository.Context;
using ChallangeDB1.Api.Asp.Net.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallangeDB1.Api.Asp.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadeController : ControllerBase
    {
        private readonly HabilidadeRepository habilidadeRepository;

        public HabilidadeController(DataBaseContext context)
        {
            habilidadeRepository = new HabilidadeRepository(context);
        }

        [HttpGet("{email}")]
        public ActionResult<List<HabilidadeModel>> Get([FromRoute] string email)
        {
            try
            {
                var lista = habilidadeRepository.ListarPorEmail(email);

                if (lista != null)
                {
                    return Ok(lista);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpPost]
        public ActionResult<HabilidadeModel> Post([FromBody] HabilidadeModel habilidadeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                habilidadeRepository.Inserir(habilidadeModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<HabilidadeModel> Put([FromRoute] int id, [FromBody] HabilidadeModel habilidadeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (habilidadeModel.HabilidadeId != id)
            {
                return NotFound();
            }

            try
            {
                habilidadeRepository.Alterar(habilidadeModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<HabilidadeModel> Delete([FromRoute] int id)
        {
            try
            {
                habilidadeRepository.Excluir(id);

                return NoContent();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest(e.StackTrace);
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }
    }
}
