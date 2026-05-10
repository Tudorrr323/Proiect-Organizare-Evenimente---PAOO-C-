-- =====================================================================
-- Ticketa - 10 evenimente virtuale reale (2026 - 2027)
-- Ruleaza DUPA iabilet_top21.sql
--
-- 10 evenimente noi: id_event 90-99
-- Bilete: id_bilet 328+
-- Pozele aferente se regasesc in folderul Images\
-- =====================================================================
BEGIN;

-- =====================================================================
-- Cleanup IDEMPOTENT pentru re-rulare
-- =====================================================================
DELETE FROM public."Cos_Bilet" WHERE id_bilet IN (
    SELECT id_bilet FROM public."Bilet" WHERE id_event BETWEEN 90 AND 99
);
DELETE FROM public."Cos_Bilet" WHERE id_bilet BETWEEN 328 AND 360;
DELETE FROM public."Bilet" WHERE id_event BETWEEN 90 AND 99;
DELETE FROM public."Bilet" WHERE id_bilet BETWEEN 328 AND 360;
DELETE FROM public."Evenimente" WHERE id_event BETWEEN 90 AND 99;

-- =====================================================================
-- INSERT evenimente virtuale (90-99)
-- =====================================================================

-- 90: Apple WWDC 2026 (8-12 iunie 2026, online)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(90, E'Apple WWDC 2026', E'A week of online sessions to discover the latest iOS, macOS, iPadOS, watchOS, and visionOS updates. Free for all developers worldwide.', E'https://developer.apple.com/wwdc26/', E'2026-06-08 17:00:00+00', E'Apple', E'wwdc_2026.png', NULL, E'virtual', 1000, NULL);

-- 91: Microsoft Build 2026 (2-3 iunie 2026, online + SF)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(91, E'Microsoft Build 2026', E'Microsoft developer conference streamed live from San Francisco. Keynotes and AI-focused sessions for technical leaders and enterprise developers.', E'https://build.microsoft.com/', E'2026-06-02 16:30:00+00', E'Microsoft', E'msbuild_2026.png', NULL, E'virtual', 1000, NULL);

-- 92: Cannes Lions 2026 (22-26 iunie 2026, virtual digital pass)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(92, E'Cannes Lions 2026 Digital Pass', E'Five-day International Festival of Creativity streamed online. Award ceremonies, talks, and creative content from the global advertising industry.', E'https://www.canneslions.com/', E'2026-06-22 09:00:00+00', E'Ascential', E'cannes_lions_2026.png', NULL, E'virtual', 1000, NULL);

-- 93: Black Hat USA 2026 (5-6 august 2026, virtual briefings)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(93, E'Black Hat USA 2026 - Briefings Stream', E'Cutting-edge cybersecurity research streamed from Las Vegas. On-demand access to all recorded Briefings for 30 days post-event.', E'https://blackhat.com/us-26/', E'2026-08-05 09:00:00+00', E'Informa Tech', E'blackhat_2026.png', NULL, E'virtual', 1000, NULL);

-- 94: DEF CON 34 (6-9 august 2026, virtual content)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(94, E'DEF CON 34', E'The world largest hacker conference brings villages, contests, and talks to global audiences via streamed sessions and DEF CON Media Server.', E'https://defcon.org/', E'2026-08-06 10:00:00+00', E'DEF CON', E'defcon_34.png', NULL, E'virtual', 1000, NULL);

-- 95: Dreamforce 2026 (15-17 septembrie 2026, Salesforce+ stream)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(95, E'Dreamforce 2026 on Salesforce+', E'Three days of innovation streamed live from Moscone Center. 400+ sessions, virtual hands-on trainings, and the world most influential voices.', E'https://www.salesforce.com/dreamforce/', E'2026-09-15 16:00:00+00', E'Salesforce', E'dreamforce_2026.png', NULL, E'virtual', 1000, NULL);

-- 96: GitHub Universe 2026 (28-29 octombrie 2026, virtual + SF)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(96, E'GitHub Universe 2026', E'Two days of 100+ sessions, live demos, and immersive AI experiences for developers, leaders, and innovators. Stream from anywhere in the world.', E'https://githubuniverse.com/', E'2026-10-28 16:00:00+00', E'GitHub', E'github_universe_2026.png', NULL, E'virtual', 1000, NULL);

-- 97: Adobe MAX 2026 (10-11 noiembrie 2026, virtual free)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(97, E'Adobe MAX 2026 - The Creativity Conference', E'The annual Adobe MAX online conference with creative tutorials, keynotes, and the latest Creative Cloud announcements. Free virtual access.', E'https://www.adobe.com/max.html', E'2026-11-10 17:00:00+00', E'Adobe', E'adobe_max_2026.png', NULL, E'virtual', 1000, NULL);

-- 98: AWS re:Invent 2026 (30 nov - 4 dec 2026, virtual content hub)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(98, E'AWS re:Invent 2026 Virtual Stream', E'Stream the largest annual gathering of the cloud and AI community. Keynotes, 2,100+ sessions, and security content merged from re:Inforce.', E'https://reinvent.awsevents.com/', E'2026-11-30 17:00:00+00', E'Amazon Web Services', E'aws_reinvent_2026.png', NULL, E'virtual', 1000, NULL);

-- 99: The Game Awards 2026 (10 decembrie 2026, YouTube/Twitch)
INSERT INTO public."Evenimente" (id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user) VALUES
(99, E'The Game Awards 2026', E'Live celebration of the year top games streamed worldwide on YouTube, Twitch, and all major platforms from Peacock Theater LA.', E'https://thegameawards.com/', E'2026-12-10 23:30:00+00', E'The Game Awards', E'game_awards_2026.png', NULL, E'virtual', 1000, NULL);

-- =====================================================================
-- INSERT bilete (id_bilet 328+)
-- =====================================================================

-- ---- WWDC 2026 (id 90) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (328, E'Free Online Pass', 0, E'Online - Apple Developer', E'Free pass for all registered Apple Developer Program members. Full access to keynotes and 100+ sessions on demand.', 90);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (329, E'Apple Park Special Event', 0, E'Apple Park - in person (lottery)', E'Limited in-person attendance at Apple Park on June 8 - awarded by lottery. Free of charge for selected developers and students.', 90);

-- ---- Microsoft Build 2026 (id 91) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (330, E'Free Online Pass', 0, E'Online - Microsoft Events', E'Free virtual pass with access to all keynotes and live-streamed sessions.', 91);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (331, E'In-Person Pass', 5499, E'Fort Mason Center, San Francisco', E'In-person attendance at Fort Mason Center San Francisco June 2-3. Approx 1099 USD.', 91);

-- ---- Cannes Lions 2026 (id 92) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (332, E'Digital Pass', 4495, E'Online streaming', E'Online access to all live sessions, on-demand content and the Cannes Lions Digital app. Approx 899 GBP.', 92);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (333, E'Classic Pass', 22495, E'Palais des Festivals + Online', E'Five-day in-person access at Palais des Festivals plus full digital pass content. Approx 4495 GBP.', 92);

-- ---- Black Hat USA 2026 (id 93) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (334, E'Briefings - Recorded Access', 4499, E'Streamly OnDemand', E'Twelve months on-demand access to all Black Hat USA 2026 Briefings recordings via Streamly. Approx 899 USD add-on.', 93);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (335, E'Briefings In-Person + Virtual', 14999, E'Mandalay Bay Las Vegas', E'Two-day Briefings pass with in-person attendance plus 30-day on-demand recordings. Approx 2995 USD.', 93);

-- ---- DEF CON 34 (id 94) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (336, E'Online Stream Pass', 0, E'DEF CON Media Server', E'Free access to streamed talks and the DEF CON Media Server published after the event. Pay-what-you-can supporter tier optional.', 94);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (337, E'Human Badge In-Person', 2300, E'Las Vegas Convention Center', E'In-person Human badge for full access to all four days of DEF CON 34. Approx 460 USD cash at the door.', 94);

-- ---- Dreamforce 2026 (id 95) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (338, E'Salesforce+ Free Stream', 0, E'Salesforce+ platform', E'Free virtual access through the Salesforce+ streaming platform with 400+ on-demand sessions and keynotes.', 95);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (339, E'Full Conference Pass', 9999, E'Moscone Center, San Francisco', E'In-person three-day conference pass plus full Salesforce+ access on demand. Approx 1999 USD.', 95);

-- ---- GitHub Universe 2026 (id 96) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (340, E'Virtual Pass', 0, E'GitHub Universe Online', E'Free virtual pass for two days of 100+ sessions, AI demos, and live Q&A.', 96);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (341, E'In-Person Pass', 4999, E'Fort Mason Center, San Francisco', E'Two-day in-person access at Fort Mason Center plus full virtual pass on demand. Approx 999 USD early bird.', 96);

-- ---- Adobe MAX 2026 (id 97) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (342, E'Free Online Pass', 0, E'Online - Adobe MAX', E'Free virtual access to selected sessions during the conference plus on-demand for two years post-event.', 97);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (343, E'Full In-Person Pass', 9499, E'Miami Beach Convention Center', E'Three-day in-person access in Miami Beach plus full virtual pass. Approx 1895 USD with early bird.', 97);

-- ---- AWS re:Invent 2026 (id 98) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (344, E'Free Content Hub Stream', 0, E'AWS Events Content Hub', E'Free virtual access to keynotes and selected live-streamed sessions plus on-demand content post-event.', 98);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (345, E'Full Conference Pass', 10499, E'Las Vegas Strip Venues', E'Five-day in-person pass for AWS re:Invent in Las Vegas with merged re:Inforce security content. Approx 2099 USD.', 98);

-- ---- The Game Awards 2026 (id 99) ----
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (346, E'Free Livestream', 0, E'YouTube / Twitch / Steam', E'Free worldwide livestream of the ceremony on all major platforms. Approx 3 hours of awards plus world premieres.', 99);
INSERT INTO public."Bilet" (id_bilet, denumire, pret, loc_eveniment, description, id_event) VALUES (347, E'In-Person VIP Seat', 1999, E'Peacock Theater, Los Angeles', E'In-person VIP seat at Peacock Theater Los Angeles for the live ceremony. Limited public availability.', 99);

COMMIT;

-- =====================================================================
-- Verificare
-- =====================================================================
SELECT 'Evenimente virtuale (90-99): ' || COUNT(*)::text AS status FROM public."Evenimente" WHERE id_event BETWEEN 90 AND 99;
SELECT 'Bilete virtuale (328-347): ' || COUNT(*)::text AS status FROM public."Bilet" WHERE id_bilet BETWEEN 328 AND 360;
