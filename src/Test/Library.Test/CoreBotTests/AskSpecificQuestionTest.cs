using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class AskSpecificQuestionTest
    {
        private IReader reader;
        private IPersonProfile user;
        private IMessageReceiver input;
        private IMessageSender output;
        private ISearchGift findG;

        private ConversationData storage;
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
            findG = new SearchGiftML(user);
            storage = new ConversationData();
            getSpecificCategoryStateHandler = new GetSpecifiCategoryStateHandler();
            getMixedCategoryStateHandler = new GetMixedCategoryStateHandler();
            askMixedQuestionStateHandler = new AskMixedQuestionStateHandler();
            askSpecificQuestionStateHandler = new AskSpecificQuestionStateHandler();
        }

        [Test]
        public void AskSpecificQuestionHandlerTest()
        //Se prueba que el metodo GetSpecificCategoryQuestion obtenga las preguntas especificas a preguntar a partir de las respuestas a las preguntas mixtas
        {
            //Act
            reader.ReadMixedCategories("../../../../../../Assets/MixedQuestions.txt");
            reader.ReadSpecificCategories("../../../../../../Assets/SpecificQuestions.txt");
            storage.UpdateAskMainCompleted(true);
            user.UpdateSelectedCategory("home");
            user.UpdateSelectedCategory("technology");
            getMixedCategoryStateHandler.Handle(reader, user, input, output, findG, storage);
            askMixedQuestionStateHandler.Handle(reader, user, input, output, findG, storage);
            getSpecificCategoryStateHandler.Handle(reader, user, input, output, findG, storage);
            askSpecificQuestionStateHandler.Handle(reader, user, input, output, findG, storage);

            //Assert
            Assert.AreEqual(19, storage.AnswersSpecificQuestions.Count);
        }
    }
}