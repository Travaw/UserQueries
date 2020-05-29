using AutoMapper;
using Ninject.Modules;
using ProgCentrTestTask.Application;
using ProgCentrTestTask.Application.Services;
using System.Web.ModelBinding;

namespace ProgCentrTestTask.Web.App_Start
{
    public class DIConfig: NinjectModule
    {
        public override void Load()
        {            
            Bind<IQueryService>().To<QueryService>();
            Bind<IUserService>().To<UserService>();

            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();
            Bind<IMapper>().ToMethod(ctx => new Mapper(mapperConfiguration));
            Unbind<ModelValidatorProvider>();
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(QueriesAppModule).Assembly, typeof(MvcApplication).Assembly);//
            });

            return config;
        }
    }
}