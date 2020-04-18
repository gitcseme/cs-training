using Autofac;
using SMS.Data.Repositories;
using SMS.Data.Services;
using SMS.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Data
{
    public class SchoolModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public SchoolModule(string connectionString, string migrationAssemblyname)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyname;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SchoolContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentRepository>()
                .As<IStudentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseRepository>()
                .As<ICourseRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TopicRepository>()
                .As<ITopicRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentUnitOfWork>()
                .As<IStudentUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseUnitOfWork>()
                .As<ICourseUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TopicUnitOfWork>()
                .As<ITopicUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentService>()
                .As<IStudentService>()
                .SingleInstance();
        }
    }
}
