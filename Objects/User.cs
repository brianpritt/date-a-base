using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DateABase.Objects
{
  public class User
  {
    public int Id  {get; set;}
    public string UserName {get; set;}
    public string Password {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string ZipCode {get; set;}
    public string PhoneNumber {get; set;}
    public string Email {get; set;}
    public string AboutMe {get; set;}
    public string TagLine {get; set;}

    private List<string> UserInput = new List<string>{};

    public User(string username, string password, string firstName = " ", string lastName = " ", string zipcode = "44313", string email = " ", string tagLine = " ", string phoneNumber = " ", string aboutMe = " ", int id = 0)
    {
      this.Id = id;
      this.UserName = username;
      this.Password = password;
      this.FirstName = firstName;
      this.LastName = lastName;
      this.ZipCode = zipcode;
      this.PhoneNumber = phoneNumber;
      this.Email = email;
      this.AboutMe = aboutMe;
      this.TagLine = tagLine;
    }
    public override bool Equals(System.Object otherUser)
    {
      if(!(otherUser is User))
      {
        return false;
      }
      else
      {
        User newUser = (User) otherUser;
        bool idEquality = this.Id == newUser.Id;
        bool firstNameEquality = this.FirstName == newUser.FirstName;
        bool lastNameEquality = this.LastName == newUser.LastName;
        bool zipcodeEquality = this.ZipCode == newUser.ZipCode;
        bool phoneNumberEquality = this.PhoneNumber == newUser.PhoneNumber;
        bool emailEquality = this.Email == newUser.Email;
        bool aboutMeEquality = this.AboutMe == newUser.AboutMe;
        bool tageLineEquality = this.TagLine == newUser.TagLine;
        bool usernameEquality = this.UserName == newUser.UserName;
        bool passwordEquality = this.Password == newUser.Password;

        return (idEquality && firstNameEquality && lastNameEquality && zipcodeEquality && phoneNumberEquality && emailEquality && aboutMeEquality && tageLineEquality && usernameEquality && passwordEquality);
      }
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO users (first_name, last_name, zip_code, email, phone_number, about_me, tag_line, user_name, password) OUTPUT INSERTED.id VALUES (@FirstName, @LastName, @ZipCode, @Email, @PhoneNumber, @AboutMe, @TagLine, @UserName, @Password);", conn);

      cmd.Parameters.AddWithValue("@FirstName", this.FirstName);
      cmd.Parameters.AddWithValue("@LastName", this.LastName);
      cmd.Parameters.AddWithValue("@ZipCode", this.ZipCode);
      cmd.Parameters.AddWithValue("@Email", this.Email);
      cmd.Parameters.AddWithValue("@PhoneNumber", this.PhoneNumber);
      cmd.Parameters.AddWithValue("@AboutMe", this.AboutMe);
      cmd.Parameters.AddWithValue("@TagLine", this.TagLine);
      cmd.Parameters.AddWithValue("@UserName", this.UserName);
      cmd.Parameters.AddWithValue("@Password", this.Password);

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


    public static List<User> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM users;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<User> allUsers = new List<User>{};

      while(rdr.Read())
      {
        int userId = rdr.GetInt32(0);
        string userFirstName = rdr.GetString(1);
        string userLastName = rdr.GetString(2);
        string userZipCode = rdr.GetString(3);
        string userPhoneNumber = rdr.GetString(4);
        string userAboutMe = rdr.GetString(5);
        string userEmail = rdr.GetString(6);
        string userTagLine = rdr.GetString(7);
        string userUserName = rdr.GetString(8);
        string userPassword = rdr.GetString(9);

        User newUser = new User(userUserName, userPassword, userFirstName, userLastName, userZipCode, userPhoneNumber, userAboutMe, userEmail, userTagLine, userId);
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
    public void Edit(string userName, string password, string firstName, string lastName, string zipCode, string email, string tagLine, string phoneNumber, string aboutMe)
    {
      Console.WriteLine(userName);
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE users SET first_name = @FirstName, last_name = @LastName, zip_code= @ZipCode, email= @Email, phone_number= @PhoneNumber, about_me= @AboutMe, tag_line= @TagLine, user_name= @UserName, password= @Password OUTPUT INSERTED.id, INSERTED.user_name, INSERTED.password, INSERTED.first_name, INSERTED.last_name, INSERTED.zip_code, INSERTED.phone_number, INSERTED.email, INSERTED.about_me, INSERTED.tag_line WHERE id = @UserId;", conn);

      cmd.Parameters.AddWithValue("@UserId", this.Id.ToString());
      cmd.Parameters.AddWithValue("@FirstName", firstName);
      cmd.Parameters.AddWithValue("@LastName", lastName);
      cmd.Parameters.AddWithValue("@ZipCode", zipCode);
      cmd.Parameters.AddWithValue("@Email", email);
      cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
      cmd.Parameters.AddWithValue("@AboutMe", aboutMe);
      cmd.Parameters.AddWithValue("@TagLine", tagLine);
      cmd.Parameters.AddWithValue("@UserName", userName);
      cmd.Parameters.AddWithValue("@Password", password);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this.Id = rdr.GetInt32(0);
        this.UserName = rdr.GetString(1);
        this.Password = rdr.GetString(2);
        this.FirstName = rdr.GetString(3);
        this.LastName = rdr.GetString(4);
        this.ZipCode = rdr.GetString(5);
        this.PhoneNumber = rdr.GetString(6);
        this.Email = rdr.GetString(7);
        this.AboutMe = rdr.GetString(8);
        this.TagLine = rdr.GetString(9);
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

    public static User Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE id = @UserId;", conn);
      SqlParameter UserIdParameter = new SqlParameter("@UserId", id.ToString());
      cmd.Parameters.Add(UserIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundUserId = 0;
      string foundFirstName = null;
      string foundLastName = null;
      string foundZipCode = null;
      string foundPhoneNumber = null;
      string foundAboutMe = null;
      string foundEmail = null;
      string foundTagLine = null;
      string foundUserName = null;
      string foundPassword = null;

      while(rdr.Read())
      {
        foundUserId = rdr.GetInt32(0);
        foundFirstName = rdr.GetString(1);
        foundLastName = rdr.GetString(2);
        foundZipCode = rdr.GetString(3);
        foundPhoneNumber = rdr.GetString(4);
        foundAboutMe = rdr.GetString(5);
        foundEmail = rdr.GetString(6);
        foundTagLine = rdr.GetString(7);
        foundUserName = rdr.GetString(8);
        foundPassword = rdr.GetString(9);

      }
      User foundUser = new User(foundUserName, foundPassword, foundFirstName, foundLastName, foundZipCode, foundEmail, foundTagLine, foundPhoneNumber, foundAboutMe, foundUserId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return foundUser;
    }

    public static User GetCurrentUser()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM state;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      int userId = 0;

      while(rdr.Read())
      {
        userId = rdr.GetInt32(1);
      }
      User currentUser = User.Find(userId);
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
      return currentUser;
    }

    public static void SetCurrentUser(User selectedUser)
    {

    }

    public static User FindByUserName(string userName)
    {
      User foundUser = new User("", "");
      return foundUser;
    }
    public static bool CheckLogin(string userName, string password)
    {
      return false;
    }
    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE id = @UserId; DELETE FROM state", conn);
      cmd.Parameters.AddWithValue("@UserId", this.Id.ToString());
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
      SqlCommand cmd = new SqlCommand("DELETE FROM users;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
