using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock2
{
    internal class Weather
    {
        public class weather
        {
            public string main { get; set; }
            public string desription { get; set; }
        }

        public class main
        {
            public double temp { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double humidity { get; set; }
        }

        public class root
        {
            public List<weather> weather { get; set; }
            public main main { get; set; }
        }
    }
}
