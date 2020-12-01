using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Presentacion.Models
{
    public class FileUploadModel
    {
        [Required(ErrorMessage = "Seleccione un archivo de texto!")]
        [Display(Name = "Archivo con datos: ")]
        [DataType(DataType.Upload)]
        public string Archivo { get; set; }
    }
}