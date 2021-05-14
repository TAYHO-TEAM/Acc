using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_KhauTru : DOBase
    {
        #region Fields
        private int? _goiThauId;
        private int? _projectId;
        private string _noiDung;
        private string _dienGiai;
        private decimal? _giaTri;
        private decimal? _giaTriCon;
        #endregion Fields

        #region Constructors
        private NS_KhauTru()
        {
        }

        public NS_KhauTru(int? GoiThauId,int? ProjectId,
            string NoiDung,
            string DienGiai,
            decimal? GiaTri,
            decimal? GiaTriCon) : this()
        {
            _goiThauId = GoiThauId;
            _projectId = ProjectId;
            _noiDung = NoiDung;
            _dienGiai = DienGiai;
            _giaTri = GiaTri;
            _giaTriCon = GiaTriCon;
        }
        #endregion Constructors

        #region Properties
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? GoiThauId { get => _goiThauId; }
        public int? ProjectId { get => _projectId; }
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string NoiDung { get => _noiDung; }
        public string DienGiai { get => _dienGiai; }
        public decimal? GiaTri { get => _giaTri; }
        public decimal? GiaTriCon { get => _giaTriCon; }
        #endregion Properties

        #region Behaviours
        public void SetGoiThauId(int? GoiThauId) { _goiThauId = !GoiThauId.HasValue ? _goiThauId : GoiThauId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProjectId(int? ProjectId) { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoiDung(string NoiDung) { _noiDung = NoiDung == null ? _noiDung : NoiDung; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai) { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaTri(decimal? GiaTri) { _giaTri = !GiaTri.HasValue ? _giaTri : GiaTri; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaTriCon(decimal? GiaTriCon) { _giaTriCon = !GiaTriCon.HasValue ? _giaTriCon : GiaTriCon; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
