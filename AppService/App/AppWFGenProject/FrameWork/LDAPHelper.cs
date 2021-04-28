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
        public bool CreateAccount()
        {
            return true;
        }
        public static bool CreateUser(string firstName, string lastName, string userLogonName, string employeeID, string emailAddress, string telephone, string address, string pwdOfNewlyCreatedUser)
        {
            // Creating the PrincipalContext
            PrincipalContext principalContext = null;
            try
            {
                principalContext = new PrincipalContext(ContextType.Domain, "fabrikam", "DC=fabrikam,DC=com");
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to create PrincipalContext. Exception: " + e);
                Application.Exit();
            }

            // Check if user object already exists in the store
            UserPrincipal usr = UserPrincipal.FindByIdentity(principalContext, userLogonName);
            if (usr != null)
            {
                MessageBox.Show(userLogonName + " already exists. Please use a different User Logon Name.");
                return false;
            }

            // Create the new UserPrincipal object
            UserPrincipal userPrincipal = new UserPrincipal(principalContext);

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

            pwdOfNewlyCreatedUser = "abcde@@12345!~";
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
    }
}
