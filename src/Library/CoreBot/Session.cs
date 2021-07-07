using System;
using System.Collections.Generic;

namespace Library
{
    public class Session
    {
        private static Session instance;

        public static Session Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }

        public static Dictionary<long, Request> userSessions = new Dictionary<long, Request>();
        public static IReader reader;
        public static IStateHandler askInitialQuestionStateHandler;
        IStateHandler askMainCategoryStateHanlder;
        IStateHandler getMixedCategoryStateHandler;
        IStateHandler askMixedQuestionStateHanlder;
        IStateHandler getSpecificCategoryStateHandler;
        IStateHandler askSpecificCategoryStateHandler;
        IStateHandler getProductToSearchStateHandler;
        IStateHandler findGiftStateHandler;
        IStateHandler noMixedAnswersStateHandler;
        IStateHandler noSpecificAnswersStateHandler;

        public void Awake()
        {
            reader = new FileReader();
            reader.UploadFiles();
            InitiateStateHandlers();
        }

        private void InitiateStateHandlers()
        {
            askInitialQuestionStateHandler = new AskInitialQuestionStateHandler();
            askMainCategoryStateHanlder = new AskMainQuestionStateHandler();
            getMixedCategoryStateHandler = new GetMixedCategoryStateHandler();
            askMixedQuestionStateHanlder = new AskMixedQuestionStateHandler();
            getSpecificCategoryStateHandler = new GetSpecifiCategoryStateHandler();
            askSpecificCategoryStateHandler = new AskSpecificQuestionStateHandler();
            getProductToSearchStateHandler = new GetProductToSearchStateHandler();
            findGiftStateHandler = new FindGiftStateHandler();

            noMixedAnswersStateHandler = new NoMixedAnswersStateHandler();
            noSpecificAnswersStateHandler = new NoSpecificAnswersStateHandler();

            askInitialQuestionStateHandler.SetNext(askMainCategoryStateHanlder);
            askMainCategoryStateHanlder.SetNext(getMixedCategoryStateHandler);
            getMixedCategoryStateHandler.SetNext(askMixedQuestionStateHanlder);
            askMixedQuestionStateHanlder.SetNext(getSpecificCategoryStateHandler);
            getSpecificCategoryStateHandler.SetNext(askSpecificCategoryStateHandler);
            askSpecificCategoryStateHandler.SetNext(getProductToSearchStateHandler);
            getProductToSearchStateHandler.SetNext(findGiftStateHandler);

            
            noMixedAnswersStateHandler.SetNext(askMixedQuestionStateHanlder);
            noSpecificAnswersStateHandler.SetNext(askSpecificCategoryStateHandler);

            getSpecificCategoryStateHandler.SetPrevious(noMixedAnswersStateHandler);
            getProductToSearchStateHandler.SetPrevious(noSpecificAnswersStateHandler); 
        }
    }
}