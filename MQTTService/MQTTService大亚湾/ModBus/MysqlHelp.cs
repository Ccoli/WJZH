using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ModBus
{
    public class MySqlHelp
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }


        private MySqlConnection OpenMySql()
        {
            string ConnectionString = ConfigurationManager.AppSettings["MySqlConnectionString"];
            MySqlConnection conn = new MySqlConnection(ConnectionString); //创建一个新连接
            try
            {
                conn.Open();
            }
            catch (Exception ee)
            {
                return null;
            }

            return conn;
        }

        public bool LinkOracle()
        {
            MySqlConnection conn = OpenMySql();
            bool ret = false;
            if (conn != null)
            {
                ret = true;
            }
            return ret;
        }

        public DataTable select(string sql)
        {
            MySqlConnection conn = OpenMySql();
            if (conn == null)
                return null;

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter oda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                oda.Fill(dt);
            }
            catch (System.Exception ex)
            {
                dt = null;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            return dt;
        }

        public int Execute(string sql)
        {
            MySqlConnection conn = OpenMySql();
            if (conn == null)
                return 0;

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int result = 0;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Dispose();
            }

            return result;
        }

        public int Insert(string sql)
        {
            return Execute(sql);
        }

        public int UpdataBatchCommand(ArrayList commandStringList)
        {
            MySqlConnection conn = OpenMySql();
            if (conn == null)
                return 1;

            MySqlTransaction oracleTrans = conn.BeginTransaction();
            MySqlCommand com = new MySqlCommand();
            com.Connection = conn;
            string tmpStr = "";
            int influenceRowCount = 0;
            try
            {
                foreach (string commandString in commandStringList)
                {
                    tmpStr = commandString;
                    com.CommandText = tmpStr;
                    influenceRowCount += com.ExecuteNonQuery();
                }
                oracleTrans.Commit();
            }
            catch (MySqlException ex)
            {
                oracleTrans.Rollback();
            }
            finally
            {
                com.Dispose();
                oracleTrans.Dispose();
            }
            return influenceRowCount;
        }
    }
}
