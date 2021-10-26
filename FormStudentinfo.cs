﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_last
{
    public partial class FormStudentinfo : Form
    {
        FormStudent form;
        public FormStudentinfo()
        {
            InitializeComponent();
            form = new FormStudent(this);
        }


        public void Display()
        {
            DbStudent.DisplayAndSearch("SELECT ID , Name, Reg, Class, Section FROM student_table", dataGridView);
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
           // FormStudent form = new FormStudent(this);
            form.Clear();
            form.ShowDialog();
        }

        private void FormStudentinfo_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbStudent.DisplayAndSearch("SELECT ID , Name, Reg, Class, Section FROM student_table WHERE Name LIKE'%"+txtSearch.Text +"%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                ///edit
                form.Clear();
                form.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.name = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.reg = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.@class = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.section = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();

                return;
            }
            if(e.ColumnIndex == 1)
            {
                //delect
               if (MessageBox.Show("Are you want to delect?", "information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbStudent.DeleteStudent(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }

            }
            return;
        }
    }
}
