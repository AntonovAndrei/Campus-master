using API.Extensions;
using API.Middleware;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices(_config);
            services.AddIdentityServices(_config);
        }

        //КОЛИЧЕСТВО НЕПУСТЫХ СТРОК В ПРОЕКТЕ
        //Get-ChildItem -Recurse -File -Filter *.cs | Where-Object { $_.DirectoryName -notmatch '\\bin$|\\obj$|\\Release$|\\Debug$' } | ForEach-Object { Get-Content $_.FullName | Where-Object { $_ -match '\S' } } | Measure-Object -Line | Select-Object -ExpandProperty Lines
        //
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Campus API v1"));
            }
            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
