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
            coreBot = new CoreBot(reader,user,input);
        }

/*         [Test]
        public void AskInitialQuestionsTest()
        //Se prueba que el metodo AskInitialQuestions actualice las preferencias del perfil del usuario
        {
            //Act
            input = new FakeAnswerReceiver("1");
            reader.ReadInitialQuestions();
            coreBot.AskInitialQuestions();
            //Assert
            Assert.AreEqual(5, user.Preferences.Count);
        } */

   /*      [Test]
        public void AskMainCategoriesTest()
        //Se prueba que el metodo AskMainCategories actualice las categorias seleccionadas del perfil del usuario
        {
            //Act
            input = new FakeAnswerReceiver("1");
            reader.ReadMainCategories();
            coreBot.AskMainCategories();
            //Assert
            Assert.AreEqual(2, user.SelectedCategory.Count);
        } */


        /* [Test]
        public void AskMixedQuestionsTest()
        {
            //Act
            reader.ReadMainCategories();
            reader.ReadMixedCategories();
            input = new FakeAnswerReceiver("1");
            coreBot.AskMainCategories();
            input = new FakeAnswerReceiver("si");
            coreBot.AskMixedQuestions();
            //Assert
            Assert.AreEqual(6,coreBot.AnswersMixedQuestions.Count);
        } */

    }

}