using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class GetSpecificCategoryTest
    {
        private IPersonProfile user;
        private IMessageReceiver input;
        private IMessageSender output;
        private ISearchGift findG;

        private IStorage storage;
        private IStateHandler getSpecificCategoryStateHandler;

        private IStateHandler getMixedCategoryStateHandler;

        private IStateHandler askMixedQuestionStateHandler;

        [SetUp]
        public void Setup()
        {
            user = new PersonProfile();
            input = new TestAnswerReceiver("1");
            output = new ConsolePrinter();
            findG = new SearchGiftML(user, output);
            storage = new ConversationData();
            getSpecificCategoryStateHandler = new GetSpecifiCategoryStateHandler();
            getMixedCategoryStateHandler = new GetMixedCategoryStateHandler();
            askMixedQuestionStateHandler = new AskMixedQuestionStateHandler();
        }

        [Test]
        public void GetSpecificCategoryQuestionTest()
        //Se prueba que se obtenga las preguntas especificas a preguntar a partir de las respuestas a las preguntas mixtas
        {
            //Act
            IRequest request = new Request("mixed",1);
            CoreBot.Instance.Reader.ReadMixedCategories("../../../../../../Assets/MixedQuestions.txt");
            CoreBot.Instance.Reader.ReadSpecificCategories("../../../../../../Assets/SpecificQuestions.txt");
            storage.UpdateAskMainCompleted(true);
            user.UpdateSelectedCategory("home");
            user.UpdateSelectedCategory("technology");
            getMixedCategoryStateHandler.Handle(request, user, input, output, findG, storage);
            askMixedQuestionStateHandler.Handle(request, user, input, output, findG, storage);
            getSpecificCategoryStateHandler.Handle(request, user, input, output, findG, storage);
            //Assert
            Assert.AreEqual(10, storage.SpecificCategoriesSelected.Count);
        }
    }
}