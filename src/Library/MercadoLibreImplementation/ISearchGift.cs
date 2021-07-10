using System.Collections.Generic;
using System;
using LibraryAPI;
using PII_MLApi;
using System.Linq;

namespace Library
{
    public interface ISearchGift
    {
        void FindGift(long requestId);

        List<MLApiSearchResult> Results { get; }
        List<MLApiSearchResult> ResultsFiltered { get; }
    }
}