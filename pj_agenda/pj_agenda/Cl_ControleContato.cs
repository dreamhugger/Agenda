using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace pj_agenda
{
    class Cl_ControleContato
    {
        Cl_Conexao c = new Cl_Conexao();

        public string cadastrar(Cl_Contato cont)
        {
            try
            {
                string sql = "INSERT INTO tbcontato (nome, telefone, celular, email) " + "VALUES ('" + cont.Nome + "', '" + cont.Telefone + "', " + "'" + cont.Celular + "', '" + cont.Email + "')";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();
                return ("Cadastro realizado com sucesso.");
            }

            catch (MySqlException e)
            {
                return (e.ToString());
            }

        }
    }
}
