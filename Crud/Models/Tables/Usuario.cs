using System;
using System.Collections.Generic;

namespace Crud.Models.Tables
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
    }
}
