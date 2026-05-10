# Proiect-Organizare-Evenimente---PAOO-C-
# Ticketa

Aplicatie desktop WinForms pentru organizare si vanzare bilete la evenimente. Port C# al unui prototip Retool ("Ticketa") cu baza de date PostgreSQL locala.

Proiect academic pentru cursul **PAOO** (Programare Avansata Orientata pe Obiecte).

---

## Cuprins

- [Stack tehnologic](#stack-tehnologic)
- [Roluri si functionalitati](#roluri-si-functionalitati)
- [Structura proiectului](#structura-proiectului)
- [Instalare si configurare](#instalare-si-configurare)
- [Initializare baza de date](#initializare-baza-de-date)
- [Conturi de test](#conturi-de-test)
- [Manual de utilizare](#manual-de-utilizare)
- [Capturi](#capturi)
- [Note de dezvoltare](#note-de-dezvoltare)

---

## Stack tehnologic

| Componenta | Tehnologie |
| --- | --- |
| Limbaj | C# 12 |
| Runtime | .NET 10 (Windows) |
| UI | WinForms |
| Bazade date | PostgreSQL 14+ |
| Driver DB | [Npgsql 9.0.3](https://www.npgsql.org/) |
| Hashing parole | [BCrypt.Net-Next 4.0.3](https://github.com/BcryptNet/bcrypt.net) |
| Generare PDF | [QuestPDF 2024.6.0](https://www.questpdf.com/) |
| QR code | [QRCoder 1.6.0](https://github.com/codebude/QRCoder) |

Cerinte minime pe masina utilizator:
- Windows 10 / 11
- .NET 10 Runtime (sau SDK)
- PostgreSQL 14 sau mai recent
- pgAdmin 4 (recomandat pentru rularea scripturilor SQL)

---

## Roluri si functionalitati

Aplicatia suporta **3 roluri** de utilizator. Rolul controleaza ce vede in sidebar si la ce pagini are acces.

### Client (`user`)

- **Acasa** - vede evenimentele apropiate, cele mai populare, etc.
- **Descopera evenimente** - cauta dupa nume, organizator, oras, tip, interval de date
- **Biletele mele** - lista comenzilor finalizate, cu QR code si export PDF per bilet
- **Cosul meu** - cosul de cumparaturi cu cantitati, total si checkout
- **Evenimente virtuale** - filtru dedicat pentru evenimente online
- **Profilul meu** - editare date personale + schimbare parola

### Manager (`manager`)

In plus fata de Client:
- **Creeaza eveniment** - formular completare detalii eveniment + upload poster + tipuri de bilete
- **Evenimentele mele** - lista evenimentelor proprii, cu acces la editare/stergere

### Admin (`admin`)

Acces dedicat la **Admin Dashboard**:

- **6 KPI cards** - total useri, useri suspendati, total evenimente, evenimente suspendate, bilete vandute, venit total
- **Tab Utilizatori** - tabel cu toti userii. Actiuni:
  - Suspendare cont (utilizatorul nu se mai poate autentifica)
  - Reactivare cont
  - Editare date (prenume, nume, email, telefon, data nasterii, companie)
  - Schimbare rol (`user` / `manager` / `admin`)
- **Tab Evenimente** - tabel cu toate evenimentele (inclusiv cele suspendate). Actiuni:
  - Suspendare eveniment (nu mai apare in listele publice)
  - Reactivare eveniment
  - Editare date eveniment (folosind acelasi UC ca managerul)
- **Tab Statistici** - 4 grafice bara:
  - Evenimente pe tip (fizic vs virtual)
  - Utilizatori pe rol
  - Top 5 evenimente dupa bilete vandute
  - Venit pe luna (ultimele 6 luni)

**Self-protect:** adminul nu se poate suspenda pe sine si nici nu isi poate retrograda propriul cont. Cand un cont suspendat incearca sa se logheze, primeste mesajul: *"Contul tau a fost suspendat. Te rugam sa contactezi administratorul."*

---

## Structura proiectului

Arhitectura **3-layer**: prezentare (UI/Forms/UserControls), business logic (BLL), data access (DAL).

```
Proiect_PAOO_Organizare_Evenimente/
├── Models/                      # Entitati de domeniu (POCO)
│   ├── Persoana.cs              # Clasa abstracta de baza
│   ├── Utilizator.cs            # Persoana cu cont (abstract)
│   ├── Client.cs                # Rol Client
│   ├── Manager.cs               # Rol Manager (cu Companie)
│   ├── Admin.cs                 # Rol Admin
│   ├── Eveniment.cs             # Eveniment + EsteSuspendat
│   ├── Bilet.cs                 # Tip de bilet asociat unui eveniment
│   ├── Cos.cs                   # Cos / comanda
│   ├── CosBilet.cs              # Linie din cos (bilet x cantitate)
│   ├── BiletDinCos.cs           # DTO afisare in UI
│   ├── Oras.cs                  # Lista de orase pre-populata
│   └── Enums.cs                 # TipEveniment, RolUtilizator + extensii
│
├── DAL/                         # Data Access Layer (Npgsql)
│   ├── DbConnectionFactory.cs   # Open() conexiune PostgreSQL
│   ├── DbInit.cs                # Verifica si initializeaza schema la pornire
│   ├── UserRepository.cs        # CRUD users + GetAll/SetSuspended/UpdateRol
│   ├── EvenimentRepository.cs   # CRUD evenimente + GetAllForAdmin/SetSuspended
│   ├── BiletRepository.cs       # CRUD bilete asociate evenimentelor
│   ├── CosRepository.cs         # Cos + Cos_Bilet (comenzi)
│   ├── OrasRepository.cs        # Lista orase
│   └── AdminStatsRepository.cs  # KPI + statistici pentru charts
│
├── BLL/                         # Business Logic Layer
│   ├── AuthService.cs           # Login + Register + ContSuspendatException
│   ├── EvenimentService.cs      # Reguli de business pentru evenimente
│   ├── CartService.cs           # Logica de cos
│   └── PasswordHash.cs          # Wrapper BCrypt + lazy upgrade
│
├── Helpers/                     # Utilitare cross-cutting
│   ├── SessionManager.cs        # User curent + EsteAdmin/EsteManager
│   ├── Navigator.cs             # Navigare intre UC-uri (back stack)
│   ├── ManageUC.cs              # Helper de Display in panelContainer
│   ├── ImageStorage.cs          # Folder Images/ (poze evenimente)
│   ├── LogoLoader.cs            # Recolorare logo la rulare
│   ├── Validators.cs            # IsEmail, IsParolaValida, etc.
│   ├── Parsing.cs               # Helper de parsare valori
│   ├── PdfBilet.cs              # Generator PDF cu QuestPDF + QRCoder
│   └── FlowSpacer.cs            # Spacer pentru FlowLayoutPanel
│
├── Forms/                       # Forme top-level
│   ├── SignUpForm.cs            # Inregistrare cont nou
│   ├── MainMenu.cs              # Sidebar + panelContainer
│   ├── BiletEditForm.cs         # Dialog editare bilet (manager)
│   └── UserEditForm.cs          # Dialog editare user (admin)
│
├── UserControls/                # UC-uri afisate in panelContainer
│   ├── UCHome.cs                # Pagina principala dupa login
│   ├── UCDiscoverEvents.cs      # Cautare avansata + paginare
│   ├── UCVirtualEvents.cs       # Doar evenimente type='virtual'
│   ├── UCMyTickets.cs           # Comenzi + bilete cumparate
│   ├── UCCart.cs                # Cos cumparaturi
│   ├── UCComandaDetalii.cs      # Detaliile unei comenzi
│   ├── UCEventPage.cs           # Pagina detaliu eveniment + cumparare
│   ├── UCCreateEvent.cs         # Creare eveniment (manager)
│   ├── UCMyEvents.cs            # Lista evenimentelor managerului
│   ├── UCEditEvent.cs           # Editare eveniment + bilete
│   ├── UCProfile.cs             # Profil + schimbare parola
│   ├── UCAdminDashboard.cs      # Dashboard admin (3 tab-uri)
│   ├── EvenimentCard.cs         # Card poster eveniment
│   ├── BiletCumparatCard.cs     # Card bilet cumparat (cu QR)
│   ├── CartItemCard.cs          # Card linie din cos
│   └── PageBar.cs               # Bara de paginare reutilizabila
│
├── Form1.cs                     # Ecran de login
├── Program.cs                   # Entry point + init QuestPDF
├── App.config                   # Connection string + config Images folder
├── Images/                      # Postere evenimente (PNG)
├── Poze/                        # Capturi de ecran pentru README
├── LatoFont/                    # Font folosit in PDF-uri
├── db/                          # Scripturi SQL (rulate cu pgAdmin)
│   ├── schema.sql               # CREATE TABLE pentru toate entitatile
│   ├── data.sql                 # Date initiale (orase, useri, evenimente, bilete)
│   ├── update_imgpath.sql       # Convertire URL Supabase -> nume fisier
│   ├── iabilet_top21.sql        # 21 evenimente preluate de pe iabilet.ro
│   ├── virtual_events_10.sql    # 10 evenimente virtuale reale
│   ├── admin_migration.sql      # Adauga is_suspended + rol admin
│   └── create_admin_account.sql # Cont admin@ticketa.ro / 123456
│
└── Proiect_PAOO_Organizare_Evenimente.csproj
```

---

## Instalare si configurare

### 1. Instaleaza dependentele

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL 14+](https://www.postgresql.org/download/)
- [pgAdmin 4](https://www.pgadmin.org/download/) (recomandat pentru rularea scripturilor SQL)
- Visual Studio 2022 (sau 2026) cu workload .NET desktop

### 2. Cloneaza proiectul

```powershell
git clone https://github.com/<USER>/Ticketa.git
cd Ticketa
```

### 3. Configureaza baza de date

In pgAdmin creezi o baza de date noua numita `ticketa`:

```sql
CREATE DATABASE ticketa;
```

### 4. Configureaza connection string-ul

Editezi `App.config` cu parola ta de PostgreSQL:

```xml
<connectionStrings>
  <add name="Ticketa"
       connectionString="Host=localhost;Port=5432;Database=ticketa;Username=postgres;Password=PAROLA_TA;"
       providerName="Npgsql" />
</connectionStrings>
```

### 5. Compileaza proiectul

```powershell
dotnet build
```

Sau apesi **F5** in Visual Studio.

---

## Initializare baza de date

Scripturile SQL se ruleaza in pgAdmin Query Tool, **conectat la baza `ticketa`**, in ordinea urmatoare:

| # | Fisier | Descriere |
| - | --- | --- |
| 1 | `db/schema.sql` | Creeaza tabelele Users, Orase, Evenimente, Bilet, Cos, Cos_Bilet |
| 2 | `db/data.sql` | Date initiale: 11 useri test, 320 orase, 67 evenimente, 199 bilete |
| 3 | `db/update_imgpath.sql` | Curata URL-urile Supabase din `imgpath` -> doar nume de fisier |
| 4 | `db/iabilet_top21.sql` | 21 evenimente reale preluate de pe iabilet.ro |
| 5 | `db/virtual_events_10.sql` | 10 evenimente virtuale (WWDC, Build, etc.) |
| 6 | `db/admin_migration.sql` | Adauga coloana `is_suspended` si suport pentru rolul Admin |
| 7 | `db/create_admin_account.sql` | Creeaza contul admin@ticketa.ro / 123456 |
| 8 | `db/fix_sequences.sql` | **Obligatoriu** - reseteaza sequence-urile IDENTITY dupa INSERT-urile cu ID explicit |

**Toate scripturile sunt idempotente** - pot fi rulate de mai multe ori fara eroare.

Daca vrei doar setup minimal, ruleaza pasii 1, 2, 3, 6, 7, 8.

> **Important:** Pasul 8 (`fix_sequences.sql`) trebuie rulat **dupa** orice script care insereaza randuri cu ID explicit. Daca il sari, aplicatia va da `duplicate key value violates unique constraint` la primul INSERT facut din UI.

---

## Conturi de test

Dupa rularea scripturilor, ai disponibile urmatoarele conturi (parola plain text se converteste automat in BCrypt la prima logare reusita):

| Email | Parola | Rol |
| --- | --- | --- |
| `admin@ticketa.ro` | `123456` | **admin** |
| `tudor.chirita@gmail.com` | `123456` | admin (promovat) |
| `andrei.kevin23@company.com` | `12345` | manager |
| `andrei.selaru@yahoo.com` | `123456` | manager |
| `test@test.com` | `1234` | manager (promovat) |
| `conttest@gmail.com` | `123456` | user |

Restul conturilor de test sunt listate in `conturi-test.txt`.

---

## Manual de utilizare

### Inregistrare cont nou

1. Pornesti aplicatia
2. Apesi **Inregistrare cont** in ecranul de login
3. Completezi formularul (prenume, email, parola, etc.). Selectezi rolul: `Client` sau `Manager` (Admin se face doar din Dashboard de catre alt admin)
4. Apesi **Inregistreaza-te**
5. Te intorci la ecranul de login si introduci credentialele

### Cumparare bilete (Client)

1. Logheaza-te cu un cont de tip Client
2. Mergi la **Acasa** sau **Descopera evenimente**
3. Click pe un poster -> deschide pagina detaliu cu lista de bilete
4. Apesi **+** la cantitatea biletului dorit -> se adauga in **Cosul meu**
5. Mergi la **Cosul meu** -> apesi **Finalizeaza comanda**
6. Comanda apare in **Biletele mele** cu PDF generat (QR code + detalii)

### Creare eveniment (Manager)

1. Logheaza-te cu cont de manager
2. Mergi la **Creeaza eveniment**
3. Completezi: nume, organizator, oras, locatie, data, ora, descriere, tip (Fizic/Virtual), stoc bilete
4. Atasezi un poster (imagine PNG/JPG) - se copiaza in folderul `Images/`
5. Apesi **Salveaza** -> apare in **Evenimentele mele**
6. Click pe card pentru a edita detalii sau adauga tipuri de bilete

### Administrare (Admin)

1. Logheaza-te cu `admin@ticketa.ro` / `123456`
2. In sidebar apare butonul **Admin Dashboard**
3. **Tab Utilizatori:**
   - Selecteaza un user din tabel
   - Apesi **Suspenda cont** sau **Reactiveaza** (in functie de starea actuala)
   - Apesi **Editeaza date** -> dialog cu campurile editabile
   - Selecteaza un rol nou din combobox + **Aplica rol**
4. **Tab Evenimente:**
   - Selecteaza un eveniment
   - Apesi **Suspenda eveniment** (dispare din listele publice)
   - Apesi **Editeaza datele** -> deschide UC-ul de editare
5. **Tab Statistici:**
   - Vezi 4 grafice live, calculate din DB la fiecare reincarcare

### Logout / cont suspendat

- Apesi **Delogare** in sidebar -> revii la ecranul de login
- Daca admin-ul a suspendat contul tau, la urmatorul login primesti mesajul: *"Contul tau a fost suspendat. Te rugam sa contactezi administratorul."*

---

## Capturi

### Autentificare

**Login:**

![Login](Poze/login.png)

**Inregistrare cont nou:**

![Inregistrare](Poze/signup.png)

---

### Sidebar per rol

Sidebar-ul difera in functie de rolul utilizatorului autentificat. Butoanele nerelevante pentru rol sunt ascunse complet.

| Client | Manager | Admin |
| --- | --- | --- |
| ![Meniu user](Poze/meniu_user.png) | ![Meniu manager](Poze/meniu_manager.png) | ![Meniu admin](Poze/meniu_admin.png) |

---

### Pagini Client

**Descopera evenimente** - cautare cu filtre (nume, organizator, oras, tip, interval de date) si paginare:

![Descopera evenimente](Poze/descopera_evenimente.png)

**Evenimente virtuale** - filtru dedicat care afiseaza doar evenimentele cu `type='virtual'`:

![Evenimente virtuale](Poze/evenimente_virtuale.png)

**Pagina detaliu eveniment** - poster, descriere, lista de bilete cu preturi si butoane "+/-" pentru adaugare in cos:

![Pagina eveniment](Poze/pagina_event.png)

**Cosul meu** - lista comenzii curente cu cantitati, total si checkout:

![Cosul meu](Poze/cosul_meu.png)

**Biletele mele** - comenzi finalizate, fiecare comanda este expandabila:

![Biletele mele](Poze/biletele_mele.png)

**Detalii bilet** - vizualizare bilet cu QR code generat:

![Detalii bilet](Poze/detalii_bilet.png)

**Bilet exportat in PDF** - cu QR code + detalii eveniment, generat de QuestPDF:

![PDF bilet](Poze/date_bilet_pdf.png)

**Profilul meu** - editare date personale + schimbare parola:

![Profilul meu](Poze/profilul_meu.png)

---

### Pagini Manager

**Creeaza eveniment** - formular completare detalii + upload poster:

![Creeaza eveniment](Poze/creeaza_eveniment.png)

**Evenimentele mele** - lista evenimentelor proprii ale managerului:

![Evenimentele mele](Poze/evenimentele_mele.png)

**Editare eveniment - tab date generale:**

![Edit event - date generale](Poze/edit_event1.png)

**Editare eveniment - tab bilete:**

![Edit event - bilete](Poze/edit_event2.png)

**Adaugare categorie bilet** - dialog modal pentru crearea unui nou tip de bilet asociat evenimentului:

![Adauga categorie bilet](Poze/adauga_categorie_bilet.png)

---

### Admin Dashboard

**Tab Utilizatori** - tabel cu toti userii, KPI cards sus, actiuni jos (suspenda/reactiveaza/editeaza/aplica rol):

![Admin - Utilizatori](Poze/admin_dashboard1.png)

**Tab Evenimente** - tabel cu toate evenimentele (inclusiv suspendate), actiuni jos (suspenda/reactiveaza/editeaza):

![Admin - Evenimente](Poze/admin_dashboard2.png)

**Tab Statistici** - 4 grafice bara live: evenimente pe tip, utilizatori pe rol, top 5 dupa bilete vandute, venit pe luna:

![Admin - Statistici](Poze/admin_dashboard3.png)

---

### Paleta de culori + layout

Aplicatia respecta paleta:
- **Navy** `#212949` - sidebar + accente text
- **Rosu** `#E53935` - actiuni distructive (Delogare, Suspendare)
- **Albastru** `#3170F9` - actiuni primare (Aplica, Editeaza)
- **Verde** `#059669` - confirmari (Reactiveaza, status active)
- **Gri deschis** `#F6F6F6` - background

Layout:
- Sidebar fix in stanga (220 px) cu logo + nume user + meniu
- Container central (panelContainer) care afiseaza UC-uri pe rand

---

## Note de dezvoltare

### Pattern session

Login-ul stocheaza utilizatorul curent in `SessionManager.UtilizatorCurent` (static, viu pe durata aplicatiei). Verifica drepturile cu:

```csharp
SessionManager.EsteAutentificat
SessionManager.EsteManager      // Utilizator e instanta de Manager
SessionManager.EsteAdmin        // Utilizator e instanta de Admin
```

### Filtru evenimente suspendate

`EvenimentRepository` are constanta `ActiveOnly` care adauga `AND is_suspended = false` la toate query-urile publice. Adminul foloseste `GetAllForAdmin()` care nu aplica filtrul.

### Lazy upgrade parole

`AuthService.Login` detecteaza parolele in clar (din backup-ul Supabase) si le converteste in BCrypt la prima logare reusita. Hash-ul se salveaza inapoi in DB transparent.

### Generare PDF

`Helpers/PdfBilet.cs` foloseste **QuestPDF** pentru layout si **QRCoder** pentru QR code. Cheia QR codifica id-ul biletului pentru validare la intrare.

### Imagini evenimente

Toate posterele se afla in `Images/` (relativ la executabil). DB stocheaza doar numele fisierului in `Evenimente.imgpath`. La afisare:
```csharp
var path = ImageStorage.PathFor(ev.CaleImagine);
picPoster.Image = Image.FromFile(path);
```

Folderul `Images/` se copiaza automat la build prin `<None Update="Images\**\*">` in `.csproj`.

---

## Licenta

Proiect academic. Folosit ca exemplu pentru cursul **PAOO**.
