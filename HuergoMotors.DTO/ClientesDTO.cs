using System;

namespace HuergoMotors.DTO
{
    [Serializable]
    public class ClientesDTO:DTOBase
    {
        public string Nombre { get; set;  }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
    }
}
