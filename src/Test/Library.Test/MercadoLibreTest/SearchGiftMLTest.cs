using NUnit.Framework;
using Library;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Test.Library
{
    public class SearchGiftMLTest
    {   
        private ISearchGift searchGiftML;
        private IPersonProfile user;
    	private IMessageSender printer;
        [SetUp]
        public void Setup()
        {
            user = new PersonProfile();
            
            printer = new ConsolePrinter();

            searchGiftML = new SearchGiftML(user,printer);
        }

        [Test]
        public void ProductSearchListNotEmpty()
        //Se prueba que la lista que devuelve la busqueda de un producto no sea vacia.
        {
            //Act
            user.AddProductToSearch("Iphone");
            user.UpdatePreferences("Negro");
            searchGiftML.FindGift(1);

            //Assert
            Assert.IsNotNull(searchGiftML.Results);
        }

        [Test]
        public void FilteredListNotEmpty()
        //Se prueba que la lista que devuelve la busqueda de un producto no sea vacia.
        {
            //Act
            user.AddProductToSearch("Iphone");
            user.UpdatePreferences("Negro");
            searchGiftML.FindGift(1);

            //Assert
            Assert.IsNotNull(searchGiftML.ResultsFiltered);
        }

        [Test]
        public void ProductSearchListFiltered()
        //Se prueba que la lista que devuelve los productos fltrados tenga como maximo dos elementos por prodcuto.
        {
            //Act
            user.AddProductToSearch("Iphone");
            user.UpdatePreferences("Negro");
            searchGiftML.FindGift(1);

            //Assert
            Assert.AreEqual(2,searchGiftML.ResultsFiltered.Count);
        }
    }
}