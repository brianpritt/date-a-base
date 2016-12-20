using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using DateABase.Objects;

namespace  DateABase
{
  public class MessageTest : IDisposable
  {
    public void MessageTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=date_a_base_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void GetAll_ReturnsEmpty_zero()
    {
      User newUser = ("mamaBear", "honey");
      int result = User.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
    public void Save_SavesCorrectMessage_true()
    {
      Message newMessage = new Message(0, 0, "hello there! I'd like to byte you bits...");
      newUser.Save();
      List<User> allUsers = User.GetAll();
      User actualUser = allUsers[0];
      Assert.Equal(newUser, actualUser);
    }
    // [Fact]
    // public void Find_FindUserInDataBase()
    // {
    //   User user1 = new User("mammaBear", "honey");
    //   user1.Save();
    //   User user2 = new User("DogMan", "bark");
    //   user2.Save();
    //
    //   User foundUser = User.Find(user1.Id);
    //
    //   Assert.Equal(user1, foundUser);
    // }
    // [Fact]
    // public void Edit_EditCorrectUser()
    // {
    //   User user1 = new User("mammaBear", "honey");
    //   user1.Save();
    //   user1.Edit("DogMan", "bark", " ", " ", " ", " ", " ", " ", " ");
    //   User expectedUser = new User("DogMan", "bark", " ", " ", " ", " ", " ", " ", " ");
    //
    //   Assert.Equal(expectedUser.UserName, user1.UserName);
    // }
    // [Fact]
    // public void Delete_DeletesCurrentUser_true()
    // {
    //   User newUser = new User("mamaBear", "honey");
    //   newUser.Save();
    //   newUser.Delete();
    //   List<User> allUsers = User.GetAll();
    //   Assert.Equal(0, allUsers.Count);
    // }
    // [Fact]
    // public void Delete_DeletesCurrentUser_false()
    // {
    //   User newUser = new User("mamaBear", "honey");
    //   newUser.Save();
    //   List<User> allUsers = User.GetAll();
    //   Assert.Equal(1, allUsers.Count);
    // }
    //
    // [Fact]
    // public void GetCurrentUser_GetsCurrentUserFromState()
    // {
    //   User newUser = new User("DogMan", "bark", " ", " ", " ", " ", " ", " ", " ");
    //   newUser.Save();
    //   User.SetCurrentUser(newUser);
    //
    //   User selectedUser = User.GetCurrentUser();
    //
    //   Assert.Equal(newUser.UserName, selectedUser.UserName);
    //
    // }
    //
    // [Fact]
    // public void GetCurrentUser_ChangesCurrentUserFromState()
    // {
    //   User newUser = new User("DogMan", "bark", " ", " ", " ", " ", " ", " ", " ");
    //   User newCurrentUser = new User("mamaBear", "honey", " ", " ", " ", " ", " ", " ", " ");
    //   User.SetCurrentUser(newUser);
    //   newUser.Save();
    //   newCurrentUser.Save();
    //   User.ChangeCurrentUser(newCurrentUser);
    //
    //   User selectedUser = User.GetCurrentUser();
    //
    //   Assert.Equal(newCurrentUser.UserName, selectedUser.UserName);
    //
    // }
    public void Dispose()
    {
      User.DeleteAll();
    }
  }
}
