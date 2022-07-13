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
    public partial class EditKBForm : Form
    {
        SqlConnection connEdit = new SqlConnection(@"Data Source=SEKOTOS2;Initial Catalog=KnowledgeBase;User ID=sa;Password=Test12345");
        SqlCommand commEdit;
        SqlDataReader readerEdit;

        public EditKBForm()
        {
            InitializeComponent();
        }

        private void EditKBForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSearchKB_Click(object sender, EventArgs e)
        {
            connEdit.Open();
            commEdit = new SqlCommand("Select * From KnowledgeBase Where articleNumber ='" + txtSSearch.Text + "'", connEdit);
            readerEdit = commEdit.ExecuteReader();
            while (readerEdit.Read())
            {
                cbSArticleNo.Text = readerEdit.GetValue(0).ToString();
                txtSArticleName.Text = readerEdit.GetValue(1).ToString();
                txtSHashtags.Text = readerEdit.GetValue(2).ToString();
                cbSTicket.SelectedIndex = cbSTicket.Items.Add(readerEdit.GetValue(3));
                cbSProduct.SelectedIndex = cbSProduct.Items.Add(readerEdit.GetValue(4));
                txtSCreatedBy.Text = readerEdit.GetValue(5).ToString();
                txtSSubmittedBy.Text = readerEdit.GetValue(6).ToString();
                txtSReviewedBy.Text = readerEdit.GetValue(7).ToString();
                txtSReviewedDate.Text = readerEdit.GetValue(8).ToString();
                cbSCountry.SelectedIndex = cbSCountry.Items.Add(readerEdit.GetValue(9));
                txtSJiraTickets.Text = readerEdit.GetValue(10).ToString();
                rtbSDescription.Text = readerEdit.GetValue(11).ToString();
                rtbSSolution.Text = readerEdit.GetValue(12).ToString();
                rtbSTemplate.Text = readerEdit.GetValue(13).ToString();
                rtbRequiredT.Text = readerEdit.GetValue(14).ToString();
            }
            connEdit.Close();
        }
    }
}
