using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyCondominio.Models
{
    public class Bloco
    {
        public int BlocoId { get; set; }

        [DisplayName("Bloco")]
        [Required(ErrorMessage = "Informe o nome do bloco")]
        [StringLength(50, ErrorMessage = "O campo aceita até no máximo 50 caracteres")]
        public string NumBloco { get; set; }

        [DisplayName("Quantidade de apartamentos")]
        [Required(ErrorMessage = "Informe a quantidade de apartamentos para este bloco")]
        public int QtdAptos { get; set; }

        [DisplayName("Área total do bloco")]
        public float AreaTotal { get; set; }

        public int CondominioId { get; set; }
        public virtual Condominio Condominio { get; set; }

        public virtual ICollection<Apartamento> Apartamentos { get; set; }
    }
}