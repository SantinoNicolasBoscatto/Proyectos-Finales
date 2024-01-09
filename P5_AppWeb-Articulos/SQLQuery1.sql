
select Codigo, Nombre, A.Descripcion Entrada, C.Descripcion Categoria, M.Descripcion Marca,
ImagenUrl, A.Id Id, Precio From ARTICULOS A, CATEGORIAS C, MARCAS M where C.Id = A.IdCategoria 
AND M.Id = A.IdMarca and C.Descripcion like'%c%'
select * from ARTICULOS
select Codigo, Nombre, A.Descripcion Entrada, C.Descripcion Categoria, M.Descripcion Marca, ImagenUrl, A.Id Id, Precio From ARTICULOS A, CATEGORIAS C, MARCAS M where C.Id = A.IdCategoria AND M.Id = A.IdMarca AND Precio <36000

create procedure ValidarLogin 
@email varchar(100), @pass varchar(20)
as
Select Id, nombre, apellido, urlImagenPerfil, admin from USERS where email = 'admin@admin.com' and pass ='admin'

create procedure RegistrarUsuario
@email varchar(100), @pass varchar(20)
as
insert into USERS (email, pass) output inserted.Id values (@email, @pass)

Update ARTICULOS set ImagenUrl = 'https://arsonyb2c.vtexassets.com/arquivos/ids/357168/d4f672c8c1b08401c3fb67cce747b7db.jpg?v=637620094081630000' where Id = 4

insert into ARTICULOS values 
('EP01', 'Epson Multifuncion', 'Epson Multifuncion perfecta para hogares', 1, 1, 
'https://mediaserver.goepson.com/ImConvServlet/imconv/7ae7db8aed4802b28af34884112fcdacc48c97a1/1200Wx1200H?use=banner&hybrisId=B2C&assetDescr=L565_1', 130000.000)