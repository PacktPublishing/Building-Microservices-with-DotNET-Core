using FlixOne.BookStore.ProductService.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlixOne.BookStore.ProductService.IntegrationTests
{
    public class TestStartup : Startup
    {
        public TestStartup(IHostingEnvironment env) : base(env)
        {
        }

        public new void ConfigureServices(IServiceCollection services)
        {
            //mock context
            services.AddDbContext<ProductContext>(
                o => o.UseSqlServer("Data Source=.;Initial Catalog=ProductsDB;Integrated Security=True;MultipleActiveResultSets=True"));
        }
    }
}