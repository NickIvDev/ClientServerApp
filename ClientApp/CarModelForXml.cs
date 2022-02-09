using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    // модель для сериализации в xml
    public class CarModelForXml
    {
        public int Id { get; set; }
        public string Brend { get; set; }
        public short Year { get; set; }
        public float Engine { get; set; }
        public byte Dors { get; set; }
    }
}
