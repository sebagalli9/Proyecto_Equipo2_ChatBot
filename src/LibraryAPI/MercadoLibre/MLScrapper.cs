using System;
using System.Collections.Generic;
using AngleSharp;
using AngleSharp.Dom;
using System.Threading.Tasks;

namespace PII_MLApi
{
    /// <summary>
    /// Ejecuta una búsqueda en ML de Uruguay y parsea el HTML
    /// de respuesta para construir la lista de resultados.
    /// </summary>
    internal class MLScrapper
    {
        private string url;

        internal MLScrapper(string query)
        {
            this.url = $"https://listado.mercadolibre.com.uy/{query}";
        }

        /// <summary>
        /// Ejecuta la búsqueda y retorna los resultados.
        /// </summary>
        /// <returns>Lista de objetos resultado.</returns>
        public virtual async Task<List<MLApiSearchResult>> Scrape()
        {
            //var config = Configuration.Default.WithDefaultLoader();
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(this.url);
            return Parse(document);
        }

        /// <summary>
        /// Parsea el HTML de respuesta para construir la lista de objetos
        /// resultado.
        /// </summary>
        /// <param name="document">El HTML de respuesta de ML.</param>
        /// <returns>Lista de objetos resultado.</returns>
        protected virtual List<MLApiSearchResult> Parse(IDocument document)
        {
            List<MLApiSearchResult> results = new List<MLApiSearchResult>();
            foreach (var item in document.QuerySelectorAll(".ui-search-results li.ui-search-layout__item"))
            {
                try
                {
                    string title = item.QuerySelector("h2.ui-search-item__title").InnerHtml.Trim();
                    string price = item.QuerySelector("span.price-tag-fraction").InnerHtml.Trim();
                    string currency = item.QuerySelector("span.price-tag-symbol").InnerHtml.Trim();
                    string itemURL;
                    string imageURL;

                    IElement itemLink = item.QuerySelector(".ui-search-result__image > a");
                    if (itemLink == null)
                    {
                        itemLink = item.QuerySelector(".ui-search-link");
                    }
                    itemURL = itemLink.GetAttribute("href").Trim();

                    IElement image = item.QuerySelector(".slick-slide.slick-active > img");
                
                    if (!String.IsNullOrEmpty(image.GetAttribute("data-src")))
                    {
                        imageURL = image.GetAttribute("data-src").Trim();
                        
                    }
                    else
                    {
                        imageURL = image.GetAttribute("src").Trim();
                        
                    }

                    results.Add(new MLApiSearchResult(title, price, currency, imageURL, itemURL));
                }
                catch (NullReferenceException) { }
            }

            return results;
        }

    }
}