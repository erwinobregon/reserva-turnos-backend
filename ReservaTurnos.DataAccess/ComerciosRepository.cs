using ReservaTurnos.Models;
using ReservaTurnos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaTurnos.DataAccess
{
    public class ComerciosRepository : Repository<Comercios>, IComerciosRepository
    {
        public ComerciosRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
