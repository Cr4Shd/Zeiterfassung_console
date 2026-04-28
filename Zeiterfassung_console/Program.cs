using System;
using System.IO;


namespace Zeiterfassung_console
{
    class Program
    {
        static bool theend = false;
        public enum MenuItemsSum
        {
            Zeiten_einpflegen = 0,
            Drucke_Zeiten = 1,
            Programm_Ende = 2
        }
        public MenuItemsSum MenuItems { get; set; }
        static void Main(string[] args)
        {
            do
            {
                bool parse;
                Console.Title = "Zeiterfassung";
                Console.WriteLine("Willkommen zur Zeiterfassung!\n");
                Console.WriteLine("Was möchten Sie tun?");
                PrintMenuItems();
                Console.WriteLine("Bitte wählen Sie aus...");
                var x = Console.ReadLine();
                var lolo = Int32.Parse(x);

                switch (lolo)
                {
                    case 1:
                        SpeichereZeitenAlsTextDatei();
                        break;
                    case 2:
                        Drucke_Zeiten();
                        break;
                    case 3:
                        Console.WriteLine("Programm wird beendet...");
                        theend = true;
                        break;
                    default:
                        break;
                }
            } while (!theend);
        }

        /// <summary>
        /// Druckt das Menü zum Start
        /// </summary>
        public static void PrintMenuItems()
        {
            string[] items = new string[3];
            for (int i = 0; i < items.Length; i++)
            {
                
                Console.WriteLine($"{i+1}: {(MenuItemsSum)i}");
            }
        }

        #region ObjektOrientierung
        /// <summary>
        /// Erfasst Start und Endzeit und bereitet alles Vor zum Speichern vor. Zum Speichern wird ein Objekt genutzt!
        /// </summary>
        public static ZeitObjekt SpeicherVorbereitungAlsObjekt()
        {
            DateTime nw = DateTime.Now;
            Console.WriteLine($"Heute ist der {nw}");
            Console.WriteLine("Wann wurde angefangen?");
            string? start = Console.ReadLine();
            Console.WriteLine("Wann ist Ende?");
            string? end = Console.ReadLine();
            ZeitObjekt ze = new(start, end);
            return ze;
        }

        #endregion 


        /// <summary>
        /// Erfasst Start und Endzeit und bereitet alles Vor zum Speichern vor.
        /// </summary>
        public static void SpeichereZeitenAlsTextDatei()
        {
            // Ein DateTime Objekt erzeugen
            DateTime nw = DateTime.Now;
            
            Console.WriteLine($"Heute ist der {nw}");
            Console.WriteLine("Wann wurde angefangen?");
            //das ? am Ende von "string" bedeutet, das dieser String auch null sein kann (und darf!)
            string? start = Console.ReadLine();
            Console.WriteLine("Wann ist Ende?");
            // nochmal eine nullable string
            string? end = Console.ReadLine();

            //Erstelle dir eine Enumeration von strings (als Array)
            string[] lines = { "=========================", $"Datum:{nw}", $"Beginn:{start}", $"Ende:{end}", "=========================\n"};

            // Kläre den Pfad, auf welchem du später Speichern möchtest
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // Hänge den Dateinamen an den Pfad an
            string comboPath = Path.Combine(docPath, "ZeitenVonNico.txt");

            try
            {
                if (!File.Exists(comboPath))
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "ZeitenVonNico.txt")))
                    {
                        foreach (string line in lines)
                            outputFile.WriteLine(line);
                    }
                    Console.WriteLine($"Zeiten eingetragen! Die Datei ist unter {docPath} ZeitenVonNico.txt zu finden.");
                }
                else
                {
                    Console.WriteLine("Datei existiert schon! Schreibe Änderungen in bestehende Datei!");
                    File.AppendAllLines(Path.Combine(docPath, "ZeitenVonNico.txt"), lines);
        
                }
            }
            catch
            {
                Console.WriteLine("Da ist scheinbar irgendetwas schief gelaufen... :(");
            }

            Console.WriteLine("Alle Zeiten wurden geschrieben - kehre in Hauptmenü zurück...");
        }

        
        public static void SchreibeZeitenInDateiObjekt()
        {
            
        }

        public static void Drucke_Zeiten()
        {
            Console.Clear();
            Console.WriteLine("Zeiten werden gedruckt...");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pathFull = path + "\\ZeitenVonNico.txt";
            var x = File.ReadAllLines(pathFull);
            foreach (string line in x)
            {
                Console.WriteLine(line);
            }
        }
    }
}
