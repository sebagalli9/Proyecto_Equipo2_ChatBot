using System.Collections.Generic;
using System;
using LibraryAPI;
using PII_MLApi;
using System.Linq;

namespace Library
{
    public class SearchGiftML : ISearchGift
    {
        private IPersonProfile user;
        private IMessageSender output;
        public List<MLApiSearchResult> Results {get; private set;}
        public List<MLApiSearchResult> ResultsFiltered {get; private set;}

        public SearchGiftML(IPersonProfile user, IMessageSender output)
        {
            this.user = user;
            this.output = output;
        }
        public void FindGift(long requestId)
        {   
            output.SendMessage("Buscando regalos...", requestId);

            ResultsFiltered = new List<MLApiSearchResult>();
            string prefs = "-";

            foreach(string pref in user.Preferences)
            {
                prefs += (pref + "-");
            }
            
            foreach (string prod in user.ProductSearcherKeyWords)
            {
                string search = prod + prefs;

                Console.WriteLine(search);
               
                Results = new MLApi().Search((search).Replace(" ", "-"));

                for(int i = 0; i < 2; i++)
                {
                    ResultsFiltered.Add(Results[i]);
                }
            }
                ResultsFiltered.ForEach(r => output.SendMessage(r.ToString(),requestId)); 

        }
    }
}