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
                    case '2':
                        KonsoleVorbereiten("SCHÜLER HINZUFÜGEN");
                        /// Schüler hinzufügen
                        SchuelerHinzufuegen();
                        break;
                    case '3':
                        KonsoleVorbereiten("SCHÜLER BEARBEITEN");
                        /// Schüler bearbeiten
                        SchuelerBearbeiten();
                        break;
                    case '4':
                        KonsoleVorbereiten("SCHÜLER LÖSCHEN");
                        /// Schüler löschen
                        SchuelerLoeschen();
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
            Console.Clear();
            Console.WriteLine("=== SCHÜLER-SUCHE ===");
            Console.WriteLine("Hinweis: Suche nach Vorname, Nachname oder Klasse möglich.");
            Console.Write("Suchbegriff eingeben: ");

            string input = Console.ReadLine();

            /// Den Manager nach Ergebnissen fragen
            var ergebnisse = manager.Suche(input);

            Console.WriteLine(); 

            if (!ergebnisse.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Keine Schüler für '{input}' gefunden.");
                Console.ResetColor();
            }
            else
            {
                /// Tabelle mit BetterConsoleTables erstellen
                var table = new Table(new ColumnHeader[]
                {
                new ColumnHeader("ID"),
                new ColumnHeader("Vorname"),
                new ColumnHeader("Nachname"),
                new ColumnHeader("Klasse")
                });

                foreach (var s in ergebnisse)
                {
                    /// Wir zeigen nur den Anfang der GUID an, damit die Tabelle kompakt bleibt
                    string shortId = s.Id.ToString().Substring(0, 8);
                    table.AddRow(shortId, s.Vorname, s.Nachname, s.Klasse);
                }
                
                Console.WriteLine(table.ToString());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Gefundene Einträge: {ergebnisse.Count()}");
                Console.ResetColor();
            }

            Console.WriteLine("\nBeliebige Taste drücken für Menü...");
            Console.ReadKey(true);
        }



        static void SchuelerHinzufuegen()
        {
            Console.WriteLine("Schüler hinzufügen");
            Console.ReadKey(true);
        }

        static void SchuelerBearbeiten()
        {
            Console.WriteLine("Schüler bearbeiten");
            Console.ReadKey(true);
        }

        static void SchuelerLoeschen()
        {
            Console.WriteLine("Schüler löschen");
            Console.ReadKey(true);
        }


    }
}
