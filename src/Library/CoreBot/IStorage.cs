using System;
using System.Collections.Generic;

namespace Library
{
    public interface IStorage
    {
        List<MixedCategory> MixedCategoriesSelected { get; }
        List<SpecificCategory> SpecificCategoriesSelected { get; }
        List<String> SubCategory { get; }
        Dictionary<string, string> AnswersMainCategories { get; }
        Dictionary<string, string> AnswersMixedQuestions { get; }
        Dictionary<string, string> AnswersSpecificQuestions { get; }

        void UpdateAskInitialCompleted(bool b);
        void UpdateAskMainCompleted(bool b);
        void UpdateAskMixedCompleted(bool b);
        void UpdateAskSpecificCompleted(bool b);
        void UpdateGetMixedCompleted(bool b);
        void UpdateGetSpecificCompleted(bool b);
        void UpdateGetProductCompleted(bool b);

        bool AskInitialCompleted { get; }
        bool AskMainCompleted { get; }
        bool AskMixedCompleted { get; }
        bool AskSpecificCompleted { get; }
        bool GetMixedCompleted { get; }
        bool GetSpecificCompleted { get; }
        bool GetProductCompleted { get; }
    }
}