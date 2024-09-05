using Microsoft.AspNetCore.Mvc;
using ReservaTurnos.Models;
using ReservaTurnos.UnitOfWork;

namespace ApiReservaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : Controller
    {
        private IUnityOfWork unityOfWork;

        public ComercioController(IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(unityOfWork.Comercios.GetById(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(unityOfWork.Comercios.GetList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Comercios comercios)
        {
            object messsage = new { Message = "El comercio no fue insertado" };

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            IEnumerable<Comercios> getComercios = unityOfWork.Comercios.GetList();
            if (getComercios.FirstOrDefault(p => p.IdComercio == comercios.IdComercio) == null)
            {
                unityOfWork.Comercios.Insert(comercios);
                messsage = new { Message = "El comercio fue insertado" };

            }
            return Ok(messsage);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Comercios comercios)
        {
            object messsage = new { Message = "El comercio no fue actualizado" };

            if (ModelState.IsValid && unityOfWork.Comercios.Update(comercios))
            {
                return Ok(new { Message = "El comercio fue actualizado" });
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Comercios comercio)
        {
            if (comercio.IdComercio > 0 && unityOfWork.Comercios.Delete(comercio))
            {
                return Ok(new { Message = "El comercio fue borrado" });
            }

            return BadRequest();
        }

    }
}
