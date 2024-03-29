﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using CienciaArgentina.Microservices.Commons.Dtos;
using CienciaArgentina.Microservices.Commons.Helpers.PapersHelper;
using CienciaArgentina.Microservices.Entities.Models.Organizations;

namespace CienciaArgentina.Microservices.Business.Application.Papers
{
    public class PapersWrapper
    {
        public static async Task<PaperDto> Get(int? pmid)
        {
            var search = await PubMedHelper.SearchByPMIDAsync(pmid);

            if(search == null)
                throw new NullReferenceException("No se encontró nada para la búsqueda asignada");

            var paper = await PubMedHelper.SearchPMIDResultsAsync(search);
            return paper;
        }

        public static async Task<List<PaperDto>> Get(string alias)
        {
            var papers = new List<PaperDto>();
            var articles = await PubMedHelper.SearchByAliasAsync(alias);
            foreach (var article in articles)
            {
                papers.Add(await Get(Convert.ToInt32(article)));
            }

            return papers;
        }
    }
}
