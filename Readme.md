# Vorgehensweise

1. Anlage eines neuen git-Repository auf GitHub wegen der besseren Übersicht und Dokumentation sowie nachvolziehbaren Änderungen. Es ist nicht möglich, die Änderungen in einem bestehenden Repository zu verfolgen, da es sich um eine Migration handelt und die Historie der Dateien verloren geht.
2. Installation von Visual Studio 2026 Community Edition.
3. Projektstruktur entwerfen

SchuelerVerwaltung/
├── Models/
│   └── Schueler.cs          // Das Datenmodell (Klasse)
├── Data/
│   └── JsonRepository.cs    // Logik für CRUD & JSON-Speicherung
├── Logic/
│   └── SchuelerManager.cs   // Suchlogik und Validierung
└── Program.cs               // Benutzermenü und Konsolen-Interaktion

4. NuGet Package hinzugefügt.
5. Modellklasse Schueler.cs erstellt.
6. Logic-Klasse SchuelerManager.cs erstellt.
7. Funktionalität für die Verwaltung von Schülern implementiert (Hinzufügen, Anzeigen, Suchen, Löschen) Läuft noch nicht einwandfrei. Keine Speicherung vorhanden.
8. Testen der Funktionen in Program.cs.
9. Implementierung der Funktion "Einsehen" der Schülerliste in Program.cs.
10.Implementierung der Funktion weiteres Einsehen der Fächer eines Schülers in Program.cs.
11. Implentierung der Funktion "Hinzufügen" eines Schülers in Program.cs.
12. Json Speicherung.