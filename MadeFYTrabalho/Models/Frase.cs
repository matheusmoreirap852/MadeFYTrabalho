using System;
using System.ComponentModel.DataAnnotations;


namespace MadeFYTrabalho.Models
{
    public class Frase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DtCadastro { get; set; }

        [StringLength(100)]
        [Required]
        public String Texto1 { get; set; }

        [StringLength(100)]
        [Required]
        public String Texto2 { get; set; }

        public String Diferenca { get; set; }
    }
}
