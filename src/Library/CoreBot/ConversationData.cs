using System;
using System.Collections.Generic;

namespace Library
{
    public class ConversationData
    {
        public List<MixedCategory> MixedCategoriesSelected { get; private set; }
        public List<SpecificCategory> SpecificCategoriesSelected { get; private set; }
        public List<String> SubCategory { get; private set; }
        public Dictionary<string, string> AnswersMainCategories { get; private set; }
        public Dictionary<string, string> AnswersMixedQuestions { get; private set; }
        public Dictionary<string, string> AnswersSpecificQuestions { get; private set; }

        public bool AskInitialCompleted {get;private set;}
        public bool AskMainCompleted {get; private set;}
        public bool AskMixedCompleted {get;private set;}
        public bool AskSpecificCompleted {get; private set;}
        public bool GetMixedCompleted {get; private set;}
        public bool GetSpecificCompleted {get; private set;}
        public bool GetProductCompleted {get; private set;}

        public ConversationData()
        {
            this.MixedCategoriesSelected = new List<MixedCategory>();
            this.SpecificCategoriesSelected = new List<SpecificCategory>();
            this.SubCategory = new List<string>();
            this.AnswersMainCategories = new Dictionary<string, string>();
            this.AnswersMixedQuestions = new Dictionary<string, string>();
            this.AnswersSpecificQuestions = new Dictionary<string, string>();
            this.AskInitialCompleted = false;
            this.AskMainCompleted = false;     
            this.AskMixedCompleted = false;
            this.GetMixedCompleted = false;
            this.AskSpecificCompleted = false;
            this.GetSpecificCompleted = false;
            this.GetProductCompleted = false;
        }

        private void CleanLists()
        {
            MixedCategoriesSelected.Clear();
            SpecificCategoriesSelected.Clear();
            SubCategory.Clear();
            AnswersMainCategories.Clear();
            AnswersMixedQuestions.Clear();
            AnswersSpecificQuestions.Clear();
        }

        public void UpdateAskInitialCompleted(bool b) {this.AskInitialCompleted = b;}
        public void UpdateAskMainCompleted(bool b) {this.AskMainCompleted = b;}
        public void UpdateAskMixedCompleted(bool b) {this.AskMixedCompleted = b;}
        public void UpdateAskSpecificCompleted(bool b) {this.AskSpecificCompleted = b;}
        public void UpdateGetMixedCompleted(bool b) {this.GetMixedCompleted = b;}
        public void UpdateGetSpecificCompleted(bool b) {this.GetSpecificCompleted = b;}
        public void UpdateGetProductCompleted(bool b) {this.GetProductCompleted = b;}

    }
}