using Newtonsoft.Json;

namespace CredoLoan.Core.Models
{
    public class CssFindPersonResponseModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("StatusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Result")]
        public Result Result { get; set; }
    }
    public class ContactList
    {
        [JsonProperty("ContactId")]
        public int ContactId { get; set; }

        [JsonProperty("PersonId")]
        public int PersonId { get; set; }

        [JsonProperty("ContactTypeId")]
        public int ContactTypeId { get; set; }

        [JsonProperty("ContactType")]
        public string ContactType { get; set; }

        [JsonProperty("Contact")]
        public string Contact { get; set; }

        [JsonProperty("BankSource")]
        public string BankSource { get; set; }

        [JsonProperty("IsSelected")]
        public bool IsSelected { get; set; }

        [JsonProperty("DateCreated")]
        public string DateCreated { get; set; }

        [JsonProperty("DateUpdated")]
        public string DateUpdated { get; set; }

        [JsonProperty("DateDeleted")]
        public object DateDeleted { get; set; }
    }

    public class DocumentList
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("PersonId")]
        public int PersonId { get; set; }

        [JsonProperty("PassportTypeId")]
        public int PassportTypeId { get; set; }

        [JsonProperty("PassportType")]
        public string PassportType { get; set; }

        [JsonProperty("PersonalN")]
        public string PersonalN { get; set; }

        [JsonProperty("PassportNumber")]
        public string PassportNumber { get; set; }

        [JsonProperty("PassportIssueAuthorityId")]
        public int PassportIssueAuthorityId { get; set; }

        [JsonProperty("PassportIssueAuthority")]
        public string PassportIssueAuthority { get; set; }

        [JsonProperty("PassportIssueDate")]
        public string PassportIssueDate { get; set; }

        [JsonProperty("PassportExpireDate")]
        public string PassportExpireDate { get; set; }

        [JsonProperty("DocumentIssuingCountryId")]
        public object DocumentIssuingCountryId { get; set; }

        [JsonProperty("DocumentIssuingCountry")]
        public object DocumentIssuingCountry { get; set; }

        [JsonProperty("DocumentStatusID")]
        public int DocumentStatusID { get; set; }

        [JsonProperty("DocumentStatus")]
        public string DocumentStatus { get; set; }

        [JsonProperty("DateOfCancellation")]
        public object DateOfCancellation { get; set; }

        [JsonProperty("PlaceOfBirth")]
        public string PlaceOfBirth { get; set; }

        [JsonProperty("AddDate")]
        public object AddDate { get; set; }

        [JsonProperty("Active")]
        public object Active { get; set; }

        [JsonProperty("IsDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("CountryId")]
        public object CountryId { get; set; }

        [JsonProperty("Country")]
        public object Country { get; set; }

        [JsonProperty("UpdateFromCra")]
        public object UpdateFromCra { get; set; }

        [JsonProperty("UpdateFromCraDate")]
        public object UpdateFromCraDate { get; set; }

        [JsonProperty("IsUnderRregistration")]
        public bool IsUnderRregistration { get; set; }

        [JsonProperty("BankSource")]
        public string BankSource { get; set; }

        [JsonProperty("IsSelected")]
        public bool IsSelected { get; set; }

        [JsonProperty("DateCreated")]
        public string DateCreated { get; set; }

        [JsonProperty("DateUpdated")]
        public object DateUpdated { get; set; }

        [JsonProperty("DateDeleted")]
        public object DateDeleted { get; set; }
    }

    public class Result
    {
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("FirstNameLat")]
        public string FirstNameLat { get; set; }

        [JsonProperty("LastNameLat")]
        public string LastNameLat { get; set; }

        [JsonProperty("BirthDate")]
        public string BirthDate { get; set; }

        [JsonProperty("BirthCountryId")]
        public int BirthCountryId { get; set; }

        [JsonProperty("BirthCountry")]
        public string BirthCountry { get; set; }

        [JsonProperty("CountryId")]
        public int CountryId { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("ResidentCountryId")]
        public int ResidentCountryId { get; set; }

        [JsonProperty("ResidentCountry")]
        public string ResidentCountry { get; set; }

        [JsonProperty("GenderId")]
        public int GenderId { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("PersonalN")]
        public string PersonalN { get; set; }

        [JsonProperty("Mobile")]
        public string Mobile { get; set; }

        [JsonProperty("CrPassword")]
        public object CrPassword { get; set; }

        [JsonProperty("isRegistration")]
        public object IsRegistration { get; set; }

        [JsonProperty("AgreeToCheckPersonalInfo")]
        public bool AgreeToCheckPersonalInfo { get; set; }

        [JsonProperty("PersonTypeId")]
        public int PersonTypeId { get; set; }

        [JsonProperty("PersonType")]
        public string PersonType { get; set; }

        [JsonProperty("TaxNumber")]
        public string TaxNumber { get; set; }

        [JsonProperty("DualCitizenshipCountryId")]
        public object DualCitizenshipCountryId { get; set; }

        [JsonProperty("DualCitizenshipCountry")]
        public object DualCitizenshipCountry { get; set; }

        [JsonProperty("MaritialStatusId")]
        public int MaritialStatusId { get; set; }

        [JsonProperty("MaritialStatus")]
        public string MaritialStatus { get; set; }

        [JsonProperty("OwnerOfGreenCard")]
        public bool OwnerOfGreenCard { get; set; }

        [JsonProperty("OwnerOfGreenCardName")]
        public string OwnerOfGreenCardName { get; set; }

        [JsonProperty("DependentPersons")]
        public int DependentPersons { get; set; }

        [JsonProperty("EmploymentStatusId")]
        public int EmploymentStatusId { get; set; }

        [JsonProperty("EmploymentStatus")]
        public string EmploymentStatus { get; set; }

        [JsonProperty("SmsLangId")]
        public int SmsLangId { get; set; }

        [JsonProperty("SmsLang")]
        public string SmsLang { get; set; }

        [JsonProperty("IsCredoEmployee")]
        public object IsCredoEmployee { get; set; }

        [JsonProperty("IsPEP")]
        public bool IsPEP { get; set; }

        [JsonProperty("IsPEPName")]
        public string IsPEPName { get; set; }

        [JsonProperty("DirectlyPoliticallyActiveName")]
        public object DirectlyPoliticallyActiveName { get; set; }

        [JsonProperty("SecretCode")]
        public string SecretCode { get; set; }

        [JsonProperty("AccountNumber")]
        public object AccountNumber { get; set; }

        [JsonProperty("AccountId")]
        public object AccountId { get; set; }

        [JsonProperty("BirthPalce")]
        public string BirthPalce { get; set; }

        [JsonProperty("DocumentList")]
        public List<DocumentList> DocumentList { get; set; }

        [JsonProperty("WorkingPlaceList")]
        public object WorkingPlaceList { get; set; }

        [JsonProperty("CurrencyIdList")]
        public object CurrencyIdList { get; set; }

        [JsonProperty("RegionId")]
        public int RegionId { get; set; }

        [JsonProperty("EbAccountId")]
        public int EbAccountId { get; set; }

        [JsonProperty("EbDependPerson")]
        public object EbDependPerson { get; set; }

        [JsonProperty("TarrifId")]
        public int TarrifId { get; set; }

        [JsonProperty("EbankStatusId")]
        public int EbankStatusId { get; set; }

        [JsonProperty("T24AccountId")]
        public object T24AccountId { get; set; }

        [JsonProperty("PeriodicalTypeId")]
        public object PeriodicalTypeId { get; set; }

        [JsonProperty("JointTableRecordId")]
        public object JointTableRecordId { get; set; }

        [JsonProperty("IsCredoPartner")]
        public bool IsCredoPartner { get; set; }

        [JsonProperty("RegistrationLegalDate")]
        public object RegistrationLegalDate { get; set; }

        [JsonProperty("KYCChannel")]
        public string KYCChannel { get; set; }

        [JsonProperty("ImageData")]
        public object ImageData { get; set; }

        [JsonProperty("JointAccountPerson")]
        public object JointAccountPerson { get; set; }

        [JsonProperty("BusinessRelationshipTypeList")]
        public object BusinessRelationshipTypeList { get; set; }

        [JsonProperty("Region")]
        public string Region { get; set; }

        [JsonProperty("InitialStartDate")]
        public object InitialStartDate { get; set; }

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Cif")]
        public int Cif { get; set; }

        [JsonProperty("RegisterDate")]
        public string RegisterDate { get; set; }

        [JsonProperty("BranchId")]
        public int BranchId { get; set; }

        [JsonProperty("Branch")]
        public string Branch { get; set; }

        [JsonProperty("UserId")]
        public int UserId { get; set; }

        [JsonProperty("User")]
        public string User { get; set; }

        [JsonProperty("ResponsibleUserId")]
        public int ResponsibleUserId { get; set; }

        [JsonProperty("ResponsibleUser")]
        public string ResponsibleUser { get; set; }

        [JsonProperty("BusinessTypeId")]
        public int BusinessTypeId { get; set; }

        [JsonProperty("BusinessType")]
        public string BusinessType { get; set; }

        [JsonProperty("ClientStatusId")]
        public int ClientStatusId { get; set; }

        [JsonProperty("ClientStatus")]
        public string ClientStatus { get; set; }

        [JsonProperty("AuthorizationLevelId")]
        public int AuthorizationLevelId { get; set; }

        [JsonProperty("AuthorizationLevel")]
        public string AuthorizationLevel { get; set; }

        [JsonProperty("DormantStatusId")]
        public int DormantStatusId { get; set; }

        [JsonProperty("DormantStatus")]
        public string DormantStatus { get; set; }

        [JsonProperty("KYCStatusId")]
        public int KYCStatusId { get; set; }

        [JsonProperty("KYCStatus")]
        public string KYCStatus { get; set; }

        [JsonProperty("AMLRisk")]
        public object AMLRisk { get; set; }

        [JsonProperty("PersonStatusId")]
        public int PersonStatusId { get; set; }

        [JsonProperty("PersonStatus")]
        public string PersonStatus { get; set; }

        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("AddressCountryId")]
        public int AddressCountryId { get; set; }

        [JsonProperty("AddressCountry")]
        public string AddressCountry { get; set; }

        [JsonProperty("AddressCityId")]
        public int AddressCityId { get; set; }

        [JsonProperty("AddressCity")]
        public string AddressCity { get; set; }

        [JsonProperty("AddressZipCode")]
        public string AddressZipCode { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("AddressLat")]
        public string AddressLat { get; set; }

        [JsonProperty("AnnualTurnoverInCredo")]
        public string AnnualTurnoverInCredo { get; set; }

        [JsonProperty("AnnualTurnoverInCredoId")]
        public int AnnualTurnoverInCredoId { get; set; }

        [JsonProperty("FullAddress")]
        public string FullAddress { get; set; }

        [JsonProperty("LegalAddressCountryId")]
        public int LegalAddressCountryId { get; set; }

        [JsonProperty("LegalAddressCountry")]
        public string LegalAddressCountry { get; set; }

        [JsonProperty("LegalAddressCityId")]
        public object LegalAddressCityId { get; set; }

        [JsonProperty("LegalAddressCity")]
        public string LegalAddressCity { get; set; }

        [JsonProperty("LegalAddressZipCode")]
        public string LegalAddressZipCode { get; set; }

        [JsonProperty("LegalAddress")]
        public string LegalAddress { get; set; }

        [JsonProperty("LegalAddressLat")]
        public string LegalAddressLat { get; set; }

        [JsonProperty("FullLegalAddress")]
        public string FullLegalAddress { get; set; }

        [JsonProperty("CopyLegalAddress")]
        public bool CopyLegalAddress { get; set; }

        [JsonProperty("PersonIndustryComment")]
        public object PersonIndustryComment { get; set; }

        [JsonProperty("IncomeSourceID")]
        public object IncomeSourceID { get; set; }

        [JsonProperty("IncomeAmountID")]
        public object IncomeAmountID { get; set; }

        [JsonProperty("IncomeSource")]
        public object IncomeSource { get; set; }

        [JsonProperty("IncomeAmount")]
        public object IncomeAmount { get; set; }

        [JsonProperty("IncomeComment")]
        public object IncomeComment { get; set; }

        [JsonProperty("BusinessRelationshipTypeNames")]
        public object BusinessRelationshipTypeNames { get; set; }

        [JsonProperty("BusinessRelationshipType")]
        public object BusinessRelationshipType { get; set; }

        [JsonProperty("BusinessRelationshipComment")]
        public string BusinessRelationshipComment { get; set; }

        [JsonProperty("PositionHeld")]
        public object PositionHeld { get; set; }

        [JsonProperty("RelatedToCredoClient")]
        public object RelatedToCredoClient { get; set; }

        [JsonProperty("PEPProperty")]
        public object PEPProperty { get; set; }

        [JsonProperty("PEPNetAnnualIncome")]
        public object PEPNetAnnualIncome { get; set; }

        [JsonProperty("PEPPersonFullName")]
        public object PEPPersonFullName { get; set; }

        [JsonProperty("SectorId")]
        public int SectorId { get; set; }

        [JsonProperty("DirectlyPoliticallyActive")]
        public object DirectlyPoliticallyActive { get; set; }

        [JsonProperty("Sector")]
        public string Sector { get; set; }

        [JsonProperty("SectorIndustryComment")]
        public object SectorIndustryComment { get; set; }

        [JsonProperty("IndustryId")]
        public int IndustryId { get; set; }

        [JsonProperty("Industry")]
        public string Industry { get; set; }

        [JsonProperty("AmlClasificatorId")]
        public int AmlClasificatorId { get; set; }

        [JsonProperty("AmlClasificator")]
        public string AmlClasificator { get; set; }

        [JsonProperty("InsiderTypeId")]
        public object InsiderTypeId { get; set; }

        [JsonProperty("InsiderType")]
        public object InsiderType { get; set; }

        [JsonProperty("CredoSegmentId")]
        public object CredoSegmentId { get; set; }

        [JsonProperty("CredoSegment")]
        public object CredoSegment { get; set; }

        [JsonProperty("TariffId")]
        public int TariffId { get; set; }

        [JsonProperty("Tariff")]
        public string Tariff { get; set; }

        [JsonProperty("KYCFirstDate")]
        public object KYCFirstDate { get; set; }

        [JsonProperty("KYCLastDate")]
        public string KYCLastDate { get; set; }

        [JsonProperty("KYCNextDate")]
        public string KYCNextDate { get; set; }

        [JsonProperty("FullName")]
        public object FullName { get; set; }

        [JsonProperty("Restriction")]
        public int Restriction { get; set; }

        [JsonProperty("BankerUserId")]
        public object BankerUserId { get; set; }

        [JsonProperty("BankerUser")]
        public object BankerUser { get; set; }

        [JsonProperty("ActivePerson")]
        public int ActivePerson { get; set; }

        [JsonProperty("IsCurrentActiveCredoEmployee")]
        public object IsCurrentActiveCredoEmployee { get; set; }

        [JsonProperty("Fatca")]
        public object Fatca { get; set; }

        [JsonProperty("ContactList")]
        public List<ContactList> ContactList { get; set; }

        [JsonProperty("CommentList")]
        public object CommentList { get; set; }

        [JsonProperty("ConnectedPersonList")]
        public object ConnectedPersonList { get; set; }

        [JsonProperty("ConnectedPeopleList")]
        public object ConnectedPeopleList { get; set; }

        [JsonProperty("AttachmentList")]
        public object AttachmentList { get; set; }

        [JsonProperty("SectorIndustryList")]
        public object SectorIndustryList { get; set; }

        [JsonProperty("PersonIncomeList")]
        public object PersonIncomeList { get; set; }

        [JsonProperty("PepPersonInfo")]
        public object PepPersonInfo { get; set; }

        [JsonProperty("ChannelTypeId")]
        public int ChannelTypeId { get; set; }

        [JsonProperty("Email")]
        public object Email { get; set; }

        [JsonProperty("UdateFromCra")]
        public bool UdateFromCra { get; set; }

        [JsonProperty("IsCurrentUpdatedFromCra")]
        public bool IsCurrentUpdatedFromCra { get; set; }

        [JsonProperty("IsInPayroll")]
        public bool IsInPayroll { get; set; }

        [JsonProperty("PayRollAgreementFile")]
        public object PayRollAgreementFile { get; set; }

        [JsonProperty("PayrollRateId")]
        public object PayrollRateId { get; set; }

        [JsonProperty("PayrollRateName")]
        public object PayrollRateName { get; set; }

        [JsonProperty("EmployedPersonList")]
        public object EmployedPersonList { get; set; }

        [JsonProperty("SDAlogIds")]
        public object SDAlogIds { get; set; }

        [JsonProperty("DistrictId")]
        public object DistrictId { get; set; }

        [JsonProperty("District")]
        public object District { get; set; }

        [JsonProperty("LegalDistrictId")]
        public object LegalDistrictId { get; set; }

        [JsonProperty("LegalDistrict")]
        public object LegalDistrict { get; set; }

        [JsonProperty("PersonalNumber")]
        public object PersonalNumber { get; set; }

        [JsonProperty("JointAccountPersonId")]
        public object JointAccountPersonId { get; set; }

        [JsonProperty("JointAccountFullName")]
        public object JointAccountFullName { get; set; }

        [JsonProperty("IsDigitalOnBoarding")]
        public bool IsDigitalOnBoarding { get; set; }

        [JsonProperty("BankSource")]
        public string BankSource { get; set; }

        [JsonProperty("IsSelected")]
        public bool IsSelected { get; set; }
    }
}
