using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEstacioneJa.Models.Enuns;

namespace AppEstacioneJa.Models
{
    public class UsuarioVaga
    {
        public long CodData { get; set; }
        public PagamentoEnum Forma_pagamento { get; set; }
        public DateTime Data { get; set; }
        public string Receptor_pagamento { get; set; }
        public string Emissor_pagamento { get; set; }
        public DateTime Ocupacao_inicial { get; set; }
        public DateTime Ocupacao_final { get; set; }
        public long VagaId { get; set; }
        public long UsuarioId { get; set; }
    }
}
