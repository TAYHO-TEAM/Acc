using AppWFGenProject.Commons;
using AppWFGenProject.Entities;
using AppWFGenProject.Extensions;
using AppWFGenProject.FrameWork;
using AppWFGenProject.Properties;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;
using Services.Common.Options;
using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Windows.Forms;

namespace AppWFGenProject
{
    public partial class GenProject : Form
    {
        protected static PrincipalContext _principalContext = null;
        protected readonly Common _common;
        protected readonly LDAPConfig _lDAPConfig;
        /// <summary>
        /// Load Form
        /// </summary>
        /// <param name="commonAccessor"></param>
        /// <param name="lDAPConfig"></param>
        public GenProject(IOptionsSnapshot<Common> commonAccessor, IOptionsSnapshot<LDAPConfig> lDAPConfig)
        {
            _common = commonAccessor.Value;
            _lDAPConfig = lDAPConfig.Value;
            InitializeComponent();
            Environment.GetEnvironmentVariable("Content");
            SwitchGroup("");
            SetToolTip();
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
        #region menuToolTip
        private void SetToolTip()
        {
            ttpApp.SetToolTip(btnLDAPClear,"Xoá tìm kiếm");
            ttpApp.SetToolTip(btnLoginLDAP, "Đăng nhập LDAP");
            ttpApp.SetToolTip(btnCreateLDAP, "Tạo tài khoản mới");
            ttpApp.SetToolTip(btnLDAPSearch, "Tìm kiếm");

        }
        #endregion menuToolTip
        /// <summary>
        /// Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region menuToolBar
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void sub11GenNetApi_Click(object sender, EventArgs e)
        {
            SwitchGroup(nameof(gbGenCode));
        }
        private void sub12SendMail_Click(object sender, EventArgs e)
        {
            SwitchGroup(nameof(gbAutoSendMail));
        }
        private void sub13LDAP_Click(object sender, EventArgs e)
        {
            SwitchGroup(nameof(gbLDAP));
        }
        #region menuToolBar function
        private void SwitchGroup(string nameGroup)
        {
            gbGenCode.Visible = false;
            gbAutoSendMail.Visible = false;
            gbLDAP.Visible = false;
            gbGenCode.Visible = (nameGroup == nameof(gbGenCode) ? true : false);
            gbAutoSendMail.Visible = (nameGroup == nameof(gbAutoSendMail) ? true : false);
            gbLDAP.Visible = (nameGroup == nameof(gbLDAP) ? true : false);
            if (nameGroup == nameof(gbGenCode))
            {
                loadGBGenCode();
            }
            else if (nameGroup == nameof(gbAutoSendMail))
            {
                LoadSendMailConfig();
            }
            else if (nameGroup == nameof(gbLDAP))
            {
                loadGBLDAP();
            }
        }
        #endregion menuTooolBar function
        #endregion menuTooolBar
        /// <summary>
        /// Group GenCode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Group GenCode
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
                    genOB.common = _common.CmdEF.ToString();//"Services.Common.APIs.Cmd.EF";//_common.CmdEF.ToString();
                    genOB.db = _common.DB.ToString(); //"QuanLyDuAn";//_common.DB.ToString();
                    genOB.version = _common.Version.ToString(); //"QuanLyDuAn";//_common.Version.ToString();

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
                            genCode.CreateGenOBRead(txtServer.Text, txtUser.Text, txtPass.Text, txtDB.Text, (string)chlTable.Items[i], genOB, typeCreate);
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
        #region Group GenCode Function
        private void loadGBGenCode()
        {
            txtPass.PasswordChar = '*';
            txtServer.Text = "db.tayho.net.vn";
            txtUser.Text = "trienpc";
            txtDB.Text = "QuanLyDuAn";
            btnGen.Enabled = false;
        }
        private void GenProject_Load(object sender, EventArgs e)
        {
            clbFunction.Items.Add("CMD", false);
            clbFunction.Items.Add("READ", false);
            clbFunction.Items.Add("HTML", false);
        }
        #endregion Group GenCode Function
        #endregion Group GenCode
        /// <summary>
        /// Group SendMailAuto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Group SendMailAuto
        private void AutoSendMail_Enter(object sender, EventArgs e)
        {

        }

        #region Group SendMailAuto Function
        private void LoadSendMailConfig()
        {

        }
        #endregion Group SendMailAuto Function
        #endregion Group SendMailAuto

        /// <summary>
        /// Group LDAP 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Group LDAP 
        private void btnLoginLDAP_Click(object sender, EventArgs e)
        {
            LoginLDAP loginLDAP = new LoginLDAP();
            loginLDAP.UserName = txtLDAPUser.Text;
            loginLDAP.PassWord = txtLDAPPass.Text;
            if (string.IsNullOrEmpty(loginLDAP.UserName) || string.IsNullOrEmpty(loginLDAP.PassWord))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo!");
            }
            else
            {
                try
                {
                    SetPrincipalContext();
                    if (!_principalContext.ValidateCredentials(loginLDAP.UserName, loginLDAP.PassWord))
                    {
                        MessageBox.Show("Lỗi Đăng nhập!", "Thông báo!");
                    }
                    else
                    {
                        EnableInputCreLDAP(true);
                        LoadTreeViewObjCate(loginLDAP, "*");
                    }
                }
                catch (DirectoryServicesCOMException cex)
                {
                    MessageBox.Show("Lỗi Đăng nhập!" + cex.ExtendedErrorMessage.ToString(), "Thông báo!");
                }
            }
        }
        private void btnCreateLDAP_Click(object sender, EventArgs e)
        {
            LDAPHelper lDAPHelper = new LDAPHelper(_principalContext);
            if (_principalContext != null)
            {
                if (LDAPHelper.CreateUser(GetInputCreLDAP()))
                {
                    ClearInputCreLDAP();
                }
            }
            else
            {
                MessageBox.Show("Lỗi Đăng nhập. Không tồn tại phiên đăng nhập LDAP vui lòng đăng nhập trước khi tạo tài khoản!", "Thông báo!");
            }
        }
        private void trvLDAPObjCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetPrincipalContext();
            if (tabLDAP.SelectedIndex == 0)
            {
                txtLDAPObjCategory.Text = "";
                txtLDAPObjCategory.Text = e.Node.Text.Substring(e.Node.Text.IndexOf('(') + 1, e.Node.Text.IndexOf(')') - e.Node.Text.IndexOf('(') - 1);
            }
            //txtLDAPObjCategory.Text = e.Node.Text.Substring(0,e.Node.Text.IndexOf('('));
        }
        private void txtLDAPPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLoginLDAP_Click(sender, e);
            }
        }
        private void btnLDAPSearch_Click(object sender, EventArgs e)
        {
            LoadTreeViewObjCate();
        }
        private void btnLDAPClear_Click(object sender, EventArgs e)
        {
            txtLDAPFindUser.Text = "";
            LoadTreeViewObjCate();
        }
        #region Grouyp LDAP function
        private void loadGBLDAP()
        {
            txtLDAPUser.Focus();
            txtLDAPUser.Enabled = true;
            txtLDAPPass.Enabled = true;
            EnableInputCreLDAP(_principalContext == null ? false : true);
        }
        private void EnableInputCreLDAP(bool isTrue)
        {
            txtCreLDAPUser.Enabled = isTrue;
            txtCreLDAPPass.Enabled = isTrue;
            txtLDAPFirstName.Enabled = isTrue;
            txtLDAPLastName.Enabled = isTrue;
            txtLDAPLastName.Enabled = isTrue;
            txtLDAPObjCategory.Enabled = isTrue;
            txtLDAPObjCategory.ReadOnly = true;
            btnCreateLDAP.Enabled = isTrue;
            if (isTrue)
            {
                //LDAPHelper lDAPHelper = new LDAPHelper(_principalContext);
                //foreach (var group in lDAPHelper.GetAllUser())
                //{
                //    cbxObjCategory.Items.Add(group.DistinguishedName);
                //}
            }
        }
        private void ClearInputCreLDAP()
        {
            txtCreLDAPUser.Text = "";
            txtCreLDAPPass.Text = "";
            txtLDAPFirstName.Text = "";
            txtLDAPLastName.Text = "";
            txtLDAPLastName.Text = "";
            txtLDAPObjCategory.Text = "";
        }
        private UserAccount GetInputCreLDAP()
        {
            UserAccount _userAccount = new UserAccount();
            _userAccount.CommonName = txtCreLDAPUser.Text.Trim();
            _userAccount.PassWord = txtCreLDAPPass.Text.Trim();
            _userAccount.FirstName = txtLDAPFirstName.Text.Trim();
            _userAccount.LastName = txtLDAPLastName.Text.Trim();
            _userAccount.ObjCategory = txtLDAPObjCategory.Text.Trim();
            return _userAccount;
        }
        private void LoadTreeViewObjCate()
        {
            LoginLDAP loginLDAP = new LoginLDAP();
            loginLDAP.UserName = txtLDAPUser.Text;
            loginLDAP.PassWord = txtLDAPPass.Text;
            LDAPHelper lDAPHelper = new LDAPHelper(_principalContext);
            LoadTreeViewObjCate(loginLDAP, string.IsNullOrEmpty(txtLDAPFindUser.Text) ? "*" : txtLDAPFindUser.Text);
        }
        private void LoadTreeViewObjCate(LoginLDAP loginLDAP, string userName = "*")
        {
            trvLDAPObjCategory.Nodes.Clear();

            userName = (string.IsNullOrEmpty(userName) || userName == "*") ? "*" : "*" + userName + "*";
            DirectoryEntry ADentry = new DirectoryEntry("LDAP://" + _lDAPConfig.DomainIP + "/DC=tayho,DC=vn", loginLDAP.UserName, loginLDAP.PassWord, AuthenticationTypes.Secure);
            DirectorySearcher Searcher = new DirectorySearcher(ADentry);

            Searcher.Filter = string.Format("(&(objectClass=*)(|(cn={0})(name={0})))", userName);  // Search all.
            ImageList myImageList = new ImageList();
            myImageList.Images.Add(Resources.icons8_computer_16);
            myImageList.Images.Add(Resources.icons8_dns_16);
            myImageList.Images.Add(Resources.icons8_user_account_16);
            myImageList.Images.Add(Resources.icons8_opened_folder_16);
            myImageList.Images.Add(Resources.icons8_user_16);
            myImageList.Images.Add(Resources.icons8_checked_16);

            trvLDAPObjCategory.ImageList = myImageList;
            
            if (userName != "*")
                foreach (SearchResult i in Searcher.FindAll())
                {
                    trvLDAPObjCategory.Nodes.Add(GetChildNode(i.GetDirectoryEntry()));
                }
            else
                // The first item in the results is always the domain. Therefore, we just get that and retrieve its children.
                foreach (DirectoryEntry entry in Searcher.FindOne().GetDirectoryEntry().Children)
                {
                    if (ShouldAddNode(entry.SchemaClassName))
                        trvLDAPObjCategory.Nodes.Add(GetChildNode(entry));
                }
        }
        private TreeNode GetChildNode(DirectoryEntry entry)
        {
            TreeNode node = new TreeNode(entry.Name.Substring(entry.Name.IndexOf('=') + 1) + "(" + entry.Path.Substring(entry.Path.LastIndexOf('/') + 1, entry.Path.Length - entry.Path.LastIndexOf('/') - 1) + ")");
            node.ImageIndex = AddIconNode(entry.SchemaClassName);
            node.SelectedImageIndex = 5;
            foreach (DirectoryEntry childEntry in entry.Children)
            {
                if (ShouldAddNode(childEntry.SchemaClassName))
                    node.Nodes.Add(GetChildNode(childEntry));
            }
            return node;
        }
        private bool ShouldAddNode(string nodeName)
        {
            //if (note == "organizationalUnit" || note == "group" || note == "computer" || note == "user" || note == "contact")
            if (nodeName == "user")
                return true;
            else
                return true;
        }
        private int AddIconNode(string nodeName)
        {
            if (nodeName == "computer")
                return 0;
            else if (nodeName == "domain")
                return 1;
            else if (nodeName == "group" || nodeName == "organizationalUnit")
                return 2;
            else if (nodeName == "user")
                return 4;
            else
                return 3;
        }
        private void SetPrincipalContext()
        {
            LoginLDAP loginLDAP = new LoginLDAP();
            loginLDAP.UserName = txtLDAPUser.Text;
            loginLDAP.PassWord = txtLDAPPass.Text;
            loginLDAP.ObjCategory = txtLDAPObjCategory.Text == null ? "" : txtLDAPObjCategory.Text;
            try
            {
                if (string.IsNullOrEmpty(loginLDAP.ObjCategory))
                    _principalContext = new PrincipalContext(ContextType.Domain, _lDAPConfig.DomainIP, loginLDAP.UserName, loginLDAP.PassWord);
                else
                    _principalContext = new PrincipalContext(ContextType.Domain, _lDAPConfig.DomainIP, loginLDAP.ObjCategory, loginLDAP.UserName, loginLDAP.PassWord);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn không có quyền thao tác trong nhóm này. Vui lòng chọn lại nhóm khác.", "Thông báo!");
            }
        }



        #endregion Grouyp LDAP function

        #endregion Grouyp LDAP

       
    }
}
