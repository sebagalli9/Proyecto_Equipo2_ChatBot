using NUnit.Framework;
using Library;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Test.Library
{
    public class FileReaderTest
    {
        private FileReader reader;

        [SetUp]
        public void Setup()
        {
            reader = new FileReader();            
        }

        [Test]
        public void ReadMainCategoriesCheck()
        //Se prueba que se agreguen las lineas de archivo correctamente a la lista de categorías.
        {
            //Act
            reader.ReadMainCategories("../../../../../../Assets/MainCategories.txt");
            //Assert
            Assert.AreEqual(5, reader.MainCategoryBank.Count);
        }

        [Test]
        public void ReadMixedCategoriesCheck()
        //Se prueba que se agreguen las lineas de archivo correctamente a la lista de categorías mixtas.
        {
            //Act
            reader.ReadMixedCategories("../../../../../../Assets/MixedQuestions.txt");
            //Assert
            Assert.AreEqual(54, reader.MixedCategoryBank.Count);
        }

        [Test]
        public void ReadSpecificCategoriesCheck()
        //Se prueba que se agreguen las lineas de archivo correctamente a la lista de categorías específicas.
        {
            //Act
            reader.ReadSpecificCategories("../../../../../../Assets/SpecificQuestions.txt");
            //Assert
            Assert.AreEqual(65, reader.SpecificCategoryBank.Count);
        }

        [Test]
        public void ReadInitialQuestionsCheck()
        //Se prueba que se agreguen las lineas de archivo correctamente a la lista de preguntas iniciales.
        {
            //Act
            reader.ReadInitialQuestions("../../../../../../Assets/InitialQuestions.txt");
            //Assert
            Assert.AreEqual(4, reader.InitialQuestionsBank.Count);
        }

        [Test]
        public void ReadPlainTextReturnsAStringCheck()
        //Se prueba que el texto que retorna el método sea del tipo string.
        {
            //Act
            string text = reader.ReadPlainText("../../../../../../Assets/Welcome.txt");
            //Assert
            Assert.IsInstanceOf(typeof(string), text);
        } 
        
        [Test]
        public void ReadPlainTextCheck()
        //Se prueba que la cantidad de caracteres del texto leído sea igual a la esperada.
        {
            //Act
            string text = reader.ReadPlainText("../../../../../../Assets/Welcome.txt");
            //Assert
            Assert.AreEqual(51, text.Length);
        }
    }

}