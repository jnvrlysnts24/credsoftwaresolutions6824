﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    public partial class frmVendor : Form
    {
        frmVendorList f;
        SqlConnection cn;
        SqlCommand cm;
        DBConnection db = new DBConnection();

        public frmVendor(frmVendorList f)
        {
            InitializeComponent();
            cn = new SqlConnection();
            cn.ConnectionString = db.MyConnection();
            this.f = f;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               if (MessageBox.Show("SAVE THE RECORD? CLICK YES TO CONFIRM.","CONFIRM",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tblVendor(vendor, address, contactperson, telephone, email, fax) values (@vendor, @address, @contactperson, @telephone, @email, @fax)", cn);
                    cm.Parameters.AddWithValue("@vendor", txtVendor.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@contactperson", txtPerson.Text);
                    cm.Parameters.AddWithValue("@telephone", txtTel.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@fax", txtfax.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("RECORD HAS BEEN SUCCESSFULLY SAVED","SAVE RECORD",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.LoadRecords();
                }
            }catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void Clear()
        {
            txtAddress.Clear();
            txtEmail.Clear();
            txtfax.Clear();
            txtPerson.Clear();
            txtTel.Clear();
            txtVendor.Clear();
            txtVendor.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void frmVendor_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("UPDATE THIS RECORD? CLICK YES TO CONFIRM.", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE tblVendor set vendor=@vendor, address=@address, contactperson=@contactperson, telephone=@telephone, email=@email, fax=@fax where id = @id", cn);
                    cm.Parameters.AddWithValue("@vendor", txtVendor.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@contactperson", txtPerson.Text);
                    cm.Parameters.AddWithValue("@telephone", txtTel.Text);
                    cm.Parameters.AddWithValue("@email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@fax", txtfax.Text);
                    cm.Parameters.AddWithValue("@id", lblID.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("RECORD HAS BEEN SUCCESSFULLY UPDATED", "UPDATE RECORD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    f.LoadRecords();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

