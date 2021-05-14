using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NotifyConfig : DOBase
    {
        #region Fields

        private int? _type;
        private string _code;
        private string _jobName;
        private string _tableName;
        private string _querryCMD;


        #endregion Fields
        #region Constructors

        private NotifyConfig()
        {
        }

        public NotifyConfig(int? Type, string Code, string JobName, string TableName, string QuerryCMD) : this()
        {
            _type = Type;
            _code = Code;
            _jobName = JobName;
            _tableName = TableName;
            _querryCMD = QuerryCMD;

        }

        #endregion Constructors
        #region Properties

        public int? Type { get => _type; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string Code { get => _code; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string JobName { get => _jobName; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string TableName { get => _tableName; }
        public string QuerryCMD { get => _querryCMD; }


        #endregion Properties
        #region Behaviours

        public void SetType(int? Type)
        { _type = !Type.HasValue ? _type : Type; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCode(string Code)
        { _code = Code == null ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetJobName(string JobName)
        { _jobName = JobName == null ? _jobName : JobName; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTableName(string TableName)
        { _tableName = TableName == null ? _tableName : TableName; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetQuerryCMD(string QuerryCMD)
        { _querryCMD = QuerryCMD == null ? _querryCMD : QuerryCMD; if (!IsValid()) throw new DomainException(_errorMessages); }


        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
