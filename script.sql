CREATE DATABASE agendacontatos;

USE agendacontatos;

CREATE TABLE TipoContato (
	Codigo int not null primary key,
	Descricao varchar(256) not null
);

CREATE TABLE Contato (
	Codigo int not null primary key,
	Nome varchar(256) not null,
	Telefone varchar(32) not null,
	CodigoTipoContato int not null
);

ALTER TABLE Contato ADD CONSTRAINT Contato_TipoContato_FK FOREIGN KEY (CodigoTipoContato) REFERENCES TipoContato(Codigo);