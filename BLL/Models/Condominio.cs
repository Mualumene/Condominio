using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BLL.Models
{
    public class Condominio
    {
        public int CondominioId { get; set; }

        [DisplayName("Condomínio")]
        [Required(ErrorMessage = "Informe o nome do condomínio")]
        [StringLength(100, ErrorMessage = "O campo aceita até no máximo 100 caracteres")]
        public string NomeCondominio { get; set; }

        [DisplayName("Quantidade de blocos")]
        [Required(ErrorMessage = "Informe a quantidade de blocos para o condomínio")]
        public int NumeroBlocos { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage = "Informe o endereço do proprietário")]
        [StringLength(150, ErrorMessage = "O campo aceita até no máximo 150 caracteres")]
        public string Endereco { get; set; }

        [StringLength(50, ErrorMessage = "O campo aceita até no máximo 50 caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe o bairro do proprietário")]
        [StringLength(100, ErrorMessage = "O campo aceita até no máximo 150 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a cidade do proprietário")]
        [StringLength(150, ErrorMessage = "O campo aceita até no máximo 150 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o estado")]
        [StringLength(150, ErrorMessage = "O campo aceita até no máximo 150 caracteres")]
        public string UF { get; set; }

        public virtual ICollection<Bloco> Blocos { get; set; }
    }
}