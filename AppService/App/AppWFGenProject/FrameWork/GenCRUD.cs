using AppWFGenProject.Extensions;
using System.Data;

namespace AppWFGenProject.FrameWork
{
    public class GenCRUD
    {
        /// <summary>
        /// function genCMD : gen domain object
        /// </summary>
        public void GenEntity(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathentitytxt = ConstPath.CRUDEntity + ConstFileNameTxt.Entity;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                GenOB.entityDTO += row["EntityDTO"].ToString() + "\r\n\t" + (i > 1 ? "\t\t" : "");
            }
            fileHelper.CreateFileFrom(pathentitytxt, fileHelper.ReplaceFileName((direct.DLLDTO + ConstFileNameTxt.Entity), GenOB), GenOB.getDictionatyChange());
        }
        public void GenEntityConfig(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// get path entity config  
            string pathEntityConfig = ConstPath.CRUDConfig + ConstFileNameTxt.EntityConfiguration;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                GenOB.builderConfigColum += row[0].ToString() + "\r\n\t" + (i > 1 ? "\t\t" : "");
            }
            fileHelper.CreateFileFrom(pathEntityConfig, fileHelper.ReplaceFileName((direct.DLLEFConfig + ConstFileNameTxt.EntityConfiguration), GenOB), GenOB.getDictionatyChange());
        }

        /// <summary>
        /// function genCRUD : gen Repos
        /// </summary>

        public void GenRepositories(GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// get path config  
            string pathEntityConfig = ConstPath.CRUDRepos + ConstFileNameTxt.EntityRepository;
            fileHelper.CreateFileFrom(pathEntityConfig, fileHelper.ReplaceFileName((direct.Repositories + ConstFileNameTxt.EntityRepository), GenOB), GenOB.getDictionatyChange());
        }
        public void GenIRespositories(GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// get repos  
            string pathRepository = ConstPath.CRUDRepos + ConstFileNameTxt.IEntityRepository;
            fileHelper.CreateFileFrom(pathRepository, fileHelper.ReplaceFileName((direct.IRepositories + ConstFileNameTxt.IEntityRepository), GenOB), GenOB.getDictionatyChange());
        }
        /// <summary>
        /// function genCMD : gen Controller
        /// </summary>
        /// 
        public void GenController(GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathController = ConstPath.CRUDController + ConstFileNameTxt.EntityController;
            fileHelper.CreateFileFrom(pathController, fileHelper.ReplaceFileName((direct.Controllers + ConstFileNameTxt.CMDEntityController), GenOB), GenOB.getDictionatyChange());
        }
       
    }
}
