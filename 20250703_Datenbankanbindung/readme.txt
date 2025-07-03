# 🧱 Lagerverwaltungs-App – Datenbankanbindung in C#

## 💡 Projektbeschreibung
Diese Anwendung wurde im Rahmen der Selbstlernaufgabe umgesetzt. Ziel war es, eine Funktion aus einem bestehenden Python-Projekt (Produktübersicht mit Lagerbestand) als C#-Windows-Forms-Anwendung nachzubauen. 

Die App verbindet sich mit einer MySQL-Datenbank und ermöglicht:
- die Anzeige von Produktdetails (ID, Stein, Farbe, Lagerbestand, Preis),
- die Auswahl eines Produkts über ein Dropdown-Menü (ComboBox),
- die Ausgabe einer Warnung, wenn der Lagerbestand unter dem Meldebestand liegt.

## 🖥 Verwendete Technologien
- C# (.NET Framework / Windows Forms)
- MySQL
- Visual Studio
- MySql.Data (NuGet-Paket)

## 🔌 Datenbankstruktur
Verwendet werden folgende Tabellen:
- `produkte`
- `stein`
- `farbe`

Beziehungen:
- `produkte` enthält `SteinID` und `FarbID` als Fremdschlüssel
- Die Anzeige kombiniert die Informationen aus allen drei Tabellen

## 🧪 Funktionen
- Produktauswahl per ComboBox
- Detailanzeige im RichTextBox-Feld
- Prüfung auf Meldebestand (Standard: 40)
- Fehlerbehandlung bei Verbindungsproblemen

## 🔧 Setup
1. Projekt in Visual Studio öffnen.
2. Sicherstellen, dass `MySql.Data` über NuGet installiert ist.
3. Verbindungskette in `DBVerbindung.cs` anpassen, falls sich IP, Benutzer oder Passwort ändern.
4. Starten – Produkte werden automatisch geladen.

## 🧩 Reflexion

### ✅ Was hat gut funktioniert?
- Die Datenbankverbindung mit MySQL über `MySql.Data`.
- Die Implementierung der GUI mit Windows Forms.
- Die strukturierte Anzeige der Details mit Formatierung.

### ⚠️ Was lief stockend?
- Das Befüllen und Abfragen der ComboBox mit Produktnamen + IDs.
- Die SQL-Joins in C# sauber zu verbinden.
- Eventhandler im Designer korrekt zu binden.

### 🔄 Unterschiede zu Python:
| Python (tkinter)             | C# (Windows Forms)         |
|-----------------------------|----------------------------|
| Flexible GUI, aber mehr Handarbeit | Drag & Drop einfacher |
| Einfachere Datenbankanbindung mit sqlite3 | MySQL-Setup etwas aufwändiger |
| Weniger Codestruktur notwendig | C# zwingt zu sauberer Trennung (z. B. Klassen, Events) |

## 🔗 Weiteres
Branch: `csharp-db`  
Aufgabenstellung siehe [Selbstlernaufgabe: Datenbankanbindung in C#]

---

