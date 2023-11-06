
Insert Into Musica values ('One Night In Arabia', 'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\Musica\24-ONE NIGHT IN ARABIA.mp3','')

--CRUD
select * from Musica


select Nombre, Apodo, Equipo, Ranking, Victorias, Derrotas, PorcentajeCarrerasGanadas WinRate, MayorRival,
Altura, Peso, Edad, Bio Biografia, Foto FotoPiloto, Cornering, Braking, Reflexes, TyresManagement, Overtaking, Defending, Rain, Overall, Concentration, Presure, Experience, Agressive, Pace, Nacionalidad, Auto, PilotoID from Pilotos

Insert into Marca values (42,'Volkswagen',
'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Marcas\Volkswagen.png')

select a.AutoID ID, a.Nombre Nom, a.Anio An, a.Traccion Trac, a.PaisFabricacion Pais, HP, Torque, Peso, a.PesoPotencia PP, a.TopSpeed TS, a.Categoria Cat, a.Kilometraje K, m.NombreMarca NM, m.ImagenMarca IM, a.auto1 f1, a.auto2 f2, a.auto3 f3, a.auto4 f4, a.Auto5 f5   from Autos a, Marca m where a.Marca = m.ID 

Insert Into Pistas values ('Akagi','El Monte Akagi es una montaña en la prefectura de Gunma, Japón. El Monte Akagi, junto con Myogi y Akina, es una de las "Tres Montañas de Jōmō".',
'5,8Km','Japon, Prefectura de Gunma','Side By Side' ,
'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Pistas\Akagi.jpg'
,'3:12.896'
,'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Pistas\Akagi_2.jpg')

Insert into Pistas (Nombre, Bio, Distancia, Pais, ModalidadPreferida,Record, Imagenes, Imagen2, Layaout) values('', '', '', '', '', '', '', '', '');


--Insert Into Pilotos values ('Nombre', 'Apodo', 'Equipo', 'Ranking', 'Victorias', 'Derrotas', 'Porcentaje', 'Rival',
--'Altura', 'Peso', 'Edad', 'Bio', 'Foto', 'Cornering', 'Brakin', 'Reflexes', 'Tyres', 'Overtaking', 'Defending',
--'Rain', 'Overall',  'Concentration', 'Pressure','Experience/Adaptabilidad', 'Agresividad', 'Pace', 'Pais', 'Auto-Foto','Auto-Foto2','Auto-Foto3','Auto-Foto4','Auto-Foto'5)

Insert Into Pilotos values ('Lewis Hamilton', 'Lewis', 'Mercedes AMG', 'Leyenda', 104, 250, 0.3, 'Max Verstappen',
'1,73 M', '65 Kg', '39', 'Itsuki trabaja a tiempo parcial en una gasolinera con Takumi e Iketani; Itsuki planea usar el dinero que gana para comprar un AE86 Corolla Levin (para complementar el AE86 Trueno de Takumi), pero compra erróneamente un AE85 inferior (menos potencia, frenos pobres, menos refuerzos del chasis y suspensión más floja). Esto lo molesta hasta que Takumi lo lleva a dar un paseo (finalmente corriendo cuesta abajo), demostrando que la habilidad del conductor puede marcar la diferencia. Con un coche, es un autoproclamado miembro de los Akina SpeedStars. A diferencia de Kenji e Iketani, Itsuki es el "miembro" más optimista y excitable de los SpeedStars. Finalmente compra un turbocompresor para su Eight-Five. Autoproclamado "Lonely Driver".',
'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Drivers\Piloto\Hamilton-Plantilla.jpg', '93', '95', '88', '79', '84', '90',
'5', '30',  '5', '11','16', '55', '34', 
'https://static.vecteezy.com/system/resources/previews/012/165/400/original/england-square-flag-button-social-media-communication-sign-business-icon-vector.jpg',
'https://cdn-5.motorsport.com/images/amp/0qXDw4y6/s1000/formula-1-abu-dhabi-gp-2022-le-2.jpg',
'https://cdn-3.motorsport.com/images/amp/6zQOZOwY/s1000/lewis-hamilton-mercedes-amg-f1.jpg',
'https://hips.hearstapps.com/hmg-prod/images/lewis-hamilton-of-great-britain-driving-the-mercedes-amg-news-photo-1653067675.jpg',
'https://radio3cadenapatagonia.com.ar/wp-content/uploads/2023/05/Hamilton-Mercedes-Formula-1.jpg')


insert Into Autos values ('Senda',1995,'FWD', 83, 55, 895, 10.80, 173.6, 'E', 350000, 42, 'Santino Boscatto',
'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Autos\Banderas-Pais-Fabricacion\Argentina.png',
'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Drivers\Auto\Santino1.jpg',
'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Drivers\Auto\Santino2.jpg',
'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Drivers\Auto\Santino1.jpg',
'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Drivers\Auto\Santino2.jpg',
'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Drivers\Auto\Santino1.jpg')

select HP from Autos where AutoID = 2

update Historial Set Clima = 'Seco'

--Eliminar Columnas
ALTER TABLE Pistas
Add   Layaout VarChar (2500);


select * from HigieneManager
--Agregar Columnas


select Circuito, DriverA, DriverB, PilotoGanador, PilotoPerdedor, AutoA, AutoB, Tiempo, Clase, Clima, Modalidad, Promocion from Historial
select * from Historial

Insert Into Historial (Circuito, DriverA, DriverB, PilotoGanador, PilotoPerdedor, AutoA, AutoB, Tiempo, Clase, Clima, Modalidad, Promocion) values ('Akina','Santino Boscatto', 'Tony Cyppriani',' Santino Boscatto', 'Tony Cyppriani', 'Volkswagen Senda Diesel 95', 'Fiat 147 Sorpasso', '6:35:401','E','Neblinoso','Side By Side', 'No')

--Crear Una Nueva Tabla
USE TougeBD; -- Cambia a la base de datos adecuada si no estás ya en ella
CREATE TABLE Alquileres (
    NumeroRegistro INT,
    Precio INT,
    Dormitorios INT,
    SalasDeEstar INT,
    Garajes INT,
    Duchas INT,
    NombreAlquiler VARCHAR(150),
    ImagenAlquiler VARCHAR(2000),
    ImagenAlquiler2 VARCHAR(2000),
    ImagenAlquiler3 VARCHAR(2000)
);

INSERT INTO alquileres (NumeroRegistro, Precio, Dormitorios, SalasDeEstar, Garajes, Duchas, NombreAlquiler, ImagenAlquiler, Estado )VALUES (10, 1100, 1, 1, 1, 1,
'Departamento Pequeño Akina Centro, Con Garaje Compartido',
'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Alquileres\Alquiler10.jpg', 1);

SELECT NumeroRegistro, Precio, Dormitorios, SalasDeEstar, Garajes, Duchas, NombreAlquiler, ImagenAlquiler, Estado from alquileres where NumeroRegistro IN (1, 2, 3)
delete from Alquileres where Precio = 2100

select * from Alquileres

Update Alquileres Set ImagenAlquiler = 
'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Alquileres\Alquiler7.png' 
where NumeroRegistro = 7


Update Pilotos set Foto = 'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Pilotos\Itsuki-Plantilla.jpg' where Apodo =  'Iggy'

select * from Economia

Update Economia set Dinero = 10000

SELECT * FROM (SELECT Circuito, DriverA AS Piloto, DriverB AS Rival, PilotoGanador AS Ganador, PilotoPerdedor AS Perdedor, AutoA AS AutoPiloto, AutoB AS AutoRival, Promocion, Tiempo, Clase, Clima, Modalidad, HistorialID AS ID FROM Historial) AS Subquery
WHERE Rival LIKE 'R%'


Insert Into Fecha Values(1,'2026-07-15')

select FechaManager from Fecha

delete from Fecha

UPDATE Fecha SET FechaManager = DATEADD(day, -4, FechaManager)

select Precio from Alquileres where NumeroRegistro =5

insert Economia (Dinero) values (13535)

UPDATE Economia SET Dinero = 13535

select * from Muebles

insert AlquilerManager values (1, 1)

CREATE TABLE estadoAutoManager (
    Aceite int,
	Motor int,
	ManAuto int,
	gomas int
);

insert into Ropa values (50, 'Pava', 'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Electronicos\2.png', 18, 1)



select NumeroDeRegistro, Precio, Comprado from Electronicos where Comprado =0

update Ropa set ImagenRopa = 'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Ropa\2.png' 
where NumeroDeRegistro = 1



Update Muebles Set Comprado = 1


UPDATE estadoAutoManager set ManAuto = 0 

UPDATE Autos set HP = 99 where dueno = 1

select * From estadoAutoManager

UPDATE Autos set IdealHP = 80 where dueno = 1

UPDATE estadoAutoManager set GomasLluvia = 0



select a.AutoID ID, a.Nombre Nom, a.Anio An, a.Traccion Trac, a.PaisFabricacion Pais, HP, Torque, Peso, a.PesoPotencia PP, a.TopSpeed TS, a.Categoria Cat, a.Kilometraje K,
m.NombreMarca NM, m.ImagenMarca IM, a.auto1 f1, a.auto2 f2, a.auto3 f3, a.auto4 f4, a.Auto5 f5, a.Tanque  from Autos a, Marca m where a.Marca = m.ID AND Dueno = 1

select * From estadoAutoManager  

select  *  from miauto

select Hp, IdealHP from Autos

Update Autos set Pais2 = 'icons/Toyota.png' where Dueno = 0

Update MiAuto set VinilosDisponible = 0

select * from MiAuto

Select Peso, HP From Autos where dueno = 1
Update Autos set PesoPotencia = Peso / HP where AutoID = 2

select HP, idealHp From Autos where dueno = 1

select TOP 1 a.Tanque, m.TanqueActual from MiAuto m, Autos a

select Aceite, Motor, ManAuto, Gomas, lavado, GomasLluvia From estadoAutoManager

select AutoID, Nombre, Anio, Traccion, HP, Traccion, Torque, Peso, PesoPotencia, TopSpeed, ImagenMarca, PaisFabricacion, Aspiracion, Price, ImagenVentas from Autos, Marca where Marca = ID and  Dueno = 0

select * from Marca

Update Autos Set ImagenVentas = 'Marcas/Lancia.png' where AutoID >1


insert Into Autos (Nombre,Anio,Traccion,PaisFabricacion,Pais2,Categoria, HP, Torque, Peso, PesoPotencia, TopSpeed,Kilometraje, Marca,Auto1,Auto2,Auto3,Auto4,Auto5,ImagenVentas, Dueno, Tanque, Aspiracion, IdealHP, Price) values 
('Mazda RX-7 GT-X (FC) 90', 1990, 'RWD', 'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Autos\Banderas-Pais-Fabricacion\Japon.png', 
'Japan', 'C', 183, 198, 1251, 6.83, 275.2, 35412, 28, 'C:\Users\Santino\source\repos\PaginaAutos\PaginaAutos\img\MazdaRX7INFINI.jpg','C:\Users\Santino\source\repos\PaginaAutos\PaginaAutos\img\MazdaRX7INFINI.jpg',
'C:\Users\Santino\source\repos\PaginaAutos\PaginaAutos\img\MazdaRX7INFINI.jpg','C:\Users\Santino\source\repos\PaginaAutos\PaginaAutos\img\MazdaRX7INFINI.jpg','C:\Users\Santino\source\repos\PaginaAutos\PaginaAutos\img\MazdaRX7INFINI.jpg',
'C:\Users\Santino\source\repos\PaginaAutos\PaginaAutos\img\MazdaRX7INFINI.jpg',0,45, 'T', 202, 65000)

select AutoID from Autos where dueno = 0

Update Marca Set ImagenPagina = 'Anon' where AutoID = 3

Update Autos Set Price = 0 Where AutoID = 2

select FechaManager , FechaPagina from Fecha

ALTER TABLE Fecha
Add FechaPagina DateTime

Update Fecha Set FechaManager = '2026-07-05 00:00:00.000'

select Hp, IdealHP from Autos where Dueno = 1

Update Economia Set Dinero = Dinero - 500

Select Price From Autos Where AutoID = 1

Update MiAuto Set Motor = 1

select * from MiAuto

select Hp, Peso, PesoPotencia, Torque, Traccion, Auto1, Aceite, Motor, Mantenimiento, Lavado, Repro, Aspiracion, TanqueActual, Tanque, GomasDeSeco, GomasDeLluvia  from Autos, MiAuto where Dueno = 1

update Electronicos set Comprado = 1

select NumeroDeRegistro, NombreElectronico, ImagenElectronico, Precio, Comprado from Electronicos

select Comprado from Muebles where Comprado = 0

select * from autos 

Update Autos set Piloto = 'Desconocido' where AutoID = 43


select * from Ropa
delete From Muebles where AutoID = 8

select a.AutoID ID, a.Nombre Nom, a.Anio An, a.Traccion Trac, a.PaisFabricacion Pais, HP, Torque, Peso, a.PesoPotencia PP, a.TopSpeed TS, a.Categoria Cat, a.Kilometraje K, m.NombreMarca NM, m.ImagenMarca IM, a.auto1 f1, a.auto2 f2, a.auto3 f3, a.auto4 f4, a.Auto5 f5, Aspiracion Asp, IdealHP as IHP, Piloto as P   from Autos a, Marca m where a.Marca = m.ID 

select * from Muebles

select * from Electronicos

select * from autos

select Nombre, Apodo, Equipo, Ranking, Victorias, Derrotas, PorcentajeCarrerasGanadas, MayorRival, Altura, Peso, Edad, Bio, Foto, Nacionalidad, Auto, AutoAtras, AutoDetalle, AutoMovimiento, Cornering, Braking, Reflexes, TyresManagement, Overtaking, Defending, Rain, Overall, Concentration, Presure, Experience, Agressive, Pace from Pilotos
Select * from Autos


update Pilotos set AutoMovimiento =  'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Autos\Fotos-Autos\CelicaGT4_M.jpg' where Nombre = 'Kenji Futawa'

Update Pistas Set Nombre = '', Bio ='', Distancia = '', Pais = '', ModalidadPreferida = '', Imagenes = '', Imagen2 = '', Layaout = '', Record = ''

select * from Pilotos

Update Pilotos set Nombre = @Nombre, Apodo = @Apodo, Equipo = @Equipo, Ranking = @Ranking, Victorias = @Victorias, Derrotas = @Derrotas, PorcentajeCarrerasGanadas = @PorcentajeCarrerasGanadas, MayorRival = @MayorRival,  Altura = @Altura, Peso = @Peso, Edad = @Edad, Bio = @Bio, Foto = @Foto, Cornering = @Cornering, Braking = @Braking, Reflexes = @Reflexes, TyresManagement = @TyresManagement, Overtaking = @Overtaking, Defending = @Defending, Rain = @Rain, Overall  = @Overall, Concentration = @Concentration, Presure = @Presure, Experience = @Experience, Agressive = @Agressive, Pace = @Pace, Nacionalidad = @Nacionalidad, Auto = @Auto, AutoAtras = @AutoAtras, AutoDetalle = @AutoDetalle, AutoMovimiento = @AutoMovimiento
