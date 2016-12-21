using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using DateABase.Objects;

namespace  DateABase
{
  public class UserTest : IDisposable
  {
    public void UserInputTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=date_a_base_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void GetAll_ReturnsEmpty_zero()
    {
      int result = User.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
    public void Save_SavesCorrectUser_true()
    {
      User newUser = new User("mamaBear", "honey");
      newUser.Save();
      List<User> allUsers = User.GetAll();
      User actualUser = allUsers[0];
      Assert.Equal(newUser, actualUser);
    }
    [Fact]
    public void Find_FindUserInDataBase()
    {
      User user1 = new User("mammaBear", "honey");
      user1.Save();
      User user2 = new User("DogMan", "bark");
      user2.Save();

      User foundUser = User.Find(user1.Id);

      Assert.Equal(user1, foundUser);
    }
    [Fact]
    public void Edit_EditCorrectUser()
    {
      User user1 = new User("mammaBear", "honey");
      user1.Save();
      user1.Edit("DogMan", "bark", " ", " ", " ", " ", " ", " ", " ", 0, 0);
      User expectedUser = new User("DogMan", "bark", " ", " ", " ", " ", " ", " ", " ", 0 , 0);

      Assert.Equal(expectedUser.UserName, user1.UserName);
    }
    [Fact]
    public void Delete_DeletesCurrentUser_true()
    {
      User newUser = new User("mamaBear", "honey");
      newUser.Save();
      newUser.Delete();
      List<User> allUsers = User.GetAll();
      Assert.Equal(0, allUsers.Count);
    }
    [Fact]
    public void Delete_DeletesCurrentUser_false()
    {
      User newUser = new User("mamaBear", "honey");
      newUser.Save();
      List<User> allUsers = User.GetAll();
      Assert.Equal(1, allUsers.Count);
    }

    [Fact]
    public void GetCurrentUser_GetsCurrentUserFromState()
    {
      User newUser = new User("DogMan", "bark", " ", " ", " ", " ", " ", " ", " ");
      newUser.Save();
      User.SetCurrentUser(newUser);

      User selectedUser = User.GetCurrentUser();

      Assert.Equal(newUser.UserName, selectedUser.UserName);
    }

    [Fact]
    public void GetCurrentUser_ChangesCurrentUserFromState()
    {
      User newUser = new User("DogMan", "bark", " ", " ", " ", " ", " ", " ", " ");
      User newCurrentUser = new User("mamaBear", "honey", " ", " ", " ", " ", " ", " ", " ");
      User.SetCurrentUser(newUser);
      newUser.Save();
      newCurrentUser.Save();
      User.ChangeCurrentUser(newCurrentUser);

      User selectedUser = User.GetCurrentUser();

      Assert.Equal(newCurrentUser.UserName, selectedUser.UserName);
    }
    [Fact]
    public void FindByUserName_FindUserInDataBase()
    {
      User user1 = new User("mammaBear", "honey");
      user1.Save();
      User user2 = new User("DogMan", "bark");
      user2.Save();

      User foundUser = User.FindByUserName("DogMan");

      Assert.Equal(user2, foundUser);
    }
    [Fact]
    public void FindByUserName_CheckLogin()
    {
      User user1 = new User("Taylor", "honda");
      user1.Save();

      bool correctUser = User.CheckLogin("Taylor", "honda");

      Assert.Equal(correctUser, true);
    }
    [Fact]
    public void CheckUserName_CheckIfUserNameExists_true()
    {
      User user1 = new User("mammaBear", "honey");
      user1.Save();
      User user2 = new User("DogMan", "bark");
      user2.Save();
      User user3 = new User("mammaBear", "honey");
      bool userNameExists = User.CheckUserName(user3.UserName);
      Assert.Equal(true, userNameExists);

    }

    public void Dispose()
    {
      User.DeleteAll();
    }
  }
}
