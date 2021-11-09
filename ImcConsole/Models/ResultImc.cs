using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcConsole.Models
{
    public class ResultImc
    {
        //1 - Maior
        //2 - Menor
        public Type TypeResult { get; set; }

        public Participante Participante { get; set; }

        public enum Type
        {
            Maior = 1,
            Menor = 2
        }

    }
}
