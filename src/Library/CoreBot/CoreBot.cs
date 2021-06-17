
using System;
using System.Collections.Generic;

namespace Library
{
     /*
     Actualmente la clase no cumple con el principio SRP ya que tiene más de una razón de cambio, por ejemplo:
     - Modificar la forma en la que se preguntan las preguntas iniciales.
     - Modificar la forma en la que se obtienen las preguntas mixtas.
     - Modificar la forma en la que se obtienen las preguntas especificas.
     - Modificar la forma en la que se obtiene el producto a buscar.
     - Modificar la forma en la que se actualiza el perfil de la persona.

     La clase no cumple con el patrón Expert ya que para conocer la información necesaria para crear 
     cada nueva ronda de preguntas, va a tener que acudir a la clase Experta en conocer las listas de categorias (un IReader).

     La clase cumple con el patrón DIP ya que depende una abstracción IReader y IPersonProfile.

     La clase cumple OCP porque depende de archivos de texto abiertos a extensión y además se evita depender de logica 
     condicional para obtener dichas preguntas, lo cual podría agregarle fragilidad y rigidez al código.

     Bajo acoplamiento y alta cohesion: PENDIENTE JUSTIFICAR
     */
     
     public class CoreBot
     {
          IReader reader;
          IPersonProfile user;
          private List<MixedCategory> mixedCategoriesSelected;
          private List<SpecificCategory> specificCategoriesSelected; 
          private List<String> subCategory; 
          private Dictionary<string, string> mainCategoriesAnswers = new Dictionary<string, string>();
          private Dictionary<string, string> answersMixedQuestions = new Dictionary<string, string>();
          private Dictionary<string, string> answersSpecificQuestions = new Dictionary<string, string>();
          
          public void AskInitialQuestions()
          {
               foreach(InitialQuestion initialQ in reader.InitialQuestionsBank)
               {
                    Console.WriteLine(initialQ.Question);
                    foreach(var option in initialQ.AnswerOptions)
                    {
                         Console.WriteLine(option.Key + " - " + option.Value);
                    }

                    string ans = Console.ReadLine();
                    while(Convert.ToInt32(ans) > initialQ.AnswerOptions.Count)
                    {
                         Console.WriteLine("Debe ingresar un número del 1 al " + initialQ.AnswerOptions.Count);
                         ans = Console.ReadLine();
                    }
                          
                    user.UpdatePreferences(initialQ.AnswerOptions[ans]);              
               }           
          }

          public void AskMainCategories()
          {    
               int contador = 1;
               Console.WriteLine("Elije el número correspondiente a una de las afirmaciones. A la persona a la que quieres regalarle:");
               foreach (MainCategory mainQ in reader.MainCategories) 
               {
                    Console.WriteLine(contador + "-" + mainQ.Question);
                    mainCategoriesAnswers.Add(contador.ToString(),mainQ.AnswerOptions[contador.ToString()]);
                    contador += 1;

               }

               string ans = Console.ReadLine(); 
               while(Convert.ToInt32(ans) > mainCategoriesAnswers.Count)
               {
                   Console.WriteLine("Debe ingresar un número del 1 al " + mainCategoriesAnswers.Count);
                    ans = Console.ReadLine(); 
               }
               user.UpdateSelectedCategory(mainCategoriesAnswers[ans]); 

               Console.WriteLine("Elije una segunda opción adicional:");
               string ans2 = Console.ReadLine();
               while(Convert.ToInt32(ans2) > mainCategoriesAnswers.Count)
               {
                   Console.WriteLine("Debe ingresar un número del 1 al " + mainCategoriesAnswers.Count);
                   ans2 = Console.ReadLine(); 
               }
               user.UpdateSelectedCategory(mainCategoriesAnswers[ans2]);
          }
         
          public void GetMixedCategoryQuestion() 
          {
               foreach (MixedCategory category in reader.MixedCategoryBank)
               {
                    if ((category.ParentCategoryName == user.SelectedCategory[0] && category.SecondParentCategoryName == user.SelectedCategory[1]) || (category.ParentCategoryName == user.SelectedCategory[1] && category.SecondParentCategoryName == user.SelectedCategory[0]))
                    {
                         mixedCategoriesSelected.Add(category);
                    }
               }
          }

          public void AskMixedQuestions() 
          {
               Console.WriteLine("Responde si o no a las siguientes preguntas.");

               foreach (MixedCategory category in mixedCategoriesSelected)
               {
                    Console.WriteLine(category.Question);

                    string ans = Console.ReadLine();
                    while(ans.ToLower() != "si" && ans.ToLower() != "no")
                    {
                         Console.WriteLine("La respuesta debe ser si o no");
                         Console.WriteLine(category.Question);
                         ans = Console.ReadLine();
                    }

                    answersMixedQuestions.Add(category.Question, ans.ToLower());
               }
          }
 
          public void GetSpecificCategoryQuestion()    
          {
               if(answersMixedQuestions.ContainsValue("si"))
               {
                    foreach (KeyValuePair<string, string> category in answersMixedQuestions)
                    {
                         if (category.Value == "si")
                         {
                              foreach (MixedCategory mixedCategory in mixedCategoriesSelected)
                              {
                                   if (mixedCategory.Question == category.Key)
                                   {
                                        subCategory.Add(mixedCategory.SubCategoryName);
                                   }
                              }
                         }
                    }

                    foreach (SpecificCategory category in reader.SpecificCategoryBank)
                    {    
                         foreach(string subCat in subCategory)
                         {
                              if (category.Name == subCat)
                              {
                                   specificCategoriesSelected.Add(category);
                              }
                         }
                    }
               }
               else
               {
                    //Pregunta preguntas random dentro de MixedQuestionsBank
                    //guarda las respuestas en answersMixedQuestions
                    //se usa una recursion que entra de nuevo en GetSpecificCategoryQuestion

                    mixedCategoriesSelected.Clear();
                    for(int i=0; i<6; i++)
                    {    
                         //sacar un elemento random del banco de mixedquestion
                         //agregar el elemento random del banco a mixedcategoriesselected si es que no esta ya ahi adentro
                         Random r = new Random();
                         int randomNum = r.Next(reader.MixedCategoryBank.Count);
                         MixedCategory randCat = reader.MixedCategoryBank[randomNum];     
                         mixedCategoriesSelected.Add(randCat);                       
                    }
                    
                    AskMixedQuestions(); 
                    GetSpecificCategoryQuestion();                

               }
          }
      
          public void AskSpecificQuestions()
          {
               Console.WriteLine("Responde si o no a las siguientes preguntas.");

               foreach (SpecificCategory category in specificCategoriesSelected)
               {
                    Console.WriteLine(category.Question);

                    string ans = Console.ReadLine();
                    while(ans.ToLower() != "si" && ans.ToLower() != "no")
                    {
                         Console.WriteLine("La respuesta debe ser si o no");
                         ans = Console.ReadLine();
                    }

                    answersSpecificQuestions.Add(category.Question, ans.ToLower());
               }
          }

          public void GetProductToSearch()   
          {
               if(answersSpecificQuestions.ContainsValue("si"))
               {   
                    foreach (KeyValuePair<string, string> category in answersSpecificQuestions)
                    {
                         if (category.Value == "si")
                         {
                              foreach (SpecificCategory specificCategory in specificCategoriesSelected)
                              {
                                   if (specificCategory.Question == category.Key)
                                   {
                                        foreach(string prod in specificCategory.Products)
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
                    specificCategoriesSelected.Clear();
                    for(int i=0; i<6; i++)
                    {
                        Random r = new Random();
                        int randomNum = r.Next(reader.SpecificCategoryBank.Count); 
                        SpecificCategory randCat = reader.SpecificCategoryBank[randomNum];     
                        specificCategoriesSelected.Add(randCat);     
                    }
                    AskMixedQuestions(); 
                    GetProductToSearch();
               }
          }

          public void Start()
          {  
               reader.ReadInitialQuestions();
               reader.ReadMainCategories();
               reader.ReadMixedCategories();
               reader.ReadSpecificCategories();
               AskInitialQuestions();
               AskMainCategories();
               GetMixedCategoryQuestion();
               AskMixedQuestions();
               GetSpecificCategoryQuestion();
               AskSpecificQuestions();
               GetProductToSearch();  
          }

          public CoreBot(IReader reader, IPersonProfile user)
          {
               this.reader = reader;
               this.user = user;
               this.mixedCategoriesSelected = new List<MixedCategory>();
               this.specificCategoriesSelected = new List<SpecificCategory>();
               this.subCategory = new List<string>();
          }
     }
}
