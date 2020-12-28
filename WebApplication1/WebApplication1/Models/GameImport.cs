using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace backend.Models
{
    public class GameImport
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Thumbnail { get; set; }
        public string ShortDescription { get; set; }
        public string GameUrl { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public string ReleaseDate { get; set; }
        public string F2pUrl { get; set; }
    }
}
