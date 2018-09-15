using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BLL.Models;

namespace BLL.Models
{
    public class SegurancaViewModels
    {
    }

    public class UsuarioViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

    }

    [NotMapped]
    public class LoginViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Senha { get; set; }
    }

    //Utilizado nas Actions Create e Edit.
    public class PapelViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }

    //Utilizado na Action Details.
    public class PapelDetailsModel
    {
        public Papel Role { get; set; }
        public IEnumerable<Usuario> Membros { get; set; }
    }
}