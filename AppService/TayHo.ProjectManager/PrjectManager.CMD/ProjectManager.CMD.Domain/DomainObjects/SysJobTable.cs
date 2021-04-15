using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class SysJobTable : DOBase
    {
        #region Fields

        private int? _sysJobId;
        private int? _no;
        private string _name;
        private bool? _isHeader;
        private string _headerColor;
        private string _headerBackGroundColor;
        private int? _border;
        private string _color;
        private string _backGroundColor;
        private int? _beginRow;
        private int? _beginCol;
        private int? _priority;
        private string _style;


        #endregion Fields
        #region Constructors

        private SysJobTable()
        {
        }

        public SysJobTable(int? SysJobId, int? No, string Name, bool? IsHeader, string HeaderColor, string HeaderBackGroundColor, int? Border, string Color, string BackGroundColor, int? BeginRow, int? BeginCol, int? Priority, string Style) : this()
        {
            _sysJobId = SysJobId;
            _no = No;
            _name = Name;
            _isHeader = IsHeader;
            _headerColor = HeaderColor;
            _headerBackGroundColor = HeaderBackGroundColor;
            _border = Border;
            _color = Color;
            _backGroundColor = BackGroundColor;
            _beginRow = BeginRow;
            _beginCol = BeginCol;
            _priority = Priority;
            _style = Style;

        }

        #endregion Constructors
        #region Properties

        public int? SysJobId { get => _sysJobId; }
        public int? No { get => _no; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string Name { get => _name; }
        public bool? IsHeader { get => _isHeader; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string HeaderColor { get => _headerColor; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string HeaderBackGroundColor { get => _headerBackGroundColor; }
        public int? Border { get => _border; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Color { get => _color; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string BackGroundColor { get => _backGroundColor; }
        public int? BeginRow { get => _beginRow; }
        public int? BeginCol { get => _beginCol; }
        public int? Priority { get => _priority; }
        [MaxLength(2048, ErrorMessage = nameof(ErrorCodeInsert.IErr2048))] public string Style { get => _style; }


        #endregion Properties
        #region Behaviours

        public void SetSysJobId(int? SysJobId)
        { _sysJobId = !SysJobId.HasValue ? _sysJobId : SysJobId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNo(int? No)
        { _no = !No.HasValue ? _no : No; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetName(string Name)
        { _name = Name == null ? _name : Name; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetIsHeader(bool? IsHeader)
        { _isHeader = !IsHeader.HasValue ? _isHeader : IsHeader; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetHeaderColor(string HeaderColor)
        { _headerColor = HeaderColor == null ? _headerColor : HeaderColor; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetHeaderBackGroundColor(string HeaderBackGroundColor)
        { _headerBackGroundColor = HeaderBackGroundColor == null ? _headerBackGroundColor : HeaderBackGroundColor; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetBorder(int? Border)
        { _border = !Border.HasValue ? _border : Border; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetColor(string Color)
        { _color = Color == null ? _color : Color; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetBackGroundColor(string BackGroundColor)
        { _backGroundColor = BackGroundColor == null ? _backGroundColor : BackGroundColor; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetBeginRow(int? BeginRow)
        { _beginRow = !BeginRow.HasValue ? _beginRow : BeginRow; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetBeginCol(int? BeginCol)
        { _beginCol = !BeginCol.HasValue ? _beginCol : BeginCol; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPriority(int? Priority)
        { _priority = !Priority.HasValue ? _priority : Priority; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStyle(string Style)
        { _style = Style == null ? _style : Style; if (!IsValid()) throw new DomainException(_errorMessages); }


        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
