using Autofac;
using AutoMapper;
using DataAccess.AutoMapper;
using DataAccess.Services.Concrete;
using DataAccess.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SubcategoryRepository>().As<ISubcategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CartRepository>().As<ICartRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StockRepository>().As<IStockRepository>().InstancePerLifetimeScope();
            builder.RegisterType<HomeRepository>().As<IHomeRepository>().InstancePerLifetimeScope();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapping());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            builder.RegisterInstance<IMapper>(mapper);
        }
    }
}
