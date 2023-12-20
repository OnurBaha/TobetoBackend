﻿using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Context;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TobetoContext>(options => options.UseSqlServer(configuration.GetConnectionString("Tobeto")));

            services.AddScoped<ICourseDal, EfCourseDal>();
            services.AddScoped<IUserDal,EfUserDal>();
            services.AddScoped<IExamDal, EfExamDal>();
            services.AddScoped<IStudentDal, EfStudentDal>();
            services.AddScoped<IInstructorDal, EfInstructorDal>();
            services.AddScoped<IMediaPostDal, EfMediaPostDal>();
            services.AddScoped<IBlogDal, EfBlogDal>();
            services.AddScoped<ISurveyDal, EfSurveyDal>();
            services.AddScoped<ISubjectDal, EfSubjectDal>();
            services.AddScoped<IExamDal, EfExamDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IStudentCourseDal, EfStudentCourseDal>();
            services.AddScoped<IPaymentDal, EfPaymentDal>();
            services.AddScoped<IManagerDal, EfManagerDal>();
            services.AddScoped<ICertificateDal, EfCertificateDal>();
            services.AddScoped<ILanguageDal, EfLanguageDal>();
            services.AddScoped<ISocialMediaAccountDal, EfSocialMediaAccountDal>();
            services.AddScoped<IApplicationDal, EfApplicationDal>();
            services.AddScoped<IRoleDal, EfRoleDal>();
            services.AddScoped<ILanguageLevelDal, EfLanguageLevelDal>();




            return services;
        }
    }
}
