-- =====================================================================
-- Ticketa - Migrare ADMIN ROLE + suspendare conturi/evenimente
-- Ruleaza in pgAdmin DUPA toate celelalte SQL-uri
-- Idempotent: poate fi rulat de mai multe ori
-- =====================================================================
BEGIN;

-- =====================================================================
-- 1. Adaugare coloana is_suspended pe Users
-- =====================================================================
ALTER TABLE public."Users"
    ADD COLUMN IF NOT EXISTS is_suspended boolean NOT NULL DEFAULT false;

-- =====================================================================
-- 2. Adaugare coloana is_suspended pe Evenimente
-- =====================================================================
ALTER TABLE public."Evenimente"
    ADD COLUMN IF NOT EXISTS is_suspended boolean NOT NULL DEFAULT false;

-- Index util pentru filtrarea evenimentelor active (non-admin)
CREATE INDEX IF NOT EXISTS idx_evenimente_suspended ON public."Evenimente" (is_suspended);

-- =====================================================================
-- 3. Promovam un user existent la rol admin (Tudor Chirita - id 6)
--    sau creem unul nou daca nu exista
-- =====================================================================
UPDATE public."Users"
SET role = 'admin'
WHERE id_user = 6;

-- Daca nu exista user id 6, INSERT cont admin default (admin@ticketa.ro / parola: admin)
INSERT INTO public."Users" (fname, lname, email, password, phone_number, bday, role, company, creation_date)
SELECT E'Admin', E'Principal', E'admin@ticketa.ro', E'admin', E'+40700000000', E'1990-01-01', E'admin', NULL, NOW()
WHERE NOT EXISTS (SELECT 1 FROM public."Users" WHERE role = 'admin');

COMMIT;

-- =====================================================================
-- Verificare
-- =====================================================================
SELECT 'Coloana is_suspended pe Users: ' ||
       (SELECT COUNT(*)::text FROM information_schema.columns
        WHERE table_name = 'Users' AND column_name = 'is_suspended') AS check_users_col;

SELECT 'Coloana is_suspended pe Evenimente: ' ||
       (SELECT COUNT(*)::text FROM information_schema.columns
        WHERE table_name = 'Evenimente' AND column_name = 'is_suspended') AS check_event_col;

SELECT 'Useri admin: ' || COUNT(*)::text AS check_admin
FROM public."Users" WHERE role = 'admin';

SELECT id_user, fname, lname, email, role, is_suspended
FROM public."Users" WHERE role = 'admin';
