using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD;
using MySqlConnector;

namespace Proyecto
{
    public partial class Form1 : Form
    {
        int cont = 0;
        int i, p = 0;
        int[] codigo = new int[3];
        String[] direccion = new String[3];
        int[] telefono = new int[3];
        String[] correo = new string[3];
        String[] cliente = new String[3];
        int[] rut = new int[3];
       

        private void btnbuscarcli_Click(object sender, EventArgs e)
        {
            grbregistro.Visible = true;

            String cod = txtcliente.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT id, codigo, RUT, nombre, direccion, telefono, correo, jefe_produccion FROM clientes WHERE codigo LIKE '" + cod + "' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtcliente.Text = reader.GetString(1);
                        txtregrut.Text = reader.GetString(2);
                        txtregnombre.Text = reader.GetString(3);
                        txtregdirec.Text = reader.GetString(4);
                        txtregtele.Text = reader.GetString(5);
                        txtregcorreo.Text = reader.GetString(6);
                        txtregjproduc.Text = reader.GetInt32(7).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnregistrarcli_Click(object sender, EventArgs e)
        {
            try
            {
                String cod = txtcliente.Text;
                String nom = txtregnombre.Text;
                int rut1 = int.Parse(txtregrut.Text);
                String dir = txtregdirec.Text;
                int telef = int.Parse(txtregtele.Text);
                String email = txtregcorreo.Text;
                int jproduc = int.Parse(txtregjproduc.Text);
                

                if (cod != "" && nom != "" && rut1 > 0 && dir != "" && telef > 0 && email != "" && jproduc > 0)
                {

                    string sql = "INSERT INTO clientes (codigo, RUT, nombre, direccion, telefono, correo, jefe_produccion) VALUES ('" + cod + "','" + rut1 + "','" + nom + "','" + dir + "','" + telef + "','" + email + "','" + jproduc + "')";

                    MySqlConnection conexionBD = Conexion.conexion();
                    conexionBD.Open();

                    try
                    {
                        MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Registro guardado");

                        txtcliente.Clear();
                        txtregrut.Clear();
                        txtregnombre.Clear();
                        txtregdirec.Clear();
                        txtregtele.Clear();
                        txtregcorreo.Clear();
                        txtregjproduc.Clear();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al guardar: " + ex.Message);
                    }
                    finally
                    {
                        conexionBD.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Datos incorrectos: " + fex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            String cod = txtcliente.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT id, codigo, nombre FROM maquina WHERE codigo LIKE '" + cod + "' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cmbcodigomaq.Text = reader.GetInt32(1).ToString();
                        txtnombremaq.Text = reader.GetString(3);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnmaquina_Click(object sender, EventArgs e)
        {
            
        }

        private void btnbuscarope_Click(object sender, EventArgs e)
        {
            grbregoperario.Visible = true;

            String cod = txtoperario.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT id, codigo, documento, nombre, apellido, edad, telefono FROM operarios WHERE codigo LIKE '" + cod + "' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtoperario.Text = reader.GetString(1);
                        txtopedocu.Text = reader.GetString(2);
                        txtopenom.Text = reader.GetString(3);
                        txtopeape.Text = reader.GetString(4);
                        txtopeedad.Text = reader.GetInt32(5).ToString();
                        txtopetele.Text = reader.GetString(6);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnregoperario_Click(object sender, EventArgs e)
        {                        
            try
            {
                String cod = txtoperario.Text;
                String docu = txtopedocu.Text;
                String nom = txtopenom.Text;
                String ape = txtopeape.Text;
                int edad = int.Parse(txtopeedad.Text);
                String telef = txtopetele.Text;

                if (cod != "" && docu != "" && nom != "" && ape != "" && edad > 0 && telef != "")
                {

                    string sql = "INSERT INTO operarios (codigo, documento, nombre, apellido, edad, telefono) VALUES ('" + cod + "','" + docu + "','" + nom + "','" + ape + "','" + edad + "','" + telef + "')";

                    MySqlConnection conexionBD = Conexion.conexion();
                    conexionBD.Open();

                    try
                    {
                        MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Registro guardado");

                        txtoperario.Clear();
                        txtopedocu.Clear();
                        txtopenom.Clear();
                        txtopeape.Clear();
                        txtopeedad.Clear();
                        txtopetele.Clear();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al guardar: " + ex.Message);
                    }
                    finally
                    {
                        conexionBD.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Datos incorrectos: " + fex.Message);
            }
        }

        private void cmbcodigomaq_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnbuscarjproduc_Click(object sender, EventArgs e)
        {
            grbregjprod.Visible = true;

            String cod = txtjproduc.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT id, codigo, nombre, apellido, correo, telefono, referencia FROM jefe_produccion WHERE codigo LIKE '" + cod + "' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtjproduc.Text = reader.GetString(1);
                        txtjnom.Text = reader.GetString(2);
                        txtjape.Text = reader.GetString(3);
                        txtjcorreo.Text = reader.GetString(4);
                        txtjtele.Text = reader.GetString(5);
                        txtjref.Text = reader.GetInt32(6).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnregjprod_Click(object sender, EventArgs e)
        {
            try
            {
                String cod = txtjproduc.Text;
                String nom = txtjnom.Text;
                String ape = txtjape.Text;
                String correo = txtjcorreo.Text;
                String telef = txtjtele.Text;
                int refe = int.Parse(txtjref.Text);
                

                if (cod != "" && nom != "" && ape != "" && correo != "" && telef != "" && refe > 0)
                {

                    string sql = "INSERT INTO jefe_produccion (codigo, nombre, apellido, correo, telefono, referencia) VALUES ('" + cod + "','" + nom + "','" + ape + "','" + correo + "','" + telef + "','" + refe + "')";

                    MySqlConnection conexionBD = Conexion.conexion();
                    conexionBD.Open();

                    try
                    {
                        MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Registro guardado");

                        txtjproduc.Clear();
                        txtjnom.Clear();
                        txtjape.Clear();
                        txtjcorreo.Clear();
                        txtjtele.Clear();
                        txtjref.Clear();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al guardar: " + ex.Message);
                    }
                    finally
                    {
                        conexionBD.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Datos incorrectos: " + fex.Message);
            }
        }

        private void btnlimpiarcli_Click(object sender, EventArgs e)
        {
            txtcliente.Clear();
            txtregrut.Clear();
            txtregnombre.Clear();
            txtregdirec.Clear();
            txtregcorreo.Clear();
            txtregtele.Clear();
            txtregjproduc.Clear();
            txtcliente.Focus();
        }

        private void btnlimparjprod_Click(object sender, EventArgs e)
        {
            txtjproduc.Clear();
            txtjnom.Clear();
            txtjape.Clear();
            txtjcorreo.Clear();
            txtjtele.Clear();
            txtjref.Clear();
            txtjproduc.Focus();
        }

        private void btnlimpiarope_Click(object sender, EventArgs e)
        {
            txtoperario.Clear();
            txtopedocu.Clear();
            txtopenom.Clear();
            txtopeape.Clear();
            txtopeedad.Clear();
            txtopetele.Clear();
            txtoperario.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grbregref.Visible = true;

            String cod = txtref.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT id, codigo, OP, nombre, valor FROM referencia WHERE codigo LIKE '" + cod + "' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtref.Text = reader.GetString(1);
                        txtrefop.Text = reader.GetString(2);
                        txtrefnom.Text = reader.GetString(3);
                        txtrefvalor.Text = reader.GetInt32(4).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnrefregistrar_Click(object sender, EventArgs e)
        {
            try
            {
                String cod = txtref.Text;
                String op = txtrefop.Text;
                String nom = txtrefnom.Text;
                int valor = int.Parse(txtrefvalor.Text);
                int sam = int.Parse(txtrefsam.Text);
                
                if (cod != "" && op != "" && nom != "" && valor > 0 && sam > 0)
                {

                    string sql = "INSERT INTO referencia (codigo, OP, nombre, valor, SAM) VALUES ('" + cod + "','" + op + "','" + nom + "','" + valor + "','" + sam + "')";

                    MySqlConnection conexionBD = Conexion.conexion();
                    conexionBD.Open();

                    try
                    {
                        MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Registro guardado");

                        txtref.Clear();
                        txtrefop.Clear();
                        txtrefnom.Clear();
                        txtrefvalor.Clear();
                        txtrefsam.Clear();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al guardar: " + ex.Message);
                    }
                    finally
                    {
                        conexionBD.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Datos incorrectos: " + fex.Message);
            }
        }

        private void btnreflimpiar_Click(object sender, EventArgs e)
        {
            txtref.Clear();
            txtrefop.Clear();
            txtrefnom.Clear();
            txtrefvalor.Clear();
            txtrefsam.Clear();
            dtgsam.Visible = false;
            dtgsam.Rows.Clear();
            txtref.Focus();
        }

        private void btnsam_Click(object sender, EventArgs e)
        {
            dtgsam.Visible = true;
            
            String cod = txtref.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT id, codigo, operacion, tiempo, valor_operacion FROM SAM WHERE codigo LIKE '" + cod + "' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int n = dtgsam.Rows.Add();
                        dtgsam.Rows[n].Cells[0].Value = reader.GetInt32(0).ToString();
                        dtgsam.Rows[n].Cells[1].Value = reader.GetString(1);
                        dtgsam.Rows[n].Cells[2].Value = reader.GetString(2);
                        dtgsam.Rows[n].Cells[3].Value = reader.GetTimeSpan(3).ToString();
                        dtgsam.Rows[n].Cells[4].Value = reader.GetInt32(4).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
