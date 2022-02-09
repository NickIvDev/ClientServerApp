using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    // модель для передачи данных в бд
    public class CarModel
    {
        public int Id { get; set; }
        public string Brend { get; set; }
        public short Year { get; set; }
        public float Engine { get; set; }
        public byte Dors { get; set; }
    }
}
