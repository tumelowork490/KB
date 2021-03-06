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
    public partial class AddNewKB : Form
    {
        SqlConnection connNew = new SqlConnection(@"Data Source=SEKOTOS2;Initial Catalog=KnowledgeBase;User ID=sa;Password=Test12345");
        SqlCommand commNew;
        //SqlDataAdapter adaptNew;
        SqlDataReader readerNew;
        byte[] uAttach1, uAttach2, uAttach3;
        string uextAttach1, uextAttach2, uextAttach3;



        public AddNewKB()
        {
            InitializeComponent();

        }

        private void AddNewKB_Load(object sender, EventArgs e)
        {
            //Convert the datetimepicker
            /*dtpNewKB.CustomFormat = "MMMM-dd-yyyy";
            dtpNewKB.Format = DateTimePickerFormat.Custom;*/

            OnCreatedForm();

        }

        private void textArticleNo_TextChanged(object sender, EventArgs e)
        {


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();


        }

        private void btnAttach1_Click(object sender, EventArgs e)
        {


            TtachAll();
        }

        private void btnAttach2_Click(object sender, EventArgs e)
        {
            TtachAll();



        }

        private void btnAttach3_Click(object sender, EventArgs e)
        {
            TtachAll();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            connNew.Open();
            commNew = new SqlCommand("INSERT into KnowledgeBase (articleNumber,articleName,hashTags,ticketType,product,createdDate,submittedBy,country," +
                "jiraTicket,partner,description,solution,template,requiredTroubleshooting,Attachement1,Extension1,Attachement2,Extension2,Attachement3,Extension3)" +
                "Values(@articleNumber, @articleName, @hashTags, @ticketType, @product, @createdDate, @submittedBy, @country, @jiraTicket, @partner, " +
                "@description, @solution, @template, @requiredTroubleshooting, @Attachement1,@Extension1,@Attachement2, @Extension2,@Attachement3, @Extension3)", connNew);

            commNew.Parameters.AddWithValue("@articleNumber", textArticleNo.Text);
            commNew.Parameters.AddWithValue("@articleName", txtArticleName.Text);
            commNew.Parameters.AddWithValue("@hashTags", txtHashtag.Text);
            commNew.Parameters.AddWithValue("@ticketType", cbTicketType.Text);
            commNew.Parameters.AddWithValue("@product", cbProduct.Text);
            commNew.Parameters.AddWithValue("@createdDate", Convert.ToDateTime(txtCreatedDate.Text));
            commNew.Parameters.AddWithValue("@submittedBy", txtSubmittedBy.Text);
            commNew.Parameters.AddWithValue("@country", cbCountry.Text);
            commNew.Parameters.AddWithValue("@jiraTicket", txtJIRA.Text);
            commNew.Parameters.AddWithValue("@partner", cbPartner.Text);
            commNew.Parameters.AddWithValue("@description", rtxtDescription.Text);
            commNew.Parameters.AddWithValue("@solution", rtxtSolution.Text);
            commNew.Parameters.AddWithValue("@template", rtxtTemplate.Text);
            commNew.Parameters.AddWithValue("@requiredTroubleshooting", rtxtRequiredT.Text);
            commNew.Parameters.AddWithValue("@Attachement1", uAttach1);
            commNew.Parameters.AddWithValue("@Extension1", uextAttach1);
            commNew.Parameters.AddWithValue("@Attachement2", uAttach2);
            commNew.Parameters.AddWithValue("@Extension2", uextAttach2);
            commNew.Parameters.AddWithValue("@Attachement3", uAttach3);
            commNew.Parameters.AddWithValue("@Extension3", uextAttach3);
            commNew.ExecuteReader();

            connNew.Close();

            //Call function to clear after submit
            ClearAll();

        }

        void OnCreatedForm()
        {

            txtCreatedDate.Text = DateTime.Now.ToString();
            try
            {
                //Adding ITIL ticket
                connNew.Open();
                commNew = new SqlCommand("Select * From TicketTypes", connNew);
                readerNew = commNew.ExecuteReader();
                while (readerNew.Read())
                {
                    cbTicketType.Items.Add(readerNew.GetValue(0));
                }
                connNew.Close();


                //Adding Products
                connNew.Open();
                commNew = new SqlCommand("Select * From Products", connNew);
                readerNew = commNew.ExecuteReader();
                while (readerNew.Read())
                {
                    cbProduct.Items.Add(readerNew.GetValue(0));
                }
                connNew.Close();

                //Adding Countries
                connNew.Open();
                commNew = new SqlCommand("Select * From Countries", connNew);
                readerNew = commNew.ExecuteReader();
                while (readerNew.Read())
                {
                    cbCountry.Items.Add(readerNew.GetValue(1));
                }
                connNew.Close();

                //Adding Partners
                connNew.Open();
                commNew = new SqlCommand("Select * From Partners", connNew);
                readerNew = commNew.ExecuteReader();
                while (readerNew.Read())
                {
                    cbPartner.Items.Add(readerNew.GetValue(1));
                }
                connNew.Close();


                //Add new KB number

                int newDBKB = 0;
                connNew.Open();
                commNew = new SqlCommand("Select articleNumber From KnowledgeBase", connNew);
                readerNew = commNew.ExecuteReader();
                while (readerNew.Read())
                {
                    newDBKB++;
                }
                connNew.Close();
                switch ((newDBKB.ToString()).Length)
                {
                    case 1:
                        textArticleNo.Text = "KB000" + (newDBKB + 1).ToString();
                        break;
                    case 2:
                        textArticleNo.Text = "KB00" + (newDBKB + 1).ToString();
                        break;
                    case 3:
                        textArticleNo.Text = "KB0" + (newDBKB + 1).ToString();
                        break;
                    case 4:
                        textArticleNo.Text = "KB" + (newDBKB + 1).ToString();
                        break;
                }

            }
            catch (Exception ex)
            {
                //
            }
        }

        public void ClearAll()
        {
            try
            {
                //Clear all ComboBox.Items.Clear();
                //ComboBox.ResetText();
                cbCountry.ResetText();
                cbPartner.ResetText();
                cbProduct.ResetText();
                cbTicketType.ResetText();

                txtAttach1.Clear();
                txtAttach2.Clear();
                txtAttach3.Clear();
                rtxtDescription.Clear();
                rtxtRequiredT.Clear();
                rtxtSolution.Clear();
                rtxtTemplate.Clear();
                txtHashtag.Clear();
                txtJIRA.Clear();
                //txtReviewedBy.Clear();
                txtSubmittedBy.Clear();
                txtArticleName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cleared");
            }
        }

        public void TtachAll()
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"c:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "Word Documents|*.doc|Excel Worksheets|*.xls;*.xlsx|" +
                    "Image Files|*.jpg;*.png" +
                    "|Text Files|*.txt" +
                    "|Archives Files|*.zip;*.rar" +
                    "|All Files|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtAttach1.Text = openFileDialog1.FileName;
            }

            if (txtAttach1.Text != "")
            {

                FileInfo attach1 = new FileInfo(txtAttach1.Text);
                uextAttach1 = attach1.Extension;
                uAttach1 = File.ReadAllBytes(txtAttach1.Text);
                MessageBox.Show(uextAttach1 + "" + uAttach1.ToString());
            }

            // }
            // catch (Exception ex)
            // {
            //
            // }
        }


    }
}
