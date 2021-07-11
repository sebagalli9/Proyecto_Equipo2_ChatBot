using System;
using System.Threading;

namespace Library
{
    /*
        POLIMORFISMO: Se aplica el patrón polimorfismo ya que las clases que 
        implementan el tipo IStateHandler implementan sus operaciones polimórficas.

        SRP: La clase cumple con el principio SRP ya que no tiene más de una razón 
        de cambio, la cual sería modificar la forma en la que se gestiona la fase de 
        preguntas principales.

    */
    
    public class AskMainQuestionStateHandler : AbstractStateHandler
    {
        public override object Handle(IRequest request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {

            if (request.CurrentState == "main" && storage.AskInitialCompleted)
            {
                int contador = 1;
                output.SendMessage("Elije el número correspondiente a una de las afirmaciones. A la persona a la que quieres regalarle:", request.RequestId);
                foreach (MainCategory mainQ in CoreBot.Instance.Reader.MainCategoryBank)
                {
                    output.SendMessage(contador + "-" + mainQ.Question, request.RequestId);
                    storage.AnswersMainCategories.Add(contador.ToString(), mainQ.AnswerOptions[contador.ToString()]);
                    contador += 1;
                    //espera
                    Thread.Sleep(700);
                    //espera
                }
                Thread.Sleep(2000);
                foreach (MainCategory mainQ in CoreBot.Instance.Reader.MainCategoryBank)
                {
                    Thread.Sleep(200);
                    output.SendMessageAnswers(mainQ.AnswerOptions, request.RequestId);
                    Thread.Sleep(500);
                }

                //espera
                string aux = input.GetInput();
                while (input.GetInput() == aux)
                {
                }
                //espera
                string ans = input.GetInput();
                user.UpdateSelectedCategory(storage.AnswersMainCategories[ans]);

                output.SendMessage("Elije una segunda opción adicional:", request.RequestId);

                //espera
                string aux2 = input.GetInput();
                while (input.GetInput() == aux2)
                {
                }
                //espera

                string ans2 = input.GetInput();
                user.UpdateSelectedCategory(storage.AnswersMainCategories[ans2]);


                if (user.SelectedCategory.Count == 2)
                {
                    storage.UpdateAskMainCompleted(true);
                    output.SendMessage("Se ha finalizado la fase de preguntas principales", request.RequestId);
                    request.UpdateCurrentState("mixed");
                }

                return base.Handle(request, user, input, output, searcher, storage);
            }
            else
            {
                return null;
            }

        }
    }
}