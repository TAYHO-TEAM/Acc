using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class ContractorInfo : DOBase
    {
        #region Fields
        private string _code;
        private string _taxCode;
        private string _avatarImg;
        private string _name;
        private string _descriptions;
        private string _businessAreas;
        private string _country;
        private string _city;
        private string _district;
        private string _address;
        private string _phone;
        private string _email;
        private byte[]? _image;
        #endregion Fields
        #region Constructors

        private ContractorInfo()
        {
        }

        public ContractorInfo(string Code,
                                string TaxCode,
                                string AvatarImg,
                                string Name,
                                string Descriptions,
                                string BusinessAreas,
                                string Country,
                                string City,
                                string District,
                                string Address,
                                string Phone,
                                string Email,
                                byte[]? Image) : this()
        {
            _code = Code;
            _taxCode = TaxCode;
            _avatarImg = AvatarImg;
            _name = Name;
            _descriptions = Descriptions;
            _businessAreas = BusinessAreas;
            _country = Country;
            _city = City;
            _district = District;
            _address = Address;
            _phone = Phone;
            _email = Email;
            _image = Image;
        }
        #endregion Constructors
        #region Properties
        [MaxLength(32, ErrorMessage = nameof(ErrorCodeInsert.IErr32))] public string Code { get => _code; }
        [MaxLength(64, ErrorMessage = nameof(ErrorCodeInsert.IErr64))] public string TaxCode { get => _taxCode; }
        [MaxLength(1028, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string AvatarImg { get => _avatarImg; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Name { get => _name; }
        public string Descriptions { get => _descriptions; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string BusinessAreas { get => _businessAreas; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Country { get => _country; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string City { get => _city; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string District { get => _district; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string Address { get => _address; }
        [MaxLength(15, ErrorMessage = nameof(ErrorCodeInsert.IErr32))] public string Phone { get => _phone; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Email { get => _email; }
        public byte[]? Image { get => _image; }
        #endregion Properties

        #region Behaviours
        public void SetCode(string Code) { _code = string.IsNullOrEmpty(Code) ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTaxCode(string TaxCode) { _taxCode = string.IsNullOrEmpty(TaxCode) ? _taxCode : TaxCode; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetAvatarImg(string AvatarImg) { _avatarImg = string.IsNullOrEmpty(AvatarImg) ? _avatarImg : AvatarImg; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetName(string Name) { _name = string.IsNullOrEmpty(Name) ? _name : Name; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescriptions(string Descriptions) { _descriptions = Descriptions == null ? _descriptions : Descriptions; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetBusinessAreas(string BusinessAreas) { _businessAreas = string.IsNullOrEmpty(BusinessAreas) ? _businessAreas : BusinessAreas; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCountry(string Country) { _country = string.IsNullOrEmpty(Country) ? _country : Country; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCity(string City) { _city = string.IsNullOrEmpty(City) ? _city : City; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDistrict(string District) { _district = string.IsNullOrEmpty(District) ? _district : District; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetAddress(string Address) { _address = string.IsNullOrEmpty(Address) ? _address : Address; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPhone(string Phone) { _phone = string.IsNullOrEmpty(Phone) ? _phone : Phone; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetEmail(string Email) { _email = string.IsNullOrEmpty(Email) ? _email : Email; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetImage(byte[]? Image) { _image = (Image == null)? _image : Image; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
