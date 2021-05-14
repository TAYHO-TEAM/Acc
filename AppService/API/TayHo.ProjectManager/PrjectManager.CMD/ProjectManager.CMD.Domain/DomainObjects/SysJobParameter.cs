using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class SysJobParameter : DOBase
    {
        #region Fields

        private string _sysJobId;
        private string _name;
        private string _displayName;
        private string _dataTypeSQL;
        private string _dataTypeC;
        private string _defaultValue;


        #endregion Fields
        #region Constructors

        private SysJobParameter()
        {
        }

        public SysJobParameter(string SysJobId, string Name, string DisplayName, string DataTypeSQL, string DataTypeC, string DefaultValue) : this()
        {
            _sysJobId = SysJobId;
            _name = Name;
            _displayName = DisplayName;
            _dataTypeSQL = DataTypeSQL;
            _dataTypeC = DataTypeC;
            _defaultValue = DefaultValue;

        }

        #endregion Constructors
        #region Properties

        [MaxLength(10, ErrorMessage = nameof(ErrorCodeInsert.IErr10))] public string SysJobId { get => _sysJobId; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Name { get => _name; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string DisplayName { get => _displayName; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string DataTypeSQL { get => _dataTypeSQL; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string DataTypeC { get => _dataTypeC; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string DefaultValue { get => _defaultValue; }


        #endregion Properties
        #region Behaviours

        public void SetSysJobId(string SysJobId)
        { _sysJobId = SysJobId == null ? _sysJobId : SysJobId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetName(string Name)
        { _name = Name == null ? _name : Name; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDisplayName(string DisplayName)
        { _displayName = DisplayName == null ? _displayName : DisplayName; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDataTypeSQL(string DataTypeSQL)
        { _dataTypeSQL = DataTypeSQL == null ? _dataTypeSQL : DataTypeSQL; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDataTypeC(string DataTypeC)
        { _dataTypeC = DataTypeC == null ? _dataTypeC : DataTypeC; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDefaultValue(string DefaultValue)
        { _defaultValue = DefaultValue == null ? _defaultValue : DefaultValue; if (!IsValid()) throw new DomainException(_errorMessages); }


        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
