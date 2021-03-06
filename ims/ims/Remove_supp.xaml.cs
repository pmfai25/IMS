﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
namespace Inventory_management_system
{
    /// <summary>
    /// Interaction logic for Remove_supp.xaml
    /// </summary>
    public partial class Remove_supp : Window
    {
        public Remove_supp()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Add_remove_supp ars = new Add_remove_supp();
            this.Hide();
            ars.Show();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("ENTER SUPPLIER ID!");
            }
            else
            {
                SqlConnection con5 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename="+GlobalVariable.path+"\\Inv.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

                SqlDataAdapter sda = new SqlDataAdapter("Select * From Supplier where S_id = '"+textBox1.Text+"'", con5);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("NO SUPPLIER FOUND!");
                }

                else
                {
                    SqlCommand cmd5 = new SqlCommand();
                    cmd5.CommandText = " Delete from Supplier_item where S_id = '" + textBox1.Text + "' ";
                    cmd5.CommandType = CommandType.Text;
                    cmd5.Connection = con5;
                    con5.Open();
                    cmd5.ExecuteNonQuery();
                    con5.Close();

                    SqlCommand cmd6 = new SqlCommand();
                    cmd6.CommandText = " Delete from Supplier where S_id = '" + textBox1.Text + "' ";
                    cmd6.CommandType = CommandType.Text;
                    cmd6.Connection = con5;
                    con5.Open();
                    cmd6.ExecuteNonQuery();
                    con5.Close();
                    MessageBox.Show("SUPPLIER REMOVED SUCCESFULLY!");
                }

            }
        }
    }
}
