using AppWFGenProject.Entities;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWFGenProject.FrameWork
{
    public class LDAPHelper
    {
        private static PrincipalContext _prinContext = null;
        public LDAPHelper(PrincipalContext principalContext)
        {
            _prinContext = principalContext;
        }
        public bool CreateAccount()
        {
            return true;
        }
        public static bool CreateUser(UserAccount userAccount)
        {
            string firstName = userAccount.FirstName;
            string lastName = userAccount.LastName;
            string userLogonName = userAccount.CommonName;
            string employeeID = userAccount.EmployeeID;
            string emailAddress = userAccount.EmailAddress;
            string telephone = userAccount.Telephone;
            string address = userAccount.Address;
            string pwdOfNewlyCreatedUser = userAccount.PassWord;

            // Check if user object already exists in the store
            UserPrincipal usr = UserPrincipal.FindByIdentity(_prinContext, userLogonName);
            if (usr != null)
            {
                MessageBox.Show(userLogonName + " này đã tồn tại.", "Thông báo!");
                return false;
            }
            // Create the new UserPrincipal object
            UserPrincipal userPrincipal = new UserPrincipal(_prinContext);

            if (lastName != null && lastName.Length > 0)
                userPrincipal.Surname = lastName;

            if (firstName != null && firstName.Length > 0)
                userPrincipal.GivenName = firstName;

            if (employeeID != null && employeeID.Length > 0)
                userPrincipal.EmployeeId = employeeID;

            if (emailAddress != null && emailAddress.Length > 0)
                userPrincipal.EmailAddress = emailAddress;

            if (telephone != null && telephone.Length > 0)
                userPrincipal.VoiceTelephoneNumber = telephone;

            if (userLogonName != null && userLogonName.Length > 0)
                userPrincipal.SamAccountName = userLogonName;

            userPrincipal.SetPassword(pwdOfNewlyCreatedUser);

            userPrincipal.Enabled = true;
            userPrincipal.ExpirePasswordNow();

            try
            {
                userPrincipal.Save();  
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi quá trình tạo tài khoản mới: " + e,"Thông báo!");
                return false;
            }

            /***************************************************************
             *   The below code demonstrates on how you can make a smooth 
             *   transition to DirectoryEntry from AccountManagement namespace, 
             *   for advanced operations.
             ***************************************************************/
            if (userPrincipal.GetUnderlyingObjectType() == typeof(DirectoryEntry))
            {
                DirectoryEntry entry = (DirectoryEntry)userPrincipal.GetUnderlyingObject();
                if (address != null && address.Length > 0)
                    entry.Properties["streetAddress"].Value = address;
                try
                {
                    entry.CommitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception modifying address of the user. " + e);
                    return false;
                }
            }
            return true;
        }
        private void GetListObjCategory()
        {

        }
        public PrincipalSearchResult<Principal> GetAllGroup(string groupName)
        {
            if (string.IsNullOrEmpty(groupName))
                groupName = "*";
            GroupPrincipal findAllGroups = new GroupPrincipal(_prinContext, groupName);
            PrincipalSearcher ps = new PrincipalSearcher(findAllGroups);
            return ps.FindAll();
        }
        public UserPrincipal SearchUser(string userName)
        {
            UserPrincipal findAllUsers = UserPrincipal.FindByIdentity(_prinContext, userName);
            //PrincipalSearcher ps = new PrincipalSearcher(findAllUsers);
            return findAllUsers;
            //using (UserPrincipal user = new UserPrincipal(_prinContext))
            //{
            //    //Specify the search parameters
            //    user.Name = userName;

            //    //Create the searcher
            //    //pass (our) user object
            //    using (PrincipalSearcher pS = new PrincipalSearcher())
            //    {
            //        pS.QueryFilter = user;

            //        //Perform the search
            //        using (PrincipalSearchResult<Principal> results = pS.FindAll())
            //        {
            //            //If necessary, request more details
            //            return  results.ToList()[0];

            //        }
            //    }
            //}
        }
        public bool DisableUser(string userName)
        {
            UserPrincipal findAllUsers = UserPrincipal.FindByIdentity(_prinContext, userName);
            if(findAllUsers != null)
            {
                findAllUsers.Enabled = false;
                findAllUsers.Save();
                return true;
            }    
            else
            {
                MessageBox.Show("Tài khoản không tồn tại.", "Thông Báo!");
                return false;
            }    
        }
        public PrincipalSearchResult<Principal> GetAllUser()
        {
            UserPrincipal findAllUsers = new UserPrincipal(_prinContext);
            PrincipalSearcher ps = new PrincipalSearcher(findAllUsers);
            return ps.FindAll();
        }
        public PrincipalSearchResult<Principal> GetAllOU()
        {
            GroupPrincipal findAllUsers = new GroupPrincipal(_prinContext);
            PrincipalSearcher ps = new PrincipalSearcher(findAllUsers);
            return ps.FindAll();
        }
        public void AddUserToGroup(string userId, string groupName)
        {
            try
            {
                using (PrincipalContext pc = _prinContext)
                {
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, groupName);
                    group.Members.Add(pc, IdentityType.UserPrincipalName, userId);
                    group.Save();
                }
            }
            catch (DirectoryServicesCOMException E)
            {
                MessageBox.Show("Lỗi trong quá trình thêm vào nhóm." + E,"Thông Báo!");
            }
        }

        public void RemoveUserFromGroup(string userId, string groupName)
        {
            try
            {
                using (PrincipalContext pc = _prinContext)
                {
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, groupName);
                    group.Members.Remove(pc, IdentityType.UserPrincipalName, userId);
                    group.Save();
                }
            }
            catch (DirectoryServicesCOMException E)
            {
                MessageBox.Show("Lỗi trong quá trình xoá khỏi nhóm." + E, "Thông Báo!");
            }
        }
        public PrincipalSearchResult<Principal> GetAllUsersGroup(string UserAccount)
        {
            UserPrincipal up = UserPrincipal.FindByIdentity(_prinContext, UserAccount);

            if (up != null)
            {
                // get groups for that user
                return up.GetAuthorizationGroups();

            }
            else
                return null;
            //GroupPrincipal qbeGroup = new GroupPrincipal(_prinContext, UserAccount);
            //PrincipalSearcher srch = new PrincipalSearcher(qbeGroup);
            //foreach (var found in srch.FindAll())
            //{
            //    var a = found;
            //}
        }
    }
}
