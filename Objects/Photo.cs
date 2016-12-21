
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DateABase.Objects
{
  public class Photo
  {
    public int Id  {get; set;}
    public int UserId {get; set;}
    public string Url {get; set;}
    public bool Profile {get; set;}

    public Photo(int userId, string url, bool profile = false, int id = 0)
    {
      this.Id = id;
      this.UserId = userId;
      this.Url = url;
      this.Profile = profile;
    }
    public override bool Equals(System.Object otherPhoto)
    {
      if(!(otherPhoto is Photo))
      {
        return false;
      }
      else
      {
        Photo newPhoto = (Photo) otherPhoto;
        bool idEquality = this.Id == newPhoto.Id;
        bool urlEquality = this.Url == newPhoto.Url;
        bool profileEquality = this.Profile == newPhoto.Profile;
        bool userIdEquality = this.UserId == newPhoto.UserId;

        return (idEquality && urlEquality && profileEquality && userIdEquality);
      }
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO photos (sender_id, body, profile) OUTPUT INSERTED.id VALUES (@UserId, @Url, @Profile);", conn);

      cmd.Parameters.AddWithValue("@Url", this.Url);
      cmd.Parameters.AddWithValue("@Profile", this.Profile);
      cmd.Parameters.AddWithValue("@UserId", this.UserId);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this.Id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static List<Photo> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM photos;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<Photo> allPhotos = new List<Photo>{};

      while(rdr.Read())
      {
        int photoId = rdr.GetInt32(0);
        int userId = rdr.GetInt32(1);
        string body = rdr.GetString(3);
        bool profile = rdr.GetBoolean(4);

        Photo newPhoto = new Photo(userId, body, profile, photoId);
        allPhotos.Add(newPhoto);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(rdr != null)
      {
        conn.Close();
      }
      return allPhotos;
    }
    public void MakeProfile()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE photos SET profile = @Profile, OUTPUT INSERTED.profile WHERE id = @PhotoId;", conn);

      cmd.Parameters.AddWithValue("@PhotoId", this.Id.ToString());
      cmd.Parameters.AddWithValue("@Profile", 1);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this.Profile = rdr.GetBoolean(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static Photo Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM photos WHERE id = @PhotoId;", conn);
      SqlParameter PhotoIdParameter = new SqlParameter("@PhotoId", id.ToString());
      cmd.Parameters.Add(PhotoIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundPhotoId = 0;
      string foundUrl = null;
      bool foundProfile = false;
      int foundUserId = 0;

      while(rdr.Read())
      {
        foundPhotoId = rdr.GetInt32(0);
        foundUserId = rdr.GetInt32(1);
        foundUrl = rdr.GetString(3);
        foundProfile = rdr.GetBoolean(4);

      }
      Photo foundPhoto = new Photo(foundUserId, foundUrl, foundProfile, foundPhotoId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return foundPhoto;
    }



    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM photos WHERE id = @PhotoId;", conn);
      cmd.Parameters.AddWithValue("@PhotoId", this.Id.ToString());
      cmd.ExecuteNonQuery();

      if(conn!=null)
      {
        conn.Close();
      }
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM photos;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
