using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;

namespace Library
{
    /*
    Actualmente la clase FileReader cumple con el principio SRP ya que no existe más de una razón de cambio, que es:
    - Modificar la forma en la que se leen los archivos txt.
    Atualmente la clase FileReader cumple con el patrón Expert ya que es la clase experta en la información que se extrae 
    de un archivo ".txt" para poder cumplir con la responsabilidad de almacenar dicha información en sus listas correspondientes.
    Actualmente la clase FileReader cumple con el patrón Creator ya que:
    - Es la clase que agrega instancias de las clases MixedCategory, SpecificCategory e InitialQuestion a listas de su mismo tipo.
    - Guarda dichas instancias.
    - Tiene los datos que seran provistos al constructor para inicializar las instancias de MixedCategory, SpecificCategory, 
    MainCategory y InitialQuestion.
    En la clase FileReader existe una relación de composición entre esta clase y las clases InitialQuestion, MainCategory,
    MixedCategory y SpecificCategory, ya que está compuesta de bancos de categorias de instancias de sus clases respectivas
    , las cuales no tienen un proposito independiente a las instancias de esta clase. 
    La clase cumple con el principio ISP ya que no depende de un tipo que no usa.
    */

    public class FileReader : IReader
    {
        public List<MainCategory> MainCategoryBank { get; private set; }
        public List<MixedCategory> MixedCategoryBank { get; private set; }
        public List<SpecificCategory> SpecificCategoryBank { get; private set; }
        public List<InitialQuestion> InitialQuestionsBank { get; private set; }
        private static FileReader reader = null;
  
/*         public static FileReader Instance()
        {
            if(reader == null){
                reader = new FileReader();
                reader.ReadInitialQuestions(@"..\..\Assets\InitialQuestions.txt");
                reader.ReadMainCategories(@"..\..\Assets\MainCategories.txt");
                reader.ReadMixedCategories(@"..\..\Assets\MixedQuestions.txt");
                reader.ReadSpecificCategories(@"..\..\Assets\SpecificQuestions.txt");
            }
            return reader;
        } */
        
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
                        try
                        {
                            listaLinea = line.Split(';');

                            MainCategory mainQ = new MainCategory(listaLinea[0]);

                            string[] keyVal = listaLinea[1].Split("-");
                            mainQ.AddAnswerOption(keyVal[0], keyVal[1]);

                            this.MainCategoryBank.Add(mainQ);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Hubo error al leer la linea {contador} del archivo MainQuestions.");
                            sr.Close();
                            throw;
                        }
                        
                    }
    	            sr.Close();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Algo salio mal con el archivo. No se pudo leer.");
                throw;
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
                        try
                        {
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
                        catch (Exception)
                        {
                            Console.WriteLine($"Hubo error al leer la linea {contador} del archivo MixedQuestions.");
                            sr.Close();
                            throw;
                        }

                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Algo salio mal con el archivo. No se pudo abrir o encontrar.");
                throw;
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

                        try
                        {
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
                        catch (Exception)
                        {
                            Console.WriteLine($"Hubo error al leer la linea {contador} del archivo SpecificQuestions.");
                            sr.Close();
                            throw;
                        }
                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Algo salio mal con el archivo. No se pudo abrir o encontrar.");
                throw;
            }

        }

        public void ReadInitialQuestions(string path)
        {
            this.InitialQuestionsBank = new List<InitialQuestion>();

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

                        try
                        {
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
                        catch (Exception)
                        {
                            Console.WriteLine($"Hubo error al leer la linea {contador} del archivo InitialQuestions.");
                            sr.Close();
                            throw;
                        }                        
                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Algo salio mal con el archivo. No se pudo abrir o encontrar.");
                throw;
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
                    try
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            contador += 1;
                            text += line;
                        }
                         sr.Close();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"Hubo error al leer la linea {contador} del archivo.");
                        sr.Close();
                        throw;
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