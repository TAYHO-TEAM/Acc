using AppWFGenProject.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AppWFGenProject.FrameWork
{
    public class GenCMD
    {
        /// <summary>
        /// function genCMD : gen domain object
        /// </summary>
        public void GenEntity(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathentitytxt = ConstPath.CMDDomain + ConstFileNameTxt.Entity;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                GenOB.builderFields += row["PrivateOBJ"].ToString() + "\r\n\t" + (i > 1 ? "\t\t" : "");
                GenOB.paramCreate += row["PublicParameter"].ToString(); 
                GenOB.functionCreate += row["FunctionPublic"].ToString() + "\r\n\t" + (i > 1 ? "\t\t" : "");
                GenOB.builderProperties += row["PropertiesOBJ"].ToString() + "\r\n\t" + (i > 1 ? "\t\t" : "");
                GenOB.builderBehaviours += row["FunctionBehavior"].ToString() + "\r\n\t" + (i > 1 ? "\t\t" : "");
            }
            GenOB.paramCreate = GenOB.paramCreate.TrimEnd(',');
            fileHelper.CreateFileFrom(pathentitytxt, fileHelper.ReplaceFileName((direct.DomainObjects + ConstFileNameTxt.Entity), GenOB), GenOB.getDictionatyChange());
        }
        public void GenIRespositories(GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// get repos  
            string pathRepository = ConstPath.CMDDomain + ConstFileNameTxt.IEntityRepository;
            fileHelper.CreateFileFrom(pathRepository, fileHelper.ReplaceFileName((direct.IRepositories + ConstFileNameTxt.IEntityRepository), GenOB), GenOB.getDictionatyChange());
        }
        /// <summary>
        /// function genCMD : gen Infra
        /// </summary>
        public void GenEntityConfig(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// get path entity config  
            string pathEntityConfig = ConstPath.CMDInfra + ConstFileNameTxt.EntityConfiguration;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                GenOB.builderConfig += row[0].ToString() + "\r\n\t" + (i > 1 ? "\t\t" : "");
            }
            fileHelper.CreateFileFrom(pathEntityConfig, fileHelper.ReplaceFileName((direct.EFConfig + ConstFileNameTxt.EntityConfiguration), GenOB), GenOB.getDictionatyChange());
        }
        public void GenRepositories(GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// get path config  
            string pathEntityConfig = ConstPath.CMDInfra + ConstFileNameTxt.EntityRepository;

            fileHelper.CreateFileFrom(pathEntityConfig, fileHelper.ReplaceFileName((direct.Repositories + ConstFileNameTxt.EntityRepository), GenOB), GenOB.getDictionatyChange());
        }
        /// <summary>
        /// function genCMD : gen Controller
        /// </summary>
        /// 
        public void GenCommandBase(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathEntityConfig = ConstPath.CMDCommandBase + ConstFileNameTxt.EntityCommand;
            string pathEntityCommandHandler = ConstPath.CMDCommandBase + ConstFileNameTxt.EntityCommandHandler;
            string pathEntityCommandSet = ConstPath.CMDCommandBase + ConstFileNameTxt.EntityCommandSet;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                GenOB.builderPublic += row[0].ToString() + "\r\n\t" + (i > 1 ? "\t\t" : "");
            }
            fileHelper.CreateFileFrom(pathEntityConfig, fileHelper.ReplaceFileName((direct.CommandBaseClasses + ConstFileNameTxt.EntityCommand), GenOB), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathEntityCommandHandler, fileHelper.ReplaceFileName((direct.CommandBaseClasses + ConstFileNameTxt.EntityCommandHandler), GenOB), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathEntityCommandSet, fileHelper.ReplaceFileName((direct.CommandBaseClasses + ConstFileNameTxt.EntityCommandSet), GenOB), GenOB.getDictionatyChange());
        }
        public void GenCMDAll(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathCreate = ConstPath.CMDCommand + ConstFileNameTxt.CreateEntityCommand;
            string pathCreateHandler = ConstPath.CMDCommand + ConstFileNameTxt.CreateEntityCommandHandler;
            string pathDelete = ConstPath.CMDCommand + ConstFileNameTxt.DeleteEntityCommand;
            string pathDeleteHandler = ConstPath.CMDCommand + ConstFileNameTxt.DeleteEntityCommandHandler;
            string pathUpdate = ConstPath.CMDCommand + ConstFileNameTxt.UpdateEntityCommand;
            string pathUpdateHandler = ConstPath.CMDCommand + ConstFileNameTxt.UpdateEntityCommandHandler;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                GenOB.builderPublic += row[0].ToString() + "\r\n\t" + (i > 1 ? "\t\t" : "");
                GenOB.builderRequestParam += row["Request"].ToString();
                GenOB.builderSetUpdate += row["UpdateSet"].ToString() + "\r\n\t" + (i > 1 ? "\t\t" : "");
            }

            fileHelper.CreateFileFrom(pathCreate, fileHelper.ReplaceFileName((direct.Command + ConstFileNameTxt.CreateEntityCommand), GenOB), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathCreateHandler, fileHelper.ReplaceFileName((direct.Command + ConstFileNameTxt.CreateEntityCommandHandler), GenOB), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathDelete, fileHelper.ReplaceFileName((direct.Command + ConstFileNameTxt.DeleteEntityCommand), GenOB), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathDeleteHandler, fileHelper.ReplaceFileName((direct.Command + ConstFileNameTxt.DeleteEntityCommandHandler), GenOB), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathUpdate, fileHelper.ReplaceFileName((direct.Command + ConstFileNameTxt.UpdateEntityCommand), GenOB), GenOB.getDictionatyChange());
            fileHelper.CreateFileFrom(pathUpdateHandler, fileHelper.ReplaceFileName((direct.Command + ConstFileNameTxt.UpdateEntityCommandHandler), GenOB), GenOB.getDictionatyChange());
        }
        public void GenController(GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathController = ConstPath.CMDControllers + ConstFileNameTxt.CMDEntityController;
            fileHelper.CreateFileFrom(pathController, fileHelper.ReplaceFileName((direct.Controllers + ConstFileNameTxt.CMDEntityController), GenOB), GenOB.getDictionatyChange());
        }
        public void GenEntityProfile(DataTable dt, GenOB GenOB)
        {
            FileHelper fileHelper = new FileHelper();
            ConstDirect direct = new ConstDirect(GenOB.nameproject, GenOB.rootDir);
            /// gen entity 
            string pathEntityProfile = ConstPath.CMDMappings + ConstFileNameTxt.CMDEntityProfile;
            fileHelper.CreateFileFrom(pathEntityProfile, fileHelper.ReplaceFileName((direct.Mappings + ConstFileNameTxt.CMDEntityProfile), GenOB), GenOB.getDictionatyChange());
        }
    }
}
