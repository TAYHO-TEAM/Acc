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
                MessageBox.Show(userLogonName + " này đã tồn tại.", "Thông báo");
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
                MessageBox.Show("Exception creating user object. " + e);
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
        public PrincipalSearchResult<Principal> GetAllGroup()
        {
            GroupPrincipal findAllGroups = new GroupPrincipal(_prinContext, "*");
            PrincipalSearcher ps = new PrincipalSearcher(findAllGroups);
            return ps.FindAll();
        }
    }
}
