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
    public class InteresseController : ControllerBase
    {
        private readonly InteresseRepository interesseRepository;

        public InteresseController(DataBaseContext context)
        {
            interesseRepository = new InteresseRepository(context);
        }

        [HttpGet("{email}")]
        public ActionResult<List<InteresseModel>> Get([FromRoute] string email)
        {
            try
            {
                var lista = interesseRepository.ListarPorEmail(email);

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
        public ActionResult<InteresseModel> Post([FromBody] InteresseModel interesseModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                interesseRepository.Inserir(interesseModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<InteresseModel> Put([FromRoute] int id, [FromBody] InteresseModel interesseModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (interesseModel.InteresseId != id)
            {
                return NotFound();
            }

            try
            {
                interesseRepository.Alterar(interesseModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<InteresseModel> Delete([FromRoute] int id)
        {
            try
            {
                interesseRepository.Excluir(id);

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
