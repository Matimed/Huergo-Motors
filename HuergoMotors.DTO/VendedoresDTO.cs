namespace HuergoMotors.DTO
{
    public class VendedoresDTO : DTOBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sucursal { get; set; }
        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {Apellido}";
            }
        }
    }
}
