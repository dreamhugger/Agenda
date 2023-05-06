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
                return ("Cadastro realizado com sucesso!");
            }

            catch (MySqlException e)
            {
                return (e.ToString());
            }

        }

        public string alterar(Cl_Contato cont)
        {
            try
            {
                string sql = "update tbcontato set nome = '" + cont.Nome + "' , " + "telefone = '" + cont.Telefone + "', celular = '" + cont.Celular + "', email = '" + cont.Email + "' where codcontato = " + cont.Codcontato + " ; ";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();
                return ("Dados alterados com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

        public string excluir(Cl_Contato cont)
        {
            try
            {
                string sql = "delete from tb_contato where cod_contato =" + cont.Codcontato + ";";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();
                return ("Dados excluídos com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

        public Cl_Contato buscar(int codigo)
        {
            Cl_Contato cont = new Cl_Contato();

            try
            {
                string sql = "select * from tbcontato where codcontato= " + codigo + ";";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);
                c.conectar();

                MySqlDataReader objDados = cmd.ExecuteReader();
                if (!objDados.HasRows)
                {
                    return null;
                }
                else
                {
                    objDados.Read();
                    cont.Codcontato = Convert.ToInt32(objDados["codcontato"]);
                    cont.Nome = objDados["nome"].ToString();
                    cont.Telefone = objDados["telefone"].ToString();
                    cont.Celular = objDados["celular"].ToString();
                    cont.Email = objDados["email"].ToString();

                    objDados.Close();
                    return cont;
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
