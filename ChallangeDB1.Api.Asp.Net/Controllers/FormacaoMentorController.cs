using ChallangeDB1.Api.Asp.Net.Models;
using ChallangeDB1.Api.Asp.Net.Repository.Context;
using ChallangeDB1.Api.Asp.Net.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallangeDB1.Api.Asp.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormacaoMentorController : ControllerBase
    {
        private readonly FormacaoMentorRepository formacaoMentorRepository;

        public FormacaoMentorController(DataBaseContext context)
        {
            formacaoMentorRepository = new FormacaoMentorRepository(context);
        }

        [HttpGet("{email}")]
        public ActionResult<List<FormacaoMentorModel>> Get([FromRoute] string email)
        {
            try
            {
                var lista = formacaoMentorRepository.ListarPorEmail(email);

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
        public ActionResult<FormacaoMentorModel> Post([FromBody] FormacaoMentorModel formacaoMentorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                formacaoMentorRepository.Inserir(formacaoMentorModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<FormacaoMentorModel> Put([FromRoute] int id, [FromBody] FormacaoMentorModel formacaoMentorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (formacaoMentorModel.FormMentorId != id)
            {
                return NotFound();
            }

            try
            {
                formacaoMentorRepository.Alterar(formacaoMentorModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<FormacaoMentorModel> Delete([FromRoute] int id)
        {
            try
            {
                formacaoMentorRepository.Excluir(id);

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
