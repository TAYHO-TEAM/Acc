using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class SysJobColum : DOBase
    {
        #region Fields

        private int? _noCol;
        private int? _sysJobTableId;
        private string _style;
        private string _formulas;
        private string _functions;


        #endregion Fields
        #region Constructors

        private SysJobColum()
        {
        }

        public SysJobColum(int? NoCol, int? SysJobTableId, string Style, string Formulas, string Functions) : this()
        {
            _noCol = NoCol;
            _sysJobTableId = SysJobTableId;
            _style = Style;
            _formulas = Formulas;
            _functions = Functions;

        }

        #endregion Constructors
        #region Properties

        public int? NoCol { get => _noCol; }
        public int? SysJobTableId { get => _sysJobTableId; }
        [MaxLength(1024, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string Style { get => _style; }
        public string Formulas { get => _formulas; }
        public string Functions { get => _functions; }


        #endregion Properties
        #region Behaviours

        public void SetNoCol(int? NoCol)
        { _noCol = !NoCol.HasValue ? _noCol : NoCol; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetSysJobTableId(int? SysJobTableId)
        { _sysJobTableId = !SysJobTableId.HasValue ? _sysJobTableId : SysJobTableId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStyle(string Style)
        { _style = Style == null ? _style : Style; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetFormulas(string Formulas)
        { _formulas = Formulas == null ? _formulas : Formulas; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetFunctions(string Functions)
        { _functions = Functions == null ? _functions : Functions; if (!IsValid()) throw new DomainException(_errorMessages); }


        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
