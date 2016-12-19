using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DateABase.Objects
{
  public class User
  {
    public int Id  {get; set;}
    public string Username {get; set;}
    public string Password {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Zipcode {get; set;}
    public string PhoneNumber {get; set;}
    public string Email {get; set;}
    public string AboutMe {get; set;}
    public string TagLine {get; set;}

    private List<string> UserInput = new List<string>{};

    public User(string username, string password, string firstName, string lastName, string zipcode, string email, string tagLine, string phoneNumber = null, string aboutMe = null, int id = 0)
    {
      this.Id = id;
      this.Username = username;
      this.Password = password;
      this.FirstName = firstName;
      this.LastName = lastName;
      this.Zipcode = zipcode;
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
        bool zipcodeEquality = this.Zipcode == newUser.Zipcode;
        bool phoneNumberEquality = this.PhoneNumber == newUser.PhoneNumber;
        bool emailEquality = this.Email == newUser.Email;
        bool aboutMeEquality = this.AboutMe == newUser.AboutMe;
        bool tageLineEquality = this.TagLine == newUser.TagLine;
        bool usernameEquality = this.Username == newUser.Username;
        bool passwordEquality = this.Password == newUser.Password;

        return (idEquality && firstNameEquality && lastNameEquality && zipcodeEquality && phoneNumberEquality && emailEquality && aboutMeEquality && tageLineEquality && usernameEquality && passwordEquality);
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
        string userZipcode = rdr.GetString(3);
        string userPhoneNumber = rdr.GetString(4);
        string userAboutMe = rdr.GetString(5);
        string userEmail = rdr.GetString(6);
        string userTagLine = rdr.GetString(7);
        string userUsername = rdr.GetString(8);
        string userPassword = rdr.GetString(9);

        User newUser = new User(userUsername, userPassword, userFirstName, userLastName, userZipcode, userPhoneNumber, userAboutMe, userEmail, userTagLine, userId);
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
  }
}
