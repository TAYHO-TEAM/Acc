using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class CustomColum : DOBase
    {
        #region Fields
        private int? _customTableId;
        private int? _colIndex;
        private string _header;
        private string _typeParam;
        private string _style;
        private string _sourceValue;
        private string _sourceLink;
        #endregion Fields
        #region Constructors

        private CustomColum()
        {
        }

        public CustomColum(int? CustomTableId,
                            int? ColIndex,
                            string Header,
                            string TypeParam,
                            string Style,
                            string SourceValue,
                            string SourceLink) : this()
        {
            _customTableId = CustomTableId;
            _colIndex = ColIndex;
            _header = Header;
            _typeParam = TypeParam;
            _style = Style;
            _sourceValue = SourceValue;
            _sourceLink = SourceLink;
        }
        #endregion Constructors
        #region Properties
        public int? CustomTableId { get => _customTableId; }
        public int? ColIndex { get => _colIndex; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string Header { get => _header; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string TypeParam { get => _typeParam; }
        [MaxLength(1028, ErrorMessage = nameof(ErrorCodeInsert.IErr1028))] public string Style { get => _style; }
        public string SourceValue { get => _sourceValue; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string SourceLink { get => _sourceLink; }
        #endregion Properties

        #region Behaviours

        public void SetCustomTableId(int? CustomTableId) { _customTableId = !CustomTableId.HasValue ? _customTableId : CustomTableId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetColIndex(int? ColIndex) { _colIndex = !ColIndex.HasValue ? _colIndex : ColIndex; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetHeader(string Header) { _header = Header == null ? _header : Header; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTypeParam(string TypeParam) { _typeParam = TypeParam == null ? _typeParam : TypeParam; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStyle(string Style) { _style = Style == null ? _style : Style; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetSourceValue(string SourceValue) { _sourceValue = SourceValue == null ? _sourceValue : SourceValue; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetSourceLink(string SourceLink) { _sourceLink = SourceLink == null ? _sourceLink : SourceLink; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
