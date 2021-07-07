using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    //ESTOS TESTS FALLAN
    public class AskSpecificQuestionTest
    {
        private IReader reader;
        private IPersonProfile user;
        private IMessageReceiver input;
        private IMessageSender output;
        private ISearchGift findG;

        private IStorage storage;
        private IStateHandler getSpecificCategoryStateHandler;

        private IStateHandler getMixedCategoryStateHandler;

        private IStateHandler askMixedQuestionStateHandler;

        private IStateHandler askSpecificQuestionStateHandler;

        [SetUp]
        public void Setup()
        {

            reader = new FileReader();
            user = new PersonProfile();
            input = new TestAnswerReceiver("1");
            output = new ConsolePrinter();
            findG = new SearchGiftML(user, output);
            storage = new ConversationData();
            getSpecificCategoryStateHandler = new GetSpecifiCategoryStateHandler();
            getMixedCategoryStateHandler = new GetMixedCategoryStateHandler();
            askMixedQuestionStateHandler = new AskMixedQuestionStateHandler();
            askSpecificQuestionStateHandler = new AskSpecificQuestionStateHandler();
        }

        [Test]
        public void AskSpecificQuestionHandlerTest()
        //Se prueba que se obtenga las preguntas especificas a preguntar a partir de las respuestas a las preguntas mixtas
        {
            //Act
            Request request = new Request("mixed");
            reader.ReadMixedCategories("../../../../../../Assets/MixedQuestions.txt");
            reader.ReadSpecificCategories("../../../../../../Assets/SpecificQuestions.txt");
            storage.UpdateAskMainCompleted(true);
            user.UpdateSelectedCategory("home");
            user.UpdateSelectedCategory("technology");
            getMixedCategoryStateHandler.Handle(request, reader, user, input, output, findG, storage);
            askMixedQuestionStateHandler.Handle(request, reader, user, input, output, findG, storage);
            request.UpdateCurrentState("specific");
            getSpecificCategoryStateHandler.Handle(request, reader, user, input, output, findG, storage);
            askSpecificQuestionStateHandler.Handle(request, reader, user, input, output, findG, storage);

            //Assert
            Assert.AreEqual(10, storage.AnswersSpecificQuestions.Count);
        }
    }
}