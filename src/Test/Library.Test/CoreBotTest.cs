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
        //Se prueba que el metodo GetMixedQuestions obtenga las preguntas mixtas a preguntar a partir de las categorias Main seleccionadas
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
        //Se prueba que el metodo AskMixedQuestions almacene correctamente las respuestas dadas a las preguntas mixtas
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

        [Test]
        public void GetSpecificCategoryQuestionTest()
        //Se prueba que el metodo GetSpecificCategoryQuestion obtenga las preguntas especificas a preguntar a partir de las respuestas a las preguntas mixtas
        {
            //Arrange
            input = new FakeAnswerReceiver("si");
            coreBot = new CoreBot(reader,user,input);
            //Act
            reader.ReadMixedCategories("../../../../../../Assets/MixedQuestions.txt");
            reader.ReadSpecificCategories("../../../../../../Assets/SpecificQuestions.txt");
            user.UpdateSelectedCategory("home");
            user.UpdateSelectedCategory("technology");
            coreBot.GetMixedCategoryQuestion();
            coreBot.AskMixedQuestions();
            coreBot.GetSpecificCategoryQuestion();
            //Assert
            Assert.AreEqual(15,coreBot.SpecificCategoriesSelected.Count);
        }

        [Test]
        public void AskSpecificQuestionsTest()
        //Se prueba que el metodo AskSpecificQuestions almacene correctamente las respuestas dadas a las preguntas mixtas
        {
            //Arrange
            input = new FakeAnswerReceiver("si");
            coreBot = new CoreBot(reader,user,input);
            //Act
            reader.ReadMixedCategories("../../../../../../Assets/MixedQuestions.txt");
            reader.ReadSpecificCategories("../../../../../../Assets/SpecificQuestions.txt");
            user.UpdateSelectedCategory("home");
            user.UpdateSelectedCategory("technology");
            coreBot.GetMixedCategoryQuestion();
            coreBot.AskMixedQuestions();
            coreBot.GetSpecificCategoryQuestion();
            coreBot.AskSpecificQuestions();
            //Assert
            Assert.AreEqual(15,coreBot.AnswersSpecificQuestions.Count);
        }

        [Test]
        public void GetProcutToSearchTest()
        //Se prueba que el metodo GetProductToSearch obtenga correctamente productos a buscar
        {
            //Arrange
            input = new FakeAnswerReceiver("si");
            coreBot = new CoreBot(reader,user,input);
            //Act
            reader.ReadMixedCategories("../../../../../../Assets/MixedQuestions.txt");
            reader.ReadSpecificCategories("../../../../../../Assets/SpecificQuestions.txt");
            user.UpdateSelectedCategory("home");
            user.UpdateSelectedCategory("technology");
            coreBot.GetMixedCategoryQuestion();
            coreBot.AskMixedQuestions();
            coreBot.GetSpecificCategoryQuestion();
            coreBot.AskSpecificQuestions();
            coreBot.GetProductToSearch();
            //Assert
            Assert.AreEqual(15,user.ProductSearcherKeyWords.Count);
        }

        [Test]
        public void MixedCategoriesSelectedMustBeAMixedCategoryList()
        //Se prueba que la lista MixedCategoriesSelected sea una lista de objetos de tipo MixedCategory
        {
            //Arrange
            input = new FakeAnswerReceiver("si");
            coreBot = new CoreBot(reader,user,input);
            //Assert
            Assert.IsInstanceOf(typeof(List<MixedCategory>), coreBot.MixedCategoriesSelected);
        }

        [Test]
        public void SpecificCategoriesSelectedMustBeASpecificCategoryList()
        //Se prueba que la lista SpecificCategoriesSelected sea una lista de objetos de tipo SpecificCategory
        {
            //Arrange
            input = new FakeAnswerReceiver("si");
            coreBot = new CoreBot(reader,user,input);
            //Assert
            Assert.IsInstanceOf(typeof(List<SpecificCategory>), coreBot.SpecificCategoriesSelected);
        }

        [Test]
        public void SubCategoryMustBeStringList()
        //Se prueba que la lista SubCategory sea una lista de strings
        {
            //Arrange
            input = new FakeAnswerReceiver("si");
            coreBot = new CoreBot(reader,user,input);
            //Assert
            Assert.IsInstanceOf(typeof(List<string>), coreBot.SubCategory);
        }

        [Test]
        public void AnswersMainCategoriesMustBeAStringDictionary()
        //Se prueba que el diccionario AnswersMainCategories sea un diccionario de tipo <strings,string>
        {
            //Arrange
            input = new FakeAnswerReceiver("si");
            coreBot = new CoreBot(reader,user,input);
            //Assert
            Assert.IsInstanceOf(typeof(Dictionary<string, string>), coreBot.AnswersMainCategories);
        }

        [Test]
        public void AnswersMixedQuestionsMustBeAStringDictionary()
        //Se prueba que el diccionario AnswersMixedQuestions sea un diccionario de tipo <strings,string>
        {
            //Arrange
            input = new FakeAnswerReceiver("si");
            coreBot = new CoreBot(reader,user,input);
            //Assert
            Assert.IsInstanceOf(typeof(Dictionary<string, string>), coreBot.AnswersMixedQuestions);
        }

        [Test]
        public void AnswersSpecificQuestionsMustBeAStringDictionary()
        //Se prueba que el diccionario AnswersSpecificQuestions sea un diccionario de tipo <strings,string>
        {
            //Arrange
            input = new FakeAnswerReceiver("si");
            coreBot = new CoreBot(reader,user,input);
            //Assert
            Assert.IsInstanceOf(typeof(Dictionary<string, string>), coreBot.AnswersSpecificQuestions);
        }

    }
}