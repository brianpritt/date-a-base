
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DateABase.Objects
{
  public class Tag
  {
    public int Id  {get; set;}
    public string Name {get; set;}

    public Tag(string name, int id = 0)
    {
      this.Id = id;
      this.Name = name;
    }
    public override bool Equals(System.Object otherTag)
    {
      if(!(otherTag is Tag))
      {
        return false;
      }
      else
      {
        Tag newTag = (Tag) otherTag;
        bool idEquality = this.Id == newTag.Id;
        bool nameEquality = this.Name == newTag.Name;
        return (idEquality && nameEquality);
      }
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO tags (name) OUTPUT INSERTED.id VALUES (@Name);", conn);

      cmd.Parameters.AddWithValue("@Name", this.Name);

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

    public static List<Tag> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM tags;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<Tag> allTags = new List<Tag>{};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);

        Tag newTag = new Tag(name, id);
        allTags.Add(newTag);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(rdr != null)
      {
        conn.Close();
      }
      return allTags;
    }

    public static Tag Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM tags WHERE id = @TagId;", conn);
      SqlParameter TagIdParameter = new SqlParameter("@TagId", id.ToString());
      cmd.Parameters.Add(TagIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundId = 0;
      string foundName = null;

      while(rdr.Read())
      {
        foundId = rdr.GetInt32(0);
        foundName = rdr.GetString(1);
      }
      Tag foundTag = new Tag(foundName, foundId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return foundTag;
    }

    public List<User> GetUsers()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT users.* FROM tags JOIN tags_users ON (tags.id = tags_users.tag_id) JOIN users ON (tags_users.user_id = users.id) WHERE tags.id = @TagId;", conn);
      SqlParameter TagIdParameter = new SqlParameter("@TagId", this.Id.ToString());
      cmd.Parameters.Add(TagIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();
      List<User> allUsers = new List<User>{};

      while(rdr.Read())
      {
        int userId = rdr.GetInt32(0);
        string userFirstName = rdr.GetString(1);
        string userLastName = rdr.GetString(2);
        string userZipCode = rdr.GetString(3);
        string userEmail = rdr.GetString(6);
        string userPhoneNumber = rdr.GetString(4);
        string userAboutMe = rdr.GetString(5);
        string userTagLine = rdr.GetString(7);
        string userUserName = rdr.GetString(8);
        string userPassword = rdr.GetString(9);
        int userGender = rdr.GetInt32(10);
        int userSeekingGender = rdr.GetInt32(11);

        User newUser = new User(userUserName, userPassword, userFirstName, userLastName, userZipCode, userEmail, userPhoneNumber, userAboutMe, userTagLine, userGender, userSeekingGender, userId);
        allUsers.Add(newUser);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(rdr != null)
      {
        conn.Close();
      }
      return allUsers;
    }

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM tags WHERE id = @TagId;", conn);
      cmd.Parameters.AddWithValue("@TagId", this.Id.ToString());
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
      SqlCommand cmd = new SqlCommand("DELETE FROM tags;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
