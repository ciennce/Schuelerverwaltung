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

        public IEnumerable<Schueler> GetAll()
        {
            return repository.Read();
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

        public void Add(Schueler neuerSchueler)
        {
            repository.Insert(neuerSchueler);
        }

        public void Delete(string idEingabe)
        {
            repository.Delete(idEingabe);
        }

        public void Update(Schueler aktualisiereSchueler)
        {
            repository.Update(aktualisiereSchueler);
        }
    }
}