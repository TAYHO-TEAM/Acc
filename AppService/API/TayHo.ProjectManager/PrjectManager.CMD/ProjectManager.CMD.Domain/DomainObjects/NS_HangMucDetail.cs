using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_HangMucDetail : DOBase
    {
        #region Fields
        private int? _hangMucId;
        private int? _projectId;
        private int? _giaiDoanId;
        private decimal? _giaTri;
        #endregion Fields

        #region Constructors
        private NS_HangMucDetail()
        {
        }

        public NS_HangMucDetail(
            int? HangMucId,
            int? ProjectId,
            int? GiaiDoanId,
            decimal? GiaTri) : this()
        {
            _hangMucId = HangMucId;
            _projectId = ProjectId;
            _giaiDoanId = GiaiDoanId;
            _giaTri = GiaTri;
        }
        #endregion Constructors

        #region Properties
        public int? HangMucId { get => _hangMucId; }
        public int? ProjectId { get => _projectId; }
        public int? GiaiDoanId { get => _giaiDoanId; }
        public decimal? GiaTri { get => _giaTri; }
        #endregion Properties

        #region Behaviours
        public void SetHangMucId(int? HangMucId) { _hangMucId = !HangMucId.HasValue ? _hangMucId : HangMucId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProjectId(int? ProjectId) { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaiDoanId(int? GiaiDoanId) { _giaiDoanId = !GiaiDoanId.HasValue ? _giaiDoanId : GiaiDoanId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaTri(decimal? GiaTri) { _giaTri = !GiaTri.HasValue ? _giaTri : GiaTri; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
