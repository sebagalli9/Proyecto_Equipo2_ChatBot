using System.Collections.Generic;
namespace PII_MLApi
{
    /// <summary>
    /// Representa un resultado de la búsqueda.
    /// </summary>
    public class MLApiSearchResult
    {
        internal MLApiSearchResult(string title, string price, string currency, string imageURL, string resultURL)
        {
            this.Title = title;
            this.Price = price;
            this.Currency = currency;
            this.ImageURL = imageURL;
            this.ResultURL = resultURL;
        }
        
        /// <value>Título del item.</value>
        public string Title { get; private set; }

        /// <value>Precio del item.</value>
        public string Price { get; private set; }

        /// <value>Símbolo de la moneda en que se expresa el precio del item.</value>
        public string Currency { get; private set;}

        /// <value>URL de la imágen del item.</value>
        public string ImageURL { get; private set; }

        /// <value>URL del item en ML.</value>
        public string ResultURL { get; private set; }

        public override string ToString()
        {
            return $"\n-----------------------------\nTitle: {Title}\nPrice: {Price}\nCurrency: {Currency}\nImageUrl: {ImageURL}\nUrl: {ResultURL}";
        }
    }
}