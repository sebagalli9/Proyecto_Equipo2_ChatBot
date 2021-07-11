using System;
using System.Collections.Generic;

namespace Library
{
    /*
        DIP: La clase CoreBot cumple con el principio DIP, ya que depende únicamente 
        de abstracciones, por lo que el código es flexible y no rígido.

        EXPERT: Al ser la clase experta en conocer los StateHandlers, es su responsabilidad
        crear la cadena de responsabilidad.

        CHAIN OF RESPONSIBILITY: En esta clase se aplica el patrón Chain of Responsibility 
        para que varios objetos gestionen las diferentes fases de preguntas y así favorecer 
        la extensibilidad.

        OCP: También cumple con el principio OCP, ya que la clase se encuentra abierta 
        a extensión, debido a que si se desearan agregar más funcionalidades a manejar, 
        simplemente habría que agregar más handlers.

        SRP: La clase no cumple con el principio SRP ya que no tiene una única razón de cambio,
        las cuales pueden ser:  
        -Modificar las preparaciones previas a que se inicie el bot (Awake() es el método 
        que se llama en Program).
        -Modificar el modo en que se almacenan elementos en el diccionario userSessions

        SINGLETON: En esta clase se aplica el patrón Singleton con el fin de que la creación 
        de la cadena de responsabilidad y la lectura de archivos se haga una única vez para una 
        mejor optimización de los recursos del bot.

    */
    
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

        private Dictionary<long, IRequest> userSessions = new Dictionary<long, IRequest>();
        public Dictionary<long, IRequest> UserSessions
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

        private IReader reader = new FileReader();
        public IReader Reader
        {
            get
            {
                return this.reader;
            }
            private set	
            {
                this.reader = value;
            }
        }
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

        public void AddUserSessions(long id, IRequest request)
        {   
            userSessions.Add(id, request);
        }
    }
}