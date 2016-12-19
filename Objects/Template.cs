using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DateABase.Objects
{
  public class User
  {
    public int Id  {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Zipcode {get; set;}
    public string PhoneNumber {get; set;}
    public string Email {get; set;}
    public string AboutMe {get; set;}
    public string Tagline {get; set;}
    public string Username {get; set;}
    public string Password {get; set;}

    private List<string> User = new List<string> {};

    public User(string firstName, string lastName, string zipcode,  string email,  string tagline, string username, string password, string phoneNumber = null, string aboutMe = null, int id = 0)
    {
      this.ID = id;
      this.FirstName = firstName;
      this.LastName = lastName;
      this.Zipcode = zipcode;
      this.PhoneNumber = phoneNumber;
      this.Email = email;
      this.AboutMe = aboutMe;
      this.Tagline = tagline;
      this.Username = username;
      this.Password = password;
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
        bool firstNameEquality = this.FirstName == newFirstName.FirstName;
        bool lastNameEquality = this.LastName == newLastName.LastName;
        bool zipcodeEquality = this.Zipcode == newZipcode.Zipcode;
        bool phoneNumberEquality = this.PhoneNumber == newPhoneNumber.PhoneNumber;
        bool emailEquality = this.Email == newEmail.Email;
        bool aboutMeEquality = this.AboutMe == newAboutMe.AboutMe;
        bool tageLineEquality = this.TagLine == newTagLine.TagLine;
        bool userNameEquality = this.UserName == newUserName.UserName;
        bool passwordEquality = this.Password == newPassword.Password;

        return (firstNameEquality && lastNameEquality && zipcodeEquality && phoneNumberEquality && emailEquality && aboutMeEquality && tageLineEquality && userNameEquality && passwordEquality);
      }
    }
  }
}
