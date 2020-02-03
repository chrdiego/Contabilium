create database integrador
go

use integrador
go

create table TipoUsuario (
IDTipoUsuario int identity (1, 1) not null,
Tipo nvarchar(2000) not null,
CONSTRAINT PK_TipoUsuario primary key clustered (IDTipoUsuario)
)
go

create table Usuario (
IDUsuario int identity (1,1) not null,
Nombre nvarchar(200) not null,
Apellido nvarchar(200) not null,
Edad int not null,
Estado bit not null,
IDTipoUsuario  int not null,
CONSTRAINT PK_Usuario primary key clustered (IDUsuario)
)
go

alter table [dbo].[Usuario] WITH NOCHECK add CONSTRAINT [FK_Usuario_TipoUsuario] Foreign Key([IDTipoUsuario])
references [dbo].[TipoUsuario] ([IDTipoUsuario])
go

alter table [dbo].[Usuario] check constraint [FK_Usuario_TipoUsuario]
go