namespace Projeto_Web_Lh_Pets_vers_o_1;
using Projeto_Web_Lh_Pets_versão_1;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Projeto Web - LHpet 1");

        app.UseStaticFiles();
        app.MapGet("/index",(HttpContext contexto) =>{
              contexto.Response.Redirect("index.html",false);
        });
       Banco dba = new Banco();
        app.MapGet("/rota", (HttpContext contexto) =>
        {
            string listaString = dba.GetListaString(); // Chamada corrigida do método
            return contexto.Response.WriteAsync(listaString); // Passa a string para Response.WriteAsync
        });

        app.Run();
    }
}
