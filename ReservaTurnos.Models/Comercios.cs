using Dapper.Contrib.Extensions;

namespace ReservaTurnos.Models
{
    public class Comercios
    {
        [Key]
        public int IdComercio { get; set; }
        public string? NombreComercio { get; set; }
        public int AforoMaximo { get; set; }

    }
}
