-- =====================================================================
-- Ticketa - TOP 21 evenimente preluate de pe iabilet.ro (homepage)
-- Ruleaza DUPA data.sql + update_imgpath.sql
--
-- 19 evenimente noi: id_event 71-89
-- 2 evenimente deja existente actualizate: id 4 IRON MAIDEN, id 5 BEACH PLEASE
-- Toate biletele asociate sunt re-inserate (id_bilet 200+)
-- Pozele aferente se regasesc in folderul Images\
-- =====================================================================
BEGIN;

-- =====================================================================
-- UPDATE evenimente existente
-- =====================================================================

-- id 4: IRON MAIDEN - Run For Your Lives World Tour (28 mai 2026, Arena Nationala)
UPDATE public."Evenimente"
SET name        = E'IRON MAIDEN - Run For Your Lives World Tour',
    description = E'Iron Maiden continua turneul aniversar „Run For Your Lives”, dedicat celor 50 de ani de cariera, cu un setlist care reuneste momente definitorii din istoria trupei si cu cel mai spectaculos show pus in scena pana acum. Trupa va urca pe scena marilor festivaluri de rock si va concerta pe stadioane din tari si regiuni neincluse in itinerariul din 2025. Pentru acest eveniment vor fi disponibile bilete cu acces general in zona de gazon (categorie unica), precum si bilete cu loc pe scaun in cele trei inele ale stadionului. Un eveniment organizat de EMAGIC si Live Nation, powered by Rock FM.',
    location    = E'Arena Națională, Bd. Basarabia 37-39, Sector 2, București',
    date        = E'2026-05-28 17:00:00+00',
    organiser   = E'EMAGIC & Live Nation',
    imgpath     = E'iron_maiden.png',
    city        = E'București',
    type        = E'fizic',
    stoc_bilete = 50000
WHERE id_event = 4;

-- id 5: BEACH, PLEASE! Festival 2026 (8-12 iulie 2026, Nibiru Costinesti)
UPDATE public."Evenimente"
SET name        = E'BEACH, PLEASE! Festival 2026',
    description = E'BEACH, PLEASE! Festival 2026 are loc intre 8-12 iulie 2026 la Nibiru, Costinesti, fiind cel mai mare festival de hip-hop si trap din Romania. Varsta minima de participare este 14 ani; minorii intre 14 si 15 ani trebuie sa fie obligatoriu insotiti de un parinte sau tutore legal cu bilet valabil. Toate biletele sunt NOMINALE si NETRANSMISIBILE - in momentul achizitiei, trebuie completat numele complet al participantului. Biletele NU SE RETURNEAZA. Festivalul ofera multiple categorii de bilete: General Access, Early Entry, General Access Plus, Golden Circle, VIP, Ultra VIP + Golden Circle si BLACK TICKET, plus bilete pentru o singura zi.',
    location    = E'Nibiru, Costinești, Județ Constanța',
    date        = E'2026-07-08 12:00:00+00',
    organiser   = E'Selfmademan',
    imgpath     = E'beach_please2.png',
    city        = E'Costinești',
    type        = E'fizic',
    stoc_bilete = 30000
WHERE id_event = 5;

-- =====================================================================
-- Cleanup IDEMPOTENT pentru re-rulare
-- Sterge tot ce ar putea ramane dintr-o rulare anterioara partiala
-- (in caz ca pgAdmin a rulat in auto-commit si nu a facut rollback)
-- =====================================================================

-- Sterge intai TOATE referintele din Cos_Bilet pentru biletele afectate
DELETE FROM public."Cos_Bilet" WHERE id_bilet IN (
    SELECT id_bilet FROM public."Bilet"
    WHERE id_event IN (4, 5) OR id_event BETWEEN 71 AND 89
);
DELETE FROM public."Cos_Bilet" WHERE id_bilet BETWEEN 200 AND 330;

-- Sterge bilete: pentru evenimente afectate + range nou (200-330)
DELETE FROM public."Bilet" WHERE id_event IN (4, 5);
DELETE FROM public."Bilet" WHERE id_event BETWEEN 71 AND 89;
DELETE FROM public."Bilet" WHERE id_bilet BETWEEN 200 AND 330;

-- Sterge evenimentele 71-89 (vor fi re-inserate)
DELETE FROM public."Evenimente" WHERE id_event BETWEEN 71 AND 89;

-- =====================================================================
-- INSERT evenimente noi (id 71-89)
-- =====================================================================

-- 71: UNTOLD Festival 2026 (6-9 august 2026, Cluj Arena)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(71, E'UNTOLD Festival 2026', E'Festivalul UNTOLD revine in vara 2026 cu un nou capitol UNTOLD ONE - 4 zile de muzica, premiere mondiale, show-uri prezentate in exclusivitate si productii create special pentru scena principala a festivalului. Cu GENERAL ACCESS PASS, ai acces 4 zile la toate zonele principale ale festivalului. Cu VIP ACCESS PASS, beneficiezi de platforma VIP cu vedere directa la Mainstage, baruri si mancare premium, toalete dedicate si experiente speciale. Cumpara abonamentul acum si fii parte din noul capitol UNTOLD ONE.', E'Cluj Arena, Aleea Stadionului 2, Cluj-Napoca, Județ Cluj', E'2026-08-06 18:00:00+00', E'UNTOLD', E'untold_2026.png', E'Cluj-Napoca', E'fizic', 80000, NULL);

-- 72: Kapital Festival (3-5 iulie 2026, Arena Nationala Bucuresti)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(72, E'Kapital Festival 2026', E'Kapital Festival aduce in vara 2026 un mix de combo-uri si momente neasteptate de artisti, diversitate de genuri muzicale, experiente care reflecta energia orasului si o comunitate plina de energie. Cu GENERAL ACCESS PASS, ai acces 3 zile la toate zonele principale ale festivalului. Cu VIP ACCESS PASS, ai acces la festival + platforma VIP cu vedere directa la Mainstage, baruri si mancare premium, toalete dedicate si experiente speciale. Bucurestiul are multe povesti: in vara 2026 scriem una noua, impreuna, acasa.', E'Arena Națională, Bd. Basarabia 37-39, Sector 2, București', E'2026-07-03 18:00:00+00', E'Kapital Festival', E'kapital_festival.png', E'București', E'fizic', 30000, NULL);

-- 73: Concert Alifantis & Zan la Hard Rock Cafe (13 mai 2026)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(73, E'Concert Alifantis & Zan la Hard Rock Cafe', E'Vino la Hard Rock Cafe sa fii aproape de artistii tai preferati si sa te bucuri de muzica lor, intr-o atmosfera unica! Show-urile explozive, colectia de suveniruri care iti reamintesc de legendele muzicii si calitatea sunetului iti garanteaza cea mai placuta experienta live. Concert intim cu Nicu Alifantis si Zan, un dialog muzical autentic intre poezie, folk si rock. Hard Rock Cafe Bucuresti se afla in parcul Herastrau - Soseaua Kiseleff, nr. 32. Locatia dispune si de cateva sute de locuri de parcare. Un eveniment BestMusic.', E'Hard Rock Cafe, Șos. Kiseleff 32, Sector 1, București', E'2026-05-13 21:00:00+00', E'BestMusic', E'alifantis_zan.png', E'București', E'fizic', 300, NULL);

-- 74: Max Korzh (23 mai 2026, Arena Nationala)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(74, E'Max Korzh - Live in București', E'Sambata, 23 mai 2026, fanii lui Max Korzh din toata Europa se vor aduna la Bucuresti. Cei care au avut norocul sa participe la un concert al lui Korzh stiu: nu este doar un show, ci epicentrul unei sarbatori a emotiilor, in care mii de oameni din tari diferite se unesc intr-un singur ritm. Concertul de la Bucuresti promite sa fie unul dintre cele mai spectaculoase show-uri ale anului 2026 - o adevarata celebrare a vietii incarcata cu sunet puternic, pirotehnie impresionanta, efecte speciale dinamice, un show de lumini spectaculos si hiturile indragite. Accesul se va face in jurul orei 16:00.', E'Arena Națională, Bd. Basarabia 37-39, Sector 2, București', E'2026-05-23 16:00:00+00', E'EMAGIC', E'max_korzh.png', E'București', E'fizic', 50000, NULL);

-- 75: Rockstadt Extreme Fest 2026 (27-31 iulie 2026, Ghimbav Brasov)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(75, E'Rockstadt Extreme Fest 2026', E'Doua festivaluri. Doua universuri. Un singur bilet. Rockstadt Extreme Fest si Jazz in the Park lanseaza abonamentul comun, un bilet care asigura intrarea la ambele festivaluri vara aceasta. De la forta si intensitatea Rockstadt Extreme Fest la libertatea si rafinamentul Jazz in the Park, intr-un singur sezon festivalier. Editia 2026 reuneste pe scena Sabaton & Marilyn Manson, Godsmack & In Flames, Lamb of God, Slaughter to Prevail, Arch Enemy, Accept, Helloween si The Prodigy. Bonus: Rockstadt Tribute Day pe 1 august 2026 cu international tribute bands plus afterparty.', E'Rockstadt Extreme Fest, Aerodromul Ghimbav, Ghimbav, Județ Brașov', E'2026-07-27 14:00:00+00', E'Rockstadt', E'rockstadt_extreme.png', E'Ghimbav', E'fizic', 15000, NULL);

-- 76: Three Days Grace, Lacuna Coil & Black Gold (26 iunie 2026)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(76, E'Three Days Grace, Lacuna Coil & Black Gold @ Shine Festival', E'Three Days Grace este una dintre formatiile etalon ale scenei rock si metal din Canada. Cu opt materiale de studio si 12 Discuri de Platina, sunt printre cele mai de succes formatii canadiene si au urcat pe scenele celor mai importante festivaluri precum Rock im Park, Graspop sau Download. Lacuna Coil este o trupa de alternative metal din Milano, Italia, formata in 1994, cunoscuta pentru armoniile vocale duale feminin/masculin (Cristina Scabbia si Andrea Ferro), ce creeaza un hibrid de gothic, groove si alternative metal - cu peste doua milioane de albume vandute. Black Gold abordeaza Nu Metal cu influente de Rap Metal, comparati cu Limp Bizkit sau Slipknot.', E'Arenele Romane, Str. Cuțitul de Argint 3, Sector 4, București', E'2026-06-26 19:00:00+00', E'BestMusic', E'three_days_grace.png', E'București', E'fizic', 5000, NULL);

-- 77: Garou - The Best Of (20 sep 2026, Arenele Romane)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(77, E'Garou - The Best Of', E'Recunoscut pentru culoarea vocala usor aspra, intensitatea interpretarii si naturalete a cu care creeaza legatura cu sala, Garou propune un show construit pe emotie, forta si eleganta scenica - o selectie de piese definitorii, momente surpriza si un sound live care ridica fiecare refren la rang de experienta. Repertoriul include reinterpretari din Elvis Presley si Joe Dassin, alaturi de incursiuni in cele mai cunoscute piese de blues si rock. Un punct central al serii il reprezinta legatura cu musicalul Notre-Dame de Paris, unde Garou a dat viata personajului Quasimodo - Belle si Sous le vent (duetul cu Celine Dion) raman repere ale serii.', E'Arenele Romane, Str. Cuțitul de Argint 3, Sector 4, București', E'2026-09-20 20:00:00+00', E'Moments', E'garou_best_of.png', E'București', E'fizic', 5000, NULL);

-- 78: Tururi Ghidate Palais Ghica Victoria (23 mai 2026)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(78, E'Tururi Ghidate - Palais Ghica Victoria', E'Mai mult decat o simpla vizita, aceasta este o invitatie de a pasi in istorie, de a strabate spatii care au fost martore la secole de viata culturala si sociala si de a admira arhitectura atemporala ce defineste farmecul unic al Palais Ghica Victoria. Sesiuni de o ora pe parcursul zilei, tur ghidat in limba romana cu 30 de locuri per sesiune. Accesul copiilor pana in 10 ani este gratuit. Sapte sesiuni disponibile in intervalul 11:00 - 18:00.', E'Palais Ghica Victoria, Calea Victoriei, Sector 1, București', E'2026-05-23 11:00:00+00', E'Tururi Ghidate', E'palais_ghica.png', E'București', E'fizic', 210, NULL);

-- 79: Turneu Holograf (14-20 mai 2026, Romania)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(79, E'Turneu Holograf 2026', E'Holograf, una dintre cele mai iubite trupe pop-rock din Romania, porneste in turneu national in luna mai 2026. Concertele aniverseaza cariera de peste 40 de ani a trupei, cu o selectie din cele mai mari hituri de la „Cat de departe” si „Mi-e dor de tine” pana la cele mai recente piese. Turneul include opriri in mai multe orase din tara, oferind fanilor Holograf o seara de magie muzicala alaturi de Dan Bittman si trupa.', E'Romania - turneu national', E'2026-05-14 20:00:00+00', E'BestMusic', E'holograf.png', E'București', E'fizic', 5000, NULL);

-- 80: Subcarpati - lansare album Hora Exacta (16 mai 2026)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(80, E'Subcarpati - Lansare album „Hora Exacta”', E'Concertul Subcarpati la Arenele Romane marcheaza lansarea oficiala a noului album „Hora Exacta”. O seara plina de muzica autentica, cu beat-uri urbane, instrumente populare romanesti si versuri puternice care exploreaza temele identitatii, ale traditiei si ale generatiei tinere. Biletele Premium au loc in sectoarele K si E, biletele Teren sunt fara loc in fata scenei, iar Acces General ofera locuri in Arena. Copiii sub 10 ani au acces gratuit doar in zona Teren si insotiti de un adult posesor de bilet valabil. Un eveniment BestMusic powered by Radio Guerrilla.', E'Arenele Romane, Str. Cuțitul de Argint 3, Sector 4, București', E'2026-05-16 20:00:00+00', E'BestMusic', E'subcarpati.png', E'București', E'fizic', 5000, NULL);

-- 81: Art Safari New Museum, Editia 18 (26 mar - 19 iul 2026)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(81, E'Art Safari New Museum - Ediția 18', E'Art Safari, cel mai important muzeu de arta din Romania, revine cu Editia 18 intr-o noua perioada extinsa. Vizitatorii au acces la trei pavilioane: Pavilionul Muzeal cu „Vermont si farmecul Belle Époque”, Pavilionul Istoric cu „R:Eminescu. Poetul rational” si Pavilionul Contemporan cu expozitia Felix Aftene - Jurnal. Bilete disponibile pentru toate expozitiile, expozitii individuale, reduceri pentru elevi/studenti, pensionari si pachet 2 persoane.', E'Art Safari New Museum, Str. Mendeleev 13, Sector 1, București', E'2026-03-26 10:00:00+00', E'Art Safari', E'art_safari_18.png', E'București', E'fizic', 50000, NULL);

-- 82: EEMC GALA – Alternosfera Theatroll (21 mai 2026)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(82, E'EEMC GALA – Alternosfera Theatroll', E'Alternosfera este una dintre cele mai solide si influente prezente din zona rockului alternativ romanesc si est-european, o formatie care, in peste doua decenii de activitate, si-a construit un univers artistic coerent, recognoscibil si profund conectat la realitatile sociale si emotionale ale publicului sau. Fondata in 1998, trupa a evoluat constant pastrand un nucleu identitar puternic. De la „Orasul 511” (2005) la albumele „Visatori cu plumb in ochi...” sau EP-ul „Flori din groapa Marianelor”, trupa a marcat tranzitia catre un discurs artistic mai matur. Un moment definitoriu il reprezinta tripticul conceptual ePIsodia: „Virgula”, „Epizodia” si „Haosoleum”.', E'Teatrul Național București, Bd. Nicolae Bălcescu 2, Sector 1, București', E'2026-05-21 19:30:00+00', E'EEMC', E'eemc_alternosfera.png', E'București', E'fizic', 1000, NULL);

-- 83: iSilent @ Sala Palatului (1 iunie 2026)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(83, E'iSilent @ Sala Palatului', E'De 1 iunie, iSilent aduce cel mai asteptat show al fanilor silentiosi la Sala Palatului. Show principal pe scena de teatru: concert iSilent in premiera, cu interactiune cu publicul, episod filmat LIVE si lobby experience la intrare cu PC-uri Minecraft, harta Silentwood, 2 zone de merch iSilent si colturi interactive cu activari de la branduri. Toti participantii la eveniment trebuie sa detina un bilet de acces, indiferent de varsta. Accesul la eveniment va fi permis incepand cu ora 15:00. Dupa inceperea spectacolului locurile afisate pe bilet nu mai pot fi garantate.', E'Sala Palatului, Str. Ion Câmpineanu 28, Sector 1, București', E'2026-06-01 17:00:00+00', E'iSilent', E'isilent.png', E'București', E'fizic', 4000, NULL);

-- 84: Theo Rose - Acorduri ample (12 nov 2026)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(84, E'Theo Rose @ Acorduri ample', E'Spectacolul vorbeste despre muzica calda, melodioasa, plina de armonii ample si orchestrari bogate ale anilor ''60-''80. O scena ca o fereastra spre alt timp: jocuri de lumina calde, decoruri curate si expresive, cadre inspirate din televiziunea vremii si un band live care reda sunetul atat de recognoscibil al perioadei. Theo Rose readuce la viata melodii care au insemnat ceva pentru milioane de romani: cantece de dragoste, de dor, de asteptare, de libertate interioara. Repertoriul include reinterpretari spectaculoase ale unor piese care au marcat istoria muzicii romanesti.', E'Sala Palatului, Str. Ion Câmpineanu 28, Sector 1, București', E'2026-11-12 20:00:00+00', E'Best Music Live', E'theo_rose.png', E'București', E'fizic', 4000, NULL);

-- 85: Cluj-Napoca: Gabriel "Fluffy" Iglesias (4 iun 2026)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(85, E'Gabriel „Fluffy” Iglesias - The 1976 Tour', E'Pregatiti-va pentru seara in care umorul la superlativ intalneste energia fenomenala a lui Fluffy! Gabriel „Fluffy” Iglesias este unul dintre cei mai de succes comedianti de stand-up din lume, cu peste 2,4 miliarde de vizualizari pe YouTube si peste 34,7 milioane de fani pe retelele sociale. In 2024, Billboard l-a desemnat al treilea cel mai bine incasat comediant al anului. In 2022, a scris istorie devenind primul comediant ce a performat cu casa inchisa pe Dodger Stadium din Los Angeles, in fata a 55.000 de oameni. A lansat patru specialuri Netflix, iar in 2026, isi va lasa amprentele pe Hollywood Walk of Fame.', E'Sala Polivalenta BTarena, Str. Uzinei Electrice 4, Cluj-Napoca, Județ Cluj', E'2026-06-04 20:00:00+00', E'Stand Up RO', E'fluffy_iglesias.png', E'Cluj-Napoca', E'fizic', 7000, NULL);

-- 86: Cluj-Napoca: Heart Society 5 Years x INNA x Dirty Nano (23 mai 2026)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(86, E'Heart Society 5 Years Anniversary x INNA x Dirty Nano', E'Heart Society aniverseaza 5 ani de existenta cu un eveniment special la Sala Polivalenta BTarena Cluj-Napoca. Pe scena vor urca INNA si Dirty Nano, alaturi de alti artisti speciali pentru o noapte memorabila. O combinatie explozive intre energia clubbing-ului contemporan si hiturile pop ale INNA, intr-un show care promite sa transforme arena intr-un dance floor de proportii.', E'Sala Polivalenta BTarena, Str. Uzinei Electrice 4, Cluj-Napoca, Județ Cluj', E'2026-05-23 21:00:00+00', E'Heart Society', E'heart_society.png', E'Cluj-Napoca', E'fizic', 7000, NULL);

-- 87: IRIS - Cristi Minculescu, Valter & Boro - Primii 45 (23 mai 2026)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(87, E'IRIS - Cristi Minculescu, Valter & Boro - Primii 45 - Concert Aniversar', E'IRIS - Cristi Minculescu, Valter si Boro celebreaza 45 de ani de cariera printr-un concert aniversar la Arenele Romane. O seara cu cele mai mari hituri ale trupei, momente speciale si invitati surpriza pentru fanii care au crescut alaturi de muzica IRIS. Biletele Premium au loc in sectoarele K si E, Teren sunt fara loc in fata scenei, iar Acces General ofera loc in Arena. Copiii sub 10 ani au acces gratuit doar in zona Teren si insotiti de un adult posesor de bilet valabil.', E'Arenele Romane, Str. Cuțitul de Argint 3, Sector 4, București', E'2026-05-23 19:30:00+00', E'BestMusic', E'iris_45.png', E'București', E'fizic', 5000, NULL);

-- 88: SAVATAGE si Trooper la Arenele Romane (21 iul 2026)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(88, E'SAVATAGE si Trooper la Arenele Romane', E'Savatage revine cu turneul „Prelude To Madness” in Europa. Pionierii aclamati ai metalului progresiv anunta un turneu european in vara 2026, prima reaparitie pe scena dupa aproape doua decenii. Turneul incepe pe 19 iulie la Istanbul si include 9 reprezentatii plus aparitii la festivaluri. Setlist exploziv cu hituri clasice ale trupei, dedicat fanilor cunoscuti sub numele „The Legion”. Solistul Zak Stevens declara: „Va fi prima data cand Savatage va canta la Istanbul, Bucuresti, Este (Italia), Varsovia si Leipzig (Germania)”. Trupa romaneasca Trooper deschide concertul. Copiii sub 10 ani au acces gratuit doar in zona Teren si insotiti de un adult posesor de bilet valabil.', E'Arenele Romane, Str. Cuțitul de Argint 3, Sector 4, București', E'2026-07-21 19:00:00+00', E'BestMusic', E'savatage_trooper.png', E'București', E'fizic', 5000, NULL);

-- 89: Deep Forest Fest Editia VII (31 iul - 1 aug 2026)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(89, E'Deep Forest Fest Ediția VII', E'From deep within the forest, the first sound rises. Deep Forest Fest 2026 anunta primul val de artisti: DIRTY NANO, HVMZA, PEPPE CITARELLA, MAHONY, REMAN, SLLASH & DOPPE, ADRIAN SAGUNA, KOV, DAVE ANDRES, AG SWIFTY, ARIAS, BRAD BRUNNER, ANDREW MAZE, EFI, MARC RAYEN, BENZOL. Doua zile de muzica electronica in mijlocul padurii, pe Platoul Feteni - o experienta imersiva pentru iubitorii de underground si DJ seturi marca house, techno si melodic. THE WONDERLAND deeper, dreamier, denser - the journey starts now.', E'Platoul Feteni, Râmnicu Vâlcea, Județ Vâlcea', E'2026-07-31 16:00:00+00', E'Deep Forest Fest', E'deep_forest.png', E'Râmnicu Vâlcea', E'fizic', 5000, NULL);

-- =====================================================================
-- INSERT bilete (id_bilet 200+)
-- =====================================================================

-- ---- Bilete pentru id_event 4: IRON MAIDEN (200-208) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (200, E'Lucky Trooper', 116.47, E'Acces general', E'Bilet redus la pret promotional 99 lei + comisioane. Stoc limitat - 5 bilete disponibile.', 4);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (201, E'Gazon (Standing) B', 290, E'Gazon zona B', E'Acces general gazon, zona B. 246.5 lei + comisioane. In picioare, fara loc rezervat.', 4);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (202, E'Tribuna - Inel 3 Spate', 310, E'Inel 3 Spate', E'Loc pe scaun in inelul 3 al stadionului, zona spate. 263.5 lei + comisioane.', 4);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (203, E'Tribuna - Inel 2 Spate', 415, E'Inel 2 Spate', E'Loc pe scaun in inelul 2 al stadionului, zona spate. 352.75 lei + comisioane.', 4);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (204, E'Tribuna - Inel 1 Spate', 520, E'Inel 1 Spate', E'Loc pe scaun in inelul 1 al stadionului, zona spate. 442 lei + comisioane.', 4);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (205, E'Tribuna - Inel 1 Front', 630, E'Inel 1 Front', E'Loc pe scaun in inelul 1 frontal, vedere optima. 535.5 lei + comisioane.', 4);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (206, E'Gazon (Standing) A', 640, E'Gazon zona A', E'Acces general gazon, zona A - aproape de scena. 544 lei + comisioane. STOC EPUIZAT.', 4);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (207, E'Tribuna - Inel 2 Front', 720, E'Inel 2 Front', E'Loc pe scaun in inelul 2 frontal. 612 lei + comisioane.', 4);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (208, E'Tribuna - Inel 1 Premium', 900, E'Inel 1 Premium', E'Loc Premium in inelul 1 al stadionului. 765 lei + comisioane. STOC EPUIZAT.', 4);

-- ---- Bilete pentru id_event 5: BEACH, PLEASE! (209-223) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (209, E'General Access — 5 Days Pass', 999, E'Acces General', E'Acces in festival pe toata durata evenimentului (8-12 iulie). 196 EUR (176 bilet + 20 comision emitere).', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (210, E'EARLY ENTRY: General Access — 5 Days Pass', 895, E'Acces General Early Entry', E'Acces in festival pe toata durata evenimentului, cu conditia intrarii INAINTE DE ORA 17:00. 176 EUR (156 bilet + 20 comision).', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (211, E'General Access Plus — 5 Days Pass', 1149, E'Acces General Plus', E'Toate beneficiile General Access + FAST LINE ACCESS pentru intrare prioritara. 226 EUR.', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (212, E'Golden Circle — 5 Days Pass', 949, E'Zona Golden Circle - in fata scenei', E'Toate beneficiile General Access Plus + acces exclusiv in zona din fata scenei. 190 EUR.', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (213, E'VIP — 5 Days Pass', 1529, E'Zona VIP', E'Acces zona VIP cu vizibilitate premium, bar dedicat, toalete private, FAST LANE ACCESS. 300 EUR.', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (214, E'ULTRA VIP + GOLDEN CIRCLE — 5 Days Pass', 2029, E'Zona Ultra VIP + Golden Circle', E'Acces Ultra VIP + Golden Circle, facilitati premium, bar privat, Fast Lane. 398 EUR.', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (215, E'BLACK TICKET — 5 Days Pass', 5099, E'Zona BLACK TICKET (Ultra VIP + Golden Circle)', E'Cele mai exclusive beneficii: Ultra VIP, Golden Circle, Fast Lane, parcare VIP dedicata, concierge WhatsApp, gift bag, Snake Pit, tur backstage. 1000 EUR.', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (216, E'GENERAL ACCESS — 1 Day Pass: Joi 9 Jul', 504, E'Acces General - o zi (Joi)', E'Acces in festival doar pe data de 9 iulie. 99 EUR.', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (217, E'GENERAL ACCESS — 1 Day Pass: Vineri 10 Jul', 402, E'Acces General - o zi (Vineri)', E'Acces in festival doar pe data de 10 iulie. 79 EUR (ofertat).', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (218, E'GENERAL ACCESS — 1 Day Pass: Sambata 11 Jul', 504, E'Acces General - o zi (Sambata)', E'Acces in festival doar pe data de 11 iulie. 99 EUR.', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (219, E'GENERAL ACCESS — 1 Day Pass: Duminica 12 Jul', 504, E'Acces General - o zi (Duminica)', E'Acces in festival doar pe data de 12 iulie. 99 EUR.', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (220, E'VIP — 1 Day Pass: Joi 9 Jul', 1018, E'VIP - o zi (Joi)', E'Acces VIP doar pe data de 9 iulie. 200 EUR.', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (221, E'VIP — 1 Day Pass: Vineri 10 Jul', 1018, E'VIP - o zi (Vineri)', E'Acces VIP doar pe data de 10 iulie. 200 EUR.', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (222, E'VIP — 1 Day Pass: Sambata 11 Jul', 1018, E'VIP - o zi (Sambata)', E'Acces VIP doar pe data de 11 iulie. 200 EUR.', 5);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (223, E'VIP — 1 Day Pass: Duminica 12 Jul', 1018, E'VIP - o zi (Duminica)', E'Acces VIP doar pe data de 12 iulie. 200 EUR.', 5);

-- ---- Bilete pentru id_event 71: UNTOLD (224-230) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (224, E'GA - Acces 4 Zile - Phase 3', 1009.98, E'General Access & Under 25', E'Acces 4 zile la scenele si zonele publice ale festivalului. Check-in online gratuit primele 30 de zile dupa achizitie. Comenzile platite nu pot fi returnate.', 71);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (225, E'GA - Acces 4 Zile - Risk Free', 1114.21, E'General Access & Under 25', E'Acces 4 zile cu Risk Free - bilete returnabile cu cel tarziu 30 de zile inainte de festival, exceptand taxa Risk Free care nu se ramburseaza.', 71);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (226, E'VIP ACCESS PASS', 2259.47, E'VIP Mainstage', E'Acces 4 zile + platforma VIP la Mainstage cu vizibilitate premium, acces dedicat in festival, baruri selecte si facilitati exclusive. Pentru cei peste 18 ani.', 71);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (227, E'Galaxy Backstage - Acces 4 Zile', 1928.95, E'Galaxy Backstage', E'Acces 4 zile in zona backstage Galaxy Stage, pentru o experienta exclusiva aproape de artisti. Pentru cei peste 18 ani.', 71);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (228, E'VIP ULTIMATE EXPERIENCE', 14532.16, E'Ultimate VIP Experience', E'Acces 4 zile + platforma VIP cu zone cu locuri si in picioare, intrare prioritara, lounge-uri private, petreceri private UNTOLD, concierge dedicat, tururi exclusive, gift bag, livrare bratara si masa cu bauturi incluse. 18+.', 71);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (229, E'GA Friendship Pack (Pachet 2 Bilete)', 864.66, E'Friendship Pack 2x', E'Pret pe bilet la pachet de 2. Se cumpara doar in multipli de 2. Acces 4 zile la scenele si zonele publice ale festivalului.', 71);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (230, E'GA Friendship Pack (Pachet 3 Bilete)', 792.01, E'Friendship Pack 3x', E'Pret pe bilet la pachet de 3. Se cumpara doar in multipli de 3. Acces 4 zile la scenele si zonele publice.', 71);

-- ---- Bilete pentru id_event 72: Kapital Festival (231-233) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (231, E'GA - Acces 3 Zile - Phase 1', 498.91, E'General Access', E'Acces 3 zile la scenele si zonele publice ale festivalului. Check-in online gratuit primele 30 de zile.', 72);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (232, E'GA - Acces 3 Zile Phase 1 UNDER 25', 426.19, E'General Access Under 25', E'Acces 3 zile, destinat persoanelor cu varsta de pana la 25 de ani.', 72);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (233, E'VIP - 3 Zile', 1004.67, E'VIP Mainstage', E'Acces 3 zile + platforma VIP la Mainstage cu vizibilitate premium, baruri selecte si facilitati exclusive. 18+.', 72);

-- ---- Bilete pentru id_event 73: Alifantis & Zan (234-237) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (234, E'VIP - loc la masa in fata scenei', 184.11, E'VIP - masa in fata scenei', E'Acces prioritar, loc la masa in fata scenei, complimentary drink & snacks, limited edition menu. 169 lei + comision.', 73);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (235, E'Acces general - cu loc la masa', 142.90, E'Acces general - masa in sala', E'Bilet acces general cu rezervare la masa in sala. 129 lei + comision.', 73);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (236, E'Fara loc - in picioare', 142.90, E'Acces general fara loc', E'Bilet acces general fara loc rezervat, in picioare. 129 lei + comision.', 73);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (237, E'Bilete persoane cu dizabilitati', 0, E'Acces dizabilitati', E'Bilete gratuite pentru persoane cu handicap grav/accentuat plus insotitor, in limita stocului disponibil. Necesita documente justificative la intrare.', 73);

-- ---- Bilete pentru id_event 74: Max Korzh (238) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (238, E'Seating - Sectiunea 1', 520, E'Tribuna - Seating sectiunea 1', E'Bilet cu loc pe scaun, sectiunea 1. 468 lei + comisioane. Acces de la ora 16:00.', 74);

-- ---- Bilete pentru id_event 75: Rockstadt Extreme Fest 2026 (239-252) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (239, E'ABONAMENT FULL PASS TIER 3 2026', 1125, E'Acces general 5 zile', E'Acces general la toate cele 5 zile de festival si zonele deschise participantilor. Nu include Tribute Day din 1 august.', 75);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (240, E'TEENS FULL PASS 2026', 550, E'Acces general teens 12-18', E'Pass valabil pentru participanti cu varsta intre 12-18 ani. Sub 18 ani trebuie insotiti de un parinte sau tutore legal.', 75);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (241, E'VIP 2026', 750, E'Zona VIP', E'Upgrade VIP peste un bilet de festival valabil. Acces zona VIP exclusiva cu platforme dedicate, baruri private, toalete dedicate si lounge confortabil.', 75);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (242, E'Abonament 2x Festivals: Rockstadt & Jazz in the Park', 1362.92, E'Abonament dublu - 2 festivaluri', E'Abonament comun ce ofera acces complet la ambele festivaluri Rockstadt Extreme Fest si Jazz in the Park, vara aceasta. Editie limitata.', 75);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (243, E'Day 1 - 27 July', 685, E'Bilet o zi - Luni 27 iul', E'Sabaton & Marilyn Manson. Acces doar in ziua de 27 iulie.', 75);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (244, E'Day 2 - 28 July', 585, E'Bilet o zi - Marti 28 iul', E'Godsmack & In Flames. Acces doar in ziua de 28 iulie.', 75);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (245, E'Day 3 - 29 July', 615, E'Bilet o zi - Miercuri 29 iul', E'Lamb of God, Slaughter to Prevail, Arch Enemy, Accept. Acces doar pe 29 iulie.', 75);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (246, E'Day 4 - 30 July', 585, E'Bilet o zi - Joi 30 iul', E'Helloween. Acces doar in ziua de 30 iulie.', 75);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (247, E'Day 5 - 31 July', 615, E'Bilet o zi - Vineri 31 iul', E'The Prodigy. Acces doar in ziua de 31 iulie.', 75);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (248, E'Extreme Camping', 220, E'Camping zona', E'Add-on acces zona de camping. Necesita bilet festival valabil. Cort si echipament propriu, dimensionat pentru numarul de persoane.', 75);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (249, E'RV camping with electric hookup', 750, E'RV camping cu electricitate', E'Parking pass RV cu electricitate. Necesita Extreme Camping pass per persoana. Dusuri si toalete in camping.', 75);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (250, E'RV camping (without electric hookup)', 200, E'RV camping fara electricitate', E'Parking pass RV fara electricitate. Necesita Extreme Camping pass per persoana.', 75);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (251, E'Tribute Day - 1 August - Full Pass Add-on', 50, E'Tribute Day add-on', E'Valid doar daca ai deja Rockstadt Extreme Fest 2026 Full Pass. Acces in ziua de Tribute Day, 1 august.', 75);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (252, E'Tribute Day - 1 August', 200, E'Tribute Day acces general', E'Acces general la Rockstadt Tribute Day pe 1 august 2026 - international tribute bands plus afterparty.', 75);

-- ---- Bilete pentru id_event 76: Three Days Grace, Lacuna Coil & Black Gold (253-257) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (253, E'Golden Circle 3X PACK (Teren)', 375.59, E'Pachet 3 bilete Golden Circle', E'Trei bilete in fata scenei cu discount 25%. Oferta limitata - 200 pachete disponibile.', 76);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (254, E'Premium 3X PACK', 474.87, E'Pachet 3 bilete Premium', E'Trei bilete cu discount 25%. Loc in zonele K si E, aproape de scena. Acces toate categoriile, earlyentry si afis cadou.', 76);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (255, E'Premium', 523.08, E'Premium - sectoarele K si E', E'Loc in sectoarele K si E, aproape de scena. Asigura acces in toate categoriile, earlyentry si afis cadou.', 76);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (256, E'Golden Circle (Teren)', 477.58, E'Teren - in fata scenei', E'Fara loc, in fata scenei. Cea mai aproape pozitie de artisti.', 76);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (257, E'Acces General', 350.95, E'Acces general - in spatele Golden Circle', E'In spatele categoriei Golden Circle. Acces general la concert.', 76);

-- ---- Bilete pentru id_event 77: Garou - The Best Of (258-261) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (258, E'VIP', 393.15, E'Zona VIP - Arenele Romane', E'Acces in zona VIP la Arenele Romane, cele mai bune locuri.', 77);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (259, E'Premium', 304.04, E'Premium - aproape de scena', E'Loc Premium aproape de scena.', 77);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (260, E'Categoria A', 220.16, E'Categoria A', E'Loc Categoria A.', 77);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (261, E'Categoria B', 157.26, E'Categoria B', E'Loc Categoria B.', 77);

-- ---- Bilete pentru id_event 78: Tururi Ghidate Palais Ghica (262-268) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (262, E'Tur Ghidat Romana 11:00 - 12:00', 158.01, E'Sesiunea 11:00', E'Acces general - tur ghidat in limba romana, sesiunea 11:00 - 12:00. 30 locuri disponibile.', 78);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (263, E'Tur Ghidat Romana 12:00 - 13:00', 158.01, E'Sesiunea 12:00', E'Acces general - tur ghidat in limba romana, sesiunea 12:00 - 13:00. 30 locuri disponibile.', 78);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (264, E'Tur Ghidat Romana 13:00 - 14:00', 158.01, E'Sesiunea 13:00', E'Acces general - tur ghidat in limba romana, sesiunea 13:00 - 14:00. 30 locuri disponibile.', 78);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (265, E'Tur Ghidat Romana 14:00 - 15:00', 158.01, E'Sesiunea 14:00', E'Acces general - tur ghidat in limba romana, sesiunea 14:00 - 15:00. 30 locuri disponibile.', 78);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (266, E'Tur Ghidat Romana 15:00 - 16:00', 158.01, E'Sesiunea 15:00', E'Acces general - tur ghidat in limba romana, sesiunea 15:00 - 16:00. 30 locuri disponibile.', 78);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (267, E'Tur Ghidat Romana 16:00 - 17:00', 158.01, E'Sesiunea 16:00', E'Acces general - tur ghidat in limba romana, sesiunea 16:00 - 17:00. 30 locuri disponibile.', 78);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (268, E'Tur Ghidat Romana 17:00 - 18:00', 158.01, E'Sesiunea 17:00', E'Acces general - tur ghidat in limba romana, sesiunea 17:00 - 18:00. 30 locuri disponibile.', 78);

-- ---- Bilete pentru id_event 79: Turneu Holograf (269-270) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (269, E'Acces General', 150, E'Acces general turneu', E'Bilet acces general la concertele turneului national Holograf 2026.', 79);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (270, E'Premium', 250, E'Premium - in fata scenei', E'Bilet Premium cu loc in fata scenei la concertele turneului national Holograf 2026.', 79);

-- ---- Bilete pentru id_event 80: Subcarpati - Hora Exacta (271-277) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (271, E'Premium', 268.53, E'Premium - sectoarele K si E', E'Loc in sectoarele K si E. Acces toate categoriile, earlyentry si afis cadou.', 80);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (272, E'Teren', 206.72, E'Teren - in fata scenei', E'Fara loc, in fata scenei.', 80);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (273, E'Acces General', 165.51, E'Acces general - Arena', E'Loc in Arena (mai putin sectoarele K si E) sau fara loc in spatele Teren.', 80);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (274, E'Bilete persoane cu dizabilitati', 0, E'Acces dizabilitati', E'Bilete gratuite pentru persoane cu handicap grav/accentuat plus insotitor. Necesita documente justificative.', 80);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (275, E'Premium 3X PACK', 196.41, E'Pachet 3 bilete Premium', E'Pachet 3 bilete Premium cu discount 25%. Loc in sectoarele K si E.', 80);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (276, E'Teren 3X PACK', 155.2, E'Pachet 3 bilete Teren', E'Pachet 3 bilete Teren cu discount 25%. Fara loc, in fata scenei.', 80);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (277, E'Acces General 3X PACK', 113.99, E'Pachet 3 bilete Acces General', E'Pachet 3 bilete Acces General cu discount 25%. Loc in Arena.', 80);

-- ---- Bilete pentru id_event 81: Art Safari Ediția 18 (278-284) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (278, E'Toate expozițiile', 150, E'Acces 1 zi - toate expozitiile', E'Acces 1 zi - include toate expozitiile (Pavilion Muzeal, Pavilion Istoric, Pavilion Contemporan).', 81);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (279, E'Toate expozițiile - 2 persoane', 250, E'Acces 1 zi - 2 persoane', E'Bilet pentru 2 persoane simultan, toate expozitiile.', 81);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (280, E'Pavilionul Muzeal', 70, E'Pavilionul Muzeal', E'Vermont si farmecul Belle Époque - doar Pavilionul Muzeal.', 81);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (281, E'Pavilionul Istoric', 60, E'Pavilionul Istoric', E'R:Eminescu. Poetul rational - doar Pavilionul Istoric.', 81);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (282, E'Pavilionul Contemporan', 50, E'Pavilionul Contemporan', E'Felix Aftene. Jurnal - doar Pavilionul Contemporan.', 81);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (283, E'Toate expozițiile - reducere elevi/studenți', 60, E'Acces redus elevi/studenti', E'Bilet redus elevi si studenti, toate expozitiile. Necesita act dovada.', 81);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (284, E'Toate expozițiile - reducere pensionari', 60, E'Acces redus pensionari', E'Bilet redus pensionari, toate expozitiile. Necesita act dovada.', 81);

-- ---- Bilete pentru id_event 82: EEMC GALA Alternosfera (285-289) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (285, E'Categoria I', 307.5, E'Categoria I', E'Loc Categoria I, cele mai bune locuri din sala.', 82);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (286, E'Categoria II', 256.25, E'Categoria II', E'Loc Categoria II.', 82);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (287, E'Categoria III', 205, E'Categoria III', E'Loc Categoria III.', 82);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (288, E'Categoria IV', 153.75, E'Categoria IV', E'Loc Categoria IV.', 82);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (289, E'Categoria V', 123, E'Categoria V', E'Loc Categoria V.', 82);

-- ---- Bilete pentru id_event 83: iSilent @ Sala Palatului (290-295) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (290, E'Categoria D', 160.68, E'Categoria D', E'Loc Categoria D in Sala Palatului.', 83);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (291, E'Categoria C', 190.68, E'Categoria C', E'Loc Categoria C in Sala Palatului.', 83);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (292, E'Categoria B', 220.68, E'Categoria B', E'Loc Categoria B in Sala Palatului.', 83);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (293, E'Categoria A', 260.68, E'Categoria A', E'Loc Categoria A in Sala Palatului.', 83);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (294, E'VIP', 300.68, E'VIP - Sala Palatului', E'Loc VIP in Sala Palatului.', 83);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (295, E'Bilete persoane cu dizabilitati', 0, E'Acces dizabilitati', E'Bilete gratuite pentru persoane cu handicap grav/accentuat plus insotitor. Necesita documente justificative.', 83);

-- ---- Bilete pentru id_event 84: Theo Rose - Acorduri ample (296-303) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (296, E'Ultra VIP', 1026.56, E'Ultra VIP - Sala Palatului', E'Acces prioritar, Meet & Greet si goodie bag. Acces M&G doar pentru posesorul biletului - fara insotitori.', 84);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (297, E'Premium', 575.85, E'Premium', E'Loc Premium in Sala Palatului.', 84);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (298, E'Categoria A', 450.71, E'Categoria A', E'Loc Categoria A.', 84);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (299, E'Categoria B', 396.63, E'Categoria B', E'Loc Categoria B.', 84);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (300, E'Categoria C', 358.45, E'Categoria C', E'Loc Categoria C.', 84);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (301, E'Categoria D', 306.48, E'Categoria D', E'Loc Categoria D.', 84);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (302, E'Categoria E', 242.85, E'Categoria E', E'Loc Categoria E.', 84);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (303, E'Categoria F', 179.22, E'Categoria F', E'Loc Categoria F.', 84);

-- ---- Bilete pentru id_event 85: Fluffy Iglesias (304-311) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (304, E'Premium 1', 524.28, E'Premium 1 - cele mai bune locuri', E'Loc Premium 1, cele mai bune locuri in BTarena.', 85);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (305, E'Premium 2', 471.74, E'Premium 2', E'Loc Premium 2.', 85);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (306, E'Premium 3', 440.22, E'Premium 3', E'Loc Premium 3.', 85);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (307, E'Categoria 1', 387.69, E'Categoria 1', E'Loc Categoria 1.', 85);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (308, E'Categoria 2', 314.15, E'Categoria 2', E'Loc Categoria 2.', 85);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (309, E'Categoria 3', 230.09, E'Categoria 3', E'Loc Categoria 3.', 85);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (310, E'Categoria 4', 177.56, E'Categoria 4', E'Loc Categoria 4.', 85);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (311, E'Categoria 5', 125.03, E'Categoria 5', E'Loc Categoria 5.', 85);

-- ---- Bilete pentru id_event 86: Heart Society x INNA x Dirty Nano (312-313) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (312, E'Acces General - Presale Phase 4', 94.36, E'Acces general - Phase 4', E'Bilet Acces General Phase 4. Stoc limitat.', 86);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (313, E'VIP Phase 3', 157.26, E'VIP - Phase 3', E'Bilet VIP Phase 3. Stoc limitat.', 86);

-- ---- Bilete pentru id_event 87: IRIS Primii 45 (314-320) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (314, E'Premium', 272.56, E'Premium - sectoarele K si E', E'Loc in sectoarele K si E. Acces si in categoria Teren, earlyentry si afis cadou.', 87);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (315, E'Teren', 200.45, E'Teren - in fata scenei', E'Fara loc, in fata scenei.', 87);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (316, E'Acces General', 169.54, E'Acces general - Arena', E'Loc in Arena (mai putin sectoarele K si E) sau fara loc in spatele Teren.', 87);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (317, E'Bilete persoane cu dizabilitati', 0, E'Acces dizabilitati', E'Bilete gratuite pentru persoane cu handicap grav/accentuat plus insotitor. Necesita documente justificative.', 87);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (318, E'Premium 3X PACK', 220.02, E'Pachet 3 bilete Premium', E'Pachet 3 bilete Premium cu reducere. Oferta limitata.', 87);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (319, E'Teren 3X PACK', 158.2, E'Pachet 3 bilete Teren', E'Pachet 3 bilete Teren cu reducere. Oferta limitata.', 87);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (320, E'Acces General 3X PACK', 116.99, E'Pachet 3 bilete Acces General', E'Pachet 3 bilete Acces General cu reducere. Oferta limitata.', 87);

-- ---- Bilete pentru id_event 88: SAVATAGE si Trooper (321-326) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (321, E'Premium', 350.95, E'Premium - sectoarele K si E', E'Loc in sectoarele K si E. Acces si in categoria Teren, earlyentry si afis cadou.', 88);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (322, E'Teren', 278.83, E'Teren - in fata scenei', E'Fara loc, in fata scenei.', 88);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (323, E'Acces General', 196.41, E'Acces general - Arena', E'Loc in Arena (mai putin sectoarele K si E) sau fara loc in spatele Teren.', 88);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (324, E'Premium 3X PACK', 264.41, E'Pachet 3 bilete Premium', E'Pachet 3 bilete Premium cu pret redus. Oferta limitata.', 88);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (325, E'Teren 3X PACK', 212.9, E'Pachet 3 bilete Teren', E'Pachet 3 bilete Teren cu pret redus. Oferta limitata.', 88);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (326, E'Acces General 3X PACK', 151.08, E'Pachet 3 bilete Acces General', E'Pachet 3 bilete Acces General cu pret redus. Oferta limitata.', 88);

-- ---- Bilete pentru id_event 89: Deep Forest Fest VII (327) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (327, E'Blind Price', 106.05, E'Acces general primul tier', E'Bilet Blind Price - acces general 2 zile, primul tier la Deep Forest Fest 2026 pe Platoul Feteni.', 89);

COMMIT;

-- =====================================================================
-- Verificare rapida
-- =====================================================================
SELECT 'Evenimente noi (71-89): ' || COUNT(*)::text AS status FROM public."Evenimente" WHERE id_event BETWEEN 71 AND 89;
SELECT 'Evenimente updated (4, 5): ' || COUNT(*)::text AS status FROM public."Evenimente" WHERE id_event IN (4, 5);
SELECT 'Bilete noi (200+): ' || COUNT(*)::text AS status FROM public."Bilet" WHERE id_bilet >= 200;
