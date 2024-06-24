using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Quản_lí_thông_tin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAB1-MAY27\\MISASME2022;Initial Catalog=QuanLyThongTin;Integrated Security=True;Encrypt=False");
        private void opencon()
        {
            if (con.State == ConnectionState.Closed) 
            { 
            con.Open();
            }
            
        }
        private void closecon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private Boolean exe (string cmd)
        {
            opencon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch { 
            
                check = false;
                throw;
            
            }
            closecon();
            return check;
        }
        private DataTable red(string cmd)
        {
            opencon();
            DataTable dt=new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd,con);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch(Exception)
            {
                 dt=null;
                 throw;
                
            }
            closecon();
            return dt;
        }
        private void  load()
        {
            DataTable dt =  red( "select *  from quanlythongtin");
            if (dt != null)
            {
                dataGridView1.DataSource= dt;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}

