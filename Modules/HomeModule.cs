using Nancy;
using System.Collections.Generic;
using System;
using TEMPLATE.Objects;

namespace TEMPLATE
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["TEMPLATE.cshtml"];
      };

    }
  }
}
