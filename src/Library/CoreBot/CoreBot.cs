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
        IMessageReceiver input;
        ISearchGift giftSearcherEngine;
        ConversationData storage;


        public void AskInitialQuestions()
        {
            foreach (InitialQuestion initialQ in reader.InitialQuestionsBank)
            {
                output.SendMessage(initialQ.Question);  
                output.SendMessageAnswers(initialQ.AnswerOptions);
                string ans = input.GetInput();
                Console.WriteLine("La respuesta es" + ans);
                user.UpdatePreferences(initialQ.AnswerOptions[ans]);
            }

            if(user.Preferences.Count == reader.InitialQuestionsBank.Count)
            {
                storage.UpdateAskInitialCompleted(true);
                output.SendMessage("Se ha finalizado la fase de preguntas iniciales");
            }
        }

        /* private int currentInitialQItemIndex;
        public void ProcessNextInitialQuestion()
        {
            if( currentInitialQItemIndex < reader.InitialQuestionsBank.Count )
            {
                output.SendMessage(reader.InitialQuestionsBank[currentInitialQItemIndex].Question);
                output.SendMessageAnswers(reader.InitialQuestionsBank[currentInitialQItemIndex].AnswerOptions);
                string ans = input.GetInput();
                Console.WriteLine("La respuesta es" + ans);
                user.UpdatePreferences(reader.InitialQuestionsBank[currentInitialQItemIndex].AnswerOptions[ans]);

                currentInitialQItemIndex ++;
                ProcessNextInitialQuestion();
            }
        } */ 

        public void AskPriceQuestions()
        {
            foreach (PriceQuestion priceQ in reader.PriceQuestionsBank)
            {
                output.SendMessage(priceQ.Question);
                output.SendMessageAnswers(priceQ.AnswerOptions);
                string ans = input.GetInput();
                user.UpdatePricePreferences(priceQ.AnswerOptions[ans]);
            }
        }

        public void AskMainCategories()
        {
            if(storage.AskInitialCompleted)
            {
                int contador = 1;
                output.SendMessage("Elije el número correspondiente a una de las afirmaciones. A la persona a la que quieres regalarle:");
                foreach (MainCategory mainQ in reader.MainCategoryBank)
                {
                    output.SendMessage(contador + "-" + mainQ.Question);
                    storage.AnswersMainCategories.Add(contador.ToString(), mainQ.AnswerOptions[contador.ToString()]);
                    contador += 1;
                }
                foreach (MainCategory mainQ in reader.MainCategoryBank)
                {
                    output.SendMessageAnswers(mainQ.AnswerOptions);
                }
                string ans = input.GetInput();
                user.UpdateSelectedCategory(storage.AnswersMainCategories[ans]);


                output.SendMessage("Elije una segunda opción adicional:");
                string ans2 = input.GetInput();
                user.UpdateSelectedCategory(storage.AnswersMainCategories[ans2]);
            }

            if(user.SelectedCategory.Count == 2 && storage.AskInitialCompleted)
            {
                storage.UpdateAskMainCompleted(true);
                output.SendMessage("Se ha finalizado la fase de preguntas principales");
            }
            
        }

        public void GetMixedCategoryQuestion()
        {  
            if(storage.AskMainCompleted)
            {
                foreach (MixedCategory category in reader.MixedCategoryBank)
                {
                    if ((category.ParentCategoryName == user.SelectedCategory[0] && category.SecondParentCategoryName == user.SelectedCategory[1]) || (category.ParentCategoryName == user.SelectedCategory[1] && category.SecondParentCategoryName == user.SelectedCategory[0]))
                    {
                        storage.MixedCategoriesSelected.Add(category);
                    }
                }
            }
             
            if(storage.MixedCategoriesSelected.Count > 0 && storage.AskMainCompleted)
            {
                storage.UpdateGetMixedCompleted(true);
                output.SendMessage("Se ha finalizado la fase de seleccion de preguntas mixtas");
            }         
        }

        public void AskMixedQuestions()
        {
            if(storage.GetMixedCompleted)
            {
                output.SendMessage("Responde marcando 1 para responder si o 2 para responder no a las siguientes preguntas.");

                foreach (MixedCategory category in storage.MixedCategoriesSelected)
                {
                    output.SendMessage(category.Question);
                    output.SendMessageAnswers(category.AnswerOptions);
                    string ans = input.GetInput();
                    storage.AnswersMixedQuestions.Add(category.Question, category.AnswerOptions[ans]);
                }
            }

            if(storage.MixedCategoriesSelected.Count == storage.AnswersMixedQuestions.Count && storage.GetMixedCompleted)
            {
                storage.UpdateAskMixedCompleted(true);
                output.SendMessage("Se ha finalizado la fase de preguntas mixtas"); 
            }
            
        }

        public void GetSpecificCategoryQuestion()
        {
            if(storage.AskMixedCompleted)
            {
                if (storage.AnswersMixedQuestions.ContainsValue("si"))
                {
                    foreach (KeyValuePair<string, string> category in storage.AnswersMixedQuestions)
                    {
                        if (category.Value == "si")
                        {
                            foreach (MixedCategory mixedCategory in storage.MixedCategoriesSelected)
                            {
                                if (mixedCategory.Question == category.Key)
                                {
                                    storage.SubCategory.Add(mixedCategory.SubCategoryName);
                                }
                            }
                        }
                    }

                    foreach (SpecificCategory category in reader.SpecificCategoryBank)
                    {
                        foreach (string subCat in storage.SubCategory)
                        {
                            if (category.Name == subCat)
                            {
                                storage.SpecificCategoriesSelected.Add(category);
                            }
                        }
                    }
                }
                else
                {
                    storage.MixedCategoriesSelected.Clear();
                    for (int i = 0; i < 6; i++)
                    {
                        Random r = new Random();
                        int randomNum = r.Next(reader.MixedCategoryBank.Count);
                        MixedCategory randCat = reader.MixedCategoryBank[randomNum];
                        storage.MixedCategoriesSelected.Add(randCat);
                    }
                    AskMixedQuestions();
                    GetSpecificCategoryQuestion();
                }
            }

            if(storage.SpecificCategoriesSelected.Count > 0 && storage.AskMixedCompleted)
            {
                storage.UpdateGetSpecificCompleted(true);
                output.SendMessage("Se ha finalizado la fase de seleccion de preguntas especificas");
            }
            
        }
        public void AskSpecificQuestions()
        {
            if(storage.GetSpecificCompleted)
            {
                output.SendMessage("Responde marcando 1 para responder si o 2 para responder no a las siguientes preguntas.");

                foreach (SpecificCategory category in storage.SpecificCategoriesSelected)
                {
                    output.SendMessage(category.Question);
                    output.SendMessageAnswers(category.AnswerOptions);
                    string ans = input.GetInput();
                    storage.AnswersSpecificQuestions.Add(category.Question, category.AnswerOptions[ans]);
                }
            }

            if(storage.SpecificCategoriesSelected.Count == storage.AnswersSpecificQuestions.Count && storage.GetSpecificCompleted)
            {
                storage.UpdateAskSpecificCompleted(true);
                output.SendMessage("Se ha finalizado la fase de preguntas especificas"); 
            }
            
        }

        public void GetProductToSearch()
        {
            if(storage.AskSpecificCompleted)
            {
                if (storage.AnswersSpecificQuestions.ContainsValue("si"))
                {
                    foreach (KeyValuePair<string, string> category in storage.AnswersSpecificQuestions)
                    {
                        if (category.Value == "si")
                        {
                            foreach (SpecificCategory specificCategory in storage.SpecificCategoriesSelected)
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
                    storage.SpecificCategoriesSelected.Clear();
                    for (int i = 0; i < 6; i++)
                    {
                        Random r = new Random();
                        int randomNum = r.Next(reader.SpecificCategoryBank.Count);
                        SpecificCategory randCat = reader.SpecificCategoryBank[randomNum];
                        storage.SpecificCategoriesSelected.Add(randCat);
                    }
                    Console.WriteLine("Has respondido a todo que no");
                    AskMixedQuestions();
                    GetProductToSearch();
                }
            }
            
        } 

        public void Start()
        {      
            //user.CleanSelections();
            reader.ReadInitialQuestions(@"..\..\Assets\InitialQuestions.txt");
            reader.ReadMainCategories(@"..\..\Assets\MainCategories.txt");
            reader.ReadMixedCategories(@"..\..\Assets\MixedQuestions.txt");
            reader.ReadSpecificCategories(@"..\..\Assets\SpecificQuestions.txt");
            reader.ReadPriceQuestions(@"..\..\Assets\PriceQuestions.txt");
            //ProcessNextInitialQuestion();
            AskInitialQuestions();
            //AskPriceQuestions();
            AskMainCategories();
            GetMixedCategoryQuestion();
            AskMixedQuestions();
            GetSpecificCategoryQuestion();
            AskSpecificQuestions();
            GetProductToSearch();
            giftSearcherEngine.FindGift();
        }

        public CoreBot(IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
        {
            this.reader = reader;
            this.user = user;
            this.input = input;
            this.output = output;
            this.giftSearcherEngine = searcher;
            this.storage = storage;

        }
    }
}
