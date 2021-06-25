using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;

namespace Library
{
    /*
    Actualmente la clase FileReader no cumple con el principio SRP ya que existe más de una razón de cambio, por ejemplo:
    - Modificar la forma en la que se leen las MixedCategories de un archivo txt.
    - Modificar la forma en la que se leen las SpecificCategories de un archivo txt.

    Atualmente la clase FileReader cumple con el patrón Expert ya que es la clase experta en la información que se extrae 
    del archivo ".txt" para poder cumplir con la responsabilidad de almacenar dicha información en sus listas correspondientes.

    Actualmente la clase FileReader cumple con el patrón Creator ya que:
    - Es la clase que agrega instancias de las clases MixedCategory, SpecificCategory e InitialQuestion a listas de su mismo tipo.
    - Guarda dichas instancias.
    - Tiene los datos que seran provistos al constructor para inicializar las instancias de MixedCategory, SpecificCategory
      y InitialQuestion.
    */

    public class FileReader : IReader
    {
        public List<MainCategory> MainCategoryBank { get; private set; }
        public List<MixedCategory> MixedCategoryBank { get; private set; }
        public List<SpecificCategory> SpecificCategoryBank { get; private set; }
        public List<InitialQuestion> InitialQuestionsBank { get; private set; }

        public void ReadMainCategories(string path)
        {
            MainCategoryBank = new List<MainCategory>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int contador = 0;
                    string line;
                    string[] listaLinea;
                    while ((line = sr.ReadLine()) != null)
                    {
                        contador += 1;

                        listaLinea = line.Split(';');

                        MainCategory mainQ = new MainCategory(listaLinea[0]);

                        string[] keyVal = listaLinea[1].Split("-");
                        mainQ.AddAnswerOption(keyVal[0], keyVal[1]);

                        this.MainCategoryBank.Add(mainQ);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Algo salio mal con el archivo. No se pudo leer.");
            }
        }

        public void ReadMixedCategories(string path)
        {
            this.MixedCategoryBank = new List<MixedCategory>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int contador = 0;
                    string line;
                    string[] listaLinea;
                    while ((line = sr.ReadLine()) != null)
                    {
                        contador += 1;
                        listaLinea = line.Split(';');
                        MixedCategory mixedQ = new MixedCategory(listaLinea[0], listaLinea[1], listaLinea[2], listaLinea[3]);

                        string[] answers = listaLinea[4].Split(",");

                        foreach (string element in answers)
                        {
                            string[] keyVal = element.Split("-");
                            mixedQ.AddAnswerOption(keyVal[0], keyVal[1]);
                        }

                        this.MixedCategoryBank.Add(mixedQ);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Algo salio mal con el archivo. No se pudo abrir o encontrar.");
            }
        }

        public void ReadSpecificCategories(string path)
        {
            this.SpecificCategoryBank = new List<SpecificCategory>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int contador = 0;
                    string line;
                    string[] listaLinea;
                    while ((line = sr.ReadLine()) != null)
                    {
                        contador += 1;

                        listaLinea = line.Split(';').ToArray();

                        SpecificCategory specificCat = new SpecificCategory(listaLinea[0], listaLinea[1]);
                        string[] products = listaLinea[2].Split(",");
                        foreach (string prod in products)
                        {
                            specificCat.AddProduct(prod);
                        }

                        string[] answers = listaLinea[3].Split(",");

                        foreach (string element in answers)
                        {
                            string[] keyVal = element.Split("-");
                            specificCat.AddAnswerOption(keyVal[0], keyVal[1]);
                        }

                        SpecificCategoryBank.Add(specificCat);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Algo salio mal con el archivo. No se pudo abrir o encontrar.");
            }

        }

        public void ReadInitialQuestions(string path)
        {
            InitialQuestionsBank = new List<InitialQuestion>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int contador = 0;
                    string line;
                    string[] listaLinea;
                    while ((line = sr.ReadLine()) != null)
                    {
                        contador += 1;
                        listaLinea = line.Split(';');
                        string[] answers = listaLinea[1].Split(",");

                        InitialQuestion initialQ = new InitialQuestion(listaLinea[0]);
                        foreach (string element in answers)
                        {
                            string[] keyVal = element.Split("-");
                            initialQ.AddAnswerOption(keyVal[0], keyVal[1]);
                        }

                        this.InitialQuestionsBank.Add(initialQ);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Algo salio mal con el archivo. No se pudo abrir o encontrar.");
            }
        }

        public string ReadPlainText(string path)
        {
            string text = "";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int contador = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        contador += 1;
                        text += line;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Algo salio mal con el archivo. No se pudo leer.");
            }
            return text;
        }
    }
}
