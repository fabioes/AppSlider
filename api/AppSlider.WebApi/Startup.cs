namespace AppSlider.WebApi
{
    using Autofac;
    using AppSlider.WebApi.Filters;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.IO;
    using Autofac.Configuration;
    using AppSlider.Domain.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Options;
    using System;
    using AppSlider.Application.User.Services.Get;
    using Microsoft.AspNetCore.Http;
    using AutoMapper;
    using AppSlider.Infrastructure.DataAccess;
    using Microsoft.EntityFrameworkCore;
    using AppSlider.Domain.Repositories;
    using AppSlider.Infrastructure.EntityFrameworkDataAccess;
    using AppSlider.Application.User.Services.Update;
    using AppSlider.Application.User.Services.Create;
    using AppSlider.Application.User.Services.Delete;
    using AppSlider.Application.User.Services.Config;
    using AppSlider.Application.Business.Services.Get;
    using AppSlider.Domain.Entities.Users;
    using AppSlider.Application.Business.Services.Create;
    using AppSlider.Application.Business.Services.Delete;
    using AppSlider.Application.Business.Services.Update;
    using AppSlider.Application.Business.Services.Config;
    using AppSlider.Application.Equipament.Services.Get;
    using AppSlider.Application.Login.Services;
    using AppSlider.Application.Role.Services.Get;
    using AppSlider.Application.TypeBusiness.Services.Get;
    using AppSlider.Application.TypeBusiness.Services.Create;
    using AppSlider.Application.TypeBusiness.Services.Update;
    using AppSlider.Application.Playlist.Services.Get;
    using AppSlider.Application.Playlist.Services.Update;
    using AppSlider.Application.Playlist.Services.Create;
    using AppSlider.Application.Playlist.Services.Config;
    using AppSlider.Application.Equipament.Services.Playlist;
    using AppSlider.Application.Equipament.Services.Update;
    using AppSlider.Application.Equipament.Services.Config;
    using AppSlider.Application.Equipament.Services.Delete;
    using AppSlider.Application.Equipament.Services.Create;
    using AppSlider.Application.TypeBusiness.Services.Delete;
    using AppSlider.Application.Playlist.Services.Delete;
    using AppSlider.Application.PlaylistFile.Services;
    using AppSlider.Application.Category.Services.Get;
    using AppSlider.Application.Category.Services.Update;
    using AppSlider.Application.Category.Services.Create;
    using AppSlider.Application.Category.Services.Delete;
    using AppSlider.Application.File.Services;
    using Microsoft.AspNetCore.Server.Kestrel.Core;

    public class Startup
    {
        private IContainer _container { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {



            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();

                options.IncludeXmlComments(
                    Path.ChangeExtension(
                        typeof(Startup).Assembly.Location,
                        "xml"));

                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = Configuration["App:Title"],
                    Version = Configuration["App:Version"],
                    Description = Configuration["App:Description"],
                    TermsOfService = Configuration["App:TermsOfService"]
                });

                options.CustomSchemaIds(x => x.FullName);

                options.OperationFilter<SwaggerAuthorizationHeaderParameterOperationFilter>();
            });


            services.AddDbContext<Context>(options =>
              options.UseMySql(Configuration.GetConnectionString("midiafone")).UseLazyLoadingProxies());

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRoleGetService, RoleGetService>();


            services.AddScoped<IUserGetService, UserGetService>();
            services.AddScoped<IUserUpdateService, UserUpdateService>();
            services.AddScoped<IUserCreateService, UserCreateService>();
            services.AddScoped<IUserDeleteService, UserDeleteService>();
            services.AddScoped<IUserConfigService, UserConfigService>();

            services.AddScoped<IBusinessGetService, BusinessGetService>();
            services.AddScoped<IBusinessCreateService, BusinessCreateService>();
            services.AddScoped<IBusinessDeleteService, BusinessDeleteService>();
            services.AddScoped<IBusinessUpdateService, BusinessUpdateService>();
            services.AddScoped<IBusinessConfigService, BusinessConfigService>();

            services.AddScoped<ITypeBusinessGetService, TypeBusinessGetService>();
            services.AddScoped<ITypeBusinessCreateService, TypeBusinessCreateService>();
            services.AddScoped<ITypeBusinessUpdateService, TypeBusinessUpdateService>();
            services.AddScoped<ITypeBusinessDeleteService, TypeBusinessDeleteService>();

            services.AddScoped<IPlaylistGetService, PlaylistGetService>();
            services.AddScoped<IPlaylistUpdateService, PlaylistUpdateService>();
            services.AddScoped<IPlaylistCreateService, PlaylistCreateService>();
            services.AddScoped<IPlaylistConfigService, PlaylistConfigService>();
            services.AddScoped<IPlaylistDeleteService, PlaylistDeleteService>();

            services.AddScoped<IPlaylistFileService, PlaylistFileService>();

            services.AddScoped<IEquipamentGetService, EquipamentGetService>();
            services.AddScoped<IEquipamentPlaylistService, EquipamentPlaylistService>();
            services.AddScoped<IEquipamentUpdateService, EquipamentUpdateService>();
            services.AddScoped<IEquipamentConfigService, EquipamentConfigService>();
            services.AddScoped<IEquipamentDeleteService, EquipamentDeleteService>();
            services.AddScoped<IEquipamentCreateService, EquipamentCreateService>();

            services.AddScoped<ICategoryGetService, CategoryGetService>();
            services.AddScoped<ICategoryUpdateService, CategoryUpdateService>();
            services.AddScoped<ICategoryCreateService, CategoryCreateService>();
            services.AddScoped<ICategoryDeleteService, CategoryDeleteService>();

            services.AddScoped<IFileGetService, FileGetService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<IBusinessTypeRepository, BusinessTypeRepository>();
            services.AddScoped<IEquipamentRepository, EquipamentRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            var loggedUser = new LoggedUser();
            services.AddSingleton(loggedUser);

            services.AddMvc(options =>
            {
                var sp = services.BuildServiceProvider();

                var userGetService = sp.GetService<IUserGetService>();

                options.Filters.Add(new CustomAuthorizeFilter(userGetService, new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser()
                    .Build(), loggedUser));

                options.Filters.Add(typeof(BusinessExceptionFilter));
                options.Filters.Add(typeof(ValidateModelAttribute));
            });

            //Custom Authentication
            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(Configuration.GetSection("TokenConfigurations")).Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            var signingConfigurations = new SigningConfigurations(tokenConfigurations.StringKey);
            services.AddSingleton(signingConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;

                paramsValidation.RequireSignedTokens = true;
                paramsValidation.RequireExpirationTime = true;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set default value is: 30 MB
            });
            //Custom Authentication End's
        }

        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    builder.RegisterBuildCallback(_builder =>
        //    {
        //        _container = _builder;
        //    });

        //    builder.RegisterModule(new ConfigurationModule(Configuration));
        //}

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            string midiafone = @"/midiafoneapi";
            if (env.IsDevelopment())
            {
                midiafone = string.Empty;
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint($@"{midiafone}/swagger/v1/swagger.json", "Midiafone API V1");
               });
        }
    }
}
