using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class GetMixedCategoryTest
    {
        private IReader reader;
        private IPersonProfile user;
        private IMessageReceiver input;
        private IMessageSender output;
        private ISearchGift findG;

        private ConversationData storage;

        private IStateHandler getMixedCategoryStateHandler;

        [SetUp]
        public void Setup()
        {
            reader = new FileReader();
            user = new PersonProfile();
            input = new TestAnswerReceiver("1");
            output = new ConsolePrinter();
            findG = new SearchGiftML(user,output);
            storage = new ConversationData();
            getMixedCategoryStateHandler = new GetMixedCategoryStateHandler();
        }

        [Test]
        public void GetMixedCategoryHandleTest()
        //Se prueba que el metodo GetMixedQuestions obtenga las preguntas mixtas a preguntar a partir de las categorias Main seleccionadas
        {
            //Act
            reader.ReadMixedCategories("../../../../../../Assets/MixedQuestions.txt");
            storage.UpdateAskMainCompleted(true);
            user.UpdateSelectedCategory("home");
            user.UpdateSelectedCategory("technology");
            getMixedCategoryStateHandler.Handle(reader, user, input, output, findG, storage);
            //Assert
            Assert.AreEqual(6, storage.MixedCategoriesSelected.Count);
        } 
    }
}