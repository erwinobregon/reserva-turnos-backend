using Dapper.Contrib.Extensions;


namespace ReservaTurnos.Models
{
    public class Servicios
    {
        [Key]
        public int IdServicio { get; set; }
        public int IdComercio { get; set; }
        public string? NombreServicio { get; set; }
        public TimeSpan HoraApertura { get; set; }
        public TimeSpan HoraCierre { get; set; }
        public int Duracion { get; set; }
    }
}
