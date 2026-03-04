using BetterConsoleTables;
using Schuelerverwaltung.Models;
using System.Data.Common;
using System.Drawing;

namespace Schuelerverwaltung
{
    using Schuelerverwaltung.Logic;
    using System;

    class Program
    {
        /// <summary>
        /// Manager-Instanz, die die gesamte Logik für die Schülerverwaltung enthält.
        /// </summary>
        static SchuelerManager manager = new SchuelerManager();

        static void Main(string[] args)
        {
            bool programmLaeuft = true;

            while (programmLaeuft)
            {
                ZeigeHauptmenue();

                /// Liest die Benutzereingabe für die Menüauswahl. Die Eingabe wird nicht in der Konsole angezeigt (true-Parameter).
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.KeyChar)
                {
                    case '1':
                        KonsoleVorbereiten("SCHÜLER EINSEHEN");
                        /// Schüler einsehen
                        SchuelerEinsehen();
                        break;
                    case 'q': /// Beenden (Das Programm)
                        programmLaeuft = false;
                        break;
                }
            }
        }

        static void ZeigeHauptmenue()
        {
            Console.Clear();
            Console.WriteLine("=== SCHÜLERVERWALTUNG v1.0 ===");
            var headers = new ColumnHeader[] {
                new ColumnHeader("Einsehen [1]"),
                new ColumnHeader("Hinzufügen [2]"),
                new ColumnHeader("Bearbeiten [3]"),
                new ColumnHeader("Löschen [4]"),
                new ColumnHeader("Beenden [q]")
            };
            var table = new Table(headers);


            Console.WriteLine(table.ToString());
        }

        static void KonsoleVorbereiten(string titel)
        {
            Console.Clear();
            Console.WriteLine($"--- {titel} ---");
        }

        static void SchuelerEinsehen()
        {
            Console.WriteLine("Schüler einsehen");
            Console.ReadKey(true);
        }

        //static void
    }
}
