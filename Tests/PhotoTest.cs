
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
      newUser.AddPhoto(newPhoto2);
      List<Photo> allPhotos = newUser.GetPhotos();
      Assert.Equal(2, allPhotos.Count);
    }
    [Fact]
    public void MakeProfile_ChangesProfilePic_true()
    {
      User user1 = new User("mammaBear", "honey");
      user1.Save();
      Photo newPhoto = new Photo(user1.Id, "another/photo.jpeg",  true);
      newPhoto.Save();
      Photo newPhoto2 = new Photo(user1.Id, "my/photo.jpeg");
      newPhoto2.Save();
      newPhoto2.MakeProfile(user1.Id);
      Photo profilePhoto = user1.GetProfilePhoto();
      Assert.Equal(newPhoto2, profilePhoto);
    }
    [Fact]
    public void Find_FindPhoto_true()
    {
      Photo newPhoto = new Photo(0, "another/photo.jpeg",  true);
      newPhoto.Save();

      Photo foundPhoto = Photo.Find(newPhoto.Id);
      Assert.Equal(newPhoto, foundPhoto);
    }
    [Fact]
    public void Delete_DeletesCorrectPhoto_true()
    {
      User newUser = new User("mammaBear", "honey");
      Photo newPhoto = new Photo(newUser.Id, "my/photo.jpeg",  false);
      newPhoto.Save();
      newPhoto.Delete();
      List<Photo> allPhotos = Photo.GetAll();
      Assert.Equal(0, allPhotos.Count);
    }
    public void Dispose()
    {
      Photo.DeleteAll();
      User.DeleteAll();
    }
  }
}
