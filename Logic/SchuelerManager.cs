using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schuelerverwaltung.Models;
using System.IO;
using System.Text.Json;

namespace Schuelerverwaltung.Logic
{
    public class SchuelerManager
    {
        
        private List<Schueler> schuelerListe = new List<Schueler>();
        private readonly string dateiPfad = "schueler.json";

        public SchuelerManager()
        {
            // Versuch die Daten zu laden
            LadeDaten();
        }

        private void SpeichereDaten()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true }; 
                string json = JsonSerializer.Serialize(schuelerListe, options);
                File.WriteAllText(dateiPfad, json);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Fehler beim Speichern: {exception.Message}");
            }
        }

        private void LadeDaten()
        {
            if (File.Exists(dateiPfad))
            {                
             string json = File.ReadAllText(dateiPfad);
             schuelerListe = JsonSerializer.Deserialize<List<Schueler>>(json) ?? new List<Schueler>();
            }
            else
            {
                // Beispiel-Daten nur hinzufügen, wenn noch keine Datei existiert
                schuelerListe.Add(new Schueler { Vorname = "Max", Nachname = "Mustermann", Klasse = "10A", Mathematik = "2", Deutsch = "2+", Englisch = "3-", Biologie = "4", Geschichte = "3" });
                schuelerListe.Add(new Schueler { Vorname = "Laura", Nachname = "Schmidt", Klasse = "10C", Mathematik = "1", Deutsch = "2", Englisch = "2+", Biologie = "4", Geschichte = "3" });
                schuelerListe.Add(new Schueler { Vorname = "Tim", Nachname = "Reuter", Klasse = "5F", Mathematik = "4", Deutsch = "5", Englisch = "2", Biologie = "4", Geschichte = "3" });

                SpeichereDaten();
            }
        }

        public IEnumerable<Schueler> GetAll()
        {
            return schuelerListe;
        }


        //Suche eines Schülers nach Keywords in Vorname, Nachname oder Klasse
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

        public void Add(Schueler neuerSchueler)
        {
            schuelerListe.Add(neuerSchueler);
            // Nach jedem Hinzufügen speichern
            SpeichereDaten();
        }

        public void Delete(string idEingabe)
        {
            // Sucht den Schüler, dessen ID mit der Eingabe beginnt.
            var schueler = schuelerListe.FirstOrDefault(s => s.Id.ToString().StartsWith(idEingabe, StringComparison.OrdinalIgnoreCase));

            if (schueler != null)
            {
                schuelerListe.Remove(schueler);

                // JSON wird aktualisiert, nachdem der Schüler gelöscht wurde
                string text = JsonSerializer.Serialize(schuelerListe);
                File.WriteAllText("daten.json", text);
            }
        }


    }
}