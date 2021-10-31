using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HuergoMotors.DTO;

namespace HuergoMotors.DAO
{
    public class VentasDAO : DAOBase<VentasDTO>
    {
        private static (string campos, string tablas) Ventas = ("a.Id, a.Fecha, a.IdVehiculo, a.IdCliente, a.IdVendedor, a.Observaciones, a.Total, b.Modelo AS Vehiculo, c.Nombre AS Cliente, (d.Nombre + ' ' + d.Apellido) AS Vendedor", "Ventas a LEFT JOIN Vehiculos b ON a.IdVehiculo = b.Id JOIN Clientes c ON a.IdCliente = c.Id LEFT JOIN Vendedores d ON a.IdVendedor = d.Id");
        private static (string campos, string tablas) VentasAccesorios = ("a.Id, a.IdVenta, a.IdAccesorio, a.Precio, b.Nombre AS NombreAccesorio, b.Tipo AS TipoAccesorio", "VentasAccesorios a JOIN Accesorios b ON a.IdAccesorio = b.Id");


        DAOBase<VentasRDTO> daoVentasJoins = new DAOBase<VentasRDTO>();
        DAOBase<VentasAccesoriosRDTO> daoVentasAccesoriosJoins = new DAOBase<VentasAccesoriosRDTO>();

        public List<VentasRDTO> CargarTablaVentas()
        {
            return daoVentasJoins.CargarDatos(Ventas.campos, Ventas.tablas);
        }

        public List<VentasAccesoriosRDTO> CargarTablaVentasAccesorios(int idVenta)
        {
            return daoVentasAccesoriosJoins.CargarDatos(VentasAccesorios.campos, VentasAccesorios.tablas, $"a.IdVenta = {idVenta}");
        }

        public List<VentasRDTO> CargarTablaVentasCliente(int id)
        {
            return daoVentasJoins.CargarDatos(Ventas.campos, Ventas.tablas, $"a.idCliente = {id}");
        }

        public new List<VentasRDTO> Buscar(string filtro)
        {
            return daoVentasJoins.CargarDatos(Ventas.campos, Ventas.tablas,
                $"a.Fecha LIKE '%{filtro}%' OR a.Total LIKE '%{filtro}%' OR b.Modelo LIKE '%{filtro}%'" +
                $"OR c.Nombre LIKE '%{filtro}%' OR d.Nombre LIKE '%{filtro}%' OR d.Apellido LIKE '%{filtro}%'");
        }

        public void ConfirmarVenta(VentasDTO venta, List<AccesoriosDTO> listaAccesorios)
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        //Valida el stock otra vez
                        VehiculosDAO vehiculosDAO = new VehiculosDAO();
                        VehiculosDTO vehiculo = vehiculosDAO.BuscarId(venta.IdVehiculo);
                        if (vehiculo.Stock < 1) throw new Exception("No hay stock del vehiculo seleccionado");
                        AgregarElemento(venta, transaction);

                        //Actualizar Stock
                        vehiculo.Stock = vehiculo.Stock - 1;
                        string[] propiedades = new string[1] {"Stock"};
                        vehiculosDAO.ModificarElemento(vehiculo, propiedades, transaction);
                       

                        //Si hay accesorios los agrega uno por uno
                        if (listaAccesorios != null && listaAccesorios.Count > 0)
                        {
                            foreach (AccesoriosDTO accesorio in listaAccesorios)
                            {
                                using (SqlCommand command = new SqlCommand())
                                {
                                    command.CommandText = $"INSERT INTO VentasAccesorios (IdVenta, IdAccesorio, Precio) VALUES" +
                                        $"((SELECT MAX(Id) FROM Ventas), '{accesorio.Id}', '{accesorio.Precio.ToString(NFI())}')";
                                    EditarDB(command, transaction);
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

        public void ConfirmarVentaAccesorios(VentasDTO venta, List<AccesoriosDTO> listaAccesorios)
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        //using (SqlCommand command = new SqlCommand())
                        //{
                        //    command.CommandText = $"INSERT INTO Ventas (Fecha, IdCliente, Observaciones, Total) VALUES" +
                        //        $"({venta.Fecha}, {venta.IdCliente}, '{venta.Observaciones}', {venta.Total.ToString(NFI())})";
                        //    EditarDB(command, transaction);
                        //}
                        //AgregarElemento(venta, transaction);
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Parameters.AddWithValue("@fecha", venta.Fecha);
                            command.Parameters.AddWithValue("@idCliente", venta.IdCliente);
                            command.Parameters.AddWithValue("@Observaciones", venta.Observaciones);
                            command.Parameters.AddWithValue("@Total", venta.Total);
                            List<string> nombrePropiedades = new List<string>();
                            nombrePropiedades.Add("Fecha");
                            nombrePropiedades.Add("idCliente");
                            nombrePropiedades.Add("Observaciones");
                            nombrePropiedades.Add("Total");
                            command.CommandText = QueryCreate(nombrePropiedades.ToArray());
                            EditarDB(command, transaction);
                        }

                        if (listaAccesorios != null && listaAccesorios.Count > 0)
                        {
                            foreach (AccesoriosDTO accesorio in listaAccesorios)
                            {
                                using (SqlCommand command = new SqlCommand())
                                {
                                    command.CommandText = $"INSERT INTO VentasAccesorios (IdVenta, IdAccesorio, Precio) VALUES" +
                                        $"((SELECT MAX(Id) FROM Ventas), '{accesorio.Id}', '{accesorio.Precio.ToString(NFI())}')";
                                    EditarDB(command, transaction);
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
