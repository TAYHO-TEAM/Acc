using AppWFGenProject.Extensions;
using System.Data;


namespace AppWFGenProject.FrameWork
{
    public class GenREAD
    {
        /// <summary>
        /// function genREAD : gen domain object
        /// </summary>
        /// 
        public void GenEntityDTO(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathentitytxt = ConstPath.ReadDTOs + ConstFileNameTxt.EntityDTO;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                GenOB.builderPublic += row[0].ToString() + "\r\n\t" + (i > 1 ? "\t\t" : "");
            }
            fileHelper.CreateFileFrom(pathentitytxt, fileHelper.ReplaceFileName((direct.DTOs + ConstFileNameTxt.EntityDTO), GenOB), GenOB.getDictionatyChange());
        }
        public void GenEntityViewModel(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathentitytxt = ConstPath.ReadViewModels + ConstFileNameTxt.EntityResponseViewModel;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                GenOB.builderPublic += row[0].ToString() + "\r\n\t" + (i > 1 ? "\t\t" : "");
            }
            fileHelper.CreateFileFrom(pathentitytxt, fileHelper.ReplaceFileName((direct.ViewModels + ConstFileNameTxt.EntityResponseViewModel), GenOB), GenOB.getDictionatyChange());
        }
        public void GenEntityMapping(GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathentitytxt = ConstPath.ReadMappings + ConstFileNameTxt.ReadEntityProfile;
            fileHelper.CreateFileFrom(pathentitytxt, fileHelper.ReplaceFileName((direct.ReadMappings + ConstFileNameTxt.ReadEntityProfile), GenOB), GenOB.getDictionatyChange());
        }
        public void GenEntityController(GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathentitytxt = ConstPath.ReadControllers + ConstFileNameTxt.ReadEntityController;

            fileHelper.CreateFileFrom(pathentitytxt, fileHelper.ReplaceFileName((direct.ReadControllers + ConstFileNameTxt.ReadEntityController), GenOB), GenOB.getDictionatyChange());
        }
    }
}
