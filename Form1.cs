using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using MySql.Data.MySqlClient;



namespace WindowsFormsApp_last
{
    public partial class Form1 : Form
    {
        
        // con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=student");
        //int i = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DbStudent.LoginStudent("SELECT * FROM login_user ='" + textBox1.Text + "'and pas ='" + textBox2.Text + "'");


            // Student std = new Student(textBox1.Text.Trim(), textBox2.Text.Trim());
            //DbStudent.LoginStudent(std);



            //con.Open();
            //MySqlCommand cmd = con.CreateCommand();
            // cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT * FROM login_user ='"+textBox1.Text+ "'and pas ='" + textBox2.Text + "'";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            // MySqlDataAdapter da = new  MySqlDataAdapter(cmd);
            //da.Fill(dt);
            // i = Convert.ToInt32(dt.Rows.Count.ToString());
            //if (i == 0)
            // {
            //  label3.Text = "Nooooooo";
            //}
            //else
            //{
            // this.Hide();
            // FormStudentinfo form = new FormStudentinfo();
            //form.Show();

            //}

            DbStudent DB = new DbStudent();
            String user = textBox1.Text;
            String pas = textBox2.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM login_user WHERE user = @user and pas = @pas",DbStudent.GetConnection());
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = user;
            cmd.Parameters.Add("@pas", MySqlDbType.VarChar).Value = pas;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                //MessageBox.Show("yes");
                 this.Hide();
                 FormStudentinfo form = new FormStudentinfo();
                form.Show();
            }
            else
            {
                MessageBox.Show("no");
            }







        }
    }
}
