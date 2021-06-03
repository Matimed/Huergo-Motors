namespace HuergoMotors.DTO
{
    public class AccesoriosRDTO:DTOBase
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }
        public int IdVehiculo { get; set; }
        public string Modelo { get; set; }
    }
}
