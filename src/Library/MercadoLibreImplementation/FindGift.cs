using System.Collections.Generic;
using System;
using LibraryAPI;
using PII_MLApi;
using System.Linq;

namespace Library
{
    public class FindGift
    {
        public void SearchGiftML()
        {   
            foreach (string prod in PersonProfile.Instance.ProductSearcherKeyWords)
            {
                string search = "";
                foreach(string pref in PersonProfile.Instance.Preferences)
                {
                    search += prod.Replace(" ", "-") + pref;
                }
                
                List<MLApiSearchResult> results = new MLApi().Search(search);

                CurrencyChanger currencyChanger = new CurrencyChanger();
            
                List<MLApiSearchResult> resultsFiltered = new List<MLApiSearchResult>();

                resultsFiltered = results.Where(x=>Convert.ToDouble(x.Price)<=Convert.ToDouble(PersonProfile.Instance.PricePreferences[0])).ToList();
                resultsFiltered.ForEach(r => Console.WriteLine(r));
            }
            
        }
    }
}