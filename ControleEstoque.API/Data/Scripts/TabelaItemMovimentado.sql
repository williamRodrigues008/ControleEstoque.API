Create table ItemMovimentado(
Id int identity primary key,
IdMovimentacao int not null,
Nome varchar(50) not null,
Quantidade int,
ProdutoQuimico bit,
Tipo varchar(10),
CONSTRAINT FK_ItemMovimentacao_Movimentacao foreign key (IdMovimentacao) references Movimentacao(Id)
)
