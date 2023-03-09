using System;

namespace bolsa_de_empleo_api.Models
{
    public class Ciudadanos
    {
        public int Id { get; set; }
        public string Tipo_documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime? Fecha_nacimiento { get; set; }
        public string Profesion { get; set; }
        public decimal Aspiracion_salarial { get; set; }
        public string Email { get; set; }
    }
}
