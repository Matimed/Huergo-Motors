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

        private VentasAccesoriosDTO CrearVentaAccesorio(AccesoriosDTO accesorio, int idVenta)
        {
            VentasAccesoriosDTO ventaAccesorio = new VentasAccesoriosDTO();
            ventaAccesorio.IdAccesorio = accesorio.Id;
            ventaAccesorio.IdVenta = idVenta;
            ventaAccesorio.Precio = accesorio.Precio;
            return ventaAccesorio;
        }

        public void ConfirmarVenta(VentasDTO venta, List<AccesoriosDTO> listaAccesorios)
        {
            using (SqlConnection conexion = new SqlConnection(HelperDAO.ConnectionString))
            {
                conexion.Open();
                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        //Valida el stock otra vez
                        int stock = helperDAO.CargarDatos<VehiculosDTO>($"Id = { venta.IdVehiculo}")[0].Stock;
                        if (stock < 1) throw new Exception("No hay stock del vehiculo seleccionado");
                        helperDAO.AgregarElemento(venta, conexion, transaction);

                        //Actualizar Stock
                        stock = stock - 1;
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandText = $"UPDATE Vehiculos SET Stock='{stock}' WHERE Id={venta.IdVehiculo}";
                            helperDAO.EditarDB(command, conexion, transaction);
                        }

                        //Si hay accesorios los agrega uno por uno
                        if (listaAccesorios != null && listaAccesorios.Count > 0)
                        {
                            //int idVenta = helperDAO.CargarDatos<VentasAccesoriosDTO>($"MAX(Id) AS IdVenta", "Ventas")[0].IdVenta);
                            foreach (AccesoriosDTO accesorio in listaAccesorios)
                            {
                                //helperDAO.AgregarElemento(CrearVentaAccesorio(accesorio,idVenta), conexion, transaction);
                                using (SqlCommand command = new SqlCommand())
                                {
                                    command.CommandText = $"INSERT INTO VentasAccesorios (IdVenta, IdAccesorio, Precio) VALUES" +
                                        $"((SELECT MAX(Id) AS IdVenta FROM Ventas), '{accesorio.Id}'," +
                                        $" '{accesorio.Precio.ToString(HelperDAO.NFI())}')";
                                    helperDAO.EditarDB(command, conexion, transaction);
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al intentar cargar la venta en la base de datos.", ex);
                    }
                }
            }

        }
    }
}
