using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class ConversationDataTest
    {
        private IStorage storage;

        [SetUp]
        public void Setup()
        {
            storage = new ConversationData();
        }

        [Test]
        public void MixedCategoriesSelectedMustBeAMixedCategoryList()
        //Se prueba que la lista MixedCategoriesSelected sea una lista de objetos de tipo MixedCategory
        {
            //Assert
            Assert.IsInstanceOf(typeof(List<MixedCategory>), storage.MixedCategoriesSelected);
        }

        [Test]
        public void SpecificCategoriesSelectedMustBeASpecificCategoryList()
        //Se prueba que la lista SpecificCategoriesSelected sea una lista de objetos de tipo SpecificCategory
        {
            //Assert
            Assert.IsInstanceOf(typeof(List<SpecificCategory>), storage.SpecificCategoriesSelected);
        }

        [Test]
        public void SubCategoryMustBeStringList()
        //Se prueba que la lista SubCategory sea una lista de strings
        {
            //Assert
            Assert.IsInstanceOf(typeof(List<string>), storage.SubCategory);
        }

        [Test]
        public void AnswersMainCategoriesMustBeAStringDictionary()
        //Se prueba que el diccionario AnswersMainCategories sea un diccionario de tipo <strings,string>
        {
            //Assert
            Assert.IsInstanceOf(typeof(Dictionary<string, string>), storage.AnswersMainCategories);
        }

        [Test]
        public void AnswersMixedQuestionsMustBeAStringDictionary()
        //Se prueba que el diccionario AnswersMixedQuestions sea un diccionario de tipo <strings,string>
        {
            //Assert
            Assert.IsInstanceOf(typeof(Dictionary<string, string>), storage.AnswersMixedQuestions);
        }

        [Test]
        public void AnswersSpecificQuestionsMustBeAStringDictionary()
        //Se prueba que el diccionario AnswersSpecificQuestions sea un diccionario de tipo <strings,string>
        {
            //Assert
            Assert.IsInstanceOf(typeof(Dictionary<string, string>), storage.AnswersSpecificQuestions);
        }

        [Test]
        public void UpdateAskInitialCompletedTest()
        //Se prueba que el diccionario AnswersSpecificQuestions sea un diccionario de tipo <strings,string>
        {
            //Act
            storage.UpdateAskInitialCompleted(true);
            //Assert
            Assert.AreEqual(true, storage.AskInitialCompleted);
        }

        [Test]
        public void UpdateAskMainCompletedTest()
        //Se prueba que el diccionario AnswersSpecificQuestions sea un diccionario de tipo <strings,string>
        {
            //Act
            storage.UpdateAskMainCompleted(true);
            //Assert
            Assert.AreEqual(true, storage.AskMainCompleted);
        }

        [Test]
        public void UpdateAskMixedCompletedTest()
        //Se prueba que el diccionario AnswersSpecificQuestions sea un diccionario de tipo <strings,string>
        {
            //Act
            storage.UpdateAskMixedCompleted(true);
            //Assert
            Assert.AreEqual(true, storage.AskMixedCompleted);
        }

        [Test]
        public void UpdateAskSpecificCompletedTest()
        //Se prueba que el diccionario AnswersSpecificQuestions sea un diccionario de tipo <strings,string>
        {
            //Act
            storage.UpdateAskSpecificCompleted(true);
            //Assert
            Assert.AreEqual(true, storage.AskSpecificCompleted);
        }

        [Test]
        public void UpdateGetMixedCompletedTest()
        //Se prueba que el diccionario AnswersSpecificQuestions sea un diccionario de tipo <strings,string>
        {
            //Act
            storage.UpdateGetMixedCompleted(true);
            //Assert
            Assert.AreEqual(true, storage.GetMixedCompleted);
        }

        [Test]
        public void UpdateGetSpecificCompletedTest()
        //Se prueba que el diccionario AnswersSpecificQuestions sea un diccionario de tipo <strings,string>
        {
            //Act
            storage.UpdateGetSpecificCompleted(true);
            //Assert
            Assert.AreEqual(true, storage.GetSpecificCompleted);
        }

        [Test]
        public void UpdateGetProductCompletedTest()
        //Se prueba que el diccionario AnswersSpecificQuestions sea un diccionario de tipo <strings,string>
        {
            //Act
            storage.UpdateGetProductCompleted(true);
            //Assert
            Assert.AreEqual(true, storage.GetProductCompleted);
        }
    }
}