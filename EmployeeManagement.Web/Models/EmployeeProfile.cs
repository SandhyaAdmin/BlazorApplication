﻿using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Pages;

namespace EmployeeManagement.Web.Models
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EditEmployeeModel>()
                        .ForMember(dest => dest.ConfirmEmail,
                                    opt => opt.MapFrom(src => src.Email)
                                   );
            CreateMap<EditEmployeeModel, Employee>();
        }
    }
}
