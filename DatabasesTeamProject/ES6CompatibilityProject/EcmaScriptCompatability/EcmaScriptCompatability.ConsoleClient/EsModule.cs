using EcmaScriptCompatability.Contracts;
using EcmaScriptCompatability.Data;
using EcmaScriptCompatability.Repositories.EntityFramework;
using EcmaScriptCompatability.Service;
using EcmaScriptCompatability.Service.Contracts;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Conventions;
using System.IO;
using System.Reflection;
using EcmaScriptCompatability.Repositories.Contracts;

namespace EcmaScriptCompatability.ConsoleClient
{
    class EsModule : NinjectModule
    {

        public override void Load()
        {

            //Kernel.Bind(x =>
            //{
            //    x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            //    .SelectAllClasses()
            //    .BindDefaultInterface();
            //});


            Bind<IEcmaScriptDbContext>().To<EcmaScriptDbContext>().InSingletonScope();

            Kernel.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));

            Bind<IUnitOfWork>().To<EfUnitOfWork>();
            Bind<IEcmaScriptCompatabilityServices>().To<EcmaScriptCompatabilityServices>().InSingletonScope();
            Bind<IReportService>().To<ReportService>().InSingletonScope();

            
        }
    }
}
