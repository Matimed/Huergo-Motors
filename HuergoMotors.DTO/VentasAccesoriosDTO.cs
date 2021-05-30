namespace HuergoMotors.DTO
{
    public class VentasAccesoriosDTO
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdAccesorio { get; set; }
        public decimal Precio { get; set; }
        public string NombreAccesorio { get; }
        public string TipoAccesorio { get; }


    }
}
