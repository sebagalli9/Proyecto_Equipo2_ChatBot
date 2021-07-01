using System.Threading.Tasks;
using System.Collections.Generic;

namespace PII_MLApi
{
    /// <summary>
    /// Punto de entrada principal de la biblioteca.
    /// Permite realizar una consula de listado a Mercado Libre Uruguay.
    /// </summary>
    /// <example>
    /// <code>
    /// List<MLApiSearchResult> results = new MLApi().Search("lentes de sol");
    /// results.ForEach(r => Console.WriteLine(r));
    /// </code>
    /// </example>
    public class MLApi
    {
        /// <summary>
        /// Realiza una búsqueda en ML de Uruguay y retorna una lista con
        /// los resultados.
        /// 
        /// Para buscar se utiliza una (o más) palabra(s) clave. Por ejemplo, 
        /// "lentes de sol".
        /// </summary>
        /// <param name="query">Palabra(s) clave</param>
        /// <returns>Lista de resultados de la búsqueda</returns>
        public List<MLApiSearchResult> Search(string query)
        {
            var scraper = new MLScrapper(query);
            Task<List<MLApiSearchResult>> task = scraper.Scrape();
            task.Wait();
            return task.Result;
        }
    }
}
