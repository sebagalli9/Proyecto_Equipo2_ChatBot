using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class SpecificCategoryTest
    {
        private SpecificCategory specificC;

        [SetUp]
        public void Setup()
        {
            specificC = new SpecificCategory("console", "¿Esto es una pregunta?");
        }

        [Test]
        public void NameCannotBeEmpty()
        //Se prueba que el atributo name no esté vacio
        {
            Assert.IsNotEmpty(specificC.Name);
        }

        [Test]
        public void NameMustBeString()
        //Se prueba que el atributo name sea de tipo string
        {
            Assert.IsInstanceOf(typeof(string), specificC.Name);
        }

        [Test]
        public void QuestionCannotBeEmpty()
        //Se prueba que el atributo question de la instancia no esté vacío
        {
            Assert.IsNotEmpty(specificC.Question);
        }

        [Test]
        public void QuestionMustBeString()
        //Se prueba que el atributo question de la instancia sea de tipo string
        {
            Assert.IsInstanceOf(typeof(string), specificC.Question);
        }

        [Test]
        public void ProdcutsMustBeAStringList()
        //Se prueba que el atributo products sea una lista de strings
        {
           Assert.IsInstanceOf(typeof(List<string>), specificC.Products);
        }

        [Test]
        public void AddProductTest()
        //Se prueba el metodo para agregar productos a la lista
        {
            //Act
            specificC.AddProduct("consola");
            specificC.AddProduct("mando");
            specificC.AddProduct("juguete eléctrico");
            //Assert
            Assert.AreEqual(3, specificC.Products.Count);
        }   



    }

}