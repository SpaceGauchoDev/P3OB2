using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Proyectos")]
    public class Proyecto
    {
        // properties proyecto
        // ===================
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProyecto { get; set; }

        [StringLength(1)]
        [Required]
        public string Estado { get; set; } // check A || C

        [StringLength(1)]
        [Required]
        public string TipoDeEquipo { get; set; } // check P || C

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string ImgURL { get; set; }

        [Required]
        public DateTime FechaDePresentacion { get; set; }

        // properties proyecto - cooperativo
        // =================================
        public int CantidadDeIntegrantes { get; set; }

        // properties proyecto - personal
        // ==============================
        public string ExperienciaPersonal { get; set; }

        // properties prestamo solicitado
        // ==============================
        [Required]
        public int Cuotas { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        [Required]
        public decimal PrecioPorCuota { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        [Required]
        public decimal MontoSolicitado { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        [Required]
        public decimal PorcentajeDeInteres { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        [Required]
        public decimal MontoConseguido { get; set; }

        // navegacion
        // ==========
        [ForeignKey("Solicitante")]
        public int IdSolicitante { get; set; }
        public Solicitante Solicitante { get; set; }

        public ICollection<Financiacion> Financiaciones { get; set; }
    }
}
