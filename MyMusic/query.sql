use Music
create table Brani(
ID  int identity(1,1) primary key,
Titolo nvarchar(50) not null,
Band nvarchar(50) not null,
Album nvarchar(50)  null,
AnnoUscita int null,
Durata decimal null,
Genere nvarchar(50)  null)

create table Album(
ID  int identity(1,1) primary key,
Titolo nvarchar(50) not null,
IdBrani int not null,
IdBand int not null,
AnnoUscita int null)

create table Artisti(
ID  int identity(1,1) primary key,
Nome nvarchar(50) not null,
Cognome nvarchar(50) not null,
NomeArte nvarchar(50) not null,
Tipo nvarchar(50)  null)

create table Band(
ID  int identity(1,1) primary key,
Nome nvarchar(50) not null,
IdArtista int not null,
Immagine nvarchar(2083) null,
Genere nvarchar(50) null)

insert into Brani(Titolo,Band,AnnoUscita,Durata)
values('Estate','Negramaro',2010,2.50)
insert into Brani(Titolo,Band,AnnoUscita,Durata)
values('Come mai','883',2005,3.20)
insert into Brani(Titolo,Band,Album,Durata,AnnoUscita)
values('Autunno','Test','Primo album',3.30,2015)


insert into Album(Titolo,IdBrani,IdBand,AnnoUscita)
values('Primo album',1,1,2010)

insert into Artisti(Nome,Cognome,NomeArte)
values('Andrea','Rossi','Red')

insert into Band(Nome,IdArtista,Genere)
values('Test',2,'Rock')

drop table Brani

select * from Brani
select * from Album
select * from Artisti
select * from Band