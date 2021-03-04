using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_DuChi : DOBase
    {
        #region Fields
        private int? _projectId;
        private int? _nhomCongViecId;
        private int? _groupId;
        private DateTime? _thoiGianBaoCao;
        private DateTime? _thoiGianDuChi;
        private decimal? _giaTri;
        #endregion Fields

        #region Constructors
        private NS_DuChi()
        {
        }

        public NS_DuChi(
            int? ProjectId,
            int? NhomCongViecId,
            int? GroupId,
            DateTime? ThoiGianBaoCao,
            DateTime? ThoiGianDuChi,
            decimal? GiaTri) : this()
        {
            _projectId = ProjectId;
            _nhomCongViecId = NhomCongViecId;
            _groupId = GroupId;
            _thoiGianBaoCao = ThoiGianBaoCao;
            _thoiGianDuChi = ThoiGianDuChi;
            _giaTri = GiaTri;
        }
        #endregion Constructors

        #region Properties
        public int? ProjectId { get => _projectId; }
        public int? NhomCongViecId { get => _nhomCongViecId; }
        public int? GroupId { get => _groupId; }
        public DateTime? ThoiGianBaoCao { get => _thoiGianBaoCao; }
        public DateTime? ThoiGianDuChi { get => _thoiGianDuChi; }
        public decimal? GiaTri { get => _giaTri; }
        #endregion Properties

        #region Behaviours
        public void SetProjectId(int? ProjectId) { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNhomCongViecId(int? NhomCongViecId) { _nhomCongViecId = !NhomCongViecId.HasValue ? _nhomCongViecId : NhomCongViecId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGroupId(int? GroupId) { _groupId = !GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetThoiGianBaoCao(DateTime? ThoiGianBaoCao) { _thoiGianBaoCao = !ThoiGianBaoCao.HasValue ? _thoiGianBaoCao : ThoiGianBaoCao; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetThoiGianDuChi(DateTime? ThoiGianDuChi) { _thoiGianDuChi = !ThoiGianDuChi.HasValue ? _thoiGianDuChi : ThoiGianDuChi; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaTri(decimal? GiaTri) { _giaTri = !GiaTri.HasValue ? _giaTri : GiaTri; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
