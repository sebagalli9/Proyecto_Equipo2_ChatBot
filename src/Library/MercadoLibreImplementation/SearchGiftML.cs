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
        IMessageSender output;

        public SearchGiftML(IPersonProfile user, IMessageSender output)
        {
            this.user = user;
            this.output = output;
        }
        public void FindGift()
        {   
            output.SendMessage("Buscando regalos...");

            List<MLApiSearchResult> resultsFiltered = new List<MLApiSearchResult>();
            string prefs = "";

            foreach(string pref in user.Preferences)
            {
                prefs += (pref + "-");
            }
            
            foreach (string prod in user.ProductSearcherKeyWords)
            {
                string search = prod;

                //Console.WriteLine(search);
               
                List<MLApiSearchResult> results = new MLApi().Search((search).Replace(" ", "-"));

                for(int i = 0; i < 2; i++)
                {
                    resultsFiltered.Add(results[i]);
                }
            }
                resultsFiltered.ForEach(r => output.SendMessage(r.ToString())); 

        }
    }
}