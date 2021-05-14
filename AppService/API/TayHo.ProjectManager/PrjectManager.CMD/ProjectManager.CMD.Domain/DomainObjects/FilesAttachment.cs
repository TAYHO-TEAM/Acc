using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class FilesAttachment : DOBase
    {
        #region Fields
        private int? _ownerById;
        private string _ownerByTable;
        private string _code;
        private string _fileName;
        private string _tail;
        private string _url;
        private string _host;
        private string _type;
        private string _direct;
        private string _displayName;
        #endregion Fields
        #region Constructors
        private FilesAttachment()
        {
           
        }

        public FilesAttachment(int? OwnerById,
                                string OwnerByTable,
                                string Code,
                                string FileName,
                                string DisplayName,
                                string Tail,
                                string Url,
                                string Host,
                                string Type,
                                string Direct) : this()
        {
            _ownerById = OwnerById;
            _ownerByTable = OwnerByTable;
            _code = Code;
            _fileName = FileName;
            _displayName = DisplayName;
            _tail = Tail;
            _url = Url;
            _host = Host;
            _type = Type;
            _direct = Direct;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        public int? OwnerById { get => _ownerById; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string OwnerByTable { get => _ownerByTable; }
        [MaxLength(32, ErrorMessage = nameof(ErrorCodeInsert.IErr32))] public string Code { get => _code; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string FileName { get => _fileName; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string DisplayName { get => _displayName; }
        [MaxLength(10, ErrorMessage = nameof(ErrorCodeInsert.IErr10))] public string Tail { get => _tail; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Url { get => _url; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Host { get => _host; }
        [MaxLength(10, ErrorMessage = nameof(ErrorCodeInsert.IErr10))] public string Type { get => _type; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Direct { get => _direct; }
        #endregion Properties

        #region Behaviours
        public void SetOwnerById(int? OwnerById) { _ownerById = OwnerById.HasValue ? _ownerById : OwnerById; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetOwnerByTable(string OwnerByTable) { _ownerByTable = string.IsNullOrEmpty(OwnerByTable) ? _ownerByTable : OwnerByTable; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCode(string Code) { _code = string.IsNullOrEmpty(Code) ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetFileName(string FileName) { _fileName = string.IsNullOrEmpty(FileName) ? _fileName : FileName; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDisplayName(string DisplayName) { _displayName = string.IsNullOrEmpty(DisplayName) ? _displayName : DisplayName; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTail(string Tail) { _tail = string.IsNullOrEmpty(Tail) ? _tail : Tail; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetUrl(string Url) { _url = string.IsNullOrEmpty(Url) ? _url : Url; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetHost(string Host) { _host = string.IsNullOrEmpty(Host) ? _host : Host; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetType(string Type) { _type = string.IsNullOrEmpty(Type) ? _type : Type; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDirect(string Direct) { _direct = string.IsNullOrEmpty(Direct) ? _direct : Direct; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
