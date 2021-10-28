﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp_last
{
    class DbStudent
    {
        public static MySqlConnection GetConnection() 
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=student";
            MySqlConnection con = new MySqlConnection(sql);

            try
            {
                con.Open();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("MySql Connection! \n"+ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            return con;
        }

        public static void AddStudent(Student std)
        {
            string sql = "INSERT INTO student_table VALUES (NULL,@StudentName,@StudentReg,@StudentClass,@StudentSection,NULL)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StudentReg", MySqlDbType.VarChar).Value = std.Reg;
            cmd.Parameters.Add("@StudentClass", MySqlDbType.VarChar).Value = std.Class;
            cmd.Parameters.Add("@StudentSection", MySqlDbType.VarChar).Value = std.Section;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Add Success." , "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Student not insert" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();

        }

        public static void UpdateStudent(Student std, string id)
        {
            string sql = "UPDATE student_table SET Name = @StudentName, Reg = @StudentReg, Class = @StudentClass, Section = @StudentSection WHERE ID = @StudentID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentID", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@StudentName", MySqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StudentReg", MySqlDbType.VarChar).Value = std.Reg;
            cmd.Parameters.Add("@StudentClass", MySqlDbType.VarChar).Value = std.Class;
            cmd.Parameters.Add("@StudentSection", MySqlDbType.VarChar).Value = std.Section;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Success.", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Student not Update" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();

        }
        public static void DeleteStudent(string id)
        {
            string sql = "DELETE FROM student_table WHERE ID = @StudentID";

            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentID", MySqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Success.", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Student not Delete" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();

        }
        public static void DisplayAndSearch(string query ,DataGridView dgv) 
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();

        }

        
    }

}
