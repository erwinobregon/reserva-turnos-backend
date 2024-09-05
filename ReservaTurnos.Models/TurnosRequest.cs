namespace ReservaTurnos.Models
{
    public class TurnosRequest
    {
        public int IdServicio { get; set; }
        public DateTime FechaInicio { get; set; }
        public  DateTime FechaFin { get; set; }
    }
}
