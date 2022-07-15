using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KB
{
    public partial class SearchKB : Form
    {
        string conString;
        SqlConnection connSearchKB = new SqlConnection(@"Data Source=SEKOTOS2;Initial Catalog=KnowledgeBase;User ID=sa;Password=Test12345");
        SqlDataAdapter adaptSearchKB;

        public SearchKB()
        {
            InitializeComponent();
        }

        private void SearchKB_Load(object sender, EventArgs e)
        {

            connSearchKB.Open();
            DataTable dt = new DataTable();
            adaptSearchKB = new SqlDataAdapter("Select * From KnowledgeBase", connSearchKB);
            adaptSearchKB.Fill(dt);
            dgvListData.DataSource = dt;
            connSearchKB.Close();
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            txtSearchBar.Text = txtSearchBar.Text.Trim();
            //search like google online
            connSearchKB.Open();
            adaptSearchKB = new SqlDataAdapter("Select * from KnowledgeBase where articleName like '" + txtSearchBar.Text + "%'", connSearchKB);
            DataTable dt = new DataTable();
            adaptSearchKB.Fill(dt);
            dgvListData.DataSource = dt;
            connSearchKB.Close();

            dgvListData.Refresh();
            dgvListData.Update();
        }
    }
}
