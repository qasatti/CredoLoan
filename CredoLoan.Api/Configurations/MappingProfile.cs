using AutoMapper;
using CredoLoan.Api.ViewModels;
using CredoLoan.Core.Models;
using CredoLoan.Data.Entities;

namespace CredoLoan.Api.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SignInViewModel, SignInModel>();
            CreateMap<SignUpViewModel, SignUpModel>();
            CreateMap<SignUpModel, Client>();

            CreateMap<CreateLoanApplicationViewModel, CreateLoanApplicationModel>();
            CreateMap<CreateLoanApplicationModel, LoanApplication>();
            CreateMap<EditLoanApplicationViewModel, EditLoanApplicationModel>();
            CreateMap<EditLoanApplicationModel, LoanApplication>();

            CreateMap<LoanApplication, DetailLoanApplicationResponseModel>()
                .ForMember(dest => dest.AppliedByClientId, opt => opt.MapFrom(src => src.AppliedBy.Id))
                .ForMember(dest => dest.AppliedByClientUserName, opt => opt.MapFrom(src => src.AppliedBy.UserName));

        }
    }
}
