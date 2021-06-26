using NUnit.Framework;
using Library;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Test.Library
{
    public class FileReaderTest
    {
        private FileReader fileReader;

        [SetUp]
        public void Setup()
        {
            fileReader = new FileReader();            
        }

        [Test]
        public void ReadMainCategoriesCheck()
        //Se prueba que se agreguen las lineas de archivo correctamente a la lista de categorías.
        {
            //Act
            fileReader.ReadMainCategories("../../../../../../Assets/MainCategories.txt");
            //Assert
            Assert.AreEqual(5, fileReader.MainCategoryBank.Count);
        }

        [Test]
        public void ReadMixedCategoriesCheck()
        //Se prueba que se agreguen las lineas de archivo correctamente a la lista de categorías mixtas.
        {
            //Act
            fileReader.ReadMixedCategories("../../../../../../Assets/MixedQuestions.txt");
            //Assert
            Assert.AreEqual(54, fileReader.MixedCategoryBank.Count);
        }

        [Test]
        public void ReadSpecificCategoriesCheck()
        //Se prueba que se agreguen las lineas de archivo correctamente a la lista de categorías específicas.
        {
            //Act
            fileReader.ReadSpecificCategories("../../../../../../Assets/SpecificQuestions.txt");
            //Assert
            Assert.AreEqual(53, fileReader.SpecificCategoryBank.Count);
        }

        [Test]
        public void ReadInitialQuestionsCheck()
        //Se prueba que se agreguen las lineas de archivo correctamente a la lista de preguntas iniciales.
        {
            //Act
            fileReader.ReadInitialQuestions("../../../../../../Assets/InitialQuestions.txt");
            //Assert
            Assert.AreEqual(5, fileReader.InitialQuestionsBank.Count);
        }

        [Test]
        public void ReadPlainTextReturnsAStringCheck()
        //Se prueba que el texto que retorna el método sea del tipo string.
        {
            //Act
            string text = fileReader.ReadPlainText("../../../../../../Assets/Welcome.txt");
            //Assert
            Assert.IsInstanceOf(typeof(string), text);
        } 
        
        [Test]
        public void ReadPlainTextCheck()
        //Se prueba que la cantidad de caracteres del texto leído sea igual a la esperada.
        {
            //Act
            string text = fileReader.ReadPlainText("../../../../../../Assets/Welcome.txt");
            //Assert
            Assert.AreEqual(18, text.Length);
        }
    }

}