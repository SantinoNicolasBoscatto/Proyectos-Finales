--Insert Into Musica values 
--('One Night In Arabia', 'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\Musica\24-ONE NIGHT IN ARABIA.mp3','')

--CRUD
select Nombre, Bio Biografia, Distancia, Pais, ModalidadPreferida, Record, Imagenes, Imagen2 from pistas


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



update Historial Set Clima = 'Seco'

--Eliminar Columnas
ALTER TABLE alquileres
Drop COLUMN  ImagenAlquiler3;

--Agregar Columnas
ALTER TABLE Alquileres
Add Estado bit

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

INSERT INTO alquileres (NumeroRegistro, Precio, Dormitorios, SalasDeEstar, Garajes, Duchas, NombreAlquiler, ImagenAlquiler, Estado)VALUES (10, 1100, 1, 1, 1, 1,
'Departamento Pequeño Akina Centro, Con Garaje Compartido',
'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Alquileres\Alquiler10.jpg', 1);

SELECT NumeroRegistro, Precio, Dormitorios, SalasDeEstar, Garajes, Duchas, NombreAlquiler, ImagenAlquiler, Estado from alquileres where NumeroRegistro IN (1, 2, 3)
delete from Alquileres where Precio = 2100

select * from Alquileres

Update Alquileres Set ImagenAlquiler = 
'C:\Users\Santino\Desktop\Repositorio GITHUB\Proyectos Finales\P4_Touge-App\Touge_App\Touge_App\img\BASEDATOS\Economia\Alquileres\Alquiler7.png' 
where NumeroRegistro = 7

select Circuito, DriverA Piloto, DriverB as Rival, PilotoGanador Ganador, PilotoPerdedor Perdedor, AutoA AutoPiloto, AutoB AutoRival, 
Promocion, Tiempo, Clase, Clima, Modalidad, HistorialID ID from Historial where Rival Like 'R%'
select nombre, Victorias, PorcentajeCarrerasGanadas, Derrotas from Pilotos where Nombre = 'Lewis Hamilton'

Update Pilotos set PorcentajeCarrerasGanadas = 29.5555 where Nombre =  'Lewis Hamilton'

SELECT * FROM (SELECT Circuito, DriverA AS Piloto, DriverB AS Rival, PilotoGanador AS Ganador, PilotoPerdedor AS Perdedor, AutoA AS AutoPiloto, AutoB AS AutoRival, Promocion, Tiempo, Clase, Clima, Modalidad, HistorialID AS ID FROM Historial) AS Subquery
WHERE Rival LIKE 'R%'


Insert Into Fecha Values(1,'2026-07-15')

select FechaManager from Fecha

delete from Fecha

UPDATE Fecha SET FechaManager = DATEADD(day, -5, FechaManager)

select Precio from Alquileres where NumeroRegistro =5

insert Economia (Dinero) values (13535)

UPDATE Economia SET Dinero = 13535

select * from AlquilerManager

insert AlquilerManager values (1, 1)

CREATE TABLE AlquilerManager (
    alquilando bit,
    CasaAlquilada int
);