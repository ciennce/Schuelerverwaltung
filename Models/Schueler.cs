namespace Schuelerverwaltung.Models
{
    /// <summary>
    /// Diese Klasse repräsentiert einen Schüler in der Schülerverwaltung. 
    /// Sie enthält Informationen wie Name, Alter, Klasse und andere relevante Daten, die für die Verwaltung von Schülern erforderlich sind.
    /// </summary>
    public class Schueler
    {
        /// <summary>
        /// Eindeutige Identifikationsnummer für den Schüler. 
        /// Diese ID wird automatisch generiert, um sicherzustellen, dass jeder Schüler eine einzigartige Kennung hat.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Vorname des Schülers.
        /// </summary>
        public string Vorname { get; set; }

        /// <summary>
        /// Nachname des Schülers.
        /// </summary>
        public string Nachname { get; set; }

        /// <summary>
        /// Klasse, in der der Schüler eingeschrieben ist.
        /// </summary>
        public string Klasse { get; set; }

        /// Notenschnitt des Schülers.
        
        public int Notenschnitt { get; set; }
        
        public String Faecher { get; set; }
    }
}
