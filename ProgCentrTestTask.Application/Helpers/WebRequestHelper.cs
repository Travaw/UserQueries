using ProgCentrTestTask.Application.DTOs;
using ProgCentrTestTask.Application.QueryConsts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCentrTestTask.Application.Helpers
{
    public class WebRequestHelper
    {
        private readonly string service;

        public WebRequestHelper(string service)
        {
            this.service = service;
        }
        public string CreateRequest(QueryDisplayDTO query)
        {
            List<string> requestParams = new List<string>();
            
            if (!string.IsNullOrEmpty(query.Search))
            {
                requestParams.Add(string.Concat(QueryParams.Search, QueryParams.Equal, query.Search));
            }
            if (!string.IsNullOrEmpty(query.Page))
            {
                requestParams.Add(string.Concat(QueryParams.Page, QueryParams.Equal, query.Page));
            }
            if (!string.IsNullOrEmpty(query.Limit))
            {
                requestParams.Add(string.Concat(QueryParams.Limit, QueryParams.Equal, query.Limit));
            }
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                requestParams.Add(string.Concat(QueryParams.SortBy, QueryParams.Equal, query.SortBy));
            }
            if (!string.IsNullOrEmpty(query.Order))
            {
                requestParams.Add(string.Concat(QueryParams.Order, QueryParams.Equal, query.Order));
            }
            if (requestParams.Count > 0)
            {
                string requestLeft = string.Concat(service, QueryParams.Qst);
                string requestRight = string.Join(QueryParams.Amp, requestParams.ToArray());
                return string.Concat(requestLeft, requestRight);
            }
            else return service;


        }
    }
}
