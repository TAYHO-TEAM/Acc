using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_GiaiDoan : DOBase
    {
        #region Fields

        private string _tenGiaiDoan;
        private string _dienGiai;
        private int? _projectId;
        private int? _groupId;
        private string _capDo;
        private int? _sortIndex;


        #endregion Fields
        #region Constructors

        private NS_GiaiDoan()
        {
        }

        public NS_GiaiDoan(string TenGiaiDoan, string DienGiai, int? ProjectId, int? GroupId, string CapDo, int? SortIndex) : this()
        {
            _tenGiaiDoan = TenGiaiDoan;
            _dienGiai = DienGiai;
            _projectId = ProjectId;
            _groupId = GroupId;
            _capDo = CapDo;
            _sortIndex = SortIndex;

        }

        #endregion Constructors
        #region Properties

        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string TenGiaiDoan { get => _tenGiaiDoan; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string DienGiai { get => _dienGiai; }
        public int? ProjectId { get => _projectId; }
        public int? GroupId { get => _groupId; }
        [MaxLength(10, ErrorMessage = nameof(ErrorCodeInsert.IErr10))] public string CapDo { get => _capDo; }
        public int? SortIndex { get => _sortIndex; }


        #endregion Properties
        #region Behaviours

        public void SetTenGiaiDoan(string TenGiaiDoan)
        { _tenGiaiDoan = TenGiaiDoan == null ? _tenGiaiDoan : TenGiaiDoan; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai)
        { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProjectId(int? ProjectId)
        { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGroupId(int? GroupId)
        { _groupId = !GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCapDo(string CapDo)
        { _capDo = CapDo == null ? _capDo : CapDo; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetSortIndex(int? SortIndex)
        { _sortIndex = !SortIndex.HasValue ? _sortIndex : SortIndex; if (!IsValid()) throw new DomainException(_errorMessages); }


        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
