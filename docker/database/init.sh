#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    
    CREATE DATABASE db_addresses;
	CREATE DATABASE db_customers;

    \c db_addresses
    
    CREATE TABLE "Address" (
	id serial NOT NULL,
	zipCode VARCHAR (8) NOT NULL,
	publicArea VARCHAR (255) NOT NULL,
	neighborhood VARCHAR (100) NOT NULL,
	city VARCHAR (100) NOT NULL,
	state VARCHAR (100) NOT NULL,
	CONSTRAINT "Address_PK" PRIMARY KEY (id)
	);

    \c db_customers

    CREATE TABLE "Customer" (
    id serial NOT NULL,
    "idAddress" integer NULL,
    name VARCHAR (100) NOT NULL,
    surname VARCHAR (100) NOT NULL,
    cpf VARCHAR (100) NOT NULL,
    genre CHAR (1) NOT NULL,
    CONSTRAINT "Customer_PK" PRIMARY KEY (id)
	);

	CREATE TABLE "Contact" (
    id serial NOT NULL,
    "idCustomer" integer NOT NULL,
    ddd VARCHAR (2) NOT NULL,
    number VARCHAR (20) NOT NULL,
    email VARCHAR (50) NOT NULL,
    CONSTRAINT "Contato_PK" PRIMARY KEY (id),
    CONSTRAINT "FK_id_Customer" FOREIGN KEY ("idCustomer")
        REFERENCES "Customer" (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
	);


EOSQL