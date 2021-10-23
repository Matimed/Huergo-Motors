namespace HuergoMotors.DTO
{
    [System.Serializable]
    public class AccesoriosDTO : DTOBase
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }
        public int IdVehiculo { get; set; }
        public byte[] Foto { get;set; }
    }
}
