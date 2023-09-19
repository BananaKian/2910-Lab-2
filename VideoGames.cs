using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
        public class VideoGames : IComparable<VideoGames>
        {
            public string Name { get; set; }
            public string Platform { get; set; }
            public string Year { get; set; }
            public string Genre { get; set; }
            public string Publisher { get; set; }
            public decimal NASales { get; set; }
            public decimal EUSales { get; set; }
            public decimal JPSales { get; set; }
            public decimal OtherSales { get; set; }
            public decimal GlobalSales { get; set; }

            public int CompareTo(VideoGames other)
            {
                return Name.CompareTo(other.Name);
            }
        }
}
