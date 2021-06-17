using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class PersonProfileTest
    {
        private PersonProfile person;

        [SetUp]
        public void Setup()
        {
            person = new PersonProfile();
        }

        [Test]
        public void PreferencesMustBeAStringList()
        //Se prueba que el atributo preferences sea una lista de strings
        {
            Assert.IsInstanceOf(typeof(List<string>), person.Preferences);
        }

        [Test]
        public void SelectedCategoryMustBeAStringList()
        //Se prueba que el atributo selectedCategory sea una lista de strings
        {
            Assert.IsInstanceOf(typeof(List<string>), person.SelectedCategory);
        }

        [Test]
        public void ProductSearcherKeyWordsMustBeAStringList()
        //Se prueba que el atributo productSearcherKeyWords sea una lista de string
        {
            Assert.IsInstanceOf(typeof(List<string>), person.ProductSearcherKeyWords);
        }

        [Test]
        public void UpdatePreferencesTest()
        //Se prueba que el metodo funcione correctamente
        {
           //Act
           person.UpdatePreferences("montevideo");
           person.UpdatePreferences("nuevo"); 
           //Assert
           Assert.AreEqual(2,person.Preferences.Count);
        }

        [Test]
        public void UpdateSelectedCategoryTest()
        //Se prueba que el metodo funcione correctamente
        {
           //Act
           person.UpdateSelectedCategory("home");
           person.UpdateSelectedCategory("technology");
           //Assert
           Assert.AreEqual(2, person.SelectedCategory.Count);
        }

        [Test]
        public void AddProductToSearchTest()
        //Se prueba que el metodo funcione correctamente
        {
            //Act
            person.AddProductToSearch("playstation");
            person.AddProductToSearch("Iphone");
            //Assert
            Assert.AreEqual(2, person.ProductSearcherKeyWords.Count);
        }



    }

}