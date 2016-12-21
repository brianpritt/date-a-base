
using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using DateABase.Objects;

namespace  DateABase
{
  public class PhotoTest : IDisposable
  {
    public void PhotoInputTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=date_a_base_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void GetAll_ReturnsEmpty_zero()
    {
      User newUser = new User("mammaBear", "honey");
      Photo newPhoto = new Photo(newUser.Id, "my/photo.jpeg",  false);
      int result = Photo.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
    public void Save_SavesCorrectPhoto_true()
    {
      User newUser = new User("mammaBear", "honey");
      Photo newPhoto = new Photo(newUser.Id, "my/photo.jpeg",  false);
      newPhoto.Save();
      List<Photo> allPhotos = Photo.GetAll();
      Photo actualPhoto = allPhotos[0];
      Assert.Equal(newPhoto, actualPhoto);
    }
    [Fact]
    public void GetPhotos_GetsAllUserPhotos_true()
    {
      User newUser = new User("mammaBear", "honey");
      newUser.Save();
      Photo newPhoto = new Photo(newUser.Id, "another/photo.jpeg",  true);
      Photo newPhoto2 = new Photo(newUser.Id, "my/photo.jpeg",  false);
      newPhoto.Save();
      newPhoto2.Save();
      List<Photo> allPhotos = newUser.GetPhotos();
      Assert.Equal(2, allPhotos.Count);
    }
    // [Fact]
    // public void MakeProfile_ChangesProfilePic_true()
    // {
    //   User user1 = new User("mammaBear", "honey");
    //   user1.Save();
    //   Photo newPhoto = new Photo(newUser.Id, "another/photo.jpeg",  true);
    //   newPhoto.Save();
    //   Photo newPhoto2 = new Photo(newUser.Id, "my/photo.jpeg");
    //   newPhoto.MakeProfile();
    //   List<Photo> allSentPhotos = user1.GetAllSentPhotos();
    //   Assert.Equal(1, allSentPhotos.Count);
    // }
  //   [Fact]
  //   public void GetAllUnreadPhotos_GetsUnreadPhotos_true()
  //   {
  //     User user1 = new User("mammaBear", "honey");
  //     user1.Save();
  //     Photo newPhoto = new Photo(1,user1.Id, "hello there! I'm a backend man!", true);
  //     newPhoto.Save();
  //     Photo anotherPhoto = new Photo(1, user1.Id, "hello there! Wanna finger my keys?", false);
  //     anotherPhoto.Save();
  //     List<Photo> allSentPhotos = user1.GetAllUnreadPhotos();
  //     Assert.Equal(1, allSentPhotos.Count);
  //   }
  //   [Fact]
  //   public void GetAllReadPhotos_GetsReadPhotos_true()
  //   {
  //     User user1 = new User("mammaBear", "honey");
  //     user1.Save();
  //     Photo newPhoto = new Photo(1,user1.Id, "hello there! I'm a backend man!", true);
  //     newPhoto.Save();
  //     Photo anotherPhoto = new Photo(1, user1.Id, "hello there! Wanna finger my keys?", false);
  //     anotherPhoto.Save();
  //     List<Photo> allSentPhotos = user1.GetAllReadPhotos();
  //     Assert.Equal(1, allSentPhotos.Count);
  //   }
  //
  //   [Fact]
  //   public void GetCorrespondenceFromDater_GetsCorrespondenceFromSpecificDater_true()
  //   {
  //     User user1 = new User("mammaBear", "honey");
  //     user1.Save();
  //     User user2 = new User("papabear", "salmon");
  //     user2.Save();
  //     Photo newPhoto = new Photo(user2.Id,user1.Id, "hello there! I'm a backend man!", false);
  //     newPhoto.Save();
  //     Photo anotherPhoto = new Photo(user1.Id, user2.Id, "hello there! Wanna finger my keys?", false);
  //     anotherPhoto.Save();
  //     List<Photo> allSentPhotos = user1.GetCorrespondenceFromDater(user2);
  //     Assert.Equal(2, allSentPhotos.Count);
  //   }
  //   [Fact]
  //   public void Delete_DeletsPhotoFromDB_true()
  //   {
  //     Photo newPhoto = new Photo(0, 0, "hello there! I'd like to byte your bits...");
  //     newPhoto.Save();
  //     newPhoto.Delete();
  //     List<Photo> allPhotos = Photo.GetAll();
  //     Assert.Equal(0, allPhotos.Count);
  //   }
  //
    public void Dispose()
    {
      Photo.DeleteAll();
      User.DeleteAll();
    }
  }
}
