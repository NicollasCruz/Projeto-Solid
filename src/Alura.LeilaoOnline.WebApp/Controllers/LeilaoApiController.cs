using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        AppDbContext _context;
        LeilaoDao _dao;

        public LeilaoApiController()
        {
            _context = new AppDbContext();
            _dao = new LeilaoDao();
        }


        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = _context.Leiloes
                .Include(l => l.Categoria);
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _dao.GetLeilaoById(id);

            if (leilao == null)
                return NotFound();

            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            _dao.CreateLeilao(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            _dao.UpdateLeilao(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _dao.GetLeilaoById(id);

            if (leilao == null)
                return NotFound();

            _dao.DeleteLeilao(leilao);
            return NoContent();
        }


    }
}
