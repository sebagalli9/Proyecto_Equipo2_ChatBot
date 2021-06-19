using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class CoreBotTest
    {

        private IReader reader;
        private IPersonProfile user;
        private IInputReceiver input;
        private CoreBot coreBot;

        [SetUp]
        public void Setup()
        {
            reader = new FileReader();
            user = new PersonProfile();
        }

        [Test]
        public void AskInitialQuestionsTest()
        //Se prueba que el metodo AskInitialQuestions actualice las preferencias del perfil del usuario
        {
            //Arrange
            input = new FakeAnswerReceiver("1");
            coreBot = new CoreBot(reader,user,input);
            //Act
            reader.ReadInitialQuestions("../../../../../../Assets/InitialQuestions.txt");
            coreBot.AskInitialQuestions();
            //Assert
            Assert.AreEqual(5, user.Preferences.Count);
        }

        [Test]
        public void AskMainCategoriesTest()
        //Se prueba que el metodo AskMainCategories actualice las categorias seleccionadas del perfil del usuario
        {
            //Arrange
            input = new FakeAnswerReceiver("1");
            coreBot = new CoreBot(reader,user,input);
            //Act
            reader.ReadMainCategories("../../../../../../Assets/MainCategories.txt");
            coreBot.AskMainCategories();
            //Assert
            Assert.AreEqual(2, user.SelectedCategory.Count);
        } 

        [Test]
        public void GetMixedQuestionsTest()
        {
            //Arrange
            input = new FakeAnswerReceiver("1");
            coreBot = new CoreBot(reader,user,input);
            //Act
            reader.ReadMixedCategories("../../../../../../Assets/MixedQuestions.txt");
            user.UpdateSelectedCategory("home");
            user.UpdateSelectedCategory("technology");
            coreBot.GetMixedCategoryQuestion();
            //Assert
            Assert.AreEqual(5, coreBot.MixedCategoriesSelected.Count);
        } 
        [Test]
        public void AskMixedQuestionsTest()
        {
            //Arrange
            input = new FakeAnswerReceiver("si");
            coreBot = new CoreBot(reader,user,input);
            //Act
            reader.ReadMixedCategories("../../../../../../Assets/MixedQuestions.txt");
            user.UpdateSelectedCategory("home");
            user.UpdateSelectedCategory("technology");
            coreBot.GetMixedCategoryQuestion();
            coreBot.AskMixedQuestions();
            //Assert
            Assert.AreEqual(5,coreBot.AnswersMixedQuestions.Count);
        } 
    }
}