using AluguelDeMotos.Data;
using AluguelDeMotos.Helper;
using AluguelDeMotos.Repositorio;
using Microsoft.EntityFrameworkCore;

public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddEntityFrameworkNpgsql()
            .AddDbContext<BancoContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        builder.Services.AddScoped<IMotoRepositorio, MotoRepositorio>();
        builder.Services.AddScoped<ILocacaoRepositorio, LocacaoRepositorio>();
        builder.Services.AddScoped<ISessao, Sessao>();

        builder.Services.AddSession(o =>
        {
            o.Cookie.HttpOnly = true;
            o.Cookie.IsEssential = true;
        });

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<BancoContext>();
            dbContext.Database.Migrate();
        }

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        //app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseSession();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Login}/{action=Index}/{id?}");

        app.Run();

    }
}