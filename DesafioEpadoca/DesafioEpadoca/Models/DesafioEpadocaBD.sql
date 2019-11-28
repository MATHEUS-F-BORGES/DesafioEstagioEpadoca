create database DesafioEpadocaBD

create table Padaria
(
  IdPadaria   int           primary key   identity,
  Nome        varchar(60)   not null,
  Endereco       varchar(100)  not null
)

insert into Padaria values ('Epadoca teste', 'Rua das marmuras Nº 100') 
insert into Padaria values ('Epadoca xpto', 'Epadoca das epadocas')

use DesafioEpadocaBD

