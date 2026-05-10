-- =====================================================================
-- Ticketa - Cont admin nou: admin@ticketa.ro / 123456
-- Ruleaza in pgAdmin DUPA admin_migration.sql (care a adaugat coloana is_suspended)
-- Idempotent: poate fi rulat de mai multe ori
-- =====================================================================
BEGIN;

-- Stergem versiunea veche daca exista (din admin_migration.sql care punea parola 'admin')
DELETE FROM public."Users" WHERE email = 'admin@ticketa.ro';

-- Cont admin nou
INSERT INTO public."Users"
    (fname, lname, email, password, phone_number, bday, role, company, creation_date, is_suspended)
VALUES
    (E'Admin', E'Principal', E'admin@ticketa.ro', E'123456', E'+40700000000',
     E'1990-01-01', E'admin', NULL, NOW(), false);

COMMIT;

-- Verificare
SELECT id_user, fname, lname, email, role, is_suspended, creation_date
FROM public."Users"
WHERE email = 'admin@ticketa.ro';
