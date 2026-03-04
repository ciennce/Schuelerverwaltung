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