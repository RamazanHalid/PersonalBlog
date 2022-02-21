using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<BlogCategoryManager>().As<IBlogCategoryService>();
            builder.RegisterType<EfBlogCategoryDal>().As<IBlogCategoryDal>();


            builder.RegisterType<BlogManager>().As<IBlogService>();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>();

            builder.RegisterType<WhatIDoManager>().As<IWhatIDoService>();
            builder.RegisterType<EfWhatIDoDal>().As<IWhatIDoDal>();

            builder.RegisterType<EducationManager>().As<IEducationService>();
            builder.RegisterType<EfEducationDal>().As<IEducationDal>();

            builder.RegisterType<ExperienceManager>().As<IExperienceService>();
            builder.RegisterType<EfExperienceDal>().As<IExperienceDal>();

            builder.RegisterType<ProjectManager>().As<IProjectService>();
            builder.RegisterType<EfProjectDal>().As<IProjectDal>();


            builder.RegisterType<ContactManager>().As<IContactService>();
            builder.RegisterType<EfContactDal>().As<IContactDal>();


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
