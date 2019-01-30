using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CienciaArgentina.Microservices.Entities.QueryParameters
{
    public class QueryParameters
    {
        private const int MaxPageCount = 100;
        public int Page { get; set; } = 1;

        private int _pageCount = 100;
        public int PageCount
        {
            get => _pageCount;
            set => _pageCount = (value > MaxPageCount) ? MaxPageCount : value;
        }

        public bool HasQuery => !String.IsNullOrEmpty(Query);
        public string Query { get; set; }

        public string OrderBy { get; set; } = "Id";
        public bool Descending
        {
            get
            {
                if (!String.IsNullOrEmpty(OrderBy))
                {
                    return OrderBy.Split(' ').Last().ToLowerInvariant().StartsWith("desc");
                }
                return false;
            }
        }
    }
}
