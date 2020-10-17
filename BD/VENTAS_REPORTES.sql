USE DBVENTAS
GO
/*REPORTES*/
CREATE PROC ReporteFactura
@IdVenta int
AS
BEGIN
	SELECT Venta.IdVenta,
		(Trabajador.Apellidos + ', ' + Trabajador.Nombre) AS Trabajador,
		(Cliente.Apellidos + ', ' + Cliente.Nombre) AS Cliente,
		Cliente.Direccion,
		Cliente.Telefono,
		Cliente.NumDocumento,
		Venta.Fecha,
		Venta.TipoComprobante,
		Venta.Serie,
		Venta.Correlativo,
		Venta.Igv,
		Articulo.Nombre,
		DetalleVenta.PrecioVenta,
		DetalleVenta.Cantidad,
		DetalleVenta.Descuento,
		(DetalleVenta.Cantidad * DetalleVenta.PrecioVenta - DetalleVenta.Descuento) AS TotalParcial
	FROM DetalleVenta
	INNER JOIN DetalleIngreso	ON DetalleVenta.IdDetIngreso	= DetalleIngreso.IdDetIngreso
	INNER JOIN Articulo			ON DetalleIngreso.IdArticulo	= Articulo.IdArticulo
	INNER JOIN Venta			ON DetalleVenta.IdVenta			= Venta.IdVenta
	INNER JOIN Cliente			ON VentA.IdCliente				= Cliente.IdCliente
	INNER JOIN Trabajador		ON Venta.IdTrabajador			= Trabajador.IdTrabajador
	WHERE Venta.IdVenta = @IdVenta
END
GO
