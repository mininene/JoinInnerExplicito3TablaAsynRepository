using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaseDatos.Models.ViewModel
{
    public class Join
    {
        public Usuario usuarioList { get; set; }
        public Coche cocheList { get; set; }
        public Departamento departamentoList { get; set; }

    }
}