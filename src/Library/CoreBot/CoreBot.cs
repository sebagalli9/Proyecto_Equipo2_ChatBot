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
