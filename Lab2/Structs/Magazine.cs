using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLlab

{
    public class Magazine
    {
        public int Id { get; set; }
        public string MagazineName { get; set; }

        public int PeriodRelease { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Circulation { get; set; }
    }
}
