﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CasaDoCodigoDois
{
  public interface IRelatorio
  {
    Task Imprimir(HttpContext context);
  }
}