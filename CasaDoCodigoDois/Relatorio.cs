using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CasaDoCodigoDois
{
  public class Relatorio : IRelatorio
  {
    private readonly ICatalogo Catalogo;

    public Relatorio(ICatalogo catalogo)
    {
      Catalogo = catalogo;
    }

    public async Task Imprimir(HttpContext context)
    {
      foreach(var livro in Catalogo.ObterLivros())
      {
        await context.Response.WriteAsync($@"{Environment.NewLine}Codigo: {livro.Codigo,-10}
                  {Environment.NewLine}Nome: {livro.Nome,-40}{Environment.NewLine}Preco: {livro.Preco.ToString("c"),10}");
      }
    }
  }
}
