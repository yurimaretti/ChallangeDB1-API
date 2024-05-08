using ChallangeDB1.Api.Asp.Net.Models;
using ChallangeDB1.Api.Asp.Net.Repository;
using ChallangeDB1.Api.Asp.Net.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallangeDB1.Api.Asp.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormacaoAprendizController : ControllerBase
    {
        private readonly FormacaoAprendizRepository formacaoAprendizRepository;

        public FormacaoAprendizController(DataBaseContext context)
        {
            formacaoAprendizRepository = new FormacaoAprendizRepository(context);
        }

        [HttpGet("{email}")]
        public ActionResult<List<FormacaoAprendizModel>> Get([FromRoute] string email)
        {
            try
            {
                var lista = formacaoAprendizRepository.ListarPorEmail(email);

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
        public ActionResult<FormacaoAprendizModel> Post([FromBody] FormacaoAprendizModel formacaoAprendizModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                formacaoAprendizRepository.Inserir(formacaoAprendizModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<FormacaoAprendizModel> Put([FromRoute] int id, [FromBody] FormacaoAprendizModel formacaoAprendizModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (formacaoAprendizModel.FormAprdzId != id)
            {
                return NotFound();
            }

            try
            {
                formacaoAprendizRepository.Alterar(formacaoAprendizModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<FormacaoAprendizModel> Delete([FromRoute] int id)
        {
            try
            {
                formacaoAprendizRepository.Excluir(id);

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
