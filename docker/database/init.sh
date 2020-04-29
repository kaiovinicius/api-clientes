#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    
    CREATE DATABASE db_enderecos;
	CREATE DATABASE db_clientes;

    \c db_enderecos
    
    CREATE TABLE "Endereco" (
	id serial NOT NULL,
	cep VARCHAR (8) NOT NULL,
	logradouro VARCHAR (255) NOT NULL,
	bairro VARCHAR (100) NOT NULL,
	cidade VARCHAR (100) NOT NULL,
	estado VARCHAR (100) NOT NULL,
	CONSTRAINT "Endereco_PK" PRIMARY KEY (id)
	);

    \c db_clientes

    CREATE TABLE "Cliente" (
    id serial NOT NULL,
    nome VARCHAR (100) NOT NULL,
    sobrenome VARCHAR (100) NOT NULL,
    cpf VARCHAR (100) NOT NULL,
    sexo CHAR (1) NOT NULL,
    CONSTRAINT "Cliente_PK" PRIMARY KEY (id)
	);

	CREATE TABLE "Contato" (
    id serial NOT NULL,
    "idCliente" integer NOT NULL,
    ddd VARCHAR (2) NOT NULL,
    numero VARCHAR (20) NOT NULL,
    email VARCHAR (50) NOT NULL,
    CONSTRAINT "Contato_PK" PRIMARY KEY (id),
    CONSTRAINT "FK_id_Cliente" FOREIGN KEY ("idCliente")
        REFERENCES "Cliente" (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
	);


EOSQL