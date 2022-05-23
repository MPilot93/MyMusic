use Music
create table Brani(
ID  int identity(1,1) primary key,
Titolo nvarchar(50) not null,
Band nvarchar(50) not null,
Album nvarchar(50)  null,
AnnoUscita int null,
Durata numeric null,
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
IdBand int null,
Tipo nvarchar(50)  null)

create table Band(
ID  int identity(1,1) primary key,
Nome nvarchar(50) not null,
IdArtista int not null,
Immagine nvarchar(2083) null,
Genere nvarchar(50) null)

insert into Brani(Titolo,Band,AnnoUscita)
values('Estate','Negramaro',2010)
insert into Brani(Titolo,Band,AnnoUscita)
values('Come mai','883',2005)
insert into Brani(Titolo,Band,Album)
values('Autunno','Test','Primo album')


insert into Album(Titolo,IdBrani,IdBand,AnnoUscita)
values('Primo album',1,1,2010)

insert into Artisti(Nome,Cognome,NomeArte,IdBand)
values('Andrea','Rossi','Red',1)

insert into Band(Nome,IdArtista,Genere)
values('Test',2,'Rock')

select * from Brani
select * from Album
select * from Artisti
select * from Band