using System;
using System.Collections.Generic;

namespace Library
{
    /*
    Actualmente la clase NO cumple con el principio SRP ya que tiene más de una razón de cambio, por ejemplo:
    - Modificar la forma en la que se preguntan las preguntas iniciales.
    - Modificar la forma en la que se obtienen las preguntas mixtas.
    - Modificar la forma en la que se obtienen las preguntas especificas.
    - Modificar la forma en la que se obtiene el producto a buscar.
    - Modificar la forma en la que se actualiza el perfil de la persona.

    La clase NO cumple con el patrón Expert ya que para conocer la información necesaria para crear 
    cada nueva ronda de preguntas, tiene que acudir a la clase Experta en conocer las listas de categorias 
    (una clase que implemente IReader).

    La clase cumple con el principio DIP ya que depende solamente de abstracciones de IReader, IPersonProfile, 
    IMessageSender y IInputReceiver.

    La clase cumple el principio OCP porque depende de archivos de texto abiertos a extensión y además se evita depender de logica 
    condicional para obtener dichas preguntas, lo cual podría agregarle fragilidad y rigidez al código.

    La clase tiene bajo acoplamiento porque depende de abstracciones y por tanto no esta fuertemente conectada a otras clases.
    La clase tiene alta cohesion porque la relación entre los métodos de la clase y el propósito de la clase es fuerte. 
    El propósito de la clase es generar las rondas de preguntas y los métodos de la clase estan específicamente creados
    para ello, teniendo además una dependencia en el orden de su ejecución. 

    Para favorecer el bajo acoplamiento y la alta cohesión, se decidió NO cumplir con SRP.
    */

    public class CoreBot
    {
        IReader reader;
        IMessageSender output;
        IPersonProfile user;
        IInputReceiver input;

        public List<MixedCategory> MixedCategoriesSelected { get; private set; }
        public List<SpecificCategory> SpecificCategoriesSelected { get; private set; }
        public List<String> SubCategory { get; private set; }
        public Dictionary<string, string> AnswersMainCategories { get; private set; }
        public Dictionary<string, string> AnswersMixedQuestions { get; private set; }
        public Dictionary<string, string> AnswersSpecificQuestions { get; private set; }

        public void AskInitialQuestions()
        {
            foreach (InitialQuestion initialQ in reader.InitialQuestionsBank)
            {
                output.SendMessage(initialQ.Question);
                foreach (var option in initialQ.AnswerOptions)
                {
                    output.SendMessage(option.Key + " - " + option.Value);
                }

                string ans = input.GetInput();
                user.UpdatePreferences(initialQ.AnswerOptions[ans]);
            }
        }

        public void AskMainCategories()
        {
            int contador = 1;
            output.SendMessage("Elije el número correspondiente a una de las afirmaciones. A la persona a la que quieres regalarle:");
            foreach (MainCategory mainQ in reader.MainCategoryBank)
            {
                output.SendMessage(contador + "-" + mainQ.Question);
                AnswersMainCategories.Add(contador.ToString(), mainQ.AnswerOptions[contador.ToString()]);
                contador += 1;
            }
            string ans = input.GetInput();
            user.UpdateSelectedCategory(AnswersMainCategories[ans]);


            output.SendMessage("Elije una segunda opción adicional:");
            string ans2 = input.GetInput();
            user.UpdateSelectedCategory(AnswersMainCategories[ans2]);
        }

        public void GetMixedCategoryQuestion()
        {
            foreach (MixedCategory category in reader.MixedCategoryBank)
            {
                if ((category.ParentCategoryName == user.SelectedCategory[0] && category.SecondParentCategoryName == user.SelectedCategory[1]) || (category.ParentCategoryName == user.SelectedCategory[1] && category.SecondParentCategoryName == user.SelectedCategory[0]))
                {
                    MixedCategoriesSelected.Add(category);
                }
            }
        }

        public void AskMixedQuestions()
        {
            output.SendMessage("Responde si o no a las siguientes preguntas.");

            foreach (MixedCategory category in MixedCategoriesSelected)
            {
                output.SendMessage(category.Question);
                foreach (var option in category.AnswerOptions)
                {
                    output.SendMessage(option.Key + " - " + option.Value);
                }

                string ans = input.GetInput();
                AnswersMixedQuestions.Add(category.Question, category.AnswerOptions[ans]);
            }
        }

        public void GetSpecificCategoryQuestion()
        {
            if (AnswersMixedQuestions.ContainsValue("si"))
            {
                foreach (KeyValuePair<string, string> category in AnswersMixedQuestions)
                {
                    if (category.Value == "si")
                    {
                        foreach (MixedCategory mixedCategory in MixedCategoriesSelected)
                        {
                            if (mixedCategory.Question == category.Key)
                            {
                                SubCategory.Add(mixedCategory.SubCategoryName);
                            }
                        }
                    }
                }

                foreach (SpecificCategory category in reader.SpecificCategoryBank)
                {
                    foreach (string subCat in SubCategory)
                    {
                        if (category.Name == subCat)
                        {
                            SpecificCategoriesSelected.Add(category);
                        }
                    }
                }
            }
            else
            {
                MixedCategoriesSelected.Clear();
                for (int i = 0; i < 6; i++)
                {
                    Random r = new Random();
                    int randomNum = r.Next(reader.MixedCategoryBank.Count);
                    MixedCategory randCat = reader.MixedCategoryBank[randomNum];
                    MixedCategoriesSelected.Add(randCat);
                }
                AskMixedQuestions();
                GetSpecificCategoryQuestion();
            }
        }

        public void AskSpecificQuestions()
        {
            output.SendMessage("Responde si o no a las siguientes preguntas.");

            foreach (SpecificCategory category in SpecificCategoriesSelected)
            {
                output.SendMessage(category.Question);

                foreach (var option in category.AnswerOptions)
                {
                    output.SendMessage(option.Key + " - " + option.Value);
                }

                string ans = input.GetInput();
                AnswersSpecificQuestions.Add(category.Question, category.AnswerOptions[ans]);
            }
        }

        public void GetProductToSearch()
        {
            if (AnswersSpecificQuestions.ContainsValue("si"))
            {
                foreach (KeyValuePair<string, string> category in AnswersSpecificQuestions)
                {
                    if (category.Value == "si")
                    {
                        foreach (SpecificCategory specificCategory in SpecificCategoriesSelected)
                        {
                            if (specificCategory.Question == category.Key)
                            {
                                foreach (string prod in specificCategory.Products)
                                {
                                    user.ProductSearcherKeyWords.Add(prod);
                                }

                            }
                        }
                    }
                }
            }
            else
            {
                SpecificCategoriesSelected.Clear();
                for (int i = 0; i < 6; i++)
                {
                    Random r = new Random();
                    int randomNum = r.Next(reader.SpecificCategoryBank.Count);
                    SpecificCategory randCat = reader.SpecificCategoryBank[randomNum];
                    SpecificCategoriesSelected.Add(randCat);
                }
                AskMixedQuestions();
                GetProductToSearch();
            }
        }

        public void Start()
        {
            reader.ReadInitialQuestions(@"..\..\Assets\InitialQuestions.txt");
            reader.ReadMainCategories(@"..\..\Assets\MainCategories.txt");
            reader.ReadMixedCategories(@"..\..\Assets\MixedQuestions.txt");
            reader.ReadSpecificCategories(@"..\..\Assets\SpecificQuestions.txt");
            AskInitialQuestions();
            AskMainCategories();
            GetMixedCategoryQuestion();
            AskMixedQuestions();
            GetSpecificCategoryQuestion();
            AskSpecificQuestions();
            GetProductToSearch();
        }

        public CoreBot(IReader reader, IPersonProfile user, IInputReceiver input, IMessageSender output)
        {
            this.reader = reader;
            this.user = user;
            this.input = input;
            this.output = output;
            this.MixedCategoriesSelected = new List<MixedCategory>();
            this.SpecificCategoriesSelected = new List<SpecificCategory>();
            this.SubCategory = new List<string>();
            this.AnswersMainCategories = new Dictionary<string, string>();
            this.AnswersMixedQuestions = new Dictionary<string, string>();
            this.AnswersSpecificQuestions = new Dictionary<string, string>();
        }
    }
}
