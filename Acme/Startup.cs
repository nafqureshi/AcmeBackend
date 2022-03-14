using Castle.Windsor;
using DbContext = Acme.Data.DBRepository.Concrete.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Acme.Services;
using Acme.Services.Repository.Abstract.ServiceAbstract;
using Castle.MicroKernel.Registration;
using Castle.Facilities.AspNetCore;
using Acme.Controllers;

namespace Acme
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private static readonly WindsorContainer Container = new WindsorContainer();

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Setup InMemoryDB
            services.AddDbContext<DbContext>(opts => opts.UseInMemoryDatabase("UserActivityDB"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Acme", Version = "v1" });
            });

            // Custom application component registrations, ordering is important here
            RegisterApplicationComponents(services);

            // Castle Windsor integration, controllers, tag helpers and view components, this should always come after RegisterApplicationComponents
            services.AddWindsor(Container, opts => opts.UseEntryAssembly(typeof(ActivityController).Assembly));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Acme v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterApplicationComponents(IServiceCollection services)
        {
            // ActivitySignupService components
            Container.Register(Component.For<IActivitySignupService>().ImplementedBy<ActivitySignupService>()
                     .LifestyleSingleton().IsDefault());
        }
    }
}
