using ChallangeDB1.Api.Asp.Net.Models;
using ChallangeDB1.Api.Asp.Net.Repository;
using ChallangeDB1.Api.Asp.Net.Repository.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallangeDB1.Api.Asp.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AprendizController : ControllerBase
    {
        private readonly AprendizRepository aprendizRepository;

        public AprendizController(DataBaseContext context)
        {
            aprendizRepository = new AprendizRepository(context);
        }

        [HttpGet]
        public ActionResult<List<AprendizModel>> Get()
        {
            try
            {
                var lista = aprendizRepository.Listar();

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
        public ActionResult<AprendizModel> Get([FromRoute] string id)
        {
            try
            {
                var aprendizModel = aprendizRepository.Buscar(id);

                if (aprendizModel != null)
                {
                    return Ok(aprendizModel);
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
        public ActionResult<AprendizModel> Post([FromBody] AprendizModel aprendizModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                aprendizRepository.Inserir(aprendizModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<AprendizModel> Put([FromRoute] string id, [FromBody] AprendizModel aprendizModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (aprendizModel.EmailAprendiz != id)
            {
                return NotFound();
            }

            try
            {
                aprendizRepository.Alterar(aprendizModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<AprendizModel> Delete([FromRoute] string id)
        {
            try
            {
                aprendizRepository.Excluir(id);
               
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
