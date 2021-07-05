using System;

namespace Library
{ 
    public class AskInitialQuestionStateHandler: AbstractStateHandler
    {
        public override object Handle(IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
        {  
            foreach (InitialQuestion initialQ in reader.InitialQuestionsBank)
            {
                output.SendMessage(initialQ.Question);  
                output.SendMessageAnswers(initialQ.AnswerOptions);
                string ans = input.GetInput();
                //Console.WriteLine("La respuesta es" + ans);
                user.UpdatePreferences(initialQ.AnswerOptions[ans]);
            }

            if(user.Preferences.Count == reader.InitialQuestionsBank.Count)
            {
                storage.UpdateAskInitialCompleted(true);
                output.SendMessage("Se ha finalizado la fase de preguntas iniciales");
            }

            return base.Handle(reader,user,input, output,searcher,storage);
            
        }
    }
}