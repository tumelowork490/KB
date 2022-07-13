using System;
using System.Data;
using System.Windows.Forms;
using System.Text;
using System.Data.SqlClient;
using System.Linq;

    
namespace KB
{
    public partial class HomeForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=SEKOTOS2;Initial Catalog=KnowledgeBase;User ID=sa;Password=Test12345");
        SqlDataAdapter adapt;
        public HomeForm()
        {
            InitializeComponent();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            try
            {
                MaximizeBox = false;

                conn.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("Select [articleNumber],[product],[articleName],[ticketType] From KnowledgeBase", conn);
                adapt.Fill(dt);
                dgvListData.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                //
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                bool newIsopen = false;

                foreach (Form newForm in Application.OpenForms)
                {
                    if (newForm.Name == "AddNewKB")
                    {
                        newIsopen = true;
                        newForm.BringToFront();
                        break;
                    }
                }
                if (newIsopen == false)
                {
                    AddNewKB addNewKB = new AddNewKB() { TopLevel = false, TopMost = true };
                    addNewKB.FormBorderStyle = FormBorderStyle.Sizable;
                    addNewKB.StartPosition = FormStartPosition.CenterParent;
                    addNewKB.MaximizeBox = false;
                    addNewKB.MinimizeBox = false;
                    this.pContainer.Controls.Add(addNewKB);
                    addNewKB.BringToFront();
                    addNewKB.Show();
                }
            }
            catch (Exception ex)
            {
                //
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                bool editIsopen = false;

                foreach (Form editForm in Application.OpenForms)
                {
                    if (editForm.Name == "EditKBForm")
                    {
                        editIsopen = true;
                        editForm.BringToFront();
                        break;
                    }
                }
                if (editIsopen == false)
                {
                    EditKBForm editKB = new EditKBForm() { TopLevel = false, TopMost = true };
                    editKB.FormBorderStyle = FormBorderStyle.Sizable;
                    this.pContainer.Controls.Add(editKB);
                    editKB.MaximizeBox = false;
                    editKB.MinimizeBox = false;
                    editKB.BringToFront();
                    editKB.Show();
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        private void pContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdvSearch_Click(object sender, EventArgs e)
        {
            try
            {
                bool advSearch = false;

                foreach (Form advSearchForm in Application.OpenForms)
                {
                    if (advSearchForm.Name == "SearchKB")
                    {
                        advSearch = true;
                        advSearchForm.BringToFront();
                        break;
                    }
                }
                if (advSearch == false)
                {

                    SearchKB advSearchKB = new SearchKB() { TopLevel = false, TopMost = true };
                    advSearchKB.FormBorderStyle = FormBorderStyle.Sizable;
                    this.pContainer.Controls.Add(advSearchKB);
                    advSearchKB.MaximizeBox = false;
                    advSearchKB.MinimizeBox = false;
                    advSearchKB.BringToFront();
                    advSearchKB.Show();
                }
            }
            catch(Exception ex)
            {
                //
            }
        }
    }
}