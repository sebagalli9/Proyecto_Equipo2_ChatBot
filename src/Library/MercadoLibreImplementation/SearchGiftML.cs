using System.Collections.Generic;
using System;
using LibraryAPI;
using PII_MLApi;
using System.Linq;

namespace Library
{
    public class SearchGiftML : ISearchGift
    {
        IPersonProfile user;

        public SearchGiftML(IPersonProfile user)
        {
            this.user = user;
        }
        public void FindGift()
        {   
            List<MLApiSearchResult> resultsFiltered = new List<MLApiSearchResult>();
            string prefs = "";

            foreach(string pref in user.Preferences)
            {
                prefs += (pref + "-");
            }
            
            foreach (string prod in user.ProductSearcherKeyWords)
            {
                string search = "";
               
                List<MLApiSearchResult> results = new MLApi().Search((search + prod + "-" + prefs).Replace(" ", "-"));

                CurrencyChanger currencyChanger = new CurrencyChanger();

                for(int i = 0; i < 2; i++)
                {
                    resultsFiltered.Add(results[i]);
                }
            }
                resultsFiltered.ForEach(r => Console.WriteLine(r)); 

        }
    }
}