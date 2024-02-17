
--Punto 1
--Por la misma razon del código, seteo @fechaHasta de las dos maneras posibles
--Comentar linea 9 para usar la fecha de hoy 
declare @fechaDesde DateTime
declare @fechaHasta datetime 

set @fechaHasta = GETDATE()
select top 1 @fechaHasta = Fecha from Venta order by Fecha desc

set @fechaDesde = DATEADD(DAY,-30, @fechaHasta)


Select SUM(Total), COUNT(Total) from Venta where Fecha between @fechaDesde and @fechaHasta

---------------------------------------------------------
--Punto 2
Select Top 1 Fecha, Total from Venta order by Total desc

---------------------------------------------------------
--Punto 3
Select Top 1 Producto.Nombre, Sum(VentaDetalle.TotalLinea) from VentaDetalle 
inner join Producto on Producto.Id_Producto = VentaDetalle.Id_Producto 
group by VentaDetalle.Id_Producto, Producto.Nombre 
order by Sum(VentaDetalle.TotalLinea) desc

---------------------------------------------------------
--Punto 4
Select top 1 Local.Nombre, SUM(Venta.Total) from Local 
inner join Venta on Venta.Id_Local = Local.Id_Local
group by Venta.Id_Local, Local.Nombre
order by SUM(Venta.Total) desc

---------------------------------------------------------
--Punto 5
Select Top 1 Marca.Nombre, SUM(VentaDetalle.TotalLinea) from VentaDetalle
inner Join Producto on Producto.Id_Producto = VentaDetalle.Id_Producto
inner Join Marca on Marca.Id_Marca = Producto.Id_Marca
group By Marca.Id_Marca, Marca.Nombre
order by SUM(VentaDetalle.TotalLinea) desc

---------------------------------------------------------
--Punto 6
Select a.Nombre, a.ProNombre, a.Cantidad 
from
(
Select Local.Nombre 'Nombre', Producto.Nombre 'ProNombre', SUM(VentaDetalle.Cantidad) 'Cantidad', 
	   ROW_NUMBER() OVER(PARTITION BY Local.Nombre ORDER BY Local.Nombre, SUM(VentaDetalle.Cantidad) DESC) rn 
	   from VentaDetalle inner join Venta on Venta.Id_Venta = VentaDetalle.Id_Venta 
	   inner join Producto on Producto.Id_Producto = VentaDetalle.Id_Producto 
	   inner join Local on Local.Id_Local = Venta.Id_Local 
	   group by Local.Id_Local, Local.Nombre, Producto.Id_Producto, Producto.Nombre 
) a Where rn = 1