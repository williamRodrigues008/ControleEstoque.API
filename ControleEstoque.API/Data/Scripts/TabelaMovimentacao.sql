create table Movimentacao(
Id int primary key identity,
[Local] varchar(30) not null, 
Solicitante varchar(30) not null,
Responsavel varchar(30) not null,
DataMovimentacao datetime not null
)