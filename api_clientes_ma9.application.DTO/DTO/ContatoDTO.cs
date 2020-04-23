﻿using System.ComponentModel.DataAnnotations;

namespace api_clientes_ma9.application.dto
{
    public partial class ContatoDTO
    {
        public int? Id { get; set; }
        public int IdCliente { get; set; }
        [Required]
        public string Ddd { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual ClienteDTO Cliente { get; set; }
    }
}
