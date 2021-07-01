using System.Collections.Generic;
using System;
using LibraryAPI;
using PII_MLApi;

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
                results.ForEach(r => Console.WriteLine(r));
            }
            
        }
    }
}