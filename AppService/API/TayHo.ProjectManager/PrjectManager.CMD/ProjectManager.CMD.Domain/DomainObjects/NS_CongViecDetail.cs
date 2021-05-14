using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_CongViecDetail : DOBase
    {
        #region Fields
        private int? _congViecId;
        private int? _reasonId;
        private int? _giaiDoanId;
        private decimal? _donGia;
        private decimal? _khoiLuong;
        #endregion Fields

        #region Constructors
        private NS_CongViecDetail()
        {
        }

        public NS_CongViecDetail(
            int? CongViecId,
            int? ReasonId,
            int? GiaiDoanId,
            decimal? DonGia,
            decimal? KhoiLuong) : this()
        {
            _congViecId = CongViecId;
            _giaiDoanId = GiaiDoanId;
            _reasonId = ReasonId;
            _donGia = DonGia;
            _khoiLuong = KhoiLuong;
        }
        #endregion Constructors

        #region Properties
        public int? CongViecId { get => _congViecId; }
        public int? ReasonId { get => _reasonId; }
        public int? GiaiDoanId { get => _giaiDoanId; }
        public decimal? DonGia { get => _donGia; }
        public decimal? KhoiLuong { get => _khoiLuong; }
        #endregion Properties

        #region Behaviours
        public void SetCongViecId(int? CongViecId) { _congViecId = !CongViecId.HasValue ? _congViecId : CongViecId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetReasonId(int? ReasonId) { _reasonId = !ReasonId.HasValue ? _reasonId : ReasonId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaiDoanId(int? GiaiDoanId) { _giaiDoanId = !GiaiDoanId.HasValue ? _giaiDoanId : GiaiDoanId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDonGia(decimal? DonGia) { _donGia = !DonGia.HasValue ? _donGia : DonGia; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetKhoiLuong(decimal? KhoiLuong) { _khoiLuong = !KhoiLuong.HasValue ? _khoiLuong : KhoiLuong; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
