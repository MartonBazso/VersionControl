﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{    
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName;
            button1.Text = Resource1.Add;
            button2.Text = Resource1.File;
            button3.Text = Resource1.Delete;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text
            };
            users.Add(u);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(dialog.FileName);
                    foreach (var user in users)
                    {
                        sw.Write(string.Format("Id: {0}\nName: {1}\n", user.ID, user.FullName));
                    }
                    sw.Close();
                }
            }

            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                users.RemoveAt(listBox1.SelectedIndex);
            }
            
        }
    }
}
