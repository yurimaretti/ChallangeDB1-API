using ChallangeDB1.Api.Asp.Net.Models;
using ChallangeDB1.Api.Asp.Net.Repository.Context;
using ChallangeDB1.Api.Asp.Net.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallangeDB1.Api.Asp.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly MentorRepository mentorRepository;

        public MentorController(DataBaseContext context)
        {
            mentorRepository = new MentorRepository(context);
        }

        [HttpGet]
        public ActionResult<List<MentorModel>> Get()
        {
            try
            {
                var lista = mentorRepository.Listar();

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

        [HttpGet("{id}")]
        public ActionResult<MentorModel> Get([FromRoute] string id)
        {
            try
            {
                var mentorModel = mentorRepository.Buscar(id);

                if (mentorModel != null)
                {
                    return Ok(mentorModel);
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
        public ActionResult<MentorModel> Post([FromBody] MentorModel mentorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                mentorRepository.Inserir(mentorModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<MentorModel> Put([FromRoute] string id, [FromBody] MentorModel mentorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (mentorModel.EmailMentor != id)
            {
                return NotFound();
            }

            try
            {
                mentorRepository.Alterar(mentorModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<MentorModel> Delete([FromRoute] string id)
        {
            try
            {
                mentorRepository.Excluir(id);

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
