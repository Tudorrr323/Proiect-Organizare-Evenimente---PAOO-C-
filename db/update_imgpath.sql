-- =====================================================================
-- Convertire imgpath: din URL Supabase -> nume fisier local
-- Ruleaza in pgAdmin Query Tool DUPA data.sql
-- =====================================================================

-- Stergem prefixul Supabase Storage
UPDATE public."Evenimente"
SET imgpath = REPLACE(imgpath,
    'https://frglmxyomjqspveyszya.supabase.co/storage/v1/object/public/event-images/',
    '')
WHERE imgpath LIKE 'https://%';

-- Decodam URL-encoding (ex: "Event%20Test.png" -> "Event Test.png")
UPDATE public."Evenimente"
SET imgpath = REPLACE(imgpath, '%20', ' ')
WHERE imgpath LIKE '%\%20%' ESCAPE '\';

-- Verificare
SELECT id_event, name, imgpath FROM public."Evenimente" ORDER BY id_event;
