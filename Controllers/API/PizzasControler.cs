using la_mia_pizzeria_model.Data;
using la_mia_pizzeria_model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_model.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            List<Pizze> pizze = new List<Pizze>();

            using (PizzeContext db = new PizzeContext())
            {
                if (search != null && search != "")
                {
                    pizze = db.Pizze.Where(pizze => pizze.Nome.Contains(search) || pizze.Descrizione.Contains(search)).ToList<Pizze>();
                }
                else
                {
                    pizze = db.Pizze?.ToList<Pizze>();
                }
            }

            return Ok(pizze);
        }

    }
}