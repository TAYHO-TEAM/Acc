using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class CustomCellContent : DOBase
    {
        #region Fields
        private int? _customFormContentId;
        private int? _customFormBodyId;
        private int? _customColumId;
        private string _contents;
        private int? _noRown;
        #endregion Fields
        #region Constructors

        private CustomCellContent()
        {
        }

        public CustomCellContent(int? CustomFormContentId,
                                    int? CustomFormBodyId,
                                    int? CustomColumId,
                                    string Contents,
                                    int? NoRown) : this()
        {
            _customFormContentId = CustomFormContentId;
            _customFormBodyId = CustomFormBodyId;
            _customColumId = CustomColumId;
            _contents = Contents;
            _noRown = NoRown;
        }
        #endregion Constructors
        #region Properties
        public int? CustomFormContentId { get => _customFormContentId; }
        public int? CustomFormBodyId { get => _customFormBodyId; }
        public int? CustomColumId { get => _customColumId; }
        public string Contents { get => _contents; }
        public int? NoRown { get => _noRown; }
        #endregion Properties

        #region Behaviours

        public void SetCustomFormContentId(int? CustomFormContentId) { _customFormContentId = !CustomFormContentId.HasValue ? _customFormContentId : CustomFormContentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCustomFormBodyId(int? CustomFormBodyId) { _customFormBodyId = !CustomFormBodyId.HasValue ? _customFormBodyId : CustomFormBodyId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCustomColumId(int? CustomColumId) { _customColumId = !CustomColumId.HasValue ? _customColumId : CustomColumId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetContents(string Contents) { _contents = Contents == null ? _contents : Contents; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoRown(int? NoRown) { _noRown = !NoRown.HasValue ? _noRown : NoRown; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
