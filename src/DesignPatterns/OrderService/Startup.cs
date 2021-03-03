using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderService.EventHandlers;
using OrderService.Events;
using OrderService.Services;
using OrderService.Strategies;

namespace OrderService {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddSingleton<IHistoryService, HistoryService>();
            services.AddSingleton<IEmailService, EmailNotification>();
            services.AddSingleton<INotificationStrategy, EmailNotification>();
            services.AddSingleton<INotificationStrategy>( p => new SmsNotificationEmailDecorator(new SmsNotification(p.GetRequiredService<IHistoryService>()), p.GetRequiredService<IEmailService>()));
            services.AddSingleton<INotificationStrategy, PushNotification>();
            services.AddSingleton<INotificationFactory, NotificationFactory>();
            services.AddSingleton<IEventHandler<OrderCreated>, CreateEventHandler>();
            services.AddSingleton<IEventHandler<OrderCreated>, SlackEventHandler>();
            services.AddSingleton<IEventHandler<OrderCreated>, NotificationEventHandler>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
