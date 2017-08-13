using System.Collections.Generic;
using System.Linq;
using RestSharp;
using DR.Common.Entities;
using DR.Common.Interfaces;

namespace DR.DataAccess
{
    public class Requester : IRequester
    {
        public List<LatestArticleItem> GetLatestArticles(string baseUrl, int numArticles)
        {
            var requestUrl = $"{baseUrl}/articles/latest.json?page_size={numArticles}";
            var client = new RestClient(requestUrl);

            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-application-name", "DR-Test");
            request.AddHeader("accept", "application/json");

            var response = client.Execute<Response<List<LatestArticleItem>>>(request).Data;
            return response.Data;
        }

        public List<EditorialSiteItem> GetEditorialSites(string baseUrl, string editorialKey)
        {
            var requestUrl = $"{baseUrl}/sites.json";
            var client = new RestClient(requestUrl);

            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-application-name", "DR-Test");
            request.AddHeader("accept", "application/json");

            var response = client.Execute<Response<List<EditorialSiteItem>>>(request).Data;
            var editorialSites = response.Data.Where(s => s.Site_Info_Collection.Body == editorialKey).ToList();
            return editorialSites;
        }
    }
}
