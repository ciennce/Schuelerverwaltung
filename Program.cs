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
                var table1 = new Table(new ColumnHeader[]
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
                    table1.AddRow(shortId, s.Vorname, s.Nachname, s.Klasse);
                }
                
                Console.WriteLine(table1.ToString());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Gefundene Einträge: {ergebnisse.Count()}");
                Console.ResetColor();
            }

            Console.WriteLine("\nWen wollen Sie einsehen?:");

            String schuelerNotenFaecherEinsehen = Console.ReadLine();

            var ergebnisse1 = manager.Suche(schuelerNotenFaecherEinsehen);

            var headers = new ColumnHeader[] {
                new ColumnHeader("Fach"),
                new ColumnHeader("Note"),
            };

            var table = new Table(headers);

            /// Noch Fehler vorhanden. Wenn sich etwas doppelt bei der eingabe werden die Noten und Fächer von beiden Schülern angezeigt.
            /// Es wird nicht unterschieden welcher Schüler gemeint ist. Es werden die Noten und Fächer von beiden Schülern angezeigt.

            foreach (var s in ergebnisse1)
            {
                Console.WriteLine($"Noten und Fächer von {s.Vorname} {s.Nachname}:");
                table.AddRow(nameof(s.Mathematik), s.Mathematik);
                table.AddRow(nameof(s.Deutsch), s.Deutsch);
                table.AddRow(nameof(s.Englisch), s.Englisch);
                table.AddRow(nameof(s.Biologie), s.Biologie);
                table.AddRow(nameof(s.Geschichte), s.Geschichte);
                table.AddRow(nameof(s.Kunst), s.Kunst);
                table.AddRow(nameof(s.Informatik), s.Informatik);
                table.AddRow(nameof(s.Sport), s.Sport);
                table.AddRow(nameof(s.Musik), s.Musik);
                table.AddRow(nameof(s.Physik), s.Physik);
                table.AddRow(nameof(s.Chemie), s.Chemie);
                table.AddRow(nameof(s.Sozialwissenschaften), s.Sozialwissenschaften);
                table.AddRow(nameof(s.Französisch), s.Französisch);
                table.AddRow(nameof(s.Latein), s.Latein);
                table.AddRow(nameof(s.Spanisch), s.Spanisch);
                table.AddRow(nameof(s.Philosophie), s.Philosophie);
                table.AddRow(nameof(s.KatholischeReligion), s.KatholischeReligion);
                table.AddRow(nameof(s.EvangelischeReligion), s.EvangelischeReligion);
                table.AddRow(nameof(s.IslamischeReligion), s.IslamischeReligion);
                table.AddRow(nameof(s.Literatur), s.Literatur);
                Console.WriteLine();
                Console.WriteLine();


            }

            Console.WriteLine(table.ToString());

            Console.ReadKey(true);
        }



        static void SchuelerHinzufuegen()
        {
            Console.Clear();
            Console.WriteLine("=== NEUEN SCHÜLER ANLEGEN ===");

            /// Ein neues Schueler-Objekt erstellen
            Schueler s = new Schueler();

            Console.Write("Vorname: ");
            s.Vorname = Console.ReadLine();

            Console.Write("Nachname: ");
            s.Nachname = Console.ReadLine();

            Console.Write("Klasse (z.B. 10A): ");
            s.Klasse = Console.ReadLine();

            /// Noten abfragen (Beispiel für die wichtigsten Fächer)
            Console.WriteLine("\nNoten eingeben (leer lassen, falls nicht belegt):");

            Console.Write("Mathematik: ");
            s.Mathematik = Console.ReadLine();

            Console.Write("Deutsch: ");
            s.Deutsch = Console.ReadLine();

            Console.Write("Englisch: ");
            s.Englisch = Console.ReadLine();

            Console.Write("Informatik: ");
            s.Informatik = Console.ReadLine();

            /// Den fertigen Schüler an den Manager übergeben
            manager.Add(s);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSchüler erfolgreich gespeichert!");
            Console.ResetColor();

            Console.WriteLine("Drücke eine Taste, um zum Menü zurückzukehren...");
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
