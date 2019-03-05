using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Commons.Dtos
{
    public class PaperDto
    {
        public string Title { get; set; }
        public string PubDate { get; set; }
        public string Magazine { get; set; }
        public string Link { get; set; }
        public string PMID { get; set; }
        public List<string> Authors { get; set; }
        public string LastAuthor { get; set; }
    }
}
