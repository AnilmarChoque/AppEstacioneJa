    using AppEstacioneJa.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacioneJa.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] Foto { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public PreferenciaEnum Preferencia { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Token { get; set; }
    }
}
