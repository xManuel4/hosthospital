using AutoMapper;
using Internetbaking.Core.Application.Dtos.Account;
using Internetbanking.Core.Application.Dtos.Account;
using Internetbanking.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internetbanking.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<RegisterRequest, SaveUserViewnModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
               .ForMember(x => x.HasError, opt => opt.Ignore())
               .ForMember(x => x.Error, opt => opt.Ignore())
               .ReverseMap();


            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
             .ForMember(x => x.HasError, opt => opt.Ignore())
             .ForMember(x => x.Error, opt => opt.Ignore())
             .ReverseMap();
 



        }

    }
}
