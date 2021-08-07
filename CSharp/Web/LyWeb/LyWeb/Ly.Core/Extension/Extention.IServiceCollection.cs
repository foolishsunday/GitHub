using AutoMapper;
using Castle.DynamicProxy;
using Ly.Core.AOP;
using Ly.Core.Primitives;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Core
{
    public static partial class Extention
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator();
        public static IServiceCollection AddAutoMapper(this IServiceCollection services, Action<IMapperConfigurationExpression> configure = null)
        {
            List<(Type from, Type[] targets)> maps = new List<(Type from, Type[] targets)>();

            maps.AddRange(GlobalAssemblies.AllTypes.Where(x => x.GetCustomAttribute<MapAttribute>() != null)
                .Select(x => (x, x.GetCustomAttribute<MapAttribute>().TargetTypes)));

            var configuration = new MapperConfiguration(cfg =>
            {
                maps.ForEach(aMap =>
                {
                    aMap.targets.ToList().ForEach(aTarget =>
                    {
                        cfg.CreateMap(aMap.from, aTarget).IgnoreAllNonExisting(aMap.from, aTarget).ReverseMap();
                    });
                });

                cfg.AddMaps(GlobalAssemblies.AllAssemblies);

                //自定义映射
                configure?.Invoke(cfg);
            });

#if DEBUG
            //只在Debug时检查配置
            configuration.AssertConfigurationIsValid();
#endif
            services.AddSingleton(configuration.CreateMapper());

            return services;
        }

        /// <summary>
        /// 自动注入拥有ITransientDependency,IScopeDependency或ISingletonDependency的类
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <returns></returns>
        public static IServiceCollection AddFxServices(this IServiceCollection services)
        {
            Dictionary<Type, ServiceLifetime> lifeTimeMap = new Dictionary<Type, ServiceLifetime>
            {
                { typeof(ITransientDependency), ServiceLifetime.Transient},
                { typeof(IScopedDependency),ServiceLifetime.Scoped},
                { typeof(ISingletonDependency),ServiceLifetime.Singleton}
            };

            GlobalAssemblies.AllTypes.ForEach(aType =>
            {
                lifeTimeMap.ToList().ForEach(aMap =>
                {
                    var theDependency = aMap.Key;
                    if (theDependency.IsAssignableFrom(aType) && theDependency != aType && !aType.IsAbstract && aType.IsClass)
                    {
                        //注入实现
                        services.Add(new ServiceDescriptor(aType, aType, aMap.Value));

                        var interfaces = GlobalAssemblies.AllTypes.Where(x => x.IsAssignableFrom(aType) && x.IsInterface && x != theDependency).ToList();
                        //有接口则注入接口
                        if (interfaces.Count > 0)
                        {
                            interfaces.ForEach(aInterface =>
                            {
                                //注入AOP
                                services.Add(new ServiceDescriptor(aInterface, serviceProvider =>
                                {
                                    CastleInterceptor castleInterceptor = new CastleInterceptor(serviceProvider);

                                    return _generator.CreateInterfaceProxyWithTarget(aInterface, serviceProvider.GetService(aType), castleInterceptor);
                                }, aMap.Value));
                            });
                        }
                        //无接口则注入自己
                        else
                        {
                            services.Add(new ServiceDescriptor(aType, aType, aMap.Value));
                        }
                    }
                });
            });

            return services;
        }
        /// <summary>
        /// 给IEnumerable拓展ForEach方法
        /// </summary>
        /// <typeparam name="T">模型类</typeparam>
        /// <param name="iEnumberable">数据源</param>
        /// <param name="func">方法</param>
        public static void ForEach<T>(this IEnumerable<T> iEnumberable, Action<T> func)
        {
            foreach (var item in iEnumberable)
            {
                func(item);
            }
        }
        /// <summary>
        /// 忽略所有不匹配的属性。
        /// </summary>
        /// <param name="expression">配置表达式</param>
        /// <param name="from">源类型</param>
        /// <param name="to">目标类型</param>
        /// <returns></returns>
        public static IMappingExpression IgnoreAllNonExisting(this IMappingExpression expression, Type from, Type to)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance;
            to.GetProperties(flags).Where(x => from.GetProperty(x.Name, flags) == null).ForEach(aProperty =>
            {
                expression.ForMember(aProperty.Name, opt => opt.Ignore());
            });

            return expression;
        }
    }

}
