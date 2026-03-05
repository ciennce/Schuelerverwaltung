using BetterConsoleTables;
using Schuelerverwaltung.Data;
using Schuelerverwaltung.Models;

namespace Schuelerverwaltung.Logic
{
    class SchuelerManager
    {
        private readonly JsonRepository repository;

        public SchuelerManager(JsonRepository repository)
        {
            this.repository = repository;
        }

        public void SchuelerEinsehen()
        {
            Console.Clear();
            Console.WriteLine("=== SCHÜLER-SUCHE ===");
            Console.WriteLine("Hinweis: Suche nach Vorname, Nachname oder Klasse möglich.\n Alle Anzeigen: [ENTER]\n");
            Console.Write("Suchbegriff eingeben: ");

            string input = Console.ReadLine();

            /// Den Manager nach Ergebnissen fragen
            var ergebnisse = Suche(input);

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
                    new ColumnHeader("Klasse"),
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

            string schuelerNotenFaecherEinsehen = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(schuelerNotenFaecherEinsehen))
            {
                Console.WriteLine("Keine Eingabe erkannt. Rückkehr zum Hauptmenü...");
                Console.ReadKey(true);
                return;
            }

            var ergebnisse1 = Suche(schuelerNotenFaecherEinsehen);

            /// Noch Fehler vorhanden. Wenn sich etwas doppelt bei der eingabe werden die Noten und Fächer von beiden Schülern angezeigt.
            /// Es wird nicht unterschieden welcher Schüler gemeint ist. Es werden die Noten und Fächer von beiden Schülern angezeigt.
            foreach (var s in ergebnisse1)
            {
                SchuelerAnzeigen(s);
            }

            Console.ReadKey(true);
        }

        public void SchuelerHinzufuegen()
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
            repository.Insert(s);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSchüler erfolgreich gespeichert!");
            Console.ResetColor();

            Console.WriteLine("Drücke eine Taste, um zum Menü zurückzukehren...(ENTER)");
            Console.ReadKey(true);
        }

        public void SchuelerBearbeiten()
        {
            Console.Clear();
            Console.WriteLine("=== SCHÜLER BEARBEITEN ===");
            Console.Write("Geben Sie die ID (oder den Anfang) des Schülers ein: ");
            string idSuche = Console.ReadLine();

            //Den Schüler finden (wir nutzen die ID-Logik aus Delete)
            var schueler = repository
                .Read()
                .FirstOrDefault(s => s.Id.ToString().StartsWith(idSuche, StringComparison.OrdinalIgnoreCase)); //hilfe von KI bekommen.

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

            repository.Update(schueler);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nÄnderungen erfolgreich gespeichert!");
            Console.ResetColor();
            Console.ReadKey(true);
        }

        //Suche eines Schülers nach Keywords in Vorname, Nachname oder Klasse
        public IEnumerable<Schueler> Suche(string query)
        {
            var schuelerListe = repository.Read();

            if (string.IsNullOrWhiteSpace(query))
                return schuelerListe;

            query = query.Trim();
            return schuelerListe.Where(s =>
                (!string.IsNullOrEmpty(s.Vorname) && s.Vorname.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(s.Nachname) && s.Nachname.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(s.Klasse) && s.Klasse.Contains(query, StringComparison.OrdinalIgnoreCase))
            );
        }

        public void SchuelerLoeschen()
        {
            Console.Clear();
            Console.WriteLine("=== SCHÜLER LÖSCHEN ===");
            Console.Write("Geben Sie die ID (oder den Anfang der ID) ein: ");
            string id = Console.ReadLine();

            // Lösch-Befehl im Manager aufrufen
            repository.Delete(id);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nDer Schüler mit der ID '{id}' wurde (falls gefunden) gelöscht.");
            Console.ResetColor();

            Console.WriteLine("\nDrücken Sie eine Taste...");
            Console.ReadKey(true);
        }

        private void SchuelerAnzeigen(Schueler s)
        {
            var headers = new ColumnHeader[]
            {
                new ColumnHeader("Fach"),
                new ColumnHeader("Note"),
            };

            var table = new Table(headers);

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
            Console.WriteLine(table.ToString());
        }
    }
}