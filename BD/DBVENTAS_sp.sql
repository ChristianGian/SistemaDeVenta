USE DBVENTAS
GO
/*STORE PROCEDURES*/
/*CATEGORIA*/
CREATE PROC MostrarCategoria
AS
BEGIN
	SELECT TOP 100 *
	FROM Categotia
	ORDER BY IdCategoria DESC
END
--EXEC MostrarCategoria
GO
CREATE PROC BuscarCategoria
@Nombre varchar(50)
AS
BEGIN
	SELECT * FROM Categotia
	WHERE Nombre LIKE @Nombre + '%'
END
GO
CREATE PROC RegistrarCategoria
@Nombre			varchar(50),
@Descripcion	varchar(256)
AS
BEGIN
	INSERT Categotia (Nombre, Descripcion)
	VALUES (@Nombre, @Descripcion)
END
GO
CREATE PROC EditarCategoria
@IdCategoria	int,
@Nombre			varchar(50),
@Descripcion	varchar(256)
AS
BEGIN
	UPDATE Categotia
	SET Nombre = @Nombre,
		Descripcion = @Descripcion
	WHERE IdCategoria = @IdCategoria
END
GO
CREATE PROC EliminarCategoria
@IdCategoria int
AS
BEGIN
	DELETE FROM Categotia
	WHERE IdCategoria = @IdCategoria
END
GO
/*FIN CATEGORIA*/

/*PRESENTACIÓN*/
CREATE PROCEDURE MostrarPresentacion
AS
BEGIN
	SELECT TOP 100 *
	FROM Presentacion
	ORDER BY IdPresentacion DESC
END
GO
CREATE PROCEDURE BuscarPresentacion
@Nombre varchar(50)
AS
BEGIN
	SELECT * FROM Presentacion
	WHERE Nombre LIKE @Nombre + '%'
END
GO
CREATE PROC RegistrarPresentacion
@Nombre			varchar(50),
@Descripcion	varchar(256)
AS
BEGIN
	INSERT Presentacion (Nombre, Descripcion)
	VALUES (@Nombre, @Descripcion)
END
GO
CREATE PROC EditarPresentacion
@IdPresentacion	int,
@Nombre			varchar(50),
@Descripcion	varchar(256)
AS
BEGIN
	UPDATE Presentacion
	SET Nombre = @Nombre,
		Descripcion = @Descripcion
	WHERE IdPresentacion = @IdPresentacion
END
GO
CREATE PROC EliminarPresentacion
@IdPresentacion	int
AS
BEGIN
	DELETE FROM Presentacion
	WHERE IdPresentacion = @IdPresentacion
END
GO
/*FIN PRESENTACIÓN*/

/*ARTÍCULOS*/
CREATE PROC MostrarArticulo
AS
BEGIN
	SELECT TOP 100 IdArticulo,
					Codigo,
					Articulo.Nombre,
					Articulo.Descripcion,
					Imagen,
					Articulo.IdCategoria,
					Categotia.Nombre AS Categoria,
					Articulo.IdPresentacion,
					Presentacion.Nombre AS Presentacion
	FROM Articulo
	INNER JOIN Categotia ON Articulo.IdCategoria = Categotia.IdCategoria
	INNER JOIN Presentacion ON Articulo.IdPresentacion = Presentacion.IdPresentacion
	ORDER BY IdArticulo DESC
END
GO
CREATE PROC BuscarArticulo
@Nombre varchar(50)
AS
BEGIN
	SELECT TOP 100 Codigo,
					Articulo.Nombre,
					Articulo.Descripcion,
					Imagen,
					Articulo.IdCategoria,
					Categotia.Nombre AS Categoria,
					Articulo.IdPresentacion,
					Presentacion.Nombre AS Presentacion
	FROM Articulo
	INNER JOIN Categotia ON Articulo.IdCategoria = Categotia.IdCategoria
	INNER JOIN Presentacion ON Articulo.IdPresentacion = Presentacion.IdPresentacion
	WHERE Articulo.Nombre LIKE @Nombre + '%'
	ORDER BY IdArticulo DESC
END
GO
CREATE PROC RegistrarArticulo
@Codigo			varchar(50),
@Nombre			varchar(50),
@Descripcion	varchar(1024),
@Imagen			image,
@IdCategoria	int,
@IdPresentacion	int
AS
BEGIN
	INSERT Articulo (Codigo, Nombre, Descripcion, Imagen, IdCategoria, IdPresentacion)
	VALUES (@Codigo, @Nombre, @Descripcion, @Imagen, @IdCategoria, @IdPresentacion)
END
GO
CREATE PROC EditarArticulo
@IdArticulo		int,
@Codigo			varchar(50),
@Nombre			varchar(50),
@Descripcion	varchar(1024),
@Imagen			image,
@IdCategoria	int,
@IdPresentacion	int
AS
BEGIN
	UPDATE Articulo
	SET Codigo = @Codigo,
		Nombre = @Nombre,
		Descripcion = @Descripcion,
		Imagen = @Imagen,
		IdCategoria = @IdCategoria,
		IdPresentacion = @IdPresentacion
	WHERE IdArticulo = @IdArticulo
END
GO
CREATE PROC EliminarArticulo
@IdArticulo int
AS
BEGIN
	DELETE FROM Articulo
	WHERE IdArticulo = @IdArticulo
END
GO
/*FIN ARTÍCULO*/

/*PROVEEDOR*/
CREATE PROC MostrarProveedor
AS
BEGIN
	SELECT TOP 100 *
	FROM Proveedor
	ORDER BY RazonSocial
END
GO
CREATE PROC BuscarRazonSocialProveedor
@RazonSocial varchar(150)
AS
BEGIN
	SELECT *
	FROM Proveedor
	WHERE RazonSocial LIKE @RazonSocial + '%'
END
GO
CREATE PROC BuscarNumDocumentoProveedor
@NumDocumento varchar(11)
AS
BEGIN
	SELECT *
	FROM Proveedor
	WHERE NumDocumento LIKE @NumDocumento + '%'
END
GO
CREATE PROC RegistrarProveedor
@RazonSocial		varchar(150),
@SectorComercial	varchar(50),
@TipoDocumento		varchar(20),
@NumDocumento		varchar(11),
@Direccion			varchar(100),
@Telefono			varchar(50),
@Email				varchar(50),
@Url				varchar(100)
AS
BEGIN
	INSERT Proveedor (RazonSocial, SectorComercial, TipoDocumento, NumDocumento, Direccion, Telefono, Email, Url)
	VALUES (@RazonSocial, @SectorComercial, @TipoDocumento, @NumDocumento, @Direccion, @Telefono, @Email, @Url)
END
GO
CREATE PROC EditarProveedor
@IdProveedor		int,
@RazonSocial		varchar(150),
@SectorComercial	varchar(50),
@TipoDocumento		varchar(20),
@NumDocumento		varchar(11),
@Direccion			varchar(100),
@Telefono			varchar(50),
@Email				varchar(50),
@Url				varchar(100)
AS
BEGIN
	UPDATE Proveedor
	SET RazonSocial = @RazonSocial,
		SectorComercial = @SectorComercial,
		TipoDocumento = @TipoDocumento,
		NumDocumento = @NumDocumento,
		Direccion = @Direccion,
		Telefono = @Telefono,
		Email = @Email,
		Url = @Url
	WHERE IdProveedor = @IdProveedor
END
GO
CREATE PROC EliminarProveedor
@IdProveedor int
AS
BEGIN
	DELETE FROM Proveedor
	WHERE IdProveedor = @IdProveedor
END
GO
/*FIN PROVEEDOR*/

/*CLIENTE*/
CREATE PROC MostrarCliente
AS
BEGIN
	SELECT TOP 100 *
	FROM Cliente
	ORDER BY Apellidos
END
GO
CREATE PROC BuscarApellidosCliente
@Apellidos varchar(40)
AS
BEGIN
	SELECT *
	FROM Cliente
	WHERE Apellidos LIKE @Apellidos + '%'
END
GO
CREATE PROC BuscarNumDocumentoCliente
@NumDocumento varchar(8)
AS
BEGIN
	SELECT *
	FROM Cliente
	WHERE NumDocumento LIKE @NumDocumento + '%'
END
GO
CREATE PROC RegistrarCliente
@Nombre			varchar(20),
@Apellidos		varchar(40),
@Genero			varchar(1),
@FecNacimiento	date,
@TipoDocumento	varchar(20),
@NumDocumento	varchar(8),
@Direccion		varchar(100),
@Telefono		varchar(10),
@Email			varchar(50)
AS
BEGIN
	INSERT Cliente (Nombre, Apellidos, Genero, FecNacimiento, TipoDocumento, NumDocumento, Direccion, Telefono, Email)
	VALUES (@Nombre, @Apellidos, @Genero, @FecNacimiento, @TipoDocumento, @NumDocumento, @Direccion, @Telefono, @Email)
END
GO
CREATE PROC EditarCliente
@IdCliente 		int,
@Nombre			varchar(20),
@Apellidos		varchar(40),
@Genero			varchar(1),
@FecNacimiento	date,
@TipoDocumento	varchar(20),
@NumDocumento	varchar(8),
@Direccion		varchar(100),
@Telefono		varchar(10),
@Email			varchar(50)
AS
BEGIN
	UPDATE Cliente
	SET Nombre = @Nombre,
		Apellidos = @Apellidos,
		Genero = @Genero,
		FecNacimiento = @FecNacimiento,
		TipoDocumento = @TipoDocumento,
		NumDocumento = @NumDocumento,
		Direccion = @Direccion,
		Telefono = @Telefono,
		Email = @Email
	WHERE IdCliente = @IdCliente
END
GO
CREATE PROC EliminarCliente
@IdCliente int
AS
BEGIN
	DELETE FROM Cliente
	WHERE IdCliente = @IdCliente
END
GO
/*FIN CLIENTE*/

/*TRABAJADOR*/
CREATE PROC MostrarTrabajador
AS
BEGIN
	SELECT TOP 100 *
	FROM Trabajador
	ORDER BY Apellidos
END
GO
CREATE PROC BuscarApellidosTrabajador
@Apellidos varchar(40)
AS
BEGIN
	SELECT *
	FROM Trabajador
	WHERE Apellidos LIKE @Apellidos + '%'
END
GO
CREATE PROC BuscarNumDocumentoTrabajador
@NumDocumento varchar(8) 
AS
BEGIN
	SELECT *
	FROM Trabajador
	WHERE NumDocumento LIKE @NumDocumento + '%'
END
GO
CREATE PROC RegistrarTrabajador
@Nombre			varchar(20),
@Apellidos		varchar(40),
@Genero			Varchar(1),
@FecNacimiento	date,
@NumDocumento	varchar(8),
@Direccion		varchar(100),
@Telefono		varchar(10),
@Email			varchar(50),
@Acceso			varchar(20),
@Username		varchar(20),
@Password		varchar(20),
@Estado			varchar(1)
AS
BEGIN
	INSERT Trabajador (Nombre, Apellidos, Genero, FecNacimiento, NumDocumento, Direccion, Telefono, Email, Acceso, Username, Password, Estado)
	VALUES (@Nombre, @Apellidos, @Genero, @FecNacimiento, @NumDocumento, @Direccion, @Telefono, @Email, @Acceso, @Username, @Password, @Estado)
END
GO
CREATE PROC EditarTrabajador
@IdTrabajador	int,
@Nombre			varchar(20),
@Apellidos		varchar(40),
@Genero			Varchar(1),
@FecNacimiento	date,
@NumDocumento	varchar(8),
@Direccion		varchar(100),
@Telefono		varchar(10),
@Email			varchar(50),
@Acceso			varchar(20),
@Username		varchar(20),
@Password		varchar(20),
@Estado			varchar(1)
AS
BEGIN
	UPDATE Trabajador
	SET Nombre = @Nombre,
		Apellidos = @Apellidos,
		Genero = @Genero,
		FecNacimiento = @FecNacimiento,
		NumDocumento = @NumDocumento,
		Direccion = @Direccion,
		Telefono = @Telefono,
		Email = @Email,
		Acceso = @Acceso,
		Username = @Username,
		Password = @Password,
		Estado = @Estado
	WHERE IdTrabajador = @IdTrabajador
END
GO
CREATE PROC EliminarTrabajador
@IdTrabajador int
AS
BEGIN
	DELETE FROM Trabajador
	WHERE IdTrabajador = @IdTrabajador
END
GO
/*FIN TRABAJADORES*/

/*LOGIN*/
CREATE PROC Login
@Username		varchar(20),
@Password		varchar(20)
AS
BEGIN
		SELECT IdTrabajador, Nombre, Apellidos, Acceso, Email, Estado
		FROM Trabajador
	WHERE Username = @Username AND Password COLLATE Latin1_General_CS_AS = @Password
END
GO
/*FIN LOGIN*/

/*INGRESOS*/
CREATE PROC MostrarIngresos
AS
BEGIN
	SELECT TOP 100 Ingreso.IdIngreso,
	Ingreso.IdTrabajador,
	Nombre + ' ' + Apellidos AS Trabajador,
	Ingreso.IdProveedor,
	RazonSocial AS Proveedor,
	Fecha,
	TipoComprobante,
	Serie,
	Correlativo,
	Igv,
	Ingreso.Estado,
	SUM(PrecioCompra * StockInicial) AS Total
	FROM Ingreso
	INNER JOIN DetalleIngreso	ON Ingreso.IdIngreso	= DetalleIngreso.IdIngreso
	INNER JOIN Trabajador		ON Ingreso.IdTrabajador	= Trabajador.IdTrabajador
	INNER JOIN Proveedor		ON Ingreso.IdProveedor	= Proveedor.IdProveedor
	GROUP BY Ingreso.IdIngreso,
			Ingreso.IdTrabajador,
			Nombre + ' ' + Apellidos,
			Ingreso.IdProveedor,
			RazonSocial,
			Fecha,
			TipoComprobante,
			Serie,
			Correlativo,
			Igv,
			Ingreso.Estado
	ORDER BY Ingreso.IdIngreso DESC
END
GO
CREATE PROC MostrarIngresosEntreFechas
@FecInicial date,
@FecFinal date
AS
BEGIN
	SELECT Ingreso.IdIngreso,
			Ingreso.IdTrabajador,
			Nombre + ' ' + Apellidos AS Trabajador,
			Ingreso.IdProveedor,
			RazonSocial AS Proveedor,
			Fecha,
			TipoComprobante,
			Serie,
			Correlativo,
			Igv,
			Ingreso.Estado,
			SUM(PrecioCompra * StockInicial) AS Total
	FROM Ingreso
	INNER JOIN DetalleIngreso	ON Ingreso.IdIngreso	= DetalleIngreso.IdIngreso
	INNER JOIN Trabajador		ON Ingreso.IdTrabajador	= Trabajador.IdTrabajador
	INNER JOIN Proveedor		ON Ingreso.IdProveedor	= Proveedor.IdProveedor
	GROUP BY Ingreso.IdIngreso,
			Ingreso.IdTrabajador,
			Nombre + ' ' + Apellidos,
			Ingreso.IdProveedor,
			RazonSocial,
			Fecha,
			TipoComprobante,
			Serie,
			Correlativo,
			Igv,
			Ingreso.Estado
	HAVING Ingreso.Fecha >= @FecInicial AND	Ingreso.Fecha <= @FecFinal
END
GO
CREATE PROC RegistrarIngreso
@IdTrabajador		int,
@IdProveedor		int,
@Fecha				date,
@TipoComprobante	varchar(20),
@Serie				varchar(4),
@Correlativo		varchar(7),
@Igv				decimal(4,2),
@Estado				varchar(7),
@IdUltimo			int output
AS
BEGIN
	INSERT Ingreso (IdTrabajador, IdProveedor, Fecha, TipoComprobante, Serie, Correlativo, Igv, Estado)
	VALUES (@IdTrabajador, @IdProveedor, @Fecha, @TipoComprobante, @Serie, @Correlativo, @Igv, @Estado)

	--Devolvemos el Id
	SET @IdUltimo = SCOPE_IDENTITY()
	RETURN @IdUltimo
END
GO
CREATE PROC AnularIngreso
@IdIngreso int
AS
BEGIN
	UPDATE Ingreso
	SET Estado = 'ANULADO'
	WHERE IdIngreso = @IdIngreso
END
GO
/*FIN INGRESO*/

/*DETALLE INGRESO*/
CREATE PROC MostrarDetalleIngreso
@IdIngreso int 
AS
BEGIN
	SELECT DetalleIngreso.IdArticulo,
			Nombre as Articulo,
			PrecioCompra,
			PrecioVenta,
			StockInicial,
			FecProduccion,
			FecVencimiento,
			(StockInicial * PrecioCompra) AS Subtotal
	FROM DetalleIngreso
	INNER JOIN Articulo	ON DetalleIngreso.IdArticulo	= Articulo.IdArticulo
	WHERE IdIngreso = @IdIngreso
END
GO
CREATE PROC RegistrarDetalleIngreso
@IdIngreso		int,
@IdArticulo		int,
@PrecioCompra	decimal(10,2),
@PrecioVenta	decimal(10,2),
@StockInicial	int,
@StockActual	int,
@FecProduccion	date,
@FecVencimiento	date
AS
BEGIN
	INSERT DetalleIngreso (IdIngreso, IdArticulo, PrecioCompra, PrecioVenta, StockInicial, StockActual, FecProduccion, FecVencimiento)
	VALUES (@IdIngreso, @IdArticulo, @PrecioCompra, @PrecioVenta, @StockInicial, @StockActual, @FecProduccion, @FecVencimiento)
END
GO
/*FIN DETALLE INGRESO*/

/*VENTA*/
CREATE PROC MostrarVenta
AS
BEGIN
	SELECT TOP 100 Venta.IdVenta,
		Venta.IdCliente,
		(Cliente.Nombre + ' ' + Cliente.Apellidos) AS Cliente,
		Venta.IdTrabajador,
		(Trabajador.Nombre + ' ' + Trabajador.Apellidos) AS Trabajador,
		Fecha,
		TipoComprobante,
		Serie,
		Correlativo,
		Igv,
		SUM(Cantidad * PrecioVenta - Descuento) AS Total
	FROM Venta
	INNER JOIN DetalleVenta	ON Venta.IdVenta		= DetalleVenta.IdVenta
	INNER JOIN Cliente		ON Venta.IdCliente		= Cliente.IdCliente
	INNER JOIN Trabajador	ON VENTA.IdTrabajador	= Trabajador.IdTrabajador
	GROUP BY Venta.IdVenta,
		Venta.IdCliente,
		(Cliente.Nombre + ' ' + Cliente.Apellidos),
		Venta.IdTrabajador,
		(Trabajador.Nombre + ' ' + Trabajador.Apellidos),
		Fecha,
		TipoComprobante,
		Serie,
		Correlativo,
		Igv
	ORDER BY Venta.IdVenta DESC
END
GO
CREATE PROC BuscarEntreFechasVentas
@FecInicio	date,
@FecFin		date
AS
BEGIN
	SELECT Venta.IdVenta,
		Venta.IdCliente,
		(Cliente.Nombre + ' ' + Cliente.Apellidos) AS Cliente,
		Venta.IdTrabajador,
		(Trabajador.Nombre + ' ' + Trabajador.Apellidos) AS Trabajador,
		Fecha,
		TipoComprobante,
		Serie,
		Correlativo,
		Igv,
		SUM(Cantidad * PrecioVenta - Descuento) AS Total
	FROM Venta
	INNER JOIN DetalleVenta	ON Venta.IdVenta		= DetalleVenta.IdVenta
	INNER JOIN Cliente		ON Venta.IdCliente		= Cliente.IdCliente
	INNER JOIN Trabajador	ON VENTA.IdTrabajador	= Trabajador.IdTrabajador
	GROUP BY Venta.IdVenta,
		Venta.IdCliente,
		(Cliente.Nombre + ' ' + Cliente.Apellidos),
		Venta.IdTrabajador,
		(Trabajador.Nombre + ' ' + Trabajador.Apellidos),
		Fecha,
		TipoComprobante,
		Serie,
		Correlativo,
		Igv
	HAVING Fecha >= @FecInicio AND Fecha <= @FecFin
END
GO
CREATE PROC RegistrarVenta
@IdCliente			int,
@IdTrabajador		int,
@Fecha				date,
@TipoComprobante	varchar(20),
@Serie				varchar(4),
@Correlativo		varchar(7),
@Igv				decimal(5,2),
@IdUltimo			int output
AS
BEGIN
	INSERT Venta (IdCliente, IdTrabajador, Fecha, TipoComprobante, Serie, Correlativo, Igv)
	VALUES (@IdCliente, @IdTrabajador, @Fecha, @TipoComprobante, @Serie, @Correlativo, @Igv)

	--Devolvemos el ID
	SET @IdUltimo = SCOPE_IDENTITY()
	RETURN @IdUltimo
END
GO
CREATE PROC EliminarVenta
@IdVenta int
AS
BEGIN
	DELETE FROM Venta
	WHERE IdVenta = @IdVenta
END
GO
/*FIN VENTA*/

/*DETALLE DE VENTA*/
CREATE PROC RegistrarDetalleVenta
@IdVenta		int,
@IdDetIngreso	int,
@Cantidad		int,
@PrecioVenta	decimal(10,2),
@Descuento		decimal(10,2)
AS
BEGIN
	INSERT DetalleVenta (IdVenta, IdDetIngreso, Cantidad, PrecioVenta, Descuento)
	VALUES (@IdVenta, @IdDetIngreso, @Cantidad, @PrecioVenta, @Descuento)
END
GO
--TRIGGER
CREATE TRIGGER T_RestablecerStock
ON DetalleVenta
FOR DELETE
AS
BEGIN
	UPDATE DetalleIngreso
	SET StockActual = StockActual + DELETED.Cantidad
	FROM DetalleIngreso INNER JOIN DELETED ON DetalleIngreso.IdDetIngreso = DELETED.IdDetIngreso
END
GO
CREATE PROC DisminuirStock
@IdDetIngreso	int,
@Cantidad		int
AS
BEGIN
	UPDATE DetalleIngreso
	SET StockActual = StockActual - @Cantidad
	WHERE IdDetIngreso = @IdDetIngreso
END
GO
CREATE PROC MostarDetalleVenta
@IdVenta int
AS
BEGIN
	SELECT IdDetVenta,
		IdVenta,
		DetalleIngreso.IdDetIngreso,
		Articulo.Nombre AS Articulo,
		Cantidad,
		DetalleVenta.PrecioVenta,
		Descuento,
		(DetalleVenta.PrecioVenta * DetalleVenta.Cantidad - Descuento) AS Subtotal
	FROM DetalleVenta
	INNER JOIN DetalleIngreso	ON DetalleVenta.IdDetIngreso = DetalleIngreso.IdDetIngreso
	INNER JOIN Articulo			ON DetalleIngreso.IdArticulo = Articulo.IdArticulo
	WHERE IdVenta = @IdVenta
END
GO
--Mostrar los articulos para la venta CAPA DATOS VENTA
CREATE PROC MostrarArticulosParaVenta
AS
BEGIN
	SELECT TOP 100 IdDetIngreso,
		Codigo,
		DetalleIngreso.IdArticulo,
		Articulo.Nombre AS Articulo,
		Categotia.Nombre AS Categoria,
		Presentacion.Nombre AS Presentacion,
		StockActual,
		PrecioCompra,
		PrecioVenta,
		FecVencimiento
	FROM Articulo
	INNER JOIN Categotia		ON Articulo.IdCategoria		= Categotia.IdCategoria
	INNER JOIN Presentacion		ON Articulo.IdPresentacion	= Presentacion.IdPresentacion
	INNER JOIN DetalleIngreso	ON Articulo.IdArticulo		= DetalleIngreso.IdArticulo
	INNER JOIN Ingreso			ON DetalleIngreso.IdIngreso	= Ingreso.IdIngreso
	AND StockActual > 0
	AND Estado <> 'ANULADO'
	ORDER BY Articulo.Nombre
END
GO
CREATE PROC MostrarArticulosPorNombreParaVenta
@Nombre varchar(50)
AS
BEGIN
	SELECT IdDetIngreso,
		Codigo,
		DetalleIngreso.IdArticulo,
		Articulo.Nombre AS Articulo,
		Categotia.Nombre AS Categoria,
		Presentacion.Nombre AS Presentacion,
		StockActual,
		PrecioCompra,
		PrecioVenta,
		FecVencimiento
	FROM Articulo
	INNER JOIN Categotia		ON Articulo.IdCategoria		= Categotia.IdCategoria
	INNER JOIN Presentacion		ON Articulo.IdPresentacion	= Presentacion.IdPresentacion
	INNER JOIN DetalleIngreso	ON Articulo.IdArticulo		= DetalleIngreso.IdArticulo
	INNER JOIN Ingreso			ON DetalleIngreso.IdIngreso	= Ingreso.IdIngreso
	WHERE Articulo.Nombre LIKE @Nombre + '%'
	AND StockActual > 0
	AND Estado <> 'ANULADO'
END
GO
CREATE PROC MostrarArticulosPorCodigoParaVenta
@Codigo varchar(50)
AS
BEGIN
	SELECT IdDetIngreso,
		Codigo,
		DetalleIngreso.IdArticulo,
		Articulo.Nombre AS Articulo,
		Categotia.Nombre AS Categoria,
		Presentacion.Nombre AS Presentacion,
		StockActual,
		PrecioCompra,
		PrecioVenta,
		FecVencimiento
	FROM Articulo
	INNER JOIN Categotia		ON Articulo.IdCategoria		= Categotia.IdCategoria
	INNER JOIN Presentacion		ON Articulo.IdPresentacion	= Presentacion.IdPresentacion
	INNER JOIN DetalleIngreso	ON Articulo.IdArticulo		= DetalleIngreso.IdArticulo
	INNER JOIN Ingreso			ON DetalleIngreso.IdIngreso	= Ingreso.IdIngreso
	WHERE Articulo.Codigo = @Codigo
	AND StockActual > 0
	AND Estado <> 'ANULADO'
END
GO
/*FIN DETALLE DE VENTA*/

/*STOCK*/
--Consultar Stock
CREATE PROC ConsultarStock
AS
BEGIN
	SELECT Articulo.Codigo,
		Articulo.Nombre AS Articulo,
		Categotia.Nombre AS Categoria,
		SUM(DetalleIngreso.StockInicial) AS StockInicial,
		SUM(DetalleIngreso.StockActual) AS StockActual,
		SUM(DetalleIngreso.StockInicial) - SUM(DetalleIngreso.StockActual) AS CantidadVentas
	FROM Articulo
	INNER JOIN Categotia		ON Articulo.IdCategoria		= Categotia.IdCategoria
	INNER JOIN DetalleIngreso	ON Articulo.IdArticulo		= DetalleIngreso.IdArticulo
	INNER JOIN Ingreso			ON DetalleIngreso.IdIngreso	= Ingreso.IdIngreso
	WHERE Ingreso.Estado <> 'ANULADO'
	GROUP BY Articulo.Codigo,
		Articulo.Nombre,
		Categotia.Nombre
END
GO
/*FIN STOCK*/

/*BACKUP*/
