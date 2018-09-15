using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BLL.Models
{
    public class Proprietario
    {
        public int ProprietarioId { get; set; }

        [DisplayName("Proprietário")]
        [Required(ErrorMessage = "Informe o nome do proprietário")]
        [StringLength(150, ErrorMessage = "O campo aceita até no máximo 150 caracteres")]
        public string Nome { get; set; }

        [StringLength(11, ErrorMessage = "O campo aceita até no máximo 11 caracteres")]
        public string CPF { get; set; }

        [StringLength(20, ErrorMessage = "O campo aceita até no máximo 20 caracteres")]
        public string RG { get; set; }

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

        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Apartamento> Apartamentos { get; set; }

    }
}