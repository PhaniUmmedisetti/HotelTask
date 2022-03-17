--
-- PostgreSQL database dump
--

-- Dumped from database version 13.6
-- Dumped by pg_dump version 13.6

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: classroom; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.classroom (
    class_id bigint NOT NULL,
    benches bigint,
    tables bigint
);


ALTER TABLE public.classroom OWNER TO postgres;

--
-- Name: student; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.student (
    student_id bigint NOT NULL,
    first_name character varying(100) NOT NULL,
    last_name character varying(100) NOT NULL,
    gender integer NOT NULL,
    address character varying(255) NOT NULL,
    class_id bigint,
    date_of_birth date
);


ALTER TABLE public.student OWNER TO postgres;

--
-- Name: student_student_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.student_student_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.student_student_id_seq OWNER TO postgres;

--
-- Name: student_student_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.student_student_id_seq OWNED BY public.student.student_id;


--
-- Name: student_subject; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.student_subject (
    student_id bigint,
    subject_id bigint
);


ALTER TABLE public.student_subject OWNER TO postgres;

--
-- Name: student_teacher; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.student_teacher (
    student_id bigint,
    teacher_id bigint
);


ALTER TABLE public.student_teacher OWNER TO postgres;

--
-- Name: subject; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.subject (
    subject_id bigint NOT NULL,
    subject_name character varying(50)
);


ALTER TABLE public.subject OWNER TO postgres;

--
-- Name: subject_subject_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.subject_subject_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.subject_subject_id_seq OWNER TO postgres;

--
-- Name: subject_subject_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.subject_subject_id_seq OWNED BY public.subject.subject_id;


--
-- Name: subject_teacher; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.subject_teacher (
    subject_id bigint,
    teacher_id bigint
);


ALTER TABLE public.subject_teacher OWNER TO postgres;

--
-- Name: teacher; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.teacher (
    teacher_id bigint NOT NULL,
    name character varying(90) NOT NULL,
    gender integer NOT NULL,
    mobile bigint NOT NULL,
    address character varying(255),
    subject_id bigint,
    date_of_birth date
);


ALTER TABLE public.teacher OWNER TO postgres;

--
-- Name: teacher_teacher_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.teacher_teacher_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.teacher_teacher_id_seq OWNER TO postgres;

--
-- Name: teacher_teacher_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.teacher_teacher_id_seq OWNED BY public.teacher.teacher_id;


--
-- Name: student student_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student ALTER COLUMN student_id SET DEFAULT nextval('public.student_student_id_seq'::regclass);


--
-- Name: subject subject_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subject ALTER COLUMN subject_id SET DEFAULT nextval('public.subject_subject_id_seq'::regclass);


--
-- Name: teacher teacher_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher ALTER COLUMN teacher_id SET DEFAULT nextval('public.teacher_teacher_id_seq'::regclass);


--
-- Data for Name: classroom; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.classroom (class_id, benches, tables) FROM stdin;
1	1	1
\.


--
-- Data for Name: student; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.student (student_id, first_name, last_name, gender, address, class_id, date_of_birth) FROM stdin;
2	@FirstName	@LastName	1	@Address	\N	\N
3	@FirstName	@LastName	1	@Address	\N	\N
4	@FirstName	@LastName	1	@Address	\N	\N
111111	p	phani	1	gwqvldwyeil	1	\N
5	@FirstName	@LastName	1	@Address	\N	\N
6	@FirstName	@LastName	2	@Address	\N	\N
7	@FirstName	@LastName	2	@Address	\N	\N
8	@FirstName	@LastName	1	@Address	\N	\N
9	@FirstName	@LastName	1	@Address	\N	\N
10	@FirstName	@LastName	1	@Address	\N	\N
11	@FirstName	@LastName	2	@Address	\N	\N
12	@FirstName	@LastName	1	@Address	\N	\N
13	@FirstName	@LastName	1	@Address	\N	\N
1	phani	sri	1	asdfghjkl	1	1998-04-22
100	sweety	sweety	2	asdfghjkl	1	1998-04-22
101	sweety	sweety	2	asdfghjkl	1	1998-04-22
\.


--
-- Data for Name: student_subject; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.student_subject (student_id, subject_id) FROM stdin;
1	12
100	11
\.


--
-- Data for Name: student_teacher; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.student_teacher (student_id, teacher_id) FROM stdin;
1	1
2	1
2	2
\.


--
-- Data for Name: subject; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.subject (subject_id, subject_name) FROM stdin;
101	Csharp
12	dotnet
11	dotnet
10	dotnet
\.


--
-- Data for Name: subject_teacher; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.subject_teacher (subject_id, teacher_id) FROM stdin;
10	3
11	2
12	1
\.


--
-- Data for Name: teacher; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.teacher (teacher_id, name, gender, mobile, address, subject_id, date_of_birth) FROM stdin;
1011	phani	1	1234567890	maths	101	\N
1	navya	1	1234567890	asdfghjkl	12	1998-01-02
2	phani	1	1234567890	asdfghjkl	12	1998-01-02
3	adnaan	1	1234567890	asdfghjkl	12	1998-01-02
111	test	1	1234567890	qwertyuiop	10	1998-04-22
\.


--
-- Name: student_student_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.student_student_id_seq', 13, true);


--
-- Name: subject_subject_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.subject_subject_id_seq', 1, false);


--
-- Name: teacher_teacher_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.teacher_teacher_id_seq', 1, false);


--
-- Name: classroom classroom_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.classroom
    ADD CONSTRAINT classroom_pkey PRIMARY KEY (class_id);


--
-- Name: student student_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT student_pkey PRIMARY KEY (student_id);


--
-- Name: subject subject_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subject
    ADD CONSTRAINT subject_pkey PRIMARY KEY (subject_id);


--
-- Name: teacher teacher_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT teacher_pkey PRIMARY KEY (teacher_id);


--
-- Name: student class_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student
    ADD CONSTRAINT class_id FOREIGN KEY (class_id) REFERENCES public.classroom(class_id) NOT VALID;


--
-- Name: student_teacher student_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student_teacher
    ADD CONSTRAINT student_id FOREIGN KEY (student_id) REFERENCES public.student(student_id);


--
-- Name: student_subject student_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student_subject
    ADD CONSTRAINT student_id FOREIGN KEY (student_id) REFERENCES public.student(student_id);


--
-- Name: student_subject subject_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student_subject
    ADD CONSTRAINT subject_id FOREIGN KEY (subject_id) REFERENCES public.subject(subject_id) NOT VALID;


--
-- Name: teacher subject_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teacher
    ADD CONSTRAINT subject_id FOREIGN KEY (subject_id) REFERENCES public.subject(subject_id) NOT VALID;


--
-- Name: subject_teacher subject_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subject_teacher
    ADD CONSTRAINT subject_id FOREIGN KEY (subject_id) REFERENCES public.subject(subject_id);


--
-- Name: student_teacher teacher_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.student_teacher
    ADD CONSTRAINT teacher_id FOREIGN KEY (teacher_id) REFERENCES public.teacher(teacher_id) NOT VALID;


--
-- Name: subject_teacher teacher_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subject_teacher
    ADD CONSTRAINT teacher_id FOREIGN KEY (teacher_id) REFERENCES public.teacher(teacher_id) NOT VALID;


--
-- PostgreSQL database dump complete
--

