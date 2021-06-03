namespace HuergoMotors.DTO
{
    public class VentasAccesoriosDTO : DTOBase
    {
        public int IdVenta { get; set; }
        public int IdAccesorio { get; set; }
        public decimal Precio { get; set; }
    }
}
