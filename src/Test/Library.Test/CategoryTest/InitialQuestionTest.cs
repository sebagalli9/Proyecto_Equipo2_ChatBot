using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class InitialQuestionTest
    {
        private InitialQuestion initialQ;

        [SetUp]
        public void Setup()
        {
            initialQ = new InitialQuestion("¿Esto es una pregunta?");
        }

        [Test]
        public void QuestionCannotBeNull()
        //Se prueba que el atributo question de la instancia no sea null
        {
            Assert.IsNotNull(initialQ.Question);
        }

        [Test]
        public void QuestionMustBeString()
        //Se prueba que el atributo question de la instancia sea de tipo string
        {
            Assert.IsInstanceOf(typeof(string),initialQ.Question);
        }

        [Test]
        public void AnswerOptionsMustBeAStringDictionary()
        //Se prueba que el atributo answerOption sea un diccionario de tipo <string,string>
        {
            Assert.IsInstanceOf(typeof(Dictionary<string,string>), initialQ.AnswerOptions);
        } 

        [Test]
        public void AddAnswerOptionAddsToDictionary()
        //Se prueba que el metodo AddAnswerOption agregue elementos al diccionario correctamente
        {
            //Act
            initialQ.AddAnswerOption("1","hombre");
            initialQ.AddAnswerOption("2","mujer");
            //Assert
            Assert.AreEqual(2,initialQ.AnswerOptions.Count);
        }

    }

}