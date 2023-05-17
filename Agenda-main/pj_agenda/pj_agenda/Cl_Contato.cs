using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pj_agenda
{
    class Cl_Contato
    {
        private int cod_contato;
        private string nome;
        private string telefone;
        private string celular;
        private string email;

        public int Codcontato
        {
            get => cod_contato;
            set => cod_contato = value;
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }

        public string Telefone
        {
            get => telefone;
            set => telefone = value;
        }

        public string Celular
        {
            get => celular;
            set => celular = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }
    }

}
