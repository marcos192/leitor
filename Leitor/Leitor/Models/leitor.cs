using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leitor.Models
    {
    public class leitor
        {
            public long Id { get; set; }
            public string Nome { get; set; }
            public string Cpf { get; set; }
            public string Data_Nascimento { get; set; }
            public string Endereco { get; set; }
            public string Cep { get; set; }
            public string Cidade { get; set; }
            public string Uf { get; set; }
        }
    }