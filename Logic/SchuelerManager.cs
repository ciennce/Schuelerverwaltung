using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schuelerverwaltung.Models;

namespace Schuelerverwaltung.Logic
{
    public class SchuelerManager
    {
        private readonly List<Schueler> schuelerListe = new List<Schueler>();

        public SchuelerManager()
        {
            // Beispiel-Daten, damit beim Start schon etwas zum Suchen vorhanden ist.
            schuelerListe.Add(new Schueler { Vorname = "Max", Nachname = "Mustermann", Klasse = "10A" });
            schuelerListe.Add(new Schueler { Vorname = "Anna", Nachname = "Müller", Klasse = "9B" });
            schuelerListe.Add(new Schueler { Vorname = "Laura", Nachname = "Schmidt", Klasse = "10A" });
        }

        /// <summary>
        /// Liefert alle Schüler
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Schueler> GetAll()
        {
            return schuelerListe;
        }

        /// Einfache Suche: findet Schüler nach Vorname, Nachname oder Klasse (case-insensitive, Teilstring)
        public IEnumerable<Schueler> Suche(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return schuelerListe;

            query = query.Trim();
            return schuelerListe.Where(s =>
                (!string.IsNullOrEmpty(s.Vorname) && s.Vorname.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(s.Nachname) && s.Nachname.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(s.Klasse) && s.Klasse.Contains(query, StringComparison.OrdinalIgnoreCase))
            );
        }
    }
}
