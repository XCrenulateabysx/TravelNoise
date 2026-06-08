-- =========================
-- USER
-- =========================
INSERT INTO public."User" ("Username", "Password")
VALUES
('admin', '$2a$11$hash_admin'),
('player1', '$2a$11$hash_player1'),
('tester', '$2a$11$hash_tester');

-- =========================
-- GENRE
-- =========================
INSERT INTO public.genre (genrename)
VALUES
('Adventure'),
('Puzzle'),
('Racing');

-- =========================
-- THEORYPAGES
-- =========================
INSERT INTO public.theorypages (title, description, imageurl)
VALUES
('Physics Basics', 'Understanding movement in games', 'http://localhost:5035/images/WTTTTTTTTTF.png'),
('AI Behavior', 'How game AI reacts to players', 'http://localhost:5035/images/WTTTTTTTF.png'),
('Level Design', 'Designing engaging game levels', 'http://localhost:5035/images/WTTTTTTTF.png');

-- =========================
-- GAMEDESCRIPTION (FIXED: 1 row per genre ONLY)
-- =========================
INSERT INTO public.gamedescription (genreid)
SELECT id FROM public.genre WHERE genrename = 'Adventure';

INSERT INTO public.gamedescription (genreid)
SELECT id FROM public.genre WHERE genrename = 'Puzzle';

INSERT INTO public.gamedescription (genreid)
SELECT id FROM public.genre WHERE genrename = 'Racing';

-- =========================
-- LOCATION (already 1:1 per genre, so safe)
-- =========================
INSERT INTO public."Location" (genreid)
SELECT id FROM public.genre WHERE genrename = 'Adventure';

INSERT INTO public."Location" (genreid)
SELECT id FROM public.genre WHERE genrename = 'Puzzle';

INSERT INTO public."Location" (genreid)
SELECT id FROM public.genre WHERE genrename = 'Racing';

-- =========================
-- PAGES
-- =========================
INSERT INTO public.pages ("PageDescription", "PageTitle", userid, genreid)
SELECT
    'Adventure gameplay guide',
    'Adventure Guide',
    u."Id",
    g.id
FROM public."User" u
JOIN public.genre g ON g.genrename = 'Adventure'
WHERE u."Username" = 'admin';

INSERT INTO public.pages ("PageDescription", "PageTitle", userid, genreid)
SELECT
    'Puzzle solving techniques',
    'Puzzle Guide',
    u."Id",
    g.id
FROM public."User" u
JOIN public.genre g ON g.genrename = 'Puzzle'
WHERE u."Username" = 'player1';

INSERT INTO public.pages ("PageDescription", "PageTitle", userid, genreid)
SELECT
    'Racing mechanics explained',
    'Racing Guide',
    u."Id",
    g.id
FROM public."User" u
JOIN public.genre g ON g.genrename = 'Racing'
WHERE u."Username" = 'tester';

-- =========================
-- PRACTICE
-- =========================
INSERT INTO public.practice (practicetype, pageid)
SELECT 1, p."Id" FROM public.pages p WHERE p."PageTitle" = 'Adventure Guide';

INSERT INTO public.practice (practicetype, pageid)
SELECT 2, p."Id" FROM public.pages p WHERE p."PageTitle" = 'Puzzle Guide';

INSERT INTO public.practice (practicetype, pageid)
SELECT 3, p."Id" FROM public.pages p WHERE p."PageTitle" = 'Racing Guide';

-- =========================
-- VOTE
-- =========================
INSERT INTO public.vote ("UserId", pageid)
SELECT u."Id", p."Id"
FROM public."User" u
JOIN public.pages p ON p."PageTitle" = 'Adventure Guide'
WHERE u."Username" = 'admin';

INSERT INTO public.vote ("UserId", pageid)
SELECT u."Id", p."Id"
FROM public."User" u
JOIN public.pages p ON p."PageTitle" = 'Puzzle Guide'
WHERE u."Username" = 'player1';

INSERT INTO public.vote ("UserId", pageid)
SELECT u."Id", p."Id"
FROM public."User" u
JOIN public.pages p ON p."PageTitle" = 'Racing Guide'
WHERE u."Username" = 'tester';