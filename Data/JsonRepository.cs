using Schuelerverwaltung.Models;
using System.Text.Json;

namespace Schuelerverwaltung.Data
{
    /// <summary>
    /// CRUD-Operationen für Schüler, die in einer JSON-Datei gespeichert werden.
    /// </summary>
    internal class JsonRepository : ISchulerRepository
    {
        private const string dateiPfad = "schueler.json";

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="schueler"></param>
        public void Insert(Schueler schueler)
        {
            var schuelerListe = Read();

            schuelerListe.Add(schueler);

            Save(schuelerListe);
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <returns></returns>
        public List<Schueler> Read()
        {
            if (!File.Exists(dateiPfad))
            {
                File.Create(dateiPfad).Close();
            }

            string json = File.ReadAllText(dateiPfad);

            var schuelerListe = JsonSerializer.Deserialize<List<Schueler>>(json);
            if (schuelerListe == null)
            {
                return new List<Schueler>();
            }

            return schuelerListe;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="schueler"></param>
        public void Update(Schueler schueler)
        {
            var schuelerListe = Read();

            var index = schuelerListe.FindIndex(s => s.Id == schueler.Id);
            if (index < 0)
            {
                return;
            }

            schuelerListe[index] = schueler;

            Save(schuelerListe);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="idEingabe"></param>
        public void Delete(string idEingabe)
        {
            var schuelerListe = Read();

            // Sucht den Schüler, dessen ID mit der Eingabe beginnt.
            var schueler = schuelerListe.FirstOrDefault(s => s.Id.ToString().StartsWith(idEingabe, StringComparison.OrdinalIgnoreCase));

            if (schueler == null)
            {
                return;
            }

            schuelerListe.Remove(schueler);

            Save(schuelerListe);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schuelerListe"></param>
        private void Save(List<Schueler> schuelerListe)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(schuelerListe, options);
            File.WriteAllText(dateiPfad, json);
        }
    }
}
