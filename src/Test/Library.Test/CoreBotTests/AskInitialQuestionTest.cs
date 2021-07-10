using NUnit.Framework;
using Library;
using System.Collections.Generic;
using System;

namespace Test.Library
{
    public class AskInitialQuestionTest
    {
        private IPersonProfile user;
        private IMessageReceiver input;
        private IMessageSender output;
        private ISearchGift findG;

        private IStorage storage;

        private IStateHandler askInitialQuestionStateHandler;

        [SetUp]
        public void Setup()
        {
            user = new PersonProfile();
            input = new TestAnswerReceiver("1");
            output = new ConsolePrinter();
            findG = new SearchGiftML(user, output);
            storage = new ConversationData();
            askInitialQuestionStateHandler = new AskInitialQuestionStateHandler();
        }

        [Test]
        public void AskInitialQuestionHandlerTest()
        //Se prueba que luego de la fase de preguntas iniciales se actualice las preferencias del perfil del usuario
        {
            //Act
            Request request = new Request("initial",1);
            CoreBot.Instance.Reader.ReadInitialQuestions("../../../../../../Assets/InitialQuestions.txt");
            askInitialQuestionStateHandler.Handle(request, user, input, output, findG, storage);
            //Assert
            Assert.AreEqual(4, user.Preferences.Count);
        }
    }
}