using DR.Common.Entities;
using System.Collections.Generic;

namespace DR.Common.Interfaces
{
    public interface IRequester
    {
        List<LatestArticleItem> GetLatestArticles(string baseUrl, int numArticles);

        List<EditorialSiteItem> GetEditorialSites(string baseUrl, string editorialKey);
    }
}
