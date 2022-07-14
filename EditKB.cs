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
        SqlDataAdapter adaptEditSearch;

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
                cbSPartner.SelectedIndex = cbSPartner.Items.Add(readerEdit.GetValue(11));
                rtbSDescription.Text = readerEdit.GetValue(12).ToString();
                rtbSSolution.Text = readerEdit.GetValue(13).ToString();
                rtbSTemplate.Text = readerEdit.GetValue(14).ToString();
                rtbRequiredT.Text = readerEdit.GetValue(15).ToString();
                txtEAttachemet1.Text = readerEdit.GetValue(16).ToString();
                txtEAttachemet2.Text = readerEdit.GetValue(18).ToString();
                txtEAttachemet3.Text = readerEdit.GetValue(20).ToString();

            }
            connEdit.Close();
        }

        private void btnSBrowse1_Click(object sender, EventArgs e)
        {

        }

        private void btnDownloadDocs_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    connEdit.Open();
                    commEdit = new SqlCommand("Select * From KnowledgeBase Where articleNumber ='" + txtSSearch.Text + "'", connEdit);
                    readerEdit = commEdit.ExecuteReader();
                    while (readerEdit.Read())
                    {
                        byte[] bytes1 = (byte[])readerEdit["Attachement1"];
                        string dAttach1 = readerEdit["articleNumber"].ToString();
                        string path1 = Path.Combine(folderBrowserDialog.SelectedPath, dAttach1 + "1" + readerEdit["Extension1"].ToString());
                        File.WriteAllBytes(path1, bytes1);
                        txtEAttachemet1.Text = path1.ToString();

                        byte[] bytes2 = (byte[])readerEdit["Attachement2"];
                        string dAttach2 = readerEdit["articleNumber"].ToString();
                        string path2 = Path.Combine(folderBrowserDialog.SelectedPath, dAttach2 + "2" + readerEdit["Extension2"].ToString());
                        File.WriteAllBytes(path2, bytes2);
                        txtEAttachemet2.Text = path2.ToString();

                        byte[] bytes3 = (byte[])readerEdit["Attachement3"];
                        string dAttach3 = readerEdit["articleNumber"].ToString();
                        string path3 = Path.Combine(folderBrowserDialog.SelectedPath, dAttach3 + "3" + readerEdit["Extension3"].ToString());
                        File.WriteAllBytes(path3, bytes3);
                        txtEAttachemet3.Text = path3.ToString();
                        /*
                    commNew.Parameters.AddWithValue("@Attachement1", uAttach1);
                    commNew.Parameters.AddWithValue("@Extension1", uextAttach1);
                    commNew.Parameters.AddWithValue("@Attachement2", uAttach2);
                    commNew.Parameters.AddWithValue("@Extension2", uextAttach2);
                    commNew.Parameters.AddWithValue("@Attachement3", uAttach3);
                    commNew.Parameters.AddWithValue("@Extension3", uextAttach3);
                         */

                    }
                    connEdit.Close();

                }
            }


        }
    }
}
