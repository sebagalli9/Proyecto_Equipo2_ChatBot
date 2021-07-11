using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class AskMainQuestionTest
    {
        private IPersonProfile user;
        private IMessageReceiver input;
        private IMessageSender output;
        private ISearchGift findG;

        private IStorage storage;

        private IStateHandler askMainQuestionStateHandler;

        [SetUp]
        public void Setup()
        {
            user = new PersonProfile();
            input = new TestAnswerReceiver("1");
            output = new ConsolePrinter();
            findG = new SearchGiftML(user, output);
            storage = new ConversationData();
            askMainQuestionStateHandler = new AskMainQuestionStateHandler();
        }

        [Test]
        public void AskMainCategoryHandlerTest()
        //Se prueba que se actualice las categorias seleccionadas del perfil del usuario
        {
            //Act
            IRequest request = new Request("main",1);
            CoreBot.Instance.Reader.ReadMainCategories("../../../../../../Assets/MainCategories.txt");
            storage.UpdateAskInitialCompleted(true);
            askMainQuestionStateHandler.Handle(request, user, input, output, findG, storage);
            //Assert
            Assert.AreEqual(2, user.SelectedCategory.Count);
        }
    }
}