
\connect db_clientes

CREATE TABLE "Cliente"
(
    id serial NOT NULL,
    nome character varying(100) COLLATE pg_catalog."default" NOT NULL,
    sobrenome character varying(100) COLLATE pg_catalog."default" NOT NULL,
    cpf character varying(11) COLLATE pg_catalog."default" NOT NULL,
    sexo "char" NOT NULL,
    CONSTRAINT "Cliente_PK" PRIMARY KEY (id)
);

ALTER TABLE "Cliente" OWNER TO postgres;

CREATE TABLE "Contato"
(
    id serial NOT NULL,
    "idCliente" integer NOT NULL,
    ddd character varying(2) COLLATE pg_catalog."default" NOT NULL,
    numero character varying(20) COLLATE pg_catalog."default" NOT NULL,
    email character varying(50) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Contato_PK" PRIMARY KEY (id),
    CONSTRAINT "FK_id_Cliente" FOREIGN KEY ("idCliente")
        REFERENCES "Cliente" (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

ALTER TABLE "Contato" OWNER TO postgres;