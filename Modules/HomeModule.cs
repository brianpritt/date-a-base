// using Nancy;
// using System.Collections.Generic;
// using System;
// using DateABase.Objects;
//
// namespace DateABase
// {
//   public class HomeModule : NancyModule
//   {
//     public HomeModule()
//     {
//       Get["/"] =_=>{
//         Dictionary<string, object> model = new Dictionary<string, object>();
//         return View["index.cshtml",model];
//       };
//       Post["/sign-up"] =_=>{
//         User newUser = new User(Request.Form["new-user-name"], Request.Form["new-user-password"]);
//         newUser.Save();
//         User.SetCurrentUser(newUser);
//         Dictionary<string, object> model = new Dictionary<string, object>();
//         var currentUser = User.GetCurrentUser();
//         model.Add("message", "Create new Profile");
//         model.Add("user", currentUser);
//         // Console.WriteLine(model["user"].UserName);
//         return View["edit_profile.cshtml", model];
//       };
//       Patch["/user/update"] = _ => {
//         var currentUser = User.GetCurrentUser();
//         currentUser.Edit(Request.Form("user-name"), Request.Form("user-password"), Request.Form("first-name"), Request.Form("last-name"), Request.Form("zip-code"), Request.Form("email"), Request.Form("tag-line"), Request.Form("phone-number"),Request.Form("about"));
//         currentUser.Save();
//         return View["profile.cshtml", currentUser];
//       };
//       Post["/sign-in"] = _ =>{
//         string userName = Request.Form("user-name");
//         string userPassword = Request.Form("user-password");
//         bool loginStatus = User.CheckLogin(Request.Form(userName), Request.Form(userPassword));
//         Dictionary<string, object> model = new Dictionary<string, object>();
//         if (loginStatus == true)
//         {
//           var foundUser = User.FindByUserName(userName);
//           User.SetCurrentUser(foundUser);
//           User currentUser = User.GetCurrentUser();
//           model.Add("message", "Welcome!");
//           model.Add("user", currentUser);
//         } else if (loginStatus == false)
//         {
//           model.Add("message", "Invalid User Name or Password");
//           return View["index.cshtml", model];
//         }
//         return View["profile.cshtml", model];
//       };
//     }
//   }
// }
