using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        
        //1 Para 1
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

        [JsonIgnore]
        //1 Para n ou N para 1
        public virtual Gerente Gerente { get; set; }

        [JsonIgnore]
        public int GerenteId { get; set; }


        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }

    }
}