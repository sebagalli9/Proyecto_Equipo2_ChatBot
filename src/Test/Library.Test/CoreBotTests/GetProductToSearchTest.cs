using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class GetProductToSearchTest
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
        private GetProductToSearchStateHandler getProductToSearchStateHandler;

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
            getProductToSearchStateHandler = new GetProductToSearchStateHandler();
        }

        [Test]
        public void GetProductToSearchCheck()
        //Se prueba que se obtengan los productos a partir de las respuestas a las preguntas especificas
        {
            //Act
            Request request = new Request("mixed",1);
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
            request.UpdateCurrentState("product");
            getProductToSearchStateHandler.Handle(request, reader, user, input, output, findG, storage);

            //Assert
            Assert.AreEqual(6, user.ProductSearcherKeyWords.Count);
        }
    }
}