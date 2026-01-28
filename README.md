[README.md](https://github.com/user-attachments/files/24923831/README.md)
# 🎬 KinowaRezerwacja – system rezerwacji miejsc w kinie

## 1. Opis projektu

Aplikacja **KinowaRezerwacja** jest webową aplikacją typu **CRUD**, stworzoną w technologii **ASP.NET Core MVC**, zaprojektowaną zgodnie z wzorcem architektonicznym **Model–View–Controller (MVC)**.

System umożliwia zarządzanie repertuarem kinowym, salami, seansami oraz rezerwacjami miejsc, z uwzględnieniem autoryzacji użytkowników, ról oraz trwałego zapisu danych w relacyjnej bazie danych.

Projekt wykorzystuje:
- **Entity Framework Core (Code First)**
- **ASP.NET Core Identity** do obsługi użytkowników i ról (Administrator, użytkownik, gość)  

---

## 2. Wymagania systemowe

- .NET SDK 8.0  
- SQL Server / SQL Server LocalDB  
- Visual Studio 2022 lub nowsze (W projekcie użyto najnowszej wersji VisualStudio 2026) 
- Przeglądarka internetowa

---

## 3. Instalacja i uruchomienie

Projekt można pobrać z repozytorium GitHub lub w formie archiwum ZIP.
https://github.com/kacpermajerski2002-dotcom/KinowaRezerwacja

Po pobraniu archiwum należy je rozpakować i otworzyć plik rozwiązania (.sln) w Visual Studio.

Aplikacja korzysta z bazy danych SQL Server.
Łańcuch połączenia znajduje się w pliku appsettings.json:

"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=aspnet-KinowaRezerwacja-70bfe875-7bd1-4cfe-93f2-5170e695a950;Trusted_Connection=True;MultipleActiveResultSets=true"
}

W razie potrzeby należy dostosować nazwę serwera SQL

Projekt nie wymaga ręcznego tworzenia bazy danych.
W Konsoli Menadżera Pakietów należy wykonać polecenie:

Update-Database

aby utworzyć bazę danych, wykonać migrację oraz utworzyć tabele aplikacyjne i tabel Identity.

Uruchomienie aplikacji nastepuję pod klawiszem **F5** w VisualStudio

---

## 4. Role użytkowników
Aplikacja rozróznia trzy typy użytkowników:

### Administrator
- zarządzanie filmami  
- zarządzanie salami  
- zarządzanie seansami  
- pełny dostęp do danych systemowych  

### Zalogowany użytkownik
- przegląd repertuaru  
- rezerwacja miejsc  
- podgląd własnych rezerwacji  
- anulowanie rezerwacji  

### Gość
- przegląd repertuaru  
- brak możliwości rezerwacji (w przypadku próby zarezerwowania miejsca - strona przenosi do panelu logowania)

### Stworzeni użytkownicy
- Admin: admin@kino.pl
h: Admin123!
- Pierwszy użytkownik testowy: user@test.pl
h: Test123!
- Drugi użytkownik testowy: s171917@uken.pl
h: Hs171918!
- (dodatkowo na prezentacji register nowego użytkownika w celu prezentacji poprawnego działania formularza)
(o danych: kacper@kacper.pl h: Kacper123!)

---

## 5. Funkcjonalności systemu

### Rezerwacje
- wizualny układ sali kinowej  
- oznaczenie miejsc wolnych i zajętych dla indywidualnych użytkowników  
- blokada wielokrotnej rezerwacji tego samego miejsca  
- przypisanie rezerwacji do zalogowanego użytkownika  

### Seanse
- lista seansów  
- szczegóły seansu (film, data, sala)  
- dostęp do rezerwacji miejsc  

### Filmy i sale (administrator)
- dodawanie, edycja i usuwanie  filmów oraz przydzielana do nich sal
- automatyczne generowanie miejsc w sali za pomocą pobierania rekordów z generowanej w bazie danych tabeli  

---

## 6. Walidacja danych

- **Data Annotations** – walidacja po stronie serwera  
- **jQuery Validation** – walidacja po stronie klienta  
- komunikaty walidacyjne w języku polskim  

---

## 7. Model danych

### Encje systemu
- `Movie`  
- `Hall`  
- `Seat`  
- `Seance`  
- `Reservation`  
- `ApplicationUser`  

### Relacje
- `Hall` → `Seats` (1:N)  
- `Movie` → `Seances` (1:N)  
- `Seance` → `Reservations` (1:N)  
- `Seat` → `Reservations` (1:N)  
- `User` → `Reservations` (1:N)  

---

## 8. Bezpieczeństwo

- **ASP.NET Core Identity**  
- role użytkowników  
- atrybuty autoryzacji:
  - `[Authorize]`
  - `[Authorize(Roles = "Admin")]`

Dostęp do funkcjonalności jest ograniczony zgodnie z rolą użytkownika.

---

## 9. Architektura projektu
Projekt został wykonany zgodnie z wzorcem MVC (Model–View–Controller):
- Model – klasy encji, walidacja, relacje,
- View – widoki Razor (.cshtml),
- Controller – logika aplikacji, obsługa żądań.
Dodatkowo w projekcie zastosowane zostały:
- Entity Framework Core (Code First),
- ASP.NET Core Identity (autoryzacja i role),
- Bootstrap (interfejs użytkownika). 
- Własny **ciemny motyw CSS** aby strona prezentowała się przyjemniej w odbiorze

Projekt został podzielony na warstwy zgodnie z zasadami MVC, co ułatwia rozwój, testowanie oraz utrzymanie aplikacji.

---
Autor: Kacper Majerski s171918
