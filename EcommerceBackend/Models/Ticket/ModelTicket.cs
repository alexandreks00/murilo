using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestSharp.models.ModelTicket
{
    public class ModelTicket
    {   
        public Transacao transacao { get; set; }
        public TransacaoSecundaria transacaoSecundaria { get; set; }

    }

    public class Beneficio
    {
        public int Quantidade { get; set; }
    }

    public class Transacao
    {
        public int ParceiroId { get; set; }
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public List<Beneficio> Beneficios { get; set; }
    }

    public class TransacaoSecundaria
    {
        public int ParceiroId { get; set; }
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public List<Beneficio> Beneficios { get; set; }
    }




}
