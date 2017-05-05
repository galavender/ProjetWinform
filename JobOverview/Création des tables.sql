if exists (select * from sys.types where name='TypeTableTache')
drop type TypeTableTache
go

create type TypeTableTache 
as table
(
	IdTache uniqueidentifier,
	Libelle nvarchar(40),
	Annexe bit,
	CodeActivite varchar(20),
	Login varchar(20),
	description nvarchar(1000) not null
)
go


if exists (select * from sys.types where name='TypeTableTacheProd')
drop type TypeTableTacheProd
go


create type TypeTableTacheProd
as table
(
	IdTache uniqueidentifier,
	DureePrevue float(5),
	DureeRestanteEstimee float(5),
	CodeModule varchar(20),
	CodeLogicielModule varchar(20),
	NumeroVersion float(4),
	CodeLogicielVersion varchar(20)
)
go