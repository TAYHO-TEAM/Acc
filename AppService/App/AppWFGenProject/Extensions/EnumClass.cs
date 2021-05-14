using System.IO;
using System.Reflection;

namespace AppWFGenProject.Extensions
{
    public static class EnumClass
    {
        public static string nameproject = "{nameproject}";
        public static string common = "{common}";
        public static string db = "{db}";
        public static string Entity = "{Entity}";
        public static string entity = "{entity}";
        public static string _entity = "{_entity}";
        public static string version = "{version}";
        public static string builderConfig = "{builderConfig}";
        public static string builderFields = "{builderFields}";
        public static string builderConfigColum = "{builderConfigColum}";
        public static string paramCreate = "{paramCreate}";
        public static string functionCreate = "{functionCreate}";
        public static string builderProperties = "{builderProperties}";
        public static string builderBehaviours = "{builderBehaviours}";
        public static string builderRegister = "{biulderRegister}";
        public static string builderRequestParam = "{builderRequestParam}";
        public static string builderSetUpdate = "{builderSetUpdate}";
        public static string builderPublic = "{builderPublic}";
        public static string entityDTO = "{entityDTO}";
        
    }
    public class ConstDirect
    {

        // CMD
        private string _command = @"\Application\Commands\{Entity}Cmd\";
        private string _commandBaseClasses = @"\Application\Commands\{Entity}Cmd\BaseClasses\";
        private string _controllers = @"\Controllers\{version}\";
        private string _mappings = @"\Infrastructure\Mappings\";
        private string _domainObjects = @"\DomainObjects\";
        private string _eFConfig = @"\EFConfig\";
        private string _iRepositories = @"\IRepositories\";
        private string _repositories = @"\Repositories\";
        private string _viewModels = @"\ViewModels\";
        private string _dTOs = @"\DTOs\DTO\";
        //CRUD 
        private string _bLLRepos = @"\Repositories\";
        private string _bLLIRepos = @"\IRepositories\";
        private string _dLLDTO = @"\DTO\";
        private string _dLLEFConfig = @"\EFConfig\";
        #region CMD
        // CMD
        ////Controller
        public string Command { get; }
        public string CommandBaseClasses { get; }
        public string Controllers { get; }
        public string Mappings { get; }
        //// Domain
        public string DomainObjects { get; }
        public string IRepositories { get; }
        //// Infrastructure
        public string EFConfig { get; }
        public string Repositories { get; }
        // Read
        //// Controller
        public string ReadControllers { get; }
        //// Mappings
        public string ReadMappings { get; }
        //// ViewModels
        public string ViewModels { get; }
        //// DTO
        public string DTOs { get; }
        #endregion CMD
        #region READ
        #endregion READ
        #region CRUD

        public string BLLRepos { get; }
        public string BLLIRepos { get; }
        public string DLLDTO { get; }
        public string DLLEFConfig { get; }
        #endregion CRUD

        public ConstDirect(string nameproject, string rootDir)
        {
            Command = rootDir + @"\" + nameproject + ".Api" + _command;
            CommandBaseClasses = rootDir + @"\" + nameproject + ".Api" + _commandBaseClasses;
            Controllers = rootDir + @"\" + nameproject + ".Api" + _controllers;
            Mappings = rootDir + @"\" + nameproject + ".Api" + _mappings;
            DomainObjects = rootDir + @"\" + nameproject + ".Domain" + _domainObjects;
            IRepositories = rootDir + @"\" + nameproject + ".Domain" + _iRepositories;
            EFConfig = rootDir + @"\" + nameproject + ".Infrastructure" + _eFConfig;
            Repositories = rootDir + @"\" + nameproject + ".Infrastructure" + _repositories;
            ReadControllers = rootDir + @"\" + nameproject + ".Api" + _controllers;
            ReadMappings = rootDir + @"\" + nameproject + ".Api" + _mappings;
            ViewModels = rootDir + @"\" + nameproject + ".Api" + _viewModels;
            DTOs = rootDir + @"\" + nameproject + ".Sql" + _dTOs;
            BLLRepos = rootDir + @"\" + nameproject + ".BLL" + _bLLRepos;
            BLLIRepos = rootDir + @"\" + nameproject + ".BLL" + _bLLIRepos;
            DLLDTO = rootDir + @"\" + nameproject + ".DLL" + _dLLDTO;
            DLLEFConfig = rootDir + @"\" + nameproject + ".DLL" + _dLLEFConfig;
        }
    }
    public static class ConstTable
    {
        public static int DomainOB = 0;
        public static int EFConfig = 1;
        public static int Command = 2;
        //public static int Reister = 3;
        public static int TableConst = 3;
        public static int SetConstTable = 4;
        public static int ServiceCollection = 5;
        public static int MappingCMD = 6;
        public static int DbSet = 7;
        public static int Entity = 8;
        public static int EFConfigColum = 9;
    }
    public static class ConstPath
    {
        public static string localDisk = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Content\TemPlate\";///@"D:\TayHo_project\TayHo.SystemCore\AppService\App\AppWFGenProject\Content\TemPlate";//@"D:\Github\SystemCore\AppService\App\AppWFGenProject\Content\TemPlate";//@"D:\TayHo_project\TayHo.SystemCore\AppService\App\AppWFGenProject\Content\TemPlate\";//D:\Github\SystemCore\AppService\App\AppWFGenProject\Content\TemPlate
        public static string CMDCommandBase = localDisk + @"CMD\Api\Application\Command\BaseClasses\";
        public static string CMDCommand = localDisk + @"CMD\Api\Application\Command\";
        public static string CMDControllers = localDisk + @"CMD\Api\Controllers\";
        public static string CMDAutofacModules = localDisk + @"CMD\Api\Infrastructure\AutofacModules\";
        public static string CMDMappings = localDisk + @"CMD\Api\Infrastructure\Mappings\";
        public static string CMDDomain = localDisk + @"CMD\Domain\";
        public static string CMDInfra = localDisk + @"CMD\Infra\";
        public static string ReadControllers = localDisk + @"READ\Api\Controllers\";
        public static string ReadMappings = localDisk + @"READ\Api\Infrastructure\Mappings\";
        public static string ReadViewModels = localDisk + @"READ\Api\ViewModels\";
        public static string ReadDTOs = localDisk + @"READ\Sql\DTOs\";
        public static string CRUDEntity = localDisk + @"CRUD\DLL\DTO\";
        public static string CRUDController = localDisk + @"CRUD\API\Controllers\";
        public static string CRUDRepos = localDisk + @"CRUD\BLL\";
        public static string CRUDConfig = localDisk + @"CRUD\DLL\EFConfig\";
    }
    public static class ConstFileNameTxt
    {
        public static string CreateEntityCommand = "CreateEntityCommand.txt";
        public static string CreateEntityCommandHandler = "CreateEntityCommandHandler.txt";
        public static string DeleteEntityCommand = "DeleteEntityCommand.txt";
        public static string DeleteEntityCommandHandler = "DeleteEntityCommandHandler.txt";
        public static string UpdateEntityCommand = "UpdateEntityCommand.txt";
        public static string UpdateEntityCommandHandler = "UpdateEntityCommandHandler.txt";
        public static string EntityCommand = "EntityCommand.txt";
        public static string EntityCommandHandler = "EntityCommandHandler.txt";
        public static string EntityCommandSet = "EntityCommandSet.txt";
        public static string CMDEntityController = "EntityController.txt";
        public static string ApplicationModule = "ApplicationModule.txt";
        public static string CMDEntityProfile = "EntityProfile.txt";
        public static string Entity = "Entity.txt";
        public static string IEntityRepository = "IEntityRepository.txt";
        public static string EntityConfiguration = "EntityConfiguration.txt";
        public static string EntityRepository = "EntityRepository.txt";
        public static string ReadEntityController = "EntityController.txt";
        public static string ReadEntityProfile = "EntityProfile.txt";
        public static string EntityResponseViewModel = "EntityResponseViewModel.txt";
        public static string EntityDTO = "EntityDTO.txt";
        public static string EntityController = "EntityController.txt";
    }
    public class SetConfig
    {

    }
}
