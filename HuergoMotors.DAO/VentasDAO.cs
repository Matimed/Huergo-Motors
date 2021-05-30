using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HuergoMotors.DTO;

namespace HuergoMotors.DAO
{
    public class VentasDAO
    {
        public List<VentaDTO> CargarListaDTOs(DataTable dataTable)
        {

            List<VentaDTO> listaVentas = new List<VentaDTO>();
            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    VentaDTO ventaDTO = new VentaDTO();
                    ventaDTO.Id = (int)dataRow["Id"];
                    ventaDTO.IdCliente = (int)dataRow["IdCliente"];
                    ventaDTO.IdVehiculo = (int)dataRow["IdVehiculo"];
                    ventaDTO.IdVendedor = (int)dataRow["IdVendedor"];
                    ventaDTO.Observaciones = (string)dataRow["Observaciones"];
                    ventaDTO.Fecha = (DateTime)dataRow["Fecha"];
                    ventaDTO.Total = (decimal)dataRow["Total"];
                    ventaDTO.Cliente = (string)dataRow["Cliente"];
                    ventaDTO.Vendedor = (string)dataRow["Vendedor"];
                    ventaDTO.Vehiculo = (string)dataRow["Vehiculo"];
                    listaVentas.Add(ventaDTO);

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return listaVentas;
        }

        public List<VentaAccesorioDTO> CargarListaAccesoriosDTOs(DataTable dataTable)
        {

            List<VentaAccesorioDTO> listaVentasAccesorios = new List<VentaAccesorioDTO>();
            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    VentaAccesorioDTO ventaDTO = new VentaAccesorioDTO();
                    ventaDTO.Id = (int)dataRow["Id"];
                    ventaDTO.IdVenta = (int)dataRow["IdVenta"];
                    ventaDTO.IdAccesorio = (int)dataRow["IdAccesorio"];
                    ventaDTO.Precio = (decimal)dataRow["Precio"];
                    ventaDTO.NombreAccesorio = (string)dataRow["NombreAccesorio"];
                    ventaDTO.TipoAccesorio = (string)dataRow["TipoAccesorio"];
                    listaVentasAccesorios.Add(ventaDTO);

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return listaVentasAccesorios;
        }

        public List<VentaDTO> CargarTablaVentas()
        {
            return CargarListaDTOs( HelperDAO.CargarDataTable("SELECT a.Id, a.Fecha, a.IdVehiculo, a.IdCliente, a.IdVendedor, a.Observaciones, a.Total," +
                " b.Modelo as Vehiculo, c.Nombre as Cliente, (d.Nombre + ' ' + d.Apellido) as Vendedor" +
                " FROM Ventas a JOIN Vehiculos b ON a.IdVehiculo = b.Id  JOIN Clientes c ON a.IdCliente = c.Id JOIN" +
                " Vendedores d ON a.IdVendedor = d.Id"));
        }

        public List<VentaAccesorioDTO> CargarTablaVentasAccesorios(int idVenta)
        {
            return CargarListaAccesoriosDTOs(HelperDAO.CargarDataTable($"SELECT a.Id, a.IdVenta, a.IdAccesorio, a.Precio, b.Nombre AS NombreAccesorio," +
                $" b.Tipo as TipoAccesorio  FROM VentasAccesorios a JOIN Accesorios b ON a.IdAccesorio = b.Id WHERE a.IdVenta = {idVenta}"));
        }

        public List<VentaDTO> Buscar(string filtro)
        {
            return CargarListaDTOs(HelperDAO.CargarDataTable($"SELECT a.Id, a.Fecha, a.IdVehiculo, a.IdCliente, a.IdVendedor," +
                $" a.Observaciones, a.Total, b.Modelo as Vehiculo, c.Nombre as Cliente, (d.Nombre + ' ' + d.Apellido) as Vendedor " +
                $"FROM Ventas a JOIN Vehiculos b ON a.IdVehiculo = b.Id JOIN Clientes c ON a.IdCliente = c.Id JOIN Vendedores d " +
                $"ON a.IdVendedor = d.Id WHERE a.Fecha LIKE '%{filtro}%' OR a.Total LIKE '%{filtro}%' OR b.Modelo LIKE '%{filtro}%'" +
                $"OR c.Nombre LIKE '%{filtro}%' OR d.Nombre LIKE '%{filtro}%' OR d.Apellido LIKE '%{filtro}%'"));
        }

        public void ConfirmarVenta(VentaDTO venta, List<AccesorioDTO> listaAccesorios)
        {
            using (SqlConnection conexion = new SqlConnection(HelperDAO.ConnectionString))
            {
                conexion.Open();
                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        //Valida el stock otra vez
                        int stock = (int)HelperDAO.CargarDataTable($"SELECT Stock FROM Vehiculos " +
                            $"WHERE Id = {venta.IdVehiculo}").Rows[0]["Stock"];
                        if (stock < 1) throw new Exception("No hay stock del vehiculo seleccionado");

                        HelperDAO.EditarDB($"INSERT INTO Ventas(Fecha, IdVehiculo, IdCliente, IdVendedor, Observaciones, Total) " +
                        $"VALUES ('{venta.Fecha.ToString("yyyyMMdd")}', '{venta.IdVehiculo}', '{venta.IdCliente}', '{venta.IdVendedor}', " +
                        $"'{venta.Observaciones}', '{venta.Total.ToString(HelperDAO.NFI())}')", conexion, transaction);

                        //Actualizar Stock
                        stock = stock - 1;
                        HelperDAO.EditarDB($"UPDATE Vehiculos SET Stock='{stock}' WHERE Id={venta.IdVehiculo}", conexion, transaction);

                        //Si hay accesorios los agrega y si no termina la transaction
                        if (listaAccesorios != null && listaAccesorios.Count > 0)
                        {
                            //Por cada accesorio en la lista se agrega una venta en VentasAccesorios
                            foreach (AccesorioDTO accesorio in listaAccesorios)
                            {
                                HelperDAO.EditarDB($"INSERT INTO VentasAccesorios (IdVenta, IdAccesorio, Precio) VALUES" +
                                    $"((SELECT MAX(Id) AS IdVenta FROM Ventas), '{accesorio.Id}'," +
                                    $" '{accesorio.Precio.ToString(HelperDAO.NFI())}')", conexion, transaction);
                                
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
