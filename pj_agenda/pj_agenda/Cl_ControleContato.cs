using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace pj_agenda
{
    class Cl_ControleContato
    {
        Cl_Conexao c = new Cl_Conexao();

        public string cadastrar(Cl_Contato cont)
        {
            try
            {
                string sql = "INSERT INTO tb_contato (nome, telefone, celular, email) " + "VALUES ('" + cont.Nome + "', '" + cont.Telefone + "', " + "'" + cont.Celular + "', '" + cont.Email + "')";

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
                string sql = "update tb_contato set nome = '" + cont.Nome + "' , " + "telefone = '" + cont.Telefone + "', celular = '" + cont.Celular + "', email = '" + cont.Email + "' where cod_contato = " + cont.Codcontato + " ; ";

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
                string sql = "select * from tb_contato where cod_contato= " + codigo + ";";

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
                    cont.Codcontato = Convert.ToInt32(objDados["cod_contato"]);
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

        public DataTable pesquisaCodigo(int codigo)
        {
            string sql = "select cod_contato as 'Código', nome as Nome, telefone as Telefone, " +
                "celular as Celular, email as Email from tb_contato where cod_contato = " + codigo + " ; ";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }

        public DataTable pesquisaNome(string nomecontato)
        {
            string sql = "select cod_contato as 'Código', nome as Nome, telefone as Telefone, " +
                "celular as Celular, email as Email from tb_contato where nome like '%" + nomecontato + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }

        public DataTable pesquisaTelefone(string telefone)
        {
            string sql = "select cod_contato as 'Código', nome as Nome, telefone as Telefone, " +
                "celular as Celular, email as Email from tb_contato where nome like '%" + telefone + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }

        public DataTable pesquisaCelular(string celular)
        {
            string sql = "select cod_contato as 'Código', nome as Nome, telefone as Telefone, " +
                "celular as Celular, email as Email from tb_contato where nome like '%" + celular + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }

        public DataTable pesquisaEmail(string email)
        {
            string sql = "select cod_contato as 'Código', nome as Nome, telefone as Telefone, " +
                "celular as Celular, email as Email from tb_contato where nome like '%" + email + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }

        public DataTable PreencherTodos()
        {
            string sql = "select cod_contato as 'Código', nome as Nome, telefone as Telefone, " +
                "celular as Celular, email as Email from tb_contato ; ";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }

        public string Backup(string Caminho)
        {
            string dataAtual = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            string CaminhoBackup = Caminho + "\\backupContatos_" + dataAtual + ".sql";

            try
            {
                MySqlCommand cmd = new MySqlCommand(CaminhoBackup, c.con);
                MySqlBackup mb = new MySqlBackup(cmd);
                c.conectar();
                mb.ExportToFile(CaminhoBackup);
                c.desconectar();
                return ("Backup  do banco de dados realizado com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

    }
}
