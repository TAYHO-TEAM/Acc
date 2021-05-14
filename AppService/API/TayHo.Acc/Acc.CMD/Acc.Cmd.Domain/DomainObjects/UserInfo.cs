using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;


namespace Acc.Cmd.Domain.DomainObjects
{
    public class UserInfo : DOBase
    {
        #region Fields
        private string _avatarImg;
        private string _firstName;
        private string _lastName;
        private byte? _sex;
        private DateTime? _dateOfBirth;
        private string _country;
        private string _city;
        private string _district;
        private string _address;
        private string _phone;
        private string _email;
        #endregion Fields
        #region Constructors

        private UserInfo()
        {
        }

        public UserInfo(string FirstName, string LastName, byte? Sex, DateTime? DateOfBirth, string Country, string City, string District, string Address, string Phone, string Email) : this()
        {
            _firstName = FirstName;
            _lastName = LastName;
            _sex = Sex;
            _dateOfBirth = DateOfBirth;
            _country = Country;
            _city = City;
            _district = District;
            _address = Address;
            _phone = Phone;
            _email = Email;

        }
        #endregion Constructors
        #region Properties
        [MaxLength(1024, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string AvatarImg { get => _avatarImg; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))]
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))]
        public string FirstName { get => _firstName; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))]
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))]
        public string LastName { get => _lastName; }
        public byte? Sex { get => _sex; }
        public DateTime? DateOfBirth { get => _dateOfBirth; }
        public string Country { get => _country; }
        public string City { get => _city; }
        public string District { get => _district; }
        public string Address { get => _address; }
        public string Phone { get => _phone; }
        public string Email { get => _email; }
        #endregion Properties

        #region Behaviours
        public void SetFirstName(string firstName)
        {
            _firstName = string.IsNullOrEmpty(firstName) ? _firstName : firstName;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public void SetLastName(string lastName)
        {
            _lastName = string.IsNullOrEmpty(lastName) ? _lastName : lastName;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public void SetSex(byte? sex)
        {
            _sex = sex.HasValue? sex:_sex;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public void SetDateOfBirth(DateTime? dateOfBirth)
        {
            _dateOfBirth = dateOfBirth.HasValue? dateOfBirth: _dateOfBirth;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public void SetCountry(string country)
        {
            _country = string.IsNullOrEmpty(country) ? _country : country;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public void SetCity(string city)
        {
            _city = string.IsNullOrEmpty(city) ? _city : city;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public void SetDistrict(string district)
        {
            _district = string.IsNullOrEmpty(district) ? _district : district;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public void SetAddress(string address)
        {
           _address = string.IsNullOrEmpty(address)? _address: address;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public void SetPhone(string phone)
        {
            _phone = string.IsNullOrEmpty(phone) ? _phone : phone;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public void SetEmail(string email)
        {
            _email = string.IsNullOrEmpty(email) ? _email : email;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
