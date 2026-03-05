using BetterConsoleTables;
using Schuelerverwaltung.Data;
using Schuelerverwaltung.Logic;

namespace Schuelerverwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Manager-Instanz, die die gesamte Logik für die Schülerverwaltung enthält.
            /// </summary>
            SchuelerManager manager = new SchuelerManager(new JsonRepository());

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
                        manager.SchuelerEinsehen();
                        break;

                    case '2':
                        KonsoleVorbereiten("SCHÜLER HINZUFÜGEN");
                        /// Schüler hinzufügen
                        manager.SchuelerHinzufuegen();
                        break;

                    case '3':
                        KonsoleVorbereiten("SCHÜLER BEARBEITEN");
                        /// Schüler bearbeiten
                        manager.SchuelerBearbeiten();
                        break;

                    case '4':
                        KonsoleVorbereiten("SCHÜLER LÖSCHEN");
                        /// Schüler löschen
                        manager.SchuelerLoeschen();
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
    }
}
