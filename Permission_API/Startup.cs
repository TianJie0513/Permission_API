
using DomainDTO.mapperConfig;
using IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Permission_API.Controllers;
using Permission_API.Filters;
using Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Permission_API
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
            //关闭默认行为过滤器
            services.Configure<ApiBehaviorOptions>(opt => opt.SuppressModelStateInvalidFilter = true);
            services.AddControllers(option=> {
                //添加自定义行为过滤器
                option.Filters.Add(typeof(CustomActtionFilter));
            });
            services.AddCors(option => option.AddPolicy("mycors", policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
            //获取连接字符串
            var con = Configuration.GetConnectionString("con");
      
            services.AddDbContext<MyDBContext.MyDBContext>(s => s.UseSqlServer(con));
            services.AddScoped(typeof(IRepostirySQLDB<>), typeof(RepostirySQLDB<>));
            services.AddScoped<IServices.IOU.IOUsServices, Services.OUS.OUsServices>();
            services.AddScoped<IServices.IOU.IOrganizationServices, Services.OUS.OrganizationServices>();
            services.AddScoped<IServices.IOU.ISysUsersServices, Services.OUS.SysUsersServices>();
            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddScoped(typeof(Tools.IRedisHelper<>), typeof(Tools.RedisHelper<>));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Permission_API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement { {
                    new OpenApiSecurityScheme{
                     Reference=new OpenApiReference{
                      Id="Bearer", Type= ReferenceType.SecurityScheme
                     }
                    },
                    new string[]{ }
                    }
                });

            });
            ///认证服务代码
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                //这一坨就是就是payload
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    // 是否开启签名认证
                    ValidateIssuerSigningKey = true,
                   
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("secretKey").Value)),
                    // 发行人验证，这里要和token类中Claim类型的发行人保持一致
                    ValidateIssuer = true,
                    ValidIssuer = "API",//发行人
                    // 接收人验证
                    ValidateAudience = true,
                    ValidAudience = "User",//订阅人
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });


        }
 
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env )
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Permission_API v1"));
            }
          //  this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            app.UseRouting();
            app.UseCors("mycors");
            //认证
            app.UseAuthentication();
            app.UseAuthorization();




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
