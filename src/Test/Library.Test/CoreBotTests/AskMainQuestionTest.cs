using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class AskMainQuestionTest
    {
        private IReader reader;
        private IPersonProfile user;
        private IMessageReceiver input;
        private IMessageSender output;
        private ISearchGift findG;

        private ConversationData storage;

        private IStateHandler askMainQuestionStateHandler;

        [SetUp]
        public void Setup()
        {
            reader = new FileReader();
            user = new PersonProfile();
            input = new TestAnswerReceiver("1");
            output = new ConsolePrinter();
            findG = new SearchGiftML(user,output);
            storage = new ConversationData();
            askMainQuestionStateHandler = new AskMainQuestionStateHandler();
        }

        [Test]
        public void AskMainCategoryHandlerTest()
        //Se prueba que el metodo AskMainCategories actualice las categorias seleccionadas del perfil del usuario
        {
            //Act
            Request request = new Request("initial");
            reader.ReadMainCategories("../../../../../../Assets/MainCategories.txt");
            storage.UpdateAskInitialCompleted(true);
            askMainQuestionStateHandler.Handle(request,reader, user, input, output, findG, storage);
            //Assert
            Assert.AreEqual(2, user.SelectedCategory.Count);
        } 
    }
}