using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Mvp24Hours.Infrastructure.Middlewares;
using Mvp24Hours.WebAPI.Extensions;
using Mvp24Hours.WebAPI.Middlewares;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PipelineAPI.Application.Logic;
using PipelineAPI.ApplicationWebClient.Factories;
using PipelineAPI.Core.Contract.Logic;
using PipelineAPI.Core.Contract.Pipelines.ProductCategories;
using PipelineAPI.Core.Contract.Pipelines.Products;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;

namespace PipelineAPI.WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            #region [ JsonSerializer ]
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                DateFormatString = "yyyy-MM-dd"
            };
            #endregion

            #region [ Cache ]
            services.AddMemoryCache();
            #endregion

            #region  [ ResponseCaching ]
            // caching response for middlewares
            services.AddResponseCaching();
            #endregion

            #region [ Mvp24Hours ]
            services.AddMvp24HoursService();
            #endregion

            #region [ MyServices ]

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductGetByBuilder, ProductGetByBuilder>();

            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductCategoryListBuilder, ProductCategoryListBuilder>();

            #endregion

            #region [ Swagger ]
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pipeline API", Version = "v1" });

                //c.DocumentFilter<CustomSwaggerFilter>();
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            #endregion

            #region [ Compression ]
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
            #endregion

            #region [ Controllers ]
            services.AddControllers();
            services.AddMvc();
            #endregion
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // check environment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                #region [ Custom Exception ]
                app.UseMiddleware<ExceptionMiddleware>();
                #endregion
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region [ Caching ]
            app.UseMiddleware<CachingMiddleware>();
            //app.UseResponseCaching();
            #endregion

            #region [ Compression ]
            //app.UseResponseCompression();
            #endregion

            #region [ Swagger ]
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Pipeline API V1");
            });
            #endregion

            #region [ Mvp24Hours ]
            app.UseMvp24Hours();
            #endregion
        }
    }
}
