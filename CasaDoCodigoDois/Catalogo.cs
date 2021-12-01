using System.Collections.Generic;

namespace CasaDoCodigoDois
{
  public class Catalogo : ICatalogo
  {
    public List<Livro> ObterLivros()
    {
      var livros = new List<Livro>();
      livros.Add(new Livro("0001", "Técnicas de programação ", 100m));
      livros.Add(new Livro("0002", "Técnicas de programação em C#", 100m));
      livros.Add(new Livro("0003", "Técnicas de programação em Javascript", 100m));

      return livros;
    }
  }
}
