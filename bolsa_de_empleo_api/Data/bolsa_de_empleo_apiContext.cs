using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bolsa_de_empleo_api.Models;

namespace bolsa_de_empleo_api.Data
{
    public class bolsa_de_empleo_apiContext : DbContext
    {
        public bolsa_de_empleo_apiContext (DbContextOptions<bolsa_de_empleo_apiContext> options)
            : base(options)
        {
        }

        public DbSet<bolsa_de_empleo_api.Models.Ciudadanos> Ciudadanos { get; set; }

        public DbSet<bolsa_de_empleo_api.Models.Aplicacion_vacantes> Aplicacion_vacantes { get; set; }

        public DbSet<bolsa_de_empleo_api.Models.Tipo_documentos> Tipo_documentos { get; set; }

        public DbSet<bolsa_de_empleo_api.Models.Vacantes> Vacantes { get; set; }
    }
}
