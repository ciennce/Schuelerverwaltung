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
            Console.WriteLine("Hinweis: Suche nach Vorname, Nachname oder Klasse möglich.\n Alle Anzeigen: [ENTER]\n");
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

            Console.WriteLine("\nWen wollen Sie einsehen? (Keiner = ENTER):");

            String schuelerNotenFaecherEinsehen = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(schuelerNotenFaecherEinsehen))
            {
                Console.WriteLine("Keine Eingabe erkannt. Rückkehr zum Hauptmenü...");
                Console.ReadKey(true);
                return;
            }
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


            Console.WriteLine("Zurück zum Hauptmenü: [ENTER]\n\nWeiter: [ANY]\n");
            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                return;
            }

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

            Console.Write("Biologie: ");
            s.Informatik = Console.ReadLine();

            Console.Write("Geschichte: ");
            s.Geschichte = Console.ReadLine();

            Console.Write("Kunst: ");
            s.Kunst = Console.ReadLine();

            Console.Write("Informatik: ");
            s.Informatik = Console.ReadLine();

            Console.Write("Sport: ");
            s.Sport = Console.ReadLine();

            Console.Write("Musik: ");
            s.Musik = Console.ReadLine();

            Console.Write("Physik: ");
            s.Physik = Console.ReadLine();

            Console.Write("Chemie: ");
            s.Chemie = Console.ReadLine();

            Console.Write("Sozialwissenschaften: ");
            s.Sozialwissenschaften = Console.ReadLine();

            Console.Write("Französisch: ");
            s.Französisch = Console.ReadLine();

            Console.Write("Latein: ");
            s.Latein = Console.ReadLine();

            Console.Write("Spanisch: ");
            s.Spanisch = Console.ReadLine();

            Console.Write("Philosophie: ");
            s.Philosophie = Console.ReadLine();

            Console.Write("Katholische Religion: ");
            s.KatholischeReligion = Console.ReadLine();

            Console.Write("Evangelische Religion: ");
            s.EvangelischeReligion = Console.ReadLine();

            Console.Write("Islamische Religion: ");
            s.IslamischeReligion = Console.ReadLine();

            Console.Write("Literatur: ");
            s.Literatur = Console.ReadLine();

            /// Den fertigen Schüler an den Manager übergeben
            manager.Add(s);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSchüler erfolgreich gespeichert!");
            Console.ResetColor();

            Console.WriteLine("Drücke eine Taste, um zum Menü zurückzukehren...(ENTER)");
            Console.ReadKey(true);
        }
        static void SchuelerBearbeiten() 
        {
            Console.Clear();
            Console.WriteLine("=== SCHÜLER BEARBEITEN ===");
            Console.Write("Geben Sie die ID (oder den Anfang) des Schülers ein: ");
            string idSuche = Console.ReadLine();

            //Den Schüler finden (wir nutzen die ID-Logik aus Delete)
            var schueler = manager.GetAll().FirstOrDefault(s => s.Id.ToString().StartsWith(idSuche, StringComparison.OrdinalIgnoreCase)); //hilfe von KI bekommen.

            if (schueler == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Schüler wurde nicht gefunden.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nBearbeite: {schueler.Vorname} {schueler.Nachname}");
            Console.WriteLine("Hinweis: ENTER drücken, um aktuellen Wert zu behalten.\n");

            //Hilfsfunktion für die Eingabe
            string UpdateFeld(string name, string aktuellerWert)
            {
                Console.Write($"{name} [{aktuellerWert}]: ");
                string eingabe = Console.ReadLine();
                return string.IsNullOrWhiteSpace(eingabe) ? aktuellerWert : eingabe;
            }

            //Daten aktualisieren
            schueler.Vorname = UpdateFeld("Vorname", schueler.Vorname);
            schueler.Nachname = UpdateFeld("Nachname", schueler.Nachname);
            schueler.Klasse = UpdateFeld("Klasse", schueler.Klasse);

            //Noten aktualisieren

            Console.WriteLine("\n--- Noten ---");
            schueler.Mathematik = UpdateFeld("Mathematik", schueler.Mathematik);
            schueler.Deutsch = UpdateFeld("Deutsch", schueler.Deutsch);
            schueler.Englisch = UpdateFeld("Englisch", schueler.Englisch);
            schueler.Biologie = UpdateFeld("Biologie", schueler.Biologie);
            schueler.Geschichte = UpdateFeld("Geschichte", schueler.Geschichte);
            schueler.Kunst = UpdateFeld("Kunst", schueler.Kunst);
            schueler.Informatik = UpdateFeld("Informatik", schueler.Informatik);
            schueler.Sport = UpdateFeld("Sport", schueler.Sport);
            schueler.Musik = UpdateFeld("Musik", schueler.Musik);
            schueler.Physik = UpdateFeld("Physik", schueler.Physik);
            schueler.Chemie = UpdateFeld("Chemie", schueler.Chemie);
            schueler.Sozialwissenschaften = UpdateFeld("Sozialwissenschaften", schueler.Sozialwissenschaften);
            schueler.Französisch = UpdateFeld("Französisch", schueler.Französisch);
            schueler.Latein = UpdateFeld("Latein", schueler.Latein);
            schueler.Spanisch = UpdateFeld("Spanisch", schueler.Spanisch);
            schueler.Philosophie = UpdateFeld("Philosophie", schueler.Philosophie);
            schueler.KatholischeReligion = UpdateFeld("Katholische Religion", schueler.KatholischeReligion);
            schueler.EvangelischeReligion = UpdateFeld("Evangelische Religion", schueler.EvangelischeReligion);
            schueler.IslamischeReligion = UpdateFeld("Islamische Religion", schueler.IslamischeReligion);
            schueler.Literatur = UpdateFeld("Literatur", schueler.Literatur);
            schueler.Notenschnitt = int.TryParse(UpdateFeld("Notenschnitt", schueler.Notenschnitt.ToString()), out int ns) ? ns : schueler.Notenschnitt;


            manager.Update(schueler);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nÄnderungen erfolgreich gespeichert!");
            Console.ResetColor();
            Console.ReadKey(true);
        }
        static void SchuelerLoeschen()
        {
            Console.Clear();
            Console.WriteLine("=== SCHÜLER LÖSCHEN ===");
            Console.Write("Geben Sie die ID (oder den Anfang der ID) ein: ");
            string id = Console.ReadLine();

            // Lösch-Befehl im Manager aufrufen
            manager.Delete(id);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nDer Schüler mit der ID '{id}' wurde (falls gefunden) gelöscht.");
            Console.ResetColor();

            Console.WriteLine("\nDrücken Sie eine Taste...");
            Console.ReadKey(true);
        }


    }
}
