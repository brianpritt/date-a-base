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
//         return View["index.cshtml"];
//       };
//       Post["/sign-up"] =_=>{
//         User newUser = new User(Request.Form("new-user-name"), Request.Form("new-user-password"));
//         newUser.Save();
//         User.SetCurrentUser(newUser);
//         Dictionary<string, object> model = new Dictionary<string, object>();
//         var currentUser = User.GetCurrentUser();
//         model.Add("message", "Create new Profile");
//         model.Add("user", currrentUser);
//         return View["edit_profile.csthml", model];
//       };
//       Patch["/user/update"] = _ => {
//         var currentUser = User.GetCurrentUser();
//         User currentUser.Update(Request.Form("user-name"), Request.Form("user-password"), Request.Form("first-name"), Request.Form("last-name"), Request.Form("zip-code"), Request.Form("email"), Request.Form("tag-line"), Request.Form("phone-number"),Request.Form("about"));
//         currentUser.Save();
//         return View["profile.cshtml", currentUser];
//       };
//       Post["/sign-in"] = _ =>{
//         bool loginStatus = User.CheckLogin(Request.Form("user-name"), Request.Form("user-password"));
//         Dictionary<string, object> model = new Dictionary<string, object>();
//         if (loginStatus == true)
//         {
//           Dictionary<string, object> model = new Dictionary<string, object>();
//           var foundUser = User.FindByUserName();
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
