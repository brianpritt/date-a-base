
using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using DateABase.Objects;

namespace  DateABase
{
  public class TagTest : IDisposable
  {
    public void TagInputTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=date_a_base_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void GetAll_ReturnsEmpty_zero()
    {
      User newUser = new User("mammaBear", "honey");
      Tag newTag = new Tag("mytag", newUser.Id);
      int result = Tag.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
    public void Save_SavesCorrectTag_true()
    {
      User newUser = new User("mammaBear", "honey");
      Tag newTag = new Tag("mytag", newUser.Id);
      newTag.Save();
      List<Tag> allTags = Tag.GetAll();
      Tag actualTag = allTags[0];
      Assert.Equal(newTag, actualTag);
    }
    [Fact]
    public void GetTags_GetsAllUserTags_true()
    {
      User newUser = new User("mammaBear", "honey");
      newUser.Save();
      Tag newTag = new Tag("anothertag");
      Tag newTag2 = new Tag("mytag");
      newTag.Save();
      newTag2.Save();
      newUser.AddTag(newTag);
      newUser.AddTag(newTag2);

      List<Tag> allTags = newUser.GetTags();
      Assert.Equal(2, allTags.Count);
    }
    [Fact]
    public void GetUsers_GetsAllUsersWithTag_true()
    {
      User newUser = new User("mammaBear", "honey");
      newUser.Save();
      User user1 = new User("DogMan", "bark");
      user1.Save();
      Tag newTag = new Tag("mytag");
      newTag.Save();
      user1.AddTag(newTag);
      newUser.AddTag(newTag);
      List<User> allUsers = newTag.GetUsers();
      Assert.Equal(2, allUsers.Count);
    }
    [Fact]
    public void Find_FindTag_true()
    {
      Tag newTag = new Tag("mytag");
      newTag.Save();

      Tag foundTag = Tag.Find(newTag.Id);
      Assert.Equal(newTag, foundTag);
    }
    [Fact]
    public void Delete_DeletesCorrectTag_true()
    {
      Tag newTag = new Tag("mytag");
      newTag.Save();
      newTag.Delete();
      List<Tag> allTags = Tag.GetAll();
      Assert.Equal(0, allTags.Count);
    }
    public void Dispose()
    {
      Tag.DeleteAll();
      User.DeleteAll();
    }
  }
}
