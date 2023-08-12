using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVoLinh_2121110083.Model
{
    public class AreaBEL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CustomerBEL> Customers { get; set; }
    }
}
