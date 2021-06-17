using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace Test.Library
{
    public class MixedCategoryTest
    {
        private MixedCategory mixedC;

        [SetUp]
        public void Setup()
        {
            mixedC = new MixedCategory("home", "sport", "¿Esto es una pregunta?", "fitness");
        }

        [Test]
        public void ParentCategoryNameCannotBeEmpty()
        //Se prueba que el atributo parentCategoryName no esté vacio
        {
            Assert.IsNotEmpty(mixedC.ParentCategoryName);
        }

        [Test]
        public void ParentCategoryNameMustBeString()
        //Se prueba que el atributo parentCategoryName sea de tipo string
        {
            Assert.IsInstanceOf(typeof(string), mixedC.ParentCategoryName);
        }

        [Test]
        public void SecondParentCategoryNameCannotBeEmpty()
        //Se prueba que el atributo secondParentCategoryName no esté vacío
        {
            Assert.IsNotEmpty(mixedC.SecondParentCategoryName);
        }

        [Test]
        public void SecondParentCategoryNameMustBeString()
        //Se prueba que el atributo secondParentCategoryName sea de tipo string
        {
            Assert.IsInstanceOf(typeof(string), mixedC.SecondParentCategoryName);
        }

        [Test]
        public void QuestionCannotBeEmpty()
        //Se prueba que el atributo question de la instancia no esté vacío
        {
            Assert.IsNotEmpty(mixedC.Question);
        }

        [Test]
        public void QuestionMustBeString()
        //Se prueba que el atributo question de la instancia sea de tipo string
        {
            Assert.IsInstanceOf(typeof(string), mixedC.Question);
        }

        [Test]
        public void SubCategoryNameCannotBeEmpty()
        //Se prueba que el atributo subCategoryName no esté vacío
        {
            Assert.IsInstanceOf(typeof(string), mixedC.SubCategoryName);
        }

        [Test]
        public void SubCategoryNameMustBeString()
        //Se prueba que el atributo subCategoryName sea de tipo string
        {
            Assert.IsInstanceOf(typeof(string), mixedC.SubCategoryName);
        }

    }

}