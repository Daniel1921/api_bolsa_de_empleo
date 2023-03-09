using System;

namespace bolsa_de_empleo_api.Models
{
    public class Aplicacion_vacantes
    {
        public int Id { get; set; }
        public int id_cedula { get; set; }
        public string Codigo_vacante { get; set; }
        public DateTime Fecha_aplicacion { get; set; }
    }
}
