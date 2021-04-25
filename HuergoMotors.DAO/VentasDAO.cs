using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuergoMotors.DAO
{
    public class VentasDAO
    {
        public DataTable CargarDTVendedores()
        {
            return HelperDAO.CargarDataTable("SELECT Id, Nombre + ' ' + Apellido AS Vendedor FROM Vendedores");
        }
        public DataTable CargarDTModelos()
        {
            return HelperDAO.CargarDataTable("SELECT  Id, Modelo FROM Vehiculos");
        }
        public DataTable CargarDTAccesorios(int id)
        {
            return HelperDAO.CargarDataTable($"SELECT Nombre, Id FROM Accesorios WHERE idVehiculo = {id}");
        }
        public void ConfirmarVenta(DTO.ClienteDTO clienteDTO, DTO.VehiculoDTO vehiculoDTO, DTO.VendedorDTO vendedorDTO,
            string fecha, string observaciones, string precioVenta, DataTable dtAccesorios)
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
                            $"WHERE Id = {vehiculoDTO.Id}").Rows[0]["Stock"];
                        if (stock < 1) throw new Exception("No hay stock del vehiculo seleccionado");

                        HelperDAO.EditarDB($"INSERT INTO Ventas(Fecha, IdVehiculo, IdCliente, IdVendedor, Observaciones, Total) " +
                        $"VALUES ('{fecha}', '{vehiculoDTO.Id}', '{clienteDTO.Id}', '{vendedorDTO.Id}', " +
                        $"'{observaciones}', '{precioVenta}')", conexion, transaction);

                        //Actualizar Stock
                        stock = stock - 1;
                        HelperDAO.EditarDB($"UPDATE Vehiculos SET Stock='{stock}' WHERE Id={vehiculoDTO.Id}", conexion, transaction);

                        //Si hay accesorios los agrega y si no termina la transaction
                        if (dtAccesorios != null && dtAccesorios.Rows.Count > 0)
                        {
                            //Por cada accesorio en la lista se agrega una venta en VentasAccesorios
                            foreach (DataRow dataRow in dtAccesorios.Rows)
                            {
                                int idAccesorio = (int)dataRow["id"];
                                decimal precioAccesorio = (decimal)dataRow["Precio"];
                                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
                                numberFormatInfo.NumberDecimalSeparator = ".";
                                HelperDAO.EditarDB($"INSERT INTO VentasAccesorios (IdVenta, IdAccesorio, Precio) VALUES" +
                                    $"((SELECT MAX(Id) AS IdVenta FROM Ventas), '{idAccesorio}'," +
                                    $" '{precioAccesorio.ToString(numberFormatInfo)}')", conexion, transaction);
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al intentar cargar la venta en la base de datos", ex);
                    }
                }
            }
        }
        public DataTable CargarTabla()
        {
            return HelperDAO.CargarDataTable("SELECT a.Id, a.Fecha, a.IdVehiculo, a.IdCliente, a.IdVendedor, a.Observaciones, a.Total," +
                " b.Modelo as Vehiculo, c.Nombre as Cliente, (d.Nombre + ' ' + d.Apellido) as Vendedor" +
                " FROM Ventas a JOIN Vehiculos b ON a.IdVehiculo = b.Id  JOIN Clientes c ON a.IdCliente = c.Id JOIN" +
                " Vendedores d ON a.IdVendedor = d.Id");
        }
        public DataTable Buscar(string filtro)
        {
            return HelperDAO.CargarDataTable($"SELECT a.Id, a.Fecha, a.IdVehiculo, a.IdCliente, a.IdVendedor," +
                $" a.Observaciones, a.Total, b.Modelo as Vehiculo, c.Nombre as Cliente, (d.Nombre + ' ' + d.Apellido) as Vendedor " +
                $"FROM Ventas a JOIN Vehiculos b ON a.IdVehiculo = b.Id JOIN Clientes c ON a.IdCliente = c.Id JOIN Vendedores d " +
                $"ON a.IdVendedor = d.Id WHERE a.Fecha LIKE '%{filtro}%' OR a.Total LIKE '%{filtro}%' OR b.Modelo LIKE '%{filtro}%'" +
                $"OR c.Nombre LIKE '%{filtro}%' OR d.Nombre LIKE '%{filtro}%' OR d.Apellido LIKE '%{filtro}%'");
        }
    }
}
