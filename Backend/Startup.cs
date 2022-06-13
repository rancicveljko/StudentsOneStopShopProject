using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Backend.KlaseZaRadSaPodacima.DBContexti;
using tusdotnet;
using tusdotnet.Helpers;
using tusdotnet.Models;
using Backend.KlaseZaRadSaPodacima.TusKonfiguracije;
using Microsoft.AspNetCore.Http;
using Backend.Autorizacija.UsloviAutorizacije;
using Microsoft.AspNetCore.Authorization;
using Backend.Autorizacija.RukovaociAutorizacijama;
using FluentValidation.AspNetCore;
using System.Reflection;
using Backend.KlaseZaIzgradnjuStringova;
using Backend.Autentikacija;

namespace Backend
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
            services.AddCors(opcije =>
            {
                opcije.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("https://soss.com:5001", "http://localhost:3000", "http://192.168.1.101:3000", "http://192.168.100.13:3000", "http://127.0.0.1:5500")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials()
                           .WithExposedHeaders(CorsHelper.GetExposedHeaders());
                });
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(opcije =>
                    {
                        opcije.Cookie.Name = "S.O.S.S.";
                        opcije.Cookie.HttpOnly = true;
                        opcije.SlidingExpiration = true;
                        opcije.Cookie.SameSite = SameSiteMode.None;
                        opcije.EventsType = typeof(KolacicAutentikacioniDogadjaj);
                    });
            services.AddAuthorization(opcije =>
            {
                opcije.AddPolicy("PolisaManipulacijeMaterijalom",
                                  polisa =>
                                  {
                                      polisa.RequireAuthenticatedUser();
                                      polisa.AddRequirements(new UslovManipulacijeMaterijalom());
                                  });
            });
            services.AddControllers()
                    .AddNewtonsoftJson()
                    .AddFluentValidation(fv =>
                     {
                         fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                         fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                     })
                    .ConfigureApiBehaviorOptions(opcije =>
                    {
                        opcije.InvalidModelStateResponseFactory = context =>
                        {
                            var greske = context.ModelState.Where(ms => ms.Value.Errors.Count > 0)
                                                            .ToDictionary(kvp => kvp.Key,
                                                                          kvp => kvp.Value.Errors.Select(greska => greska.ErrorMessage)
                                                                                                 .ToArray());
                            if (greske.Values.SelectMany(vrednost => vrednost)
                                             .Any(poruka => poruka.Contains(Poruke.serverskaGreska)))
                            {
                                ObjectResult greska = new ObjectResult(greske);
                                greska.StatusCode = StatusCodes.Status500InternalServerError;
                                return greska;
                            }
                            if (greske.Values.SelectMany(vrednost => vrednost)
                                             .Any(poruka => poruka.Contains(Poruke.pogresnaLozinka)
                                                            && greske.Values.SelectMany(vrednost => vrednost)
                                                                            .Any(poruka => poruka.Contains(Poruke.NePostoji("Korisnik", "navedenim korisničkim imenom")))))
                                greske.Remove("Lozinka");
                            return new BadRequestObjectResult(greske);
                        };

                    });

            services.Scan(scan => scan.FromCallingAssembly()
                                      .AddClasses()
                                      .AsMatchingInterface());

            services.AddScoped<KolacicAutentikacioniDogadjaj>();

            services.AddSingleton<IAuthorizationHandler, RukovalacAutorizacijeManipulacijeMaterijalom>();

            services.AddSingleton<DefaultTusConfiguration, TusKonfiguracija>();

            services.AddHttpContextAccessor();

            services.AddDbContext<BazaDbContext>(opcije =>
            {
                opcije.UseSqlServer(Configuration.GetConnectionString("SOSSCS"),
                                    opcije => opcije.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();

            app.UseTus(httpcontext =>
            {
                return Task.FromResult(httpcontext.RequestServices.GetService<DefaultTusConfiguration>());
            });

            app.Use((context, sledeci) =>
            {
                context.Request.EnableBuffering();
                return sledeci();
            });
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
