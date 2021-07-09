using System;
using System.Collections.Generic;

namespace Library
{
    //Esta clase antes se llamaba Session
    public class CoreBot
    {
        private static CoreBot instance;

        public static CoreBot Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new CoreBot();
                }
                return instance;
            }
        }

        private Dictionary<long, Request> userSessions = new Dictionary<long, Request>();
        public Dictionary<long, Request> UserSessions
        {
            get
            {
                return this.userSessions;
            }
            private set
            {
               this.userSessions = value; 
            }
        }

        public IReader Reader{get; private set;}
        public IStateHandler AskInitialQuestionStateHandler {get;private set;}
        private IStateHandler askMainCategoryStateHanlder;
        private IStateHandler getMixedCategoryStateHandler;
        private IStateHandler askMixedQuestionStateHanlder;
        private IStateHandler getSpecificCategoryStateHandler;
        private IStateHandler askSpecificCategoryStateHandler;
        private IStateHandler getProductToSearchStateHandler;
        private IStateHandler findGiftStateHandler;
        private IStateHandler noMixedAnswersStateHandler;
        IStateHandler noSpecificAnswersStateHandler;

        public void Awake()
        {
            //Inicializa el bot leyendo los archivos de texto y construyendo la cadena de responsabilidad
            Reader = new FileReader();
            Reader.UploadFiles();
            InitiateStateHandlers();
        }

        private void InitiateStateHandlers()
        {
            //Construye cadena de responsabilidad para manejar las fases de categorizacion para busqueda de regalo
            AskInitialQuestionStateHandler = new AskInitialQuestionStateHandler();
            askMainCategoryStateHanlder = new AskMainQuestionStateHandler();
            getMixedCategoryStateHandler = new GetMixedCategoryStateHandler();
            askMixedQuestionStateHanlder = new AskMixedQuestionStateHandler();
            getSpecificCategoryStateHandler = new GetSpecifiCategoryStateHandler();
            askSpecificCategoryStateHandler = new AskSpecificQuestionStateHandler();
            getProductToSearchStateHandler = new GetProductToSearchStateHandler();
            findGiftStateHandler = new FindGiftStateHandler();

            noMixedAnswersStateHandler = new NoMixedAnswersStateHandler();
            noSpecificAnswersStateHandler = new NoSpecificAnswersStateHandler();

            AskInitialQuestionStateHandler.SetNext(askMainCategoryStateHanlder);
            askMainCategoryStateHanlder.SetNext(getMixedCategoryStateHandler);
            getMixedCategoryStateHandler.SetNext(askMixedQuestionStateHanlder);
            askMixedQuestionStateHanlder.SetNext(getSpecificCategoryStateHandler);
            getSpecificCategoryStateHandler.SetNext(askSpecificCategoryStateHandler);
            askSpecificCategoryStateHandler.SetNext(getProductToSearchStateHandler);
            getProductToSearchStateHandler.SetNext(findGiftStateHandler);

            //Implementación para casos en los que la respuesta a las respuestas mixtas y especificas sean todas que "no"
            noMixedAnswersStateHandler.SetNext(askMixedQuestionStateHanlder);
            noSpecificAnswersStateHandler.SetNext(askSpecificCategoryStateHandler);

            getSpecificCategoryStateHandler.SetPrevious(noMixedAnswersStateHandler);
            getProductToSearchStateHandler.SetPrevious(noSpecificAnswersStateHandler); 
        }

        public void AddUserSessions(long id, Request request)
        {
            //Console.WriteLine(id);
            userSessions.Add(id, request);
        }
    }
}