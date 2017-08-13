using DR.Common.Interfaces;
using DR.DataAccess;
using System;
using System.Configuration;

namespace DR.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IRequester requester = new Requester();
            var baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            var numDefaultArticles = int.Parse(ConfigurationManager.AppSettings["numDefaultArticles"]);
            var editorialKey = ConfigurationManager.AppSettings["editorialKey"];


            System.Console.WriteLine("Begin request for latest articles");
            System.Console.WriteLine();

            try
            {
                var latestArticles = requester.GetLatestArticles(baseUrl, numDefaultArticles);
                latestArticles.ForEach(a => System.Console.WriteLine(a.Title));
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error detected calling DR latest article service: {ex.Message}";
                System.Console.WriteLine(errorMessage);
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Press a key...");
            System.Console.ReadKey();

            System.Console.WriteLine();
            System.Console.WriteLine("Begin request for editorial sites");
            System.Console.WriteLine();

            try
            {
                var editorialSites = requester.GetEditorialSites(baseUrl, editorialKey);
                foreach (var site in editorialSites)
                {
                    var text = site.Title ?? site.Name ?? "data mangler";
                    System.Console.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error detected calling DR editorial sites service: {ex.Message}";
                System.Console.WriteLine(errorMessage);
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Press a key...");
            System.Console.ReadKey();
        }
    }
}
