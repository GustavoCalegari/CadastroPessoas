using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadastroPessoas.Models;
using CadastroPessoas.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoas.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> Get([FromServices] DataContext context)
        {
            var pessoas = await context.Pessoas.ToListAsync();
            return pessoas;
        }

        [HttpGet]
        [Route("{id: int}")]
        public async Task<ActionResult<Pessoa>> GetById([FromServices] DataContext context, int id)
        {
            var pessoa = await context.Pessoas.Include(x => x.Id)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return pessoa;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Pessoa>> Post(
            [FromServices] DataContext context,
            [FromBody] Pessoa model)
        {
            if (ModelState.IsValid)
            {
                context.Pessoas.Add(model);
                await context.SaveChangesAsync();
                return model;
            } 
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
