using System;
using System.Threading;

namespace Library
{ 
    public class AskMainQuestionStateHandler: AbstractStateHandler
    {
        public override object Handle(IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
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
                    //espera
                    Thread.Sleep(800);
                    //espera
                }
                //espera
                Thread.Sleep(1000);
                //espera
                foreach (MainCategory mainQ in reader.MainCategoryBank)
                {
                    output.SendMessageAnswers(mainQ.AnswerOptions);
                }
                
                //espera
                string aux = input.GetInput();
                while (input.GetInput() == aux)
                {
                }
                //espera
                string ans = input.GetInput();
                user.UpdateSelectedCategory(storage.AnswersMainCategories[ans]);


                output.SendMessage("Elije una segunda opción adicional:");
            

                //espera
                string aux2 = input.GetInput();
                while (input.GetInput() == aux2)
                {
                }
                //espera
                
                string ans2 = input.GetInput();
                user.UpdateSelectedCategory(storage.AnswersMainCategories[ans2]);


                if(user.SelectedCategory.Count == 2)
                {
                    storage.UpdateAskMainCompleted(true);
                    output.SendMessage("Se ha finalizado la fase de preguntas principales");    
                }

                return base.Handle(reader,user,input, output,searcher,storage);
            }      
            else
            {
                return null;
            }
        }
    }
}