# 🎓 School Management System

Moderan sistem za upravljanje školskim podacima razvijen u ASP.NET MVC tehnologiji.

## 📋 Opis projekta

School Management System je web aplikacija koja omogućava efikasno upravljanje školskim podacima uključujući studente, kurseve, nastavnike i ostale školske aktivnosti.

## ✨ Funkcionalnosti

- **📊 Dashboard** - Pregled ključnih statistika sistema
- **👨‍🎓 Upravljanje studentima** - Dodavanje, uređivanje i pregled studenata
- **📚 Upravljanje kursevima** - Kreiranje i organizacija kurseva
- **👨‍🏫 Upravljanje nastavnicima** - Evidencija nastavnog osoblja
- **📝 Upravljanje upisima** - Praćenje upisa studenata na kurseve
- **🔐 Autentifikacija** - Sigurno prijavljivanje korisnika
- **📱 Responzivni dizajn** - Optimizovano za sve uređaje

![image](https://github.com/user-attachments/assets/e7dfffae-0c59-49f7-8505-28dec3b6b6f9)

## 🛠️ Tehnologije

- **Backend**: ASP.NET MVC
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap
- **Baza podataka**: SQL Server / Entity Framework
- **Autentifikacija**: ASP.NET Identity

## 📋 Zahtevi

- Visual Studio 2019/2022
- .NET Framework 4.7.2+ ili .NET Core 3.1+
- SQL Server

## 🚀 Pokretanje projekta

### 1. Baza podataka

Ažurirajte connection string u `appsettings.json` ili `web.config`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SchoolManagementDB;Trusted_Connection=true;"
  }
}
```

### 2. Migracije

Package Manager Console:
```bash
Add-Migration InitialCreate
Update-Database
```

Ili .NET CLI:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 3. Pokretanje

Visual Studio: `F5` ili `Ctrl+F5`

.NET CLI: `dotnet run`

Aplikacija će biti dostupna na `https://localhost:5001`

## 📁 Struktura projekta

```
SchoolManagementSystem/
├── Controllers/          # MVC kontroleri
├── Models/              # Modeli podataka
├── Views/               # Razor view-ovi
├── wwwroot/             # Statički fajlovi
├── Data/                # DbContext i migracije
├── Services/            # Biznis logika
└── Migrations/          # Entity Framework migracije
```

