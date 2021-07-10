using System;
using System.Collections.Generic;

namespace Library
{
    /*
        POLIMORFISMO: Se aplica el patrón polimorfismo ya que las clases 
        que implementan el tipo IStateHandler implementan sus operaciones polimórficas.

        SRP: La clase cumple con el principio SRP ya que no tiene más de una razón de cambio, 
        la cual sería modificar la forma en la que se gestiona la fase de obtener productos.

        DIP:  La clase cumple con el principio DIP ya que la clase es de alto nivel 
        y no depende de clases de bajo nivel, sino de abstracciones. 
    */
    
    public class GetProductToSearchStateHandler : AbstractStateHandler
    {
        public override object Handle(Request request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {
            if (storage.AskSpecificCompleted)
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

                    if (user.ProductSearcherKeyWords.Count > 0)
                    {
                        storage.UpdateGetProductCompleted(true);
                    }

                    return base.Handle(request, user, input, output, searcher, storage);
                }

                else
                {
                    output.SendMessage("¿No le gusta nada? ¡Bueno, intenemos de nuevo!", request.RequestId);
                    //return this.PrevHandler.Handle(request,reader,user,input, output,searcher,storage);
                    return null;

                }


            }
            else
            {
                return null;
            }
        }


    }
}