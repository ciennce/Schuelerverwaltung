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
        public string Vorname { get; set; } = string.Empty;

        /// <summary>
        /// Nachname des Schülers.
        /// </summary>
        public string Nachname { get; set; } = string.Empty;

        /// <summary>
        /// Klasse, in der der Schüler eingeschrieben ist.
        /// </summary>
        public string Klasse { get; set; } = string.Empty;

        /// Notenschnitt des Schülers.

        public int Notenschnitt { get; set; }

        public string Faecher { get; set; } = string.Empty;


        // Fächer

        public string Mathematik { get; set; } = string.Empty;
        public string Deutsch { get; set; } = string.Empty;
        public string Englisch { get; set; } = string.Empty;
        public string Biologie { get; set; } = string.Empty;
        public string Geschichte { get; set; } = string.Empty;
        public string Kunst { get; set; } = string.Empty;
        public string Informatik { get; set; } = string.Empty;
        public string Sport { get; set; } = string.Empty;
        public string Musik { get; set; } = string.Empty;
        public string Physik { get; set; } = string.Empty;
        public string Chemie { get; set; } = string.Empty;
        public string Sozialwissenschaften { get; set; } = string.Empty;
        public string Französisch { get; set; } = string.Empty;
        public string Latein { get; set; } = string.Empty;
        public string Spanisch { get; set; } = string.Empty;
        public string Philosophie { get; set; } = string.Empty;
        public string KatholischeReligion { get; set; } = string.Empty;
        public string EvangelischeReligion { get; set; } = string.Empty;
        public string IslamischeReligion { get; set; } = string.Empty;
        public string Literatur { get; set; } = string.Empty;




    }
}
