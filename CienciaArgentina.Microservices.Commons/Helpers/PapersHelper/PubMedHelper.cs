using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using CienciaArgentina.Microservices.Commons.Dtos;

namespace CienciaArgentina.Microservices.Commons.Helpers.PapersHelper
{
    public class PubMedHelper
    {
        // First: https://eutils.ncbi.nlm.nih.gov/entrez/eutils/esearch.fcgi?db=pubmed&term=29519839&usehistory=y
        // Then: https://eutils.ncbi.nlm.nih.gov/entrez/eutils/esummary.fcgi?db=pubmed&query_key=1&WebEnv=NCID_1_23914615_130.14.18.97_9001_1551671826_1134467423_0MetA0_S_MegaStore
        public static async Task<Tuple<string, string>> SearchPMID(int? pmid)
        {
            // Query string for PubMed search
            var url = $"https://eutils.ncbi.nlm.nih.gov/entrez/eutils/esearch.fcgi?db=pubmed&term={pmid}&usehistory=n";
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(url);
            var stringResponse = await result.Content.ReadAsStringAsync();
            var xml = XDocument.Parse(stringResponse).LastNode;
            var count = xml.XPathSelectElement("//Count");
            if (count == null || Convert.ToInt32(count.Value) == 0)
                throw new NullReferenceException("No se encontró nada para la búsqueda asignada");
            var elements = new Tuple<string, string>(xml.XPathSelectElement("//QueryKey").Value,
                xml.XPathSelectElement("//WebEnv").Value);

            return elements;
        }
        public static async Task<PaperDto> SearchPMIDResults(Tuple<string, string> search)
        {
            var url =
                $"https://eutils.ncbi.nlm.nih.gov/entrez/eutils/esummary.fcgi?db=pubmed&query_key={search.Item1}&WebEnv={search.Item2}";
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(url);
            var stringResponse = await result.Content.ReadAsStringAsync();
            var xml = XDocument.Parse(stringResponse).LastNode.XPathSelectElements("//DocSum");

            if (xml == null)
                throw new NullReferenceException("No se encontró nada para la búsqueda asignada");

            var paper = new PaperDto();
            paper.Authors = new List<string>();
            paper.Title = xml.Descendants("Item").FirstOrDefault(x => x.Attribute("Name")?.Value == "Title").Value;
            paper.PubDate = xml.Descendants("Item").FirstOrDefault(x => x.Attribute("Name")?.Value == "PubDate").Value;
            var pmid = xml.Select(x => x.Element("Id").Value).FirstOrDefault();
            paper.Link = $"https://www.ncbi.nlm.nih.gov/pubmed/{pmid}";
            paper.PMID = pmid;
            var authorsXml = xml.Descendants("Item")
                .FirstOrDefault(x => x.Attribute("Name")?.Value == "AuthorList");
            foreach (var author in authorsXml?.Elements("Item"))
            {
                paper.Authors.Add(author.Value);
            }
            paper.LastAuthor = xml.Descendants("Item").FirstOrDefault(x => x.Attribute("Name")?.Value == "LastAuthor").Value;

            return paper;
        }
    }
}
