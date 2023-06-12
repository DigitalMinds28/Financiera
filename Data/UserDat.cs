using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Model;
using MySql.Data.MySqlClient;

namespace Data
{
    public class UserDat
    {
        Persistence objPer = new Persistence();
        // procedimiento para mostar
        public DataSet showUser()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objdata = new DataSet();
            MySqlCommand objSeletCmd = new MySqlCommand();
            objSeletCmd.Connection = objPer.openConection();
            objSeletCmd.CommandText = "spSelecionarUsuarios";
            objSeletCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSeletCmd;
            objAdapter.Fill(objdata);
            objPer.closeConection();
            return objdata;
        }
        // procedimiento para guardar
        public bool saveUser(string _email, string _password, string _salt, string _state)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spAgregarUsuario";
            objSelectCmd.CommandType = CommandType.StoredProcedure; //nombre del procedimiento almacenado
            objSelectCmd.Parameters.Add("p_email", MySqlDbType.VarString).Value = _email;
            objSelectCmd.Parameters.Add("p_password", MySqlDbType.VarString).Value = _password;
            objSelectCmd.Parameters.Add("p_salt", MySqlDbType.VarString).Value = _salt;
            objSelectCmd.Parameters.Add("p_state", MySqlDbType.VarString).Value = _state;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.ToString());
            }
            objPer.closeConection();
            return executed;
        }
        // procedimiento para actualizar
        public bool updateUser(int _idUser, string _email, string _password, string _salt, string _state)
        {
            bool executed = false;
            int row;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spActualizarUsuario"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _idUser;
            objSelectCmd.Parameters.Add("p_email", MySqlDbType.VarString).Value = _email;
            objSelectCmd.Parameters.Add("p_password", MySqlDbType.VarString).Value = _password;
            objSelectCmd.Parameters.Add("p_salt", MySqlDbType.VarString).Value = _salt;
            objSelectCmd.Parameters.Add("p_state", MySqlDbType.VarString).Value = _state;


            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.ToString());
            }
            objPer.closeConection();
            return executed;
        }

        //Metodo para mostrar el Usuarios por correo
        public User showUsersMail(string _email)
        {
            User objUser = null;
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConection();
            objSelectCmd.CommandText = "spSelecionarPorCorreo";
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objSelectCmd.Parameters.Add("p_email", MySqlDbType.VarString).Value = _email;
            MySqlDataReader reader = objSelectCmd.ExecuteReader();
            if (!reader.HasRows)
            {
                return objUser;
            }
            else
            {
                while (reader.Read())
                {
                    objUser = new User(reader["usu_correo"].ToString(),
                    reader["usu_contrasena"].ToString(), reader["usu_salt"].ToString(),
                    reader["usu_estado"].ToString());
                }
            }
            objPer.closeConection();
            return objUser;
        }


    }
}