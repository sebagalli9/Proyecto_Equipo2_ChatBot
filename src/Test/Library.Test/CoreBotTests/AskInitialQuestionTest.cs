using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class AskInitialQuestionTest
    {
        private IReader reader;
        private IPersonProfile user;
        private IMessageReceiver input;
        private IMessageSender output;
        private ISearchGift findG;

        private ConversationData storage;

        private IStateHandler askInitialQuestionStateHandler;

        [SetUp]
        public void Setup()
        {
            reader = new FileReader();
            user = new PersonProfile();
            input = new TestAnswerReceiver("1");
            output = new ConsolePrinter();
            findG = new SearchGiftML(user);
            storage = new ConversationData();
            askInitialQuestionStateHandler = new AskInitialQuestionStateHandler();
        }

        [Test]
        public void AskInitialQuestionHandlerTest()
        //Se prueba que el metodo AskInitialQuestions actualice las preferencias del perfil del usuario
        {
            //Act
            reader.ReadInitialQuestions("../../../../../../Assets/InitialQuestions.txt");
            askInitialQuestionStateHandler.Handle(reader, user, input, output, findG, storage);
            //Assert
            Assert.AreEqual(4, user.Preferences.Count);
        }
    }
}