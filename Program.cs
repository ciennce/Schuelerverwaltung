using BetterConsoleTables;
using Schuelerverwaltung.Models;
using System.Data.Common;
using System.Drawing;

namespace Schuelerverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var maxMustermann = new Schueler
            {
                Vorname = "Max",
                Nachname = "Mustermann",
            };

            var headers = new ColumnHeader[]
            {
                new ColumnHeader("Vorname"),
                new ColumnHeader("Nachname"),
            };

            var table = new Table(headers);
            // table.Config = TableConfiguration

            table.AddRow(maxMustermann.Nachname, maxMustermann.Vorname);

            Console.WriteLine(table.ToString());
        }
    }
}
