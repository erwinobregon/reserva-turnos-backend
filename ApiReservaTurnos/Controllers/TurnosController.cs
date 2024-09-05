using Microsoft.AspNetCore.Mvc;
using ReservaTurnos.UnitOfWork;
using ReservaTurnos.Models;

namespace ApiReservaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : Controller
    {
        private IUnityOfWork unityOfWork;

        public TurnosController(IUnityOfWork unitOfWork)
        {
            this.unityOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(unityOfWork.Turnos.GetById(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(unityOfWork.Turnos.GetList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] TurnosRequest turno)
        {
            object messsage = new { Message = "La solicitud no fue insertada" };

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (unityOfWork.Turnos.ValidarTurnos(turno))
            {
                messsage = new { Message = $"Ya existen turnos para el rango de fechas del {turno.FechaInicio} al  {turno.FechaInicio}"};
            }

            else if (turno.FechaInicio.Year != DateTime.Now.Year)
                messsage = new { Message = "La Fecha inicio debe estar en el año actual" };
            else if (turno.FechaFin.Year != DateTime.Now.Year)
                messsage = new { Message = "La Fecha fin debe estar en el año actual" };
            else if (turno.FechaInicio.DayOfYear > turno.FechaFin.DayOfYear)
                messsage = new { Message = "La Fecha inicio no puede ser mayor a la Fecha fin" };
            else if (!turno.FechaInicio.Equals(null) && !turno.FechaFin.Equals(null) && turno.IdServicio > 0)
            {
                return Ok(unityOfWork.Turnos.CrearTurnos(turno));
            }
            return Ok(messsage);

        }

        [HttpPut]
        public IActionResult Put([FromBody] Turnos turno)
        {
            object messsage = new { Message = "El turno no fue actualizado" };

            if (ModelState.IsValid && unityOfWork.Turnos.Update(turno))
            {
                return Ok(new { Message = "El turno fue actualizado" });
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Turnos turno)
        {
            if (turno.IdTurno > 0 && turno.IdServicio > 0 && unityOfWork.Turnos.Delete(turno))
            {
                return Ok(new { Message = "El turno fue borrado" });
            }

            return BadRequest();
        }


    }
}
