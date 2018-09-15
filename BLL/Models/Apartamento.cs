using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BLL.Models
{
    public class Apartamento
    {
        public int ApartamentoId { get; set; }

        [DisplayName("Apartamento")]
        [Required(ErrorMessage ="Informe o número do apartamento")]
        [StringLength(4, ErrorMessage = "O campo aceita até no máximo 4 caracteres")]
        public string NumApto { get; set; }

        public int BlocoId { get; set; }
        public virtual Bloco Bloco { get; set; }

        public int? ProprietarioId { get; set; }
        public virtual Proprietario Proprietario { get; set; }

    }
}