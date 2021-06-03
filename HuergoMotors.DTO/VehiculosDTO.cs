namespace HuergoMotors.DTO
{
    public class VehiculosDTO : DTOBase
    {
        public string Tipo { get; set; }
        public string Modelo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
    }
}
