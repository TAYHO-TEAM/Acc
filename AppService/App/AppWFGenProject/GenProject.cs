using AppWFGenProject.Entities;
using AppWFGenProject.Extensions;
using AppWFGenProject.FrameWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;
using Services.Common.Options;
using System;
using System.Windows.Forms;

namespace AppWFGenProject
{
    public partial class GenProject : Form
    {

        private readonly Common _common;
        public GenProject( IOptionsSnapshot<Common> commonAccessor)
        {
            _common = commonAccessor.Value;
            InitializeComponent();
            Environment.GetEnvironmentVariable("Content");
            txtPass.PasswordChar = '*';
            txtServer.Text = "db.tayho.net.vn";
            txtUser.Text = "trienpc";
            txtDB.Text = "QuanLyDuAn";
            btnGen.Enabled = false;
        }
        //public GenProject(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    InitializeComponent();
        //    Environment.GetEnvironmentVariable("Content");
        //    txtPass.PasswordChar = '*';
        //    txtServer.Text = "db.tayho.net.vn";
        //    txtUser.Text = "trienpc";
        //    txtDB.Text = "QuanLyDuAn";
        //    btnGen.Enabled = false;
        //}
        private void GenProject_Load(object sender, EventArgs e)
        {
            clbFunction.Items.Add("CMD", false);
            clbFunction.Items.Add("READ", false);
            clbFunction.Items.Add("HTML", false);
        }

        private void btnTestConnec_Click(object sender, EventArgs e)
        {
            Connection newConn = new Connection();
            if (newConn.ConnectTest(txtServer.Text, txtUser.Text, txtPass.Text, txtDB.Text))
            {
                MessageBox.Show("Kết nối thành công!", "Thông tin kết nối", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Kết nối không thành công!", "Lỗi kết nối", MessageBoxButtons.OK);
            }

        }

        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            Connection newConn = new Connection();
            var listTB = newConn.GetAllTable(txtServer.Text, txtUser.Text, txtPass.Text, txtDB.Text);
            foreach (string TB in listTB)
            {
                chlTable.Items.Add(TB, false);
            }
        }

        private void btnGen_Click(object sender, EventArgs e)
        {


            int typeCreate = cbkOverWrite.Checked ? 1 : cbkCreateNew.Checked ? 2 : cbkBackUp.Checked ? 3 : -1;
            if (typeCreate <= 0)
            {
                MessageBox.Show("Bạn chưa chọn cách tạo file. Vui lòng chọn cách tạo file", "Thông báo!");
            }
            else
            {
                for (int i = 0; i < chlTable.Items.Count; i++)
                {
                    GenOB genOB = new GenOB();
                    GenCode genCode = new GenCode();

                    //ReadTemplate readTemplate = new ReadTemplate();

                    // Set rootDir
                    genOB.rootDir = txtDir.Text == "" ? _common.DirectDefault.ToString() : txtDir.Text;
                    // Set common
                    genOB.common = _common.CmdEF.ToString();
                    genOB.db = _common.DB.ToString();
                    genOB.version = _common.Version.ToString();

                    if (chlTable.GetItemChecked(i))
                    {
                        genOB.Entity = (string)chlTable.Items[i];
                        //var function = clbFunction.CheckedItems.Contains("READ") ;
                        // sert _entity
                        if (genOB.Entity != string.Empty && char.IsUpper(genOB.Entity[0]))
                        {
                            genOB._entity = "_" + (char.ToLower(genOB.Entity[0]) + genOB.Entity.Substring(1));
                        }
                        // sert entity
                        if (genOB.Entity != string.Empty && char.IsUpper(genOB.Entity[0]))
                        {
                            genOB.entity = (char.ToLower(genOB.Entity[0]) + genOB.Entity.Substring(1));
                        }
                        if (clbFunction.CheckedItems.Contains("CMD"))
                        {
                            // Set nameproject
                            genOB.nameproject = (txtNameProject.Text == "" ? "Test" : txtNameProject.Text) + ".CMD";
                            genCode.CreateGenOBCMD(txtServer.Text, txtUser.Text, txtPass.Text, txtDB.Text, (string)chlTable.Items[i], genOB, typeCreate);
                        }
                        if (clbFunction.CheckedItems.Contains("READ"))
                        {
                            // Set nameproject
                            genOB.nameproject = (txtNameProject.Text == "" ? "Test" : txtNameProject.Text) + ".READ";
                            genCode.CreateGenOBRed(txtServer.Text, txtUser.Text, txtPass.Text, txtDB.Text, (string)chlTable.Items[i], genOB, typeCreate);
                        }
                        if (clbFunction.CheckedItems.Contains("HTML"))
                        {

                        }

                    }
                }
            }

            //FileHelper fileHelper = new FileHelper();
            //fileHelper.ChangeTxtToCS(@"C:\Users\poka\Desktop\testChange.txt");
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtDir.Text = fbd.SelectedPath;
                    btnGen.Enabled = true;
                }
            }
        }

        private void cbkOverWrite_CheckedChanged(object sender, EventArgs e)
        {
            cbkBackUp.Checked = false;
            cbkCreateNew.Checked = false;
        }

        private void cbkCreateNew_CheckedChanged(object sender, EventArgs e)
        {
            cbkBackUp.Checked = false;
            cbkOverWrite.Checked = false;
        }

        private void cbkBackUp_CheckedChanged(object sender, EventArgs e)
        {
            cbkCreateNew.Checked = false;
            cbkOverWrite.Checked = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void AutoSendMail_Enter(object sender, EventArgs e)
        {

        }


        private void sub11GenNetApi_Click(object sender, EventArgs e)
        {
            gbGenCode.Visible = true;
            gbAutoSendMail.Visible = false;
        }

     
        private void sub12SendMail_Click(object sender, EventArgs e)
        {
            gbGenCode.Visible = false;
            gbAutoSendMail.Visible = true;
        }
    }
}
