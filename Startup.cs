using System.Collections.Generic;
using System.IO;
using Microsoft.AspNet.Builder;
using Nancy.Owin;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace DateABase
{
  public static class DBConfiguration
 {
   public static string ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=date_a_base;Integrated Security=SSPI";
 }
  public class Startup
  {
    public void Configure(IApplicationBuilder app)
    {
      app.UseOwin(x => x.UseNancy());
    }
  }
  public class CustomRootPathProvider : IRootPathProvider
  {
    public string GetRootPath()
    {
      return Directory.GetCurrentDirectory();
    }
  }
  public class RazorConfig : IRazorConfiguration
  {
    public IEnumerable<string> GetAssemblyNames()
    {
      return null;
    }

    public IEnumerable<string> GetDefaultNamespaces()
    {
      return null;
    }

    public bool AutoIncludeModelNamespace
    {
      get { return false; }
    }
  }
}
