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
    [Fact]
    public void ConvertGender_ChangesIntToListOfPronouns_true()
    {
      User newUser = new User("mamaBear", "honey", " ", " ", " ", " ", " ", " ", " ", 1, 4);
      newUser.Save();
      string actual = newUser.ConvertGender(newUser.Gender);
      List<string> expectedPronouns = new List<string>{"she"};
      string expected = String.Join(", ", expectedPronouns);
      Assert.Equal(expected, actual);

    }
    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(1, 9, 7)]
    [InlineData(1, 4, 3)]
    [InlineData(4, 1, 3)]
    [InlineData(4, 4, 9)]
    [InlineData(4, 9, 21)]
    [InlineData(9, 1, 7)]
    [InlineData(9, 4, 21)]
    [InlineData(9, 9, 49)]

    public void MatchByGender_FiltersUserGender(int userGender, int seekGender, int result)
    {
      User newUser = new User("mamaBear", "honey", " ", " ", " ", " ", " ", " ", " ", userGender, seekGender);
      newUser.Save();

      User dater1 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 1, 1);
      dater1.Save();
      User dater2 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 1, 3);
      dater2.Save();
      User dater3 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 1, 5);
      dater3.Save();
      User dater4 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 1, 4);
      dater4.Save();
      User dater5 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 1, 6);
      dater5.Save();
      User dater6 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 1, 8);
      dater6.Save();
      User dater7 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 1, 9);
      dater7.Save();

      User dater8 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 3, 1);
      dater8.Save();
      User dater9 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 3, 3);
      dater9.Save();
      User dater10 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 3, 5);
      dater10.Save();
      User dater11 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 3, 4);
      dater11.Save();
      User dater12 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 3, 6);
      dater12.Save();
      User dater13 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 3, 8);
      dater13.Save();
      User dater14 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 3, 9);
      dater14.Save();

      User dater15 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 5, 1);
      dater15.Save();
      User dater16 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 5, 3);
      dater16.Save();
      User dater17 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 5, 5);
      dater17.Save();
      User dater18 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 5, 4);
      dater18.Save();
      User dater19 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 5, 6);
      dater19.Save();
      User dater20 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 5, 8);
      dater20.Save();
      User dater21 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 5, 9);
      dater21.Save();

      User dater22 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 4, 1);
      dater22.Save();
      User dater23 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 4, 3);
      dater23.Save();
      User dater24 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 4, 5);
      dater24.Save();
      User dater25 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 4, 4);
      dater25.Save();
      User dater26 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 4, 6);
      dater26.Save();
      User dater27 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 4, 8);
      dater27.Save();
      User dater28 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 4, 9);
      dater28.Save();

      User dater29 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 6, 1);
      dater29.Save();
      User dater30 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 6, 3);
      dater30.Save();
      User dater31 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 6, 5);
      dater31.Save();
      User dater32 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 6, 4);
      dater32.Save();
      User dater33 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 6, 6);
      dater33.Save();
      User dater34 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 6, 8);
      dater34.Save();
      User dater35 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 6, 9);
      dater35.Save();

      User dater36 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 8, 1);
      dater36.Save();
      User dater37 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 8, 3);
      dater37.Save();
      User dater38 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 8, 5);
      dater38.Save();
      User dater39 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 8, 4);
      dater39.Save();
      User dater40 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 8, 6);
      dater40.Save();
      User dater41 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 8, 8);
      dater41.Save();
      User dater42 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 8, 9);
      dater42.Save();

      User dater43 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 9, 1);
      dater43.Save();
      User dater44 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 9, 3);
      dater44.Save();
      User dater45 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 9, 5);
      dater45.Save();
      User dater46 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 9, 4);
      dater46.Save();
      User dater47 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 9, 6);
      dater47.Save();
      User dater48 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 9, 8);
      dater48.Save();
      User dater49 = new User("CatMan", "meow", " ", " ", " ", " ", " ", " ", " ", 9, 9);
      dater49.Save();





      List<User> resultUsers = newUser.MatchByGender(newUser.Gender, newUser.SeekGender, newUser.Id);

      Assert.Equal(result, resultUsers.Count);
    }

    public void Dispose()
    {
      User.DeleteAll();
    }
  }
}
