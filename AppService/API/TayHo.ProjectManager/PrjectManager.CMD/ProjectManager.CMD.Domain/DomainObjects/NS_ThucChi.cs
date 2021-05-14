using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_ThucChi : DOBase
    {
        #region Fields
        private int? _nhomCongViecId;
        private int? _goiThauId;
        private string _thangBaoCao;
        private string _thangThucChi;
        private decimal? _giaTri;
        #endregion Fields

        #region Constructors
        private NS_ThucChi()
        {
        }

        public NS_ThucChi(
            int? NhomCongViecId,
            int? GoiThauId,
            string ThangBaoCao,
            string ThangThucChi,
            decimal? GiaTri) : this()
        {
            _nhomCongViecId = NhomCongViecId;
            _goiThauId = GoiThauId;
            _thangBaoCao = ThangBaoCao;
            _thangThucChi = ThangThucChi;
            _giaTri = GiaTri;
        }
        #endregion Constructors

        #region Properties
        public int? NhomCongViecId { get => _nhomCongViecId; }
        public int? GoiThauId { get => _goiThauId; }
        [MaxLength(100, ErrorMessage = nameof(ErrorCodeInsert.IErr100))] public string ThangBaoCao { get => _thangBaoCao; }
        [MaxLength(100, ErrorMessage = nameof(ErrorCodeInsert.IErr100))] public string ThangThucChi { get => _thangThucChi; }
        public decimal? GiaTri { get => _giaTri; }
        #endregion Properties

        #region Behaviours
        public void SetNhomCongViecId(int? NhomCongViecId) { _nhomCongViecId = !NhomCongViecId.HasValue ? _nhomCongViecId : NhomCongViecId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGoiThauId(int? GoiThauId) { _goiThauId = !GoiThauId.HasValue ? _goiThauId : GoiThauId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetThangBaoCao(string ThangBaoCao) { _thangBaoCao = ThangBaoCao == null ? _thangBaoCao : ThangBaoCao; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetThangThucChi(string ThangThucChi) { _thangThucChi = ThangThucChi == null ? _thangThucChi : ThangThucChi; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaTri(decimal? GiaTri) { _giaTri = !GiaTri.HasValue ? _giaTri : GiaTri; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
