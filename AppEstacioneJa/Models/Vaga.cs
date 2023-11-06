using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEstacioneJa.Models.Enuns;

namespace AppEstacioneJa.Models
{
    public class Vaga
    {
        public long Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Secao { get; set; }
        public DisponibilidadeEnum Disponibilidade { get; set; }
        public int Andar { get; set; }
        public double Numero { get; set; }
        public PreferenciaEnum Preferencia { get; set; }
    }
}
