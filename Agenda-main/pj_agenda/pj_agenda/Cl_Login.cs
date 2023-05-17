using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace pj_agenda
{
    class Cl_Login
    {
        Cl_Conexao c = new Cl_Conexao();

        public bool Logar(string l, string s)
        {
            try
            {
                string sql = "select login , senha from tb_login where login like '" + l + "' and senha like '" + s + "' ;";
                MySqlCommand cmd = new MySqlCommand(sql, c.con);
                c.conectar();
                MySqlDataReader objDados = cmd.ExecuteReader();
                if (!objDados.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            catch (MySqlException e)
            {
                throw (e);
            }

            finally
            {
                c.desconectar();
            }
        }
    }
}