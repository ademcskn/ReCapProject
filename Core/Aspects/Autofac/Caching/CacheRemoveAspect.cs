using System;
using System.Linq;
using System.Text;
using Core.Utilities.IoC;
using Castle.DynamicProxy;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Utilities.Interceptors;
using Core.CrossCuttingConcerns.Caching;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
