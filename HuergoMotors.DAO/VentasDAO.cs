using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HuergoMotors.DTO;

namespace HuergoMotors.DAO
{
    public class VentasDAO
    {
        public static string VentasCampos = "a.Id, a.Fecha, a.IdVehiculo, a.IdCliente, a.IdVendedor, a.Observaciones," +
            " a.Total, b.Modelo AS Vehiculo, c.Nombre AS Cliente, (d.Nombre + ' ' + d.Apellido) AS Vendedor";

        public static string VentasTablas = "Ventas a JOIN Vehiculos b ON a.IdVehiculo = b.Id " +
            "JOIN Clientes c ON a.IdCliente = c.Id JOIN Vendedores d ON a.IdVendedor = d.Id";

        public static string AccesoriosCampos = "a.Id, a.IdVenta, a.IdAccesorio, a.Precio, b.Nombre AS NombreAccesorio, b.Tipo AS TipoAccesorio";

        public static string AccesoriosTablas = "VentasAccesorios a JOIN Accesorios b ON a.IdAccesorio = b.Id";

        HelperDAO helperDAO = new HelperDAO();

        public List<VentasRDTO> CargarTablaVentas()
        {
            return helperDAO.CargarDatos<VentasRDTO>(VentasCampos, VentasTablas);
        }

        public List<VentasAccesoriosRDTO> CargarTablaVentasAccesorios(int idVenta)
        {
            return helperDAO.CargarDatos<VentasAccesoriosRDTO>(AccesoriosCampos, AccesoriosTablas, $"a.IdVenta = {idVenta}");
        }

        public List<VentasRDTO> Buscar(string filtro)
        {
            return helperDAO.CargarDatos<VentasRDTO>(VentasCampos, VentasTablas, 
                $"a.Fecha LIKE '%{filtro}%' OR a.Total LIKE '%{filtro}%' OR b.Modelo LIKE '%{filtro}%'" +
                $"OR c.Nombre LIKE '%{filtro}%' OR d.Nombre LIKE '%{filtro}%' OR d.Apellido LIKE '%{filtro}%'");
        }


        //ConfirmarVenta:
        public void ConfirmarVenta(VentasDTO venta, List<AccesoriosDTO> listaAccesorios)
        {
            //    //using (SqlConnection conexion = new SqlConnection(HelperDAO.ConnectionString))
            //    {
            //        conexion.Open();
            //        using (SqlTransaction transaction = conexion.BeginTransaction())
            //        {
            //            try
            //            {
            //                Valida el stock otra vez
            //                int stock = helperDAO.CargarDatos<VehiculosDTO>($"Id = { venta.IdVehiculo}")[0].Stock;
            //                if (stock < 1) throw new Exception("No hay stock del vehiculo seleccionado");

            //                HelperDAO.EditarDB($"INSERT INTO Ventas(Fecha, IdVehiculo, IdCliente, IdVendedor, Observaciones, Total) " +
            //                $"VALUES ('{venta.Fecha.ToString("yyyyMMdd")}', '{venta.IdVehiculo}', '{venta.IdCliente}', '{venta.IdVendedor}', " +
            //                $"'{venta.Observaciones}', '{venta.Total.ToString(HelperDAO.NFI())}')", conexion, transaction);

            //                Actualizar Stock
            //                stock = stock - 1;
            //                HelperDAO.EditarDB($"UPDATE Vehiculos SET Stock='{stock}' WHERE Id={venta.IdVehiculo}", conexion, transaction);

            //                Si hay accesorios los agrega y si no termina la transaction
            //                if (listaAccesorios != null && listaAccesorios.Count > 0)
            //                {
            //                    Por cada accesorio en la lista se agrega una venta en VentasAccesorios
            //                    foreach (AccesoriosRDTO accesorio in listaAccesorios)
            //                    {
            //                        HelperDAO.EditarDB($"INSERT INTO VentasAccesorios (IdVenta, IdAccesorio, Precio) VALUES" +
            //                            $"((SELECT MAX(Id) AS IdVenta FROM Ventas), '{accesorio.Id}'," +
            //                            $" '{accesorio.Precio.ToString(HelperDAO.NFI())}')", conexion, transaction);

            //                    }
            //                }
            //                transaction.Commit();
            //            }
            //            catch (Exception ex)
            //            {
            //                transaction.Rollback();
            //                throw new Exception("Error al intentar cargar la venta en la base de datos.", ex);
            //            }
            //        }
                //}
            }

        }
}
