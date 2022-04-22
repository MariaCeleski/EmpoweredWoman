using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoweredWoman.Shared
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string FinancialBank { get; set; } = string.Empty;
        public string Actions { get; set; } = string.Empty;
        public string LocalActions { get; set; } = string.Empty;
        public Position? Position { get; set; }
        public int PositionId { get; set; }
    }
}
