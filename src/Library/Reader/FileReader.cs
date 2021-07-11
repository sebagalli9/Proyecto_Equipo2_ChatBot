using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;

namespace Library
{
    /*
        SRP: Actualmente la clase FileReader cumple con el principio SRP 
        ya que no existe más de una razón de cambio, que es modificar la forma 
        en la que se leen los archivos txt.
    
        EXPERT: La clase FileReader cumple con el patrón Expert ya que es la clase 
        experta en la información que se extrae de un archivo ".txt" para poder cumplir 
        con la responsabilidad de almacenar dicha información en sus listas correspondientes.

        CREATOR: la clase FileReader cumple con el patrón Creator ya que es la clase 
        que agrega instancias de las clases MixedCategory, SpecificCategory, MainCategory 
        e InitialQuestion a listas de su mismo tipo, guarda dichas instancias y tiene los 
        datos que serán provistos al constructor para inicializar sus instancias.

        ISP: La clase cumple con el principio ISP ya que no depende de un tipo que no usa.

    */

    public class FileReader : IReader
    {   
        private List<MainCategory> mainCategoryBank;

        private ReadOnlyCollection<MainCategory> roMainCategoryBank;

        public IList<MainCategory> MainCategoryBank
        {
            get 
            {
                roMainCategoryBank = mainCategoryBank.AsReadOnly();
                return roMainCategoryBank;
            }
        }

        private List<MixedCategory> mixedCategoryBank = new List<MixedCategory>();

        private ReadOnlyCollection<MixedCategory> roMixedCategoryBank;

        public IList<MixedCategory> MixedCategoryBank
        {
            get 
            {
                roMixedCategoryBank = mixedCategoryBank.AsReadOnly();
                return roMixedCategoryBank;
            }
        }

        private List<SpecificCategory> specificCategoryBank = new List<SpecificCategory>();

        private ReadOnlyCollection<SpecificCategory> roSpecificCategoryBank;

        public IList<SpecificCategory> SpecificCategoryBank
        {
            get 
            {
                roSpecificCategoryBank = specificCategoryBank.AsReadOnly();
                return roSpecificCategoryBank;
            }
        }

        private List<InitialQuestion> initialQuestionsBank = new List<InitialQuestion>();

        private ReadOnlyCollection<InitialQuestion> roInitialQuestionsBank;

        public IList<InitialQuestion> InitialQuestionsBank
        {
            get 
            {
                roInitialQuestionsBank = initialQuestionsBank.AsReadOnly();
                return roInitialQuestionsBank;
            }
        }

        public void ReadMainCategories(string path)
        {
            mainCategoryBank = new List<MainCategory>();
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

                            this.mainCategoryBank.Add(mainQ);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Hubo error al leer la linea {contador} del archivo MainQuestions.");
                            throw;
                        }
                    }
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
            mixedCategoryBank = new List<MixedCategory>();
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

                            this.mixedCategoryBank.Add(mixedQ);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Hubo error al leer la linea {contador} del archivo MixedQuestions.");
                            throw;
                        }

                    }
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
            specificCategoryBank = new List<SpecificCategory>();
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

                            this.specificCategoryBank.Add(specificCat);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Hubo error al leer la linea {contador} del archivo SpecificQuestions.");
                            throw;
                        }
                    }
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
            initialQuestionsBank = new List<InitialQuestion>();
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

                            this.initialQuestionsBank.Add(initialQ);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Hubo error al leer la linea {contador} del archivo InitialQuestions.");
                            throw;
                        }                        
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Algo salio mal con el archivo. No se pudo abrir o encontrar.");
                throw;
            }
        }

        public void UploadFiles()
        {
            ReadInitialQuestions(@"..\..\Assets\InitialQuestions.txt");
            ReadMainCategories(@"..\..\Assets\MainCategories.txt");
            ReadMixedCategories(@"..\..\Assets\MixedQuestions.txt");
            ReadSpecificCategories(@"..\..\Assets\SpecificQuestions.txt");
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
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"Hubo error al leer la linea {contador} del archivo.");
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