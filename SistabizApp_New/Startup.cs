using CorePush.Apple;
using CorePush.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SistabizApp.Authentication;
using SistabizApp_New.Helper;
using SistabizApp_New.Hubs;
using SistabizApp_New.Interface;
using SistabizApp_New.IServices;
using SistabizApp_New.Models;
using SistabizApp_New.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistabizApp_New
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMvc().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

         //   var emailConfig = Configuration
         //.GetSection("EmailConfiguration")
         //.Get<EmailConfiguration>();
         //   services.AddSingleton(emailConfig);

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));

            services.AddDbContext<SistabizAppContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));

           // services.AddTransient<IMemberService, MemberService>();
            //services.AddTransient<IServiceRequestService, ServiceRequestService>();

            services.AddTransient<IBLLService, BLLService>();
            services.AddSingleton<IUserConnectionManager, UserConnectionManager>();

            // Configure strongly typed settings objects

            services.AddTransient<INotificationService, NotificationService>();
            services.AddHttpClient<FcmSender>();
            services.AddHttpClient<ApnSender>();

            var appSettingsSection = Configuration.GetSection("FcmNotification");
            services.Configure<FcmNotificationSetting>(appSettingsSection);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Place Info Service API",
                    Version = "v2",
                    Description = "Sample service for Learner",
                });
            });
            // services.AddCors();

            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", build =>
            {
                build.WithOrigins( "http://localhost:3000", "https://f81a-103-241-226-208.in.ngrok.io", "http://www.sis-temp.eagletechsolutions.uk.servepreview.net", "http://localhost", "http://18.216.1.27")
                     .AllowAnyMethod()
                     .AllowAnyHeader();
            }));
            // ... other code is omitted for the brevity
        

        

            // For Identity  
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 8;

                opts.SignIn.RequireConfirmedEmail = true;
            });

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })


            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            //signalR
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCors("ApiCorsPolicy");
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseSignalR(routes =>
            //{
            //    routes.MapHub<NotifyHubService>("/notify");
            //});
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/Hubs/NotificationHub");
               // endpoints.MapHub<ChatHub>("/hubs/chat");
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
