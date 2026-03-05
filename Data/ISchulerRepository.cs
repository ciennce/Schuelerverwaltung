using Schuelerverwaltung.Models;

namespace Schuelerverwaltung.Data
{
    /// <summary>
    /// CRUD-Oprationen für Schüler
    /// </summary>
    internal interface ISchulerRepository
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="schueler"></param>
        void Insert(Schueler schueler);

        /// <summary>
        /// Read
        /// </summary>
        /// <returns></returns>
        List<Schueler> Read();

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="schueler"></param>
        void Update(Schueler schueler);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="idEingabe"></param>
        void Delete(string idEingabe);
    }
}
