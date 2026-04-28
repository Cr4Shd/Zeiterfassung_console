using System;
using System.IO;


namespace Zeiterfassung_console
{
    class Program
    {
        public enum MenuItemsSum
        {
            Zeiten_einpflegen = 0,
            Drucke_Zeiten = 1
        }
        public MenuItemsSum MenuItems { get; set; }
        static void Main(string[] args)
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
                default:
                    break;
            }

        }

        /// <summary>
        /// Druckt das Menü zum Start
        /// </summary>
        public static void PrintMenuItems()
        {
            string[] items = new string[2];
            for (int i = 0; i < items.Length; i++)
            {
                
                Console.WriteLine($"{i+1}: {(MenuItemsSum)i}");
            }
        }
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
        /// <summary>
        /// Erfasst Start und Endzeit und bereitet alles Vor zum Speichern vor.
        /// </summary>
        public static void SpeichereZeitenAlsTextDatei()
        {
            DateTime nw = DateTime.Now;
            Console.WriteLine($"Heute ist der {nw}");
            Console.WriteLine("Wann wurde angefangen?");
            string? start = Console.ReadLine();
            Console.WriteLine("Wann ist Ende?");
            string? end = Console.ReadLine();

            //Erstelle dir eine Liste von string (als Array)
            string[] lines = {$"Beginn:{start}", $"Ende:{end}", $"Datum:{nw}", "========================="};

            // Kläre den Pfad, auf welchem du später Speichern möchtest
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

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
                    Console.WriteLine($"Zeiten eingetragen! Die Datei ist unter {docPath} ZeitenVonNico.txt");
                }
                else
                {
                    Console.WriteLine("Datei existiert schon! Schreibe Änderungen in bestehende Datei!");
                    File.AppendAllLines(Path.Combine(docPath, "ZeitenVonNico.txt"), lines);
        
                }
            }
            catch
            {
                Console.WriteLine("Da ist scheinbar irgendetwas schief gelaufen...");
            }

            Console.WriteLine("Alle Zeiten wurden geschrieben!");
        }

        
        public void SchreibeZeitenInDateiObjekt()
        {
            
        }

        public void PrintTime()
        {

        }
    }
}
