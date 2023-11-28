-- Paso 1 --
create database AstronautasDB



-- Paso 2 --
use AstronautasDB


-- Paso 3 --
-- Creacion de la Tabla Astronautas --
create table Astronautas(
	IdAstronauta int identity(1,1) primary key,
	Foto varchar(max),
	Nombre varchar(60), 
	Nacionalidad varchar(50) default ,
	Descripcion varchar(500),
	FechaNacimiento Date,
	FechaFallecimiento Date,
	Edad int,
	RedesSociales varchar(500),
	DetallesMisiones varchar(500),
	Activo bit default 1
)


-- Paso 4 --
-- Creacion de los Procedimientos Almacenados --
create procedure sp_Listar
as
begin
	select * from Astronautas
end


-- Paso 5 --
create procedure sp_Obtener(
@IdAstronauta int
)
as
begin
	select * from Astronautas where IdAstronauta = @IdAstronauta
end



-- Paso 6 --
create procedure sp_Guardar(
@Foto varchar(max),
@Nombre varchar(60), 
@Nacionalidad varchar(50),
@Descripcion varchar(500),
@FechaNacimiento Date,
@FechaFallecimiento Date,
@Edad int,
@RedesSociales varchar(500),
@DetallesMisiones varchar(500)
)
as
begin
	insert into Astronautas(Foto, Nombre, Nacionalidad, Descripcion, FechaNacimiento, FechaFallecimiento, Edad, RedesSociales, DetallesMisiones)
	values (@Foto, @Nombre, @Nacionalidad, @Descripcion, @FechaNacimiento, @FechaFallecimiento, @Edad, @RedesSociales, @DetallesMisiones)
end






-- Paso 7 --
create procedure sp_Editar(
@IdAstronauta int,
@Foto varchar(max),
@Nombre varchar(60), 
@Nacionalidad varchar(50),
@Descripcion varchar(500),
@FechaNacimiento Date,
@FechaFallecimiento Date,
@Edad int,
@RedesSociales varchar(500),
@DetallesMisiones varchar(500),
@Activo bit
)
as
begin
	update Astronautas set Foto = @Foto, Nombre = @Nombre, Nacionalidad = @Nacionalidad, Descripcion = @Descripcion,
	FechaNacimiento = @FechaNacimiento, FechaFallecimiento = @FechaFallecimiento, Edad = @Edad, RedesSociales = @RedesSociales, DetallesMisiones = @DetallesMisiones,
	Activo = @Activo
	where IdAstronauta = @IdAstronauta
end


--Paso 8--
create procedure sp_Eliminar(
@IdAstronauta int
)
as
begin
 delete from Astronautas where IdAstronauta = @IdAstronauta
end


