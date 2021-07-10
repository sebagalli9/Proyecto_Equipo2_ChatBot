using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class AskMixedQuestionTest
    {
        private IPersonProfile user;
        private IMessageReceiver input;
        private IMessageSender output;
        private ISearchGift findG;

        private IStorage storage;

        private IStateHandler askMixedQuestionStateHandler;

        private IStateHandler getMixedCategoryStateHandler;

        [SetUp]
        public void Setup()
        {
            user = new PersonProfile();
            input = new TestAnswerReceiver("1");
            output = new ConsolePrinter();
            findG = new SearchGiftML(user, output);
            storage = new ConversationData();
            askMixedQuestionStateHandler = new AskMixedQuestionStateHandler();
            getMixedCategoryStateHandler = new GetMixedCategoryStateHandler();
        }

        [Test]
        public void AskMixedQuestionHandlerTest()
        //Se prueba que se almacene correctamente las respuestas dadas a las preguntas mixtas
        {
            //Act
            Request request = new Request("mixed",1);
            CoreBot.Instance.Reader.ReadMixedCategories("../../../../../../Assets/MixedQuestions.txt");
            storage.UpdateAskMainCompleted(true);
            user.UpdateSelectedCategory("home");
            user.UpdateSelectedCategory("technology");
            getMixedCategoryStateHandler.Handle(request, user, input, output, findG, storage);
            askMixedQuestionStateHandler.Handle(request, user, input, output, findG, storage);
            //Assert
            Assert.AreEqual(6, storage.AnswersMixedQuestions.Count);
        }
    }
}