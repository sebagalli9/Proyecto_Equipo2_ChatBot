using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class MainCategoryTest
    {
        private MainCategory mainCategory;

        [SetUp]
        public void Setup()
        {
        mainCategory = new MainCategory("Le gusta quedarse en casa");
        }

        [Test]
        public void QuestionCannotBeNull()
        //Se prueba que el atributo question de la instancia no sea null
        {
            Assert.IsNotNull(mainCategory.Question);
        }

        [Test]
        public void QuestionMustBeString()
        //Se prueba que el atributo question de la instancia sea de tipo string
        {
            Assert.IsInstanceOf(typeof(string), mainCategory.Question);
        }

        [Test]
        public void AnswerOptionsMustBeAStringDictionary()
        //Se prueba que el atributo answerOption sea un diccionario de tipo <string,string>
        {
            Assert.IsInstanceOf(typeof(Dictionary<string,string>), mainCategory.AnswerOptions);
        } 

        [Test]
        public void AddAnswerOptionAddsToDictionary()
        //Se prueba que el metodo AddAnswerOption agregue elementos al diccionario correctamente
        {
            //Act
            mainCategory.AddAnswerOption("1","home");
            //Assert
            Assert.AreEqual(1, mainCategory.AnswerOptions.Count);
        }

    }

}