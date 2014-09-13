using System.Configuration;
using AutoMapper;
using Molibar.Framework.Configuration;
using Molibar.Framework.IoC;
using MongoDB.Driver;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using TescoHack.Data;
using TescoHack.Domain;

namespace TescoHack.Api.IoC
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<IRepository<Game>>();
                scan.AssemblyContainingType<Repository<Game>>();
                scan.AssemblyContainingType<FrameworkRegistry>();

                For(typeof(IRepository<>)).Use(typeof(Repository<>));

                //For<IApiProxy>().Singleton().UseSpecial(expression =>
                //{
                //    var userAgent = string.Format("{0} {1}",
                //        Config.Get("ApplicationName"), Config.Get("ApplicationVersion"));
                //    var logger = ObjectFactory.GetInstance<ILogger>();
                //    expression.Object(new ApiProxy(userAgent, logger));
                //});

                For<MongoDatabase>().Singleton().UseSpecial(expression =>
                {
                    var connectionstring = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
                    var url = new MongoUrl(connectionstring);
                    var client = new MongoClient(url);
                    var server = client.GetServer();
                    var database = server.GetDatabase(url.DatabaseName);

                    expression.Object(database);
                });

                scan.AddAllTypesOf<Profile>();
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.LookForRegistries();
            });
        }
    }
}