using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_HangMuc : DOBase
    {
        #region Fields
        private int? _parentId;
        private string _tenHangMuc;
        private string _kyHieu;
        private int? _projectId;
        #endregion Fields

        #region Constructors
        private NS_HangMuc()
        {
        }

        public NS_HangMuc(int? ParentId,
string TenHangMuc,
string KyHieu,
int? ProjectId) : this()
        {
            _parentId = ParentId;
            _tenHangMuc = TenHangMuc;
            _kyHieu = KyHieu;
            _projectId = ProjectId;
        }
        #endregion Constructors

        #region Properties
        public int? ParentId { get => _parentId; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string TenHangMuc { get => _tenHangMuc; }
        [MaxLength(50, ErrorMessage = nameof(ErrorCodeInsert.IErr50))] public string KyHieu { get => _kyHieu; }
        public int? ProjectId { get => _projectId; }
        #endregion Properties

        #region Behaviours
        public void SetParentId(int? ParentId) { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTenHangMuc(string TenHangMuc) { _tenHangMuc = TenHangMuc == null ? _tenHangMuc : TenHangMuc; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetKyHieu(string KyHieu) { _kyHieu = KyHieu == null ? _kyHieu : KyHieu; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProjectId(int? ProjectId) { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
