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
    public void Dispose()
    {
      User.DeleteAll();
    }
  }
}
