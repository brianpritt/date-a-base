
using Nancy;
using System.Collections.Generic;
using System;
// using System.Windows.Forms;
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
        bool taken = User.CheckUserName(Request.Form["new-user-name"]);
        Dictionary<string, object> model = new Dictionary<string, object>();
        if(taken)
        {
          string message  = "The username " + Request.Form["new-user-name"] + " is taken. Please choose another.";
          model.Add("message", message);
          return View["index.cshtml", model];
        }
        if(!taken)
        {
          User newUser = new User(Request.Form["new-user-name"], Request.Form["new-user-password"]);
          newUser.Save();
          User.SetCurrentUser(newUser);
          User currentUser = User.GetCurrentUser();
          model.Add("profilePic", null);
          model.Add("messageList", null);
          model.Add("message", "Create new profile");
          model.Add("user", currentUser);
        }
        return View["edit_profile.cshtml", model];
      };

      Post["/sign-in"] = _ =>{
        string userName = Request.Form["user-name"];
        string userPassword = Request.Form["user-password"];
        bool loginStatus = User.CheckLogin(userName, userPassword);
        Dictionary<string, object> model = new Dictionary<string, object>();
        User currentUser = User.FindByUserName(userName);
        if (loginStatus == true)
        {
          User.SetCurrentUser(currentUser);
          currentUser.Genders = currentUser.ConvertGender(currentUser.Gender);
          currentUser.SeekGenders = currentUser.ConvertGender(currentUser.SeekGender);
          List<Message> allUnreadMessages = currentUser.GetAllUnreadMessages();
          model.Add("messageList", allUnreadMessages);
          model.Add("message", "Welcome!");
          model.Add("user", currentUser);
          model.Add("state", true);
          model.Add("profilePic", currentUser.GetProfilePhoto().Url);
        }
        if (loginStatus == false)
        {
          model.Add("message", "Invalid User Name or Password");
          return View["index.cshtml", model];
        }
        return View["profile.cshtml", model];
      };

      Get["/profile/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        User currentUser = User.GetCurrentUser();
        User selectedUser = User.Find(parameters.id);
        selectedUser.Genders = selectedUser.ConvertGender(selectedUser.Gender);
        selectedUser.SeekGenders = selectedUser.ConvertGender(selectedUser.SeekGender);
        model.Add("user", selectedUser);
        bool isUsersProfile = false;
        Photo profilePic = selectedUser.GetProfilePhoto();
        List<Message> allUnreadMessages = currentUser.GetAllUnreadMessages();
        if (currentUser.Id == parameters.id)
        {
          isUsersProfile = true;
        }
        model.Add("messageList", allUnreadMessages);
        model.Add("profilePic", profilePic.Url);
        model.Add("state", isUsersProfile);
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
        int seekGender = Request.Form["seek-gender"];
        int gender = Request.Form["seek-gender"];
        if (seekGender == 0)
        {
          seekGender = currentUser.SeekGender;
        }
        if (gender == 0)
        {
          gender = currentUser.SeekGender;
        }
        currentUser.Edit(Request.Form["user-name"], Request.Form["user-password"], Request.Form["first-name"], Request.Form["last-name"], Request.Form["zip-code"],Request.Form["email"], Request.Form["tag-line"], Request.Form["phone-number"],  Request.Form["about"], gender, seekGender);
        Dictionary<string, object> model = new Dictionary<string, object>();
        Photo profilePic = new Photo(currentUser.Id, Request.Form["profile-pic"]);
        currentUser.AddPhoto(profilePic);
        profilePic.MakeProfile(currentUser.Id);
        currentUser.Genders = currentUser.ConvertGender(currentUser.Gender);
        currentUser.SeekGenders = currentUser.ConvertGender(currentUser.SeekGender);
        List<Message> allUnreadMessages = currentUser.GetAllUnreadMessages();
        model.Add("messageList", allUnreadMessages);
        model.Add("message", "Your profile has been updated");
        model.Add("user", currentUser);
        model.Add("state", true);
        model.Add("profilePic", profilePic.Url);
        return View["profile.cshtml", model];
      };
      Delete["/user/delete"] = _ => {
        User currentUser = User.GetCurrentUser();
        currentUser.Delete();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("message", "Profile Deleted!");
        return View["index.cshtml"];
      };
      Get["/user/delete/cancel"]=_=>{
          Dictionary<string, object> model = new Dictionary<string, object>();
          User currentUser = User.GetCurrentUser();
          model.Add("user", currentUser);
          return View["profile.cshtml", model];
      };
      Get["/users"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        List<User> allUsers = User.GetAll();
        model.Add("users", allUsers);
        return View["profiles.cshtml", model];
      };
      Get["/user/messages/"]= _ =>{
        User currentUser = User.GetCurrentUser();
        List<Message> allUnreadMessages = currentUser.GetAllUnreadMessages();
        Dictionary<string, object> messageDictionary = new Dictionary<string, object>();
        List<User> allUsers = User.GetAll();
        messageDictionary.Add("user", currentUser);
        messageDictionary.Add("messageList", allUnreadMessages);
        messageDictionary.Add("userList", allUsers);
        return View["message_center.cshtml", messageDictionary];
      };
      Get["/user/messages/read"]= _ =>{
        User currentUser = User.GetCurrentUser();
        List<Message> allReadMessages = currentUser.GetAllReadMessages();
        Dictionary<string, object> messageDictionary = new Dictionary<string, object>();
        List<User> allUsers = User.GetAll();
        messageDictionary.Add("user", currentUser);
        messageDictionary.Add("messageList", allReadMessages);
        messageDictionary.Add("userList", allUsers);
        return View["message_center.cshtml", messageDictionary];
      };
      Get["/user/{id}/message/send"] = parameters =>{
        User sendingUser = User.GetCurrentUser();
        User receivingUser = User.Find(parameters.id);
        List<Message> allCorrespondence = sendingUser.GetCorrespondenceFromDater(receivingUser);
        Dictionary<string, object> messageDictionary = new Dictionary<string, object>();
        messageDictionary.Add("history", allCorrespondence);
        messageDictionary.Add("sender", sendingUser);
        messageDictionary.Add("receiver", receivingUser);
        return View["create_message.cshtml", messageDictionary];
      };
      Post["user/message/send"] = _ => {
        Dictionary<string, object> messageDictionary = new Dictionary<string, object>();
        User senderUser = User.Find(Request.Form["sender"]);
        User receiverUser = User.Find(Request.Form["receiver"]);
        string messageText = Request.Form["message-text"];
        bool viewed = false;
        Message newMessage = new Message(senderUser.Id, receiverUser.Id, messageText, viewed);
        newMessage.Save();
        List<Message> allUnreadMessages = senderUser.GetAllUnreadMessages();
        List<User> allUsers = User.GetAll();
        messageDictionary.Add("message", "Message Sent");
        messageDictionary.Add("user", senderUser);
        messageDictionary.Add("messageList", allUnreadMessages);
        messageDictionary.Add("userList", allUsers);
        return View["message_center.cshtml", messageDictionary];
      };
      Get["/user/messages/sent"] = _ => {
        User currentUser = User.GetCurrentUser();
        List<Message> allSentMessages = currentUser.GetAllSentMessages();
        Dictionary<string, object> messageDictionary = new Dictionary<string, object>();
        List<User> allUsers = User.GetAll();
        messageDictionary.Add("user", currentUser);
        messageDictionary.Add("messageList", allSentMessages);
        messageDictionary.Add("userList", allUsers);
        return View["message_center.cshtml", messageDictionary];
      };
      Get["/user/messages/all"] = _ => {
        User currentUser = User.GetCurrentUser();
        List<Message> allMessages = currentUser.GetAllReceivedMessages();
        Dictionary<string, object> messageDictionary = new Dictionary<string, object>();
        List<User> allUsers = User.GetAll();
        messageDictionary.Add("user", currentUser);
        messageDictionary.Add("messageList", allMessages);
        messageDictionary.Add("userList", allUsers);
        return View["message_center.cshtml", messageDictionary];
      };
      Get["user/messages/{id}"] = parameters => {
        User receivingUser = User.GetCurrentUser();
        Message currentMessage = Message.Find(parameters.Id);
        User senderUser = User.Find(currentMessage.SenderId);
        Dictionary<string, object> messageDictionary = new Dictionary<string, object>();
        messageDictionary.Add("user", currentMessage);
        messageDictionary.Add("sender", senderUser);
        messageDictionary.Add("receiver", receivingUser);
        currentMessage.MarkViewed();
        return View["view_message.cshtml", messageDictionary];
      };
      Get["/user/messages/{id}/reply"] =parameters =>{
        User sendingUser = User.GetCurrentUser();
        User receivingUser = User.Find(parameters.id);
        Dictionary<string, object> messageDictionary = new Dictionary<string, object>();
        messageDictionary.Add("sender", sendingUser);
        messageDictionary.Add("receiver", receivingUser);
        return View["create_message.cshtml", messageDictionary];
      };
      Delete["/user/message/{id}/delete"] = parameters => {
        User currentUser = User.GetCurrentUser();
        Message currentMessage = Message.Find(parameters.Id);
        Console.WriteLine(currentMessage.Id);
        List<Message> allUnreadMessages = currentUser.GetAllUnreadMessages();
        List<User> allUsers = User.GetAll();
        currentMessage.DeleteMessage();
        Dictionary<string, object> messageDictionary = new Dictionary<string, object>();
        messageDictionary.Add("message", "Message Deleted!");
        messageDictionary.Add("user", currentUser);
        messageDictionary.Add("messageList", allUnreadMessages);
        messageDictionary.Add("userList", allUsers);
        return View["message_center.cshtml", messageDictionary];
      };

      Get["/user/{id}/photos"] = parameters => {
        User currentUser = User.GetCurrentUser();
        User selectedUser = User.Find(parameters.id);
        bool state = false;
        if(currentUser.Id == selectedUser.Id)
        {
          state = true;
        }
        List<Photo> usersPhotos = selectedUser.GetPhotos();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("user", selectedUser);
        model.Add("photos", usersPhotos);
        model.Add("state", state);
        return View["photos.cshtml", model];
      };

      Get["/user/{uid}/photo/{pid}"] = parameters => {
        User currentUser = User.GetCurrentUser();
        User selectedUser = User.Find(parameters.uid);
        Photo selectedPhoto = Photo.Find(parameters.pid);
        bool state = false;
        if(currentUser.Id == selectedUser.Id)
        {
          state = true;
        }
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("user", selectedUser);
        model.Add("photo", selectedPhoto);
        model.Add("state", state);
        return View["photo.cshtml", model];
      };

      Post["/photos/add"] = _ => {
        User currentUser = User.GetCurrentUser();
        Photo newPhoto = new Photo(currentUser.Id, Request.Form["new-photo"], false);
        currentUser.AddPhoto(newPhoto);
        Dictionary<string, object> model = new Dictionary<string, object>();
        string message = "Picture has been added.";
        model.Add("message", message);
        model.Add("user", currentUser);
        model.Add("photos", currentUser.GetPhotos());
        model.Add("state", true);
        return View["photos.cshtml", model];
      };
      Post["/photo/{id}/delete"] = parameters => {
      User currentUser = User.GetCurrentUser();
      User selectedUser = User.Find(parameters.uid);
      Photo selectedPhoto = Photo.Find(parameters.pid);
      selectedPhoto.Delete();
      bool state = false;
      if(currentUser.Id == selectedUser.Id)
      {
        state = true;
      }
      List<Photo> usersPhotos = selectedUser.GetPhotos();
      Dictionary<string, object> model = new Dictionary<string, object>();
      string message = "Picture has been deleted.";
      model.Add("message", message);
      model.Add("user", currentUser);
      model.Add("photos", currentUser.GetPhotos());
      model.Add("state", state);
      return View["photos.cshtml", model];
      };

      Get["/logout"] =_=>{
        Dictionary<string, object> model = new Dictionary<string, object>();
        User.DeleteState();
        return View["index.cshtml",model];
      };
    }
  }
}
