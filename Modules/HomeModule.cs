using Nancy;
using System.Collections.Generic;
using System;

using System.Windows.Forms;
using System.Windows.Forms.MessageBox;

using DateABase.Objects;

namespace DateABase
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] =_=>{
        Dictionary<string, object> model = new Dictionary<string, object>();
        return View["index.cshtml",model];
      };
      Post["/sign-up"] =_=>{
        User newUser = new User(Request.Form["new-user-name"], Request.Form["new-user-password"]);
        newUser.Save();
        User.SetCurrentUser(newUser);
        Dictionary<string, object> model = new Dictionary<string, object>();
        User currentUser = User.GetCurrentUser();
        model.Add("message", "Create new profile");
        model.Add("user", currentUser);
        return View["edit_profile.cshtml", model];
      };

      Post["/sign-in"] = _ =>{
        string userName = Request.Form["user-name"];
        string userPassword = Request.Form["user-password"];
        bool loginStatus = User.CheckLogin(Request.Form(userName), Request.Form(userPassword));
        Dictionary<string, object> model = new Dictionary<string, object>();
        if (loginStatus == true)
        {
          User currentUser = User.FindByUserName(userName);
          User.SetCurrentUser(currentUser);
          model.Add("message", "Welcome!");
          model.Add("user", currentUser);
        }
        if (loginStatus == false)
        {
          model.Add("message", "Invalid User Name or Password");
          return View["index.cshtml", model];
        }
        return View["profile.cshtml", model];
      };

      Get["/user/update"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        User currentUser = User.GetCurrentUser();
        model.Add("message", "Edit profile");
        model.Add("user", currentUser);
        return View["edit_profile.cshtml", model];
      };
      Patch["/user/update"] = _ => {
        User currentUser = User.GetCurrentUser();
        currentUser.Edit(Request.Form["user-name"], Request.Form["user-password"], Request.Form["first-name"], Request.Form["last-name"], Request.Form["zip-code"], Request.Form["email"], Request.Form["tag-line"], Request.Form["phone-number"],Request.Form["about"]);
        Dictionary<string, object> model = new Dictionary<string, object>(){{"message", "Your profile has been updated"},{"user", currentUser},{"state" , true}};
        return View["profile.cshtml", model];
      };
      Delete["/user/delete"] = _ => {
        string message = "Are you sure you'd like to delete your account?";
        string caption = "Delete Profile";
        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        DialogResult confirmDelete = MessageBox.Show(message, caption, buttons);
        if(confirmDelete == System.Windows.Forms.DialogResult.Yes)
        {
          User currentUser = User.GetCurrentUser();
          currentUser.Delete();
          return View["index.cshtml"];
        }
        else {
          Dictionary<string, object> model = new Dictionary<string, object>();
          User currentUser = User.GetCurrentUser();
          model.Add("user", currentUser);
          return View["profile.cshtml", model];
        }
      };
      Get["/users"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        List<User> allUsers = User.GetAll();
        model.Add("users", allUsers);
        return View["profiles.cshtml", model];
      };

    }
  }
}
