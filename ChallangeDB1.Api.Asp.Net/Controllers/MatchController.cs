using ChallangeDB1.Api.Asp.Net.Repository.Context;
using ChallangeDB1.Api.Asp.Net.Repository;
using Microsoft.AspNetCore.Mvc;
using ChallangeDB1.Api.Asp.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallangeDB1.Api.Asp.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly MatchRepository matchRepository;

        public MatchController(DataBaseContext context)
        {
            matchRepository = new MatchRepository(context);
        }

        [HttpGet("por-aprdz/{emailAprdz}")]
        public ActionResult<List<MatchModel>> GetPorAprdz([FromRoute] string emailAprdz)
        {
            try
            {
                var lista = matchRepository.ListarPorAprdz(emailAprdz);

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

        [HttpGet("por-mentor/{emailMentor}")]
        public ActionResult<List<MatchModel>> GetPorTipo([FromRoute] string emailMentor)
        {
            try
            {
                var lista = matchRepository.ListarPorMentor(emailMentor);

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

        [HttpGet("por-emails/{emailAprdz}/{emailMentor}")]
        public ActionResult<List<MatchModel>> GetPorEmails([FromRoute] string emailAprdz, string emailMentor)
        {
            try
            {
                var lista = matchRepository.BuscarMatch(emailAprdz, emailMentor);

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
        public ActionResult<MatchModel> Post([FromBody] MatchModel matchModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                matchRepository.Inserir(matchModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<MatchModel> Put([FromRoute] int id, [FromBody] MatchModel matchModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (matchModel.MatchId != id)
            {
                return NotFound();
            }

            try
            {
                matchRepository.Alterar(matchModel);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<MatchModel> Delete([FromRoute] int id)
        {
            try
            {
                matchRepository.Excluir(id);

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
