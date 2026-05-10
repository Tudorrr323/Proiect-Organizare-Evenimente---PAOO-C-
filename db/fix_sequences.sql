-- =====================================================================
-- Ticketa - Fix pentru sequence-urile IDENTITY
-- Ruleaza in pgAdmin DUPA toate scripturile cu INSERT-uri explicite
-- (data.sql, iabilet_top21.sql, virtual_events_10.sql, etc.)
--
-- Cauza: cand inserezi cu id explicit, sequence-ul NU se auto-incrementeaza.
-- Aplicatia (care insereaza fara id) genereaza apoi id-uri care exista deja.
-- =====================================================================

-- Users
SELECT setval(pg_get_serial_sequence('public."Users"', 'id_user'),
              GREATEST(COALESCE((SELECT MAX(id_user) FROM public."Users"), 0), 1));

-- Orase
SELECT setval(pg_get_serial_sequence('public."Orase"', 'id_oras'),
              GREATEST(COALESCE((SELECT MAX(id_oras) FROM public."Orase"), 0), 1));

-- Evenimente
SELECT setval(pg_get_serial_sequence('public."Evenimente"', 'id_event'),
              GREATEST(COALESCE((SELECT MAX(id_event) FROM public."Evenimente"), 0), 1));

-- Bilet
SELECT setval(pg_get_serial_sequence('public."Bilet"', 'id_bilet'),
              GREATEST(COALESCE((SELECT MAX(id_bilet) FROM public."Bilet"), 0), 1));

-- Cos
SELECT setval(pg_get_serial_sequence('public."Cos"', 'id_cos'),
              GREATEST(COALESCE((SELECT MAX(id_cos) FROM public."Cos"), 0), 1));

-- Cos_Bilet
SELECT setval(pg_get_serial_sequence('public."Cos_Bilet"', 'id_cos_bilet'),
              GREATEST(COALESCE((SELECT MAX(id_cos_bilet) FROM public."Cos_Bilet"), 0), 1));

-- =====================================================================
-- Verificare: fiecare sequence trebuie sa fie >= MAX(id) corespunzator
-- =====================================================================
SELECT 'Users'      AS tabel, MAX(id_user)      AS max_id, currval(pg_get_serial_sequence('public."Users"',     'id_user'))     AS seq_curent FROM public."Users"
UNION ALL SELECT 'Orase',     MAX(id_oras),  currval(pg_get_serial_sequence('public."Orase"',     'id_oras'))     FROM public."Orase"
UNION ALL SELECT 'Evenimente',MAX(id_event), currval(pg_get_serial_sequence('public."Evenimente"','id_event'))   FROM public."Evenimente"
UNION ALL SELECT 'Bilet',     MAX(id_bilet), currval(pg_get_serial_sequence('public."Bilet"',     'id_bilet'))   FROM public."Bilet"
UNION ALL SELECT 'Cos',       MAX(id_cos),   currval(pg_get_serial_sequence('public."Cos"',       'id_cos'))     FROM public."Cos"
UNION ALL SELECT 'Cos_Bilet', MAX(id_cos_bilet), currval(pg_get_serial_sequence('public."Cos_Bilet"','id_cos_bilet')) FROM public."Cos_Bilet";
