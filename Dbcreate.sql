
-- =========================
-- EXTENSIONS
-- =========================
CREATE EXTENSION IF NOT EXISTS "pgcrypto";

-- =========================
-- SCHEMA RESET (SAFE FOR DEV)
-- =========================
DROP SCHEMA public CASCADE;
CREATE SCHEMA public AUTHORIZATION pg_database_owner;

-- =========================
-- USER TABLE (UUID AUTO-GENERATED)
-- =========================
CREATE TABLE public."User" (
    "Id" uuid NOT NULL DEFAULT gen_random_uuid(),
    "Username" text NOT NULL,
    "Password" text NOT NULL,
    CONSTRAINT "User_pk" PRIMARY KEY ("Id")
);

-- =========================
-- GENRE
-- =========================
CREATE TABLE public.genre (
    id int4 GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    genrename varchar NULL
);

-- =========================
-- THEORYPAGES
-- =========================
CREATE TABLE public.theorypages (
    id int4 GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    title varchar NULL,
    description text NULL,
    imageurl varchar NULL
);

-- =========================
-- GAMEDESCRIPTION (1 per genre)
-- =========================
CREATE TABLE public.gamedescription (
    id int4 GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    genreid int4 NOT NULL,
    CONSTRAINT gamedescription_unique UNIQUE (genreid),
    CONSTRAINT gamedescription_genre_fk FOREIGN KEY (genreid) REFERENCES public.genre(id)
);

-- =========================
-- LOCATION (1 per genre)
-- =========================
CREATE TABLE public."Location" (
    id int4 GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    genreid int4 NOT NULL,
    CONSTRAINT location_unique UNIQUE (genreid),
    CONSTRAINT location_genre_fk FOREIGN KEY (genreid) REFERENCES public.genre(id)
);

-- =========================
-- PAGES
-- =========================
CREATE TABLE public.pages (
    "Id" serial PRIMARY KEY,
    "PageDescription" text,
    "PageTitle" text,
    userid uuid NOT NULL,
    genreid int4 NOT NULL,
    CONSTRAINT pages_user_fk FOREIGN KEY (userid) REFERENCES public."User"("Id"),
    CONSTRAINT pages_genre_fk FOREIGN KEY (genreid) REFERENCES public.genre(id)
);

-- =========================
-- PRACTICE
-- =========================
CREATE TABLE public.practice (
    id int4 GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    practicetype int4 NOT NULL,
    pageid int4 NOT NULL,
    CONSTRAINT practice_pages_fk FOREIGN KEY (pageid) REFERENCES public.pages("Id")
);

-- =========================
-- VOTE
-- =========================
CREATE TABLE public.vote (
    "Id" serial PRIMARY KEY,
    "UserId" uuid NOT NULL,
    pageid int4 NOT NULL,
    CONSTRAINT vote_user_fk FOREIGN KEY ("UserId") REFERENCES public."User"("Id"),
    CONSTRAINT vote_pages_fk FOREIGN KEY (pageid) REFERENCES public.pages("Id")
);

-- =========================
-- OPTIONAL: INDEXES (performance)
-- =========================
CREATE INDEX idx_pages_userid ON public.pages(userid);
CREATE INDEX idx_pages_genreid ON public.pages(genreid);
CREATE INDEX idx_vote_userid ON public.vote("UserId");
CREATE INDEX idx_vote_pageid ON public.vote(pageid);