using Microsoft.AspNetCore.Mvc;
using ReservaTurnos.Models;
using ReservaTurnos.UnitOfWork;

namespace ApiReservaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : Controller
    {
        private IUnityOfWork unityOfWork;

        public ServiciosController(IUnityOfWork unitOfWork)
        {
            this.unityOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(unityOfWork.Servicios.GetById(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(unityOfWork.Servicios.GetList());
        }


        [HttpPost]
        public IActionResult Post([FromBody] Servicios servicio)
        {
            object messsage = new { Message = "El servicio no fue insertado" };


            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            IEnumerable<Servicios> getServicios = unityOfWork.Servicios.GetList();

            if (servicio.HoraApertura.TotalSeconds >= servicio.HoraCierre.TotalSeconds)
                messsage = new { Message = "La hora de apertura no puede ser mayor o igual a la hora de cierre" };

            else if (getServicios.FirstOrDefault(p => p.NombreServicio == servicio.NombreServicio) == null)
            {
                unityOfWork.Servicios.Insert(servicio);
                messsage = new { Message = "El servicio fue insertado" };

            }
            return Ok(messsage);

        }

        [HttpPut]
        public IActionResult Put([FromBody] Servicios servicio)
        {
            object messsage = new { Message = "El servicio no fue actualizado" };
            if (servicio.HoraApertura.TotalSeconds >= servicio.HoraCierre.TotalSeconds)
                messsage = new { Message = "La hora de apertura no puede ser mayor o igual a la hora de cierre" };
            else if (ModelState.IsValid && unityOfWork.Servicios.Update(servicio))
            {
                messsage = new { Message = "El servicio fue actualizado" };
            }
            return Ok(messsage);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Servicios servicio)
        {
            if (servicio.IdServicio > 0 && servicio.IdComercio > 0 && unityOfWork.Servicios.Delete(servicio))
            {
                return Ok(new { Message = "El servicio fue borrado" });
            }

            return BadRequest();
        }
    }
}
