--CREATE DATABASE DBVENTAS
GO
USE DBVENTAS
GO
/*VALIDACIONES DE CONSTRAINT*/
ALTER TABLE Articulo
DROP CONSTRAINT IF EXISTS FK_Articulo_Categoria
GO
ALTER TABLE Articulo
DROP CONSTRAINT IF EXISTS FK_Articulo_Presentacion
GO
ALTER TABLE DetalleIngreso
DROP CONSTRAINT IF EXISTS FK_DetalleIngreso_Articulo
GO
ALTER TABLE DetalleIngreso
DROP CONSTRAINT IF EXISTS FK_DetalleIngreso_Ingreso
GO
ALTER TABLE Ingreso
DROP CONSTRAINT IF EXISTS FK_Proveedor_Ingreso
GO
ALTER TABLE Ingreso
DROP CONSTRAINT IF EXISTS FK_Ingreso_Trabajador
GO
ALTER TABLE Venta
DROP CONSTRAINT IF EXISTS FK_Venta_Trabajador
GO
ALTER TABLE DetalleVenta
DROP CONSTRAINT IF EXISTS FK_DetalleVenta_Venta
GO
ALTER TABLE DetalleVenta
DROP CONSTRAINT IF EXISTS FK_DetalleVenta_DetalleIngreso
GO
ALTER TABLE Venta
DROP CONSTRAINT IF EXISTS FK_Venta_Cliente
/**FIN VALIDACIONES DE CONSTRAINT*/

/*TABLAS*/
DROP TABLE IF EXISTS Categotia
GO
CREATE TABLE Categotia
(
IdCategoria	int identity primary key,
Nombre		varchar(50) not null,
Descripcion	varchar(256)
)
GO
DROP TABLE IF EXISTS Presentacion
GO
CREATE TABLE Presentacion
(
IdPresentacion	int identity primary key,
Nombre			varchar(50) not null,
Descripcion		varchar(256)
)
GO
DROP TABLE IF EXISTS Articulo
GO
CREATE TABLE Articulo
(
IdArticulo		int identity primary key,
Codigo			varchar(50) not null,
Nombre			varchar(50) not null,
Descripcion		varchar(1024),
Imagen			image,
IdCategoria		int not null,
IdPresentacion	int not null
)
GO
DROP TABLE IF EXISTS Proveedor
GO
CREATE TABLE Proveedor
(
IdProveedor		int identity primary key,
RazonSocial		varchar(150) not null,
SectorComercial	varchar(50) not null,
TipoDocumento	varchar(20) not null,
NumDocumento	varchar(11) not null,
Direccion		varchar(100),
Telefono		varchar(50),
Email			varchar(50),
Url				varchar(100)
)
GO
DROP TABLE IF EXISTS Trabajador
GO
CREATE TABLE Trabajador
(
IdTrabajador	int identity primary key,
Nombre			varchar(20) not null,
Apellidos		varchar(40) not null,
Genero			Varchar(1) not null,
FecNacimiento	date not null,
NumDocumento	varchar(8) not null,
Direccion		varchar(100),
Telefono		varchar(10),
Email			varchar(50),
Acceso			varchar(20) not null,
Username		varchar(20) not null,
Password		varchar(20) not null,
Estado			varchar(1) not null
)
DROP TABLE IF EXISTS Ingreso
GO
CREATE TABLE Ingreso
(
IdIngreso		int identity primary key,
IdTrabajador	int not null,
IdProveedor		int not null,
Fecha			date not null,
TipoComprobante	varchar(20) not null,
Serie			varchar(4) not null,
Correlativo		varchar(7) not null,
Igv				decimal(4,2) not null,
Estado			varchar(7) not null
)
GO
DROP TABLE IF EXISTS DetalleIngreso
GO
CREATE TABLE DetalleIngreso
(
IdDetIngreso	int identity primary key,
IdIngreso		int not null,
IdArticulo		int not null,
PrecioCompra	decimal(10,2) not null,
PrecioVenta		decimal(10,2) not null,
StockInicial	int not null,
StockActual		int not null,
FecProduccion	date not null,
FecVencimiento	date not null
)
GO
DROP TABLE IF EXISTS Cliente
GO
CREATE TABLE Cliente
(
IdCliente 		int identity primary key,
Nombre			varchar(20) not null,
Apellidos		varchar(40),
Genero			varchar(1),
FecNacimiento	date not null,
TipoDocumento	varchar(20) not null,
NumDocumento	varchar(8) not null,
Direccion		varchar(100),
Telefono		varchar(10),
Email			varchar(50)
)
GO
DROP TABLE IF EXISTS Venta
GO
CREATE TABLE Venta
(
IdVenta			int identity primary key not null,
IdCliente		int not null,
IdTrabajador	int not null,
Fecha			date not null,
TipoComprobante	varchar(20) not null,
Serie			varchar(4) not null,
Correlativo		varchar(7) not null,
Igv				decimal(10,2) not null
)
GO
DROP TABLE IF EXISTS DetalleVenta
GO
CREATE TABLE DetalleVenta
(
IdDetVenta		int identity not null,
IdVenta			int not null,
IdDetIngreso	int not null,
Cantidad		int not null,
PrecioVenta		decimal(10,2) not null,
Descuento		decimal(10,2) not null
)
GO
/*FIN TABLAS*/
/*CONSTRAINT*/
ALTER TABLE Articulo
ADD CONSTRAINT FK_Articulo_Categoria
FOREIGN KEY (IdCategoria) REFERENCES Categotia
GO
ALTER TABLE Articulo
ADD CONSTRAINT FK_Articulo_Presentacion
FOREIGN KEY (IdPresentacion) REFERENCES Presentacion
GO
ALTER TABLE DetalleIngreso
ADD CONSTRAINT FK_DetalleIngreso_Articulo
FOREIGN KEY (IdArticulo) REFERENCES Articulo
GO
ALTER TABLE DetalleIngreso
ADD CONSTRAINT FK_DetalleIngreso_Ingreso
FOREIGN KEY (IdIngreso) REFERENCES Ingreso
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE Ingreso
ADD CONSTRAINT FK_Proveedor_Ingreso
FOREIGN KEY (IdProveedor) REFERENCES Proveedor
GO
ALTER TABLE Ingreso
ADD CONSTRAINT FK_Ingreso_Trabajador
FOREIGN KEY (IdTrabajador) REFERENCES Trabajador
GO
ALTER TABLE Venta
ADD CONSTRAINT FK_Venta_Trabajador
FOREIGN KEY (IdTrabajador) REFERENCES Trabajador
GO
ALTER TABLE DetalleVenta
ADD CONSTRAINT FK_DetalleVenta_Venta
FOREIGN KEY (IdVenta) REFERENCES Venta
ON DELETE CASCADE
ON UPDATE CASCADE
GO
ALTER TABLE DetalleVenta
ADD CONSTRAINT FK_DetalleVenta_DetalleIngreso
FOREIGN KEY (IdDetIngreso) REFERENCES DetalleIngreso
GO
ALTER TABLE Venta
ADD CONSTRAINT FK_Venta_Cliente
FOREIGN KEY (IdCliente) REFERENCES Cliente
/*FIN CONSTRAINT*/
