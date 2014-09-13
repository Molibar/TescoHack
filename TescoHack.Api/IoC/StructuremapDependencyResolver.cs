using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using StructureMap;

namespace TescoHack.Api.IoC
{
    public class StructuremapDependencyResolver : IDependencyResolver
    {
        private readonly Container _container;

        public StructuremapDependencyResolver(Container container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.GetInstance(serviceType) as IHttpController;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances<object>().Where(s => s.GetType() == serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // release other disposable objects
                if (_container != null) _container.Dispose();
            }
        }

        ~StructuremapDependencyResolver()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}