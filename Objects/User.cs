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
    public int Gender {get; set;}
    public int SeekGender {get; set;}

    private List<string> UserInput = new List<string>{};

    public User(string username, string password, string firstName = " ", string lastName = " ", string zipcode = " ", string email = " ", string tagLine = " ", string phoneNumber = " ", string aboutMe = " ", int gender = 0, int seekGender = 0, int id = 0)
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
      this.Gender = gender;
      this.SeekGender = seekGender;
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
        bool genderEquality = this.Gender == newUser.Gender;
        bool seekGenderEquality = this.SeekGender == newUser.SeekGender;

        return (idEquality && firstNameEquality && lastNameEquality && zipcodeEquality && phoneNumberEquality && emailEquality && aboutMeEquality && tageLineEquality && usernameEquality && passwordEquality && genderEquality && seekGenderEquality);
      }
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO users (first_name, last_name, zip_code, email, phone_number, about_me, tag_line, user_name, password, gender_identity, seeking_gender) OUTPUT INSERTED.id VALUES (@FirstName, @LastName, @ZipCode, @Email, @PhoneNumber, @AboutMe, @TagLine, @UserName, @Password, @GenderIdentity, @SeekingGender);", conn);

      cmd.Parameters.AddWithValue("@FirstName", this.FirstName);
      cmd.Parameters.AddWithValue("@LastName", this.LastName);
      cmd.Parameters.AddWithValue("@ZipCode", this.ZipCode);
      cmd.Parameters.AddWithValue("@Email", this.Email);
      cmd.Parameters.AddWithValue("@PhoneNumber", this.PhoneNumber);
      cmd.Parameters.AddWithValue("@AboutMe", this.AboutMe);
      cmd.Parameters.AddWithValue("@TagLine", this.TagLine);
      cmd.Parameters.AddWithValue("@UserName", this.UserName);
      cmd.Parameters.AddWithValue("@Password", this.Password);
      cmd.Parameters.AddWithValue("@GenderIdentity", this.Gender.ToString());
      cmd.Parameters.AddWithValue("@SeekingGender", this.SeekGender.ToString());

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
    public void Edit(string userName, string password, string firstName, string lastName, string zipCode, string email, string tagLine, string phoneNumber, string aboutMe, int gender, int seekGender)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE users SET first_name = @FirstName, last_name = @LastName, zip_code= @ZipCode, email= @Email, phone_number= @PhoneNumber, about_me= @AboutMe, tag_line= @TagLine, user_name= @UserName, password = @Password, gender_identity = @Gender, seeking_gender = @SeekGender OUTPUT INSERTED.id, INSERTED.first_name, INSERTED.last_name, INSERTED.zip_code, INSERTED.email, INSERTED.phone_number, INSERTED.about_me, INSERTED.tag_line, INSERTED.user_name, INSERTED.password, INSERTED.gender_identity, INSERTED.seeking_gender WHERE id = @UserId;", conn);

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
      cmd.Parameters.AddWithValue("@Gender", gender);
      cmd.Parameters.AddWithValue("@SeekGender", seekGender);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this.Id = rdr.GetInt32(0);
        this.FirstName = rdr.GetString(1);
        this.LastName = rdr.GetString(2);
        this.ZipCode = rdr.GetString(3);
        this.Email = rdr.GetString(4);
        this.PhoneNumber = rdr.GetString(5);
        this.AboutMe = rdr.GetString(6);
        this.TagLine = rdr.GetString(7);
        this.UserName = rdr.GetString(8);
        this.Password = rdr.GetString(9);
        this.Gender = rdr.GetInt32(10);
        this.SeekGender = rdr.GetInt32(11);
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
      int foundGender = 0;
      int foundSeekGender = 0;

      while(rdr.Read())
      {
        foundUserId = rdr.GetInt32(0);
        foundFirstName = rdr.GetString(1);
        foundLastName = rdr.GetString(2);
        foundZipCode = rdr.GetString(3);
        foundEmail = rdr.GetString(4);
        foundPhoneNumber = rdr.GetString(5);
        foundAboutMe = rdr.GetString(6);
        foundTagLine = rdr.GetString(7);
        foundUserName = rdr.GetString(8);
        foundPassword = rdr.GetString(9);
        foundGender = rdr.GetInt32(10);
        foundSeekGender = rdr.GetInt32(11);

      }
      User foundUser = new User(foundUserName, foundPassword, foundFirstName, foundLastName, foundZipCode, foundEmail, foundTagLine, foundPhoneNumber, foundAboutMe, foundGender, foundSeekGender, foundUserId);

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

      SqlCommand cmd = new SqlCommand("SELECT user_id FROM state;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      int userId = 0;

      while(rdr.Read())
      {
        userId = rdr.GetInt32(0);
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
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO state (user_id) VALUES (@UserId);", conn);

      cmd.Parameters.AddWithValue("@UserId", selectedUser.Id.ToString());
      cmd.ExecuteNonQuery();


      if(conn!=null)
      {
        conn.Close();
      }
    }
    public static void ChangeCurrentUser(User selectedUser)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE state SET user_id = @UserId;", conn);

      cmd.Parameters.AddWithValue("@UserId", selectedUser.Id.ToString());
      cmd.ExecuteNonQuery();

      if(conn!=null)
      {
        conn.Close();
      }
    }

    public static User FindByUserName(string userName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE user_name = @UserName;", conn);
      SqlParameter UserIdParameter = new SqlParameter("@UserName", userName.ToString());
      cmd.Parameters.Add(UserIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundUserId = 0;
      string foundFirstName = null;
      string foundLastName = null;
      string foundZipCode = null;
      string foundEmail = null;
      string foundPhoneNumber = null;
      string foundAboutMe = null;
      string foundTagLine = null;
      string foundUserName = null;
      string foundPassword = null;
      int foundGender = 0;
      int foundSeekGender = 0;

      while(rdr.Read())
      {
        foundUserId = rdr.GetInt32(0);
        foundFirstName = rdr.GetString(1);
        foundLastName = rdr.GetString(2);
        foundZipCode = rdr.GetString(3);
        foundEmail = rdr.GetString(4);
        foundPhoneNumber = rdr.GetString(5);
        foundAboutMe = rdr.GetString(6);
        foundTagLine = rdr.GetString(7);
        foundUserName = rdr.GetString(8);
        foundPassword = rdr.GetString(9);
        foundGender = rdr.GetInt32(10);
        foundSeekGender = rdr.GetInt32(11);

      }
      User foundUser = new User(foundUserName, foundPassword, foundFirstName, foundLastName, foundZipCode, foundEmail, foundTagLine, foundPhoneNumber, foundAboutMe, foundGender, foundSeekGender, foundUserId);

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
    public void AddPhoto(Photo newPhoto)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO photos (user_id, url, profile) OUTPUT INSERTED.id VALUES (@UserId, @Url, @Profile);", conn);

      cmd.Parameters.AddWithValue("@UserId", this.Id.ToString());
      cmd.Parameters.AddWithValue("@Url", newPhoto.Url);
      cmd.Parameters.AddWithValue("@Profile", newPhoto.Profile);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        newPhoto.Id = rdr.GetInt32(0);
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

    public List<Photo> GetPhotos()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM photos WHERE user_id = @UserId;", conn);
      cmd.Parameters.AddWithValue("@UserId", this.Id);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<Photo> allPhotos = new List<Photo>{};

      while(rdr.Read())
      {
        int photoId = rdr.GetInt32(0);
        int userId = rdr.GetInt32(1);
        string photoUrl = rdr.GetString(2);
        bool profile = rdr.GetBoolean(3);

        Photo newPhoto = new Photo(userId, photoUrl, profile, photoId);
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

    public Photo GetProfilePhoto()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM photos WHERE user_id = @UserId AND profile = @Profile;", conn);
      cmd.Parameters.AddWithValue("@UserId", this.Id.ToString());
      cmd.Parameters.AddWithValue("@Profile", 1.ToString());

      SqlDataReader rdr = cmd.ExecuteReader();
      int photoId = 0;
      int userId = 0;
      string photoUrl = null;
      bool profile = false;
      while(rdr.Read())
      {
        photoId = rdr.GetInt32(0);
        userId = rdr.GetInt32(1);
        photoUrl = rdr.GetString(2);
        profile = rdr.GetBoolean(3);
      }
      Photo profilePhoto = new Photo(userId, photoUrl, profile, photoId);


      if(rdr != null)
      {
        rdr.Close();
      }
      if(rdr != null)
      {
        conn.Close();
      }
      return profilePhoto;
    }

    public List<Message> GetAllReceivedMessages()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE receiver_id = @ReceiverId;", conn);
      cmd.Parameters.AddWithValue("@ReceiverId", this.Id);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<Message> allMessages = new List<Message>{};

      while(rdr.Read())
      {
        int messageId = rdr.GetInt32(0);
        int messageSenderId = rdr.GetInt32(1);
        int messageReceiverId = rdr.GetInt32(2);
        string messageBody = rdr.GetString(3);
        bool messageViewed = rdr.GetBoolean(4);

        Message newMessage = new Message(messageSenderId, messageReceiverId, messageBody, messageViewed, messageId);
        allMessages.Add(newMessage);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(rdr != null)
      {
        conn.Close();
      }
      return allMessages;
    }

    public List<Message> GetAllSentMessages()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE sender_id = @SenderId;", conn);
      cmd.Parameters.AddWithValue("@SenderId", this.Id);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<Message> allMessages = new List<Message>{};

      while(rdr.Read())
      {
        int messageId = rdr.GetInt32(0);
        int messageSenderId = rdr.GetInt32(1);
        int messageReceiverId = rdr.GetInt32(2);
        string messageBody = rdr.GetString(3);
        bool messageViewed = rdr.GetBoolean(4);

        Message newMessage = new Message(messageSenderId, messageReceiverId, messageBody, messageViewed, messageId);
        allMessages.Add(newMessage);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(rdr != null)
      {
        conn.Close();
      }
      return allMessages;
    }

    public List<Message> GetCorrespondenceFromDater(User sender)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE (sender_id = @SenderId AND receiver_id = @CurrentUserId) OR (sender_id = @CurrentUserId AND receiver_id = @SenderId);", conn);
      cmd.Parameters.AddWithValue("@CurrentUserId", this.Id);
      cmd.Parameters.AddWithValue("@SenderId", sender.Id);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<Message> allMessages = new List<Message>{};

      while(rdr.Read())
      {
        int messageId = rdr.GetInt32(0);
        int messageSenderId = rdr.GetInt32(1);
        int messageReceiverId = rdr.GetInt32(2);
        string messageBody = rdr.GetString(3);
        bool messageViewed = rdr.GetBoolean(4);

        Message newMessage = new Message(messageSenderId, messageReceiverId, messageBody, messageViewed, messageId);
        allMessages.Add(newMessage);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(rdr != null)
      {
        conn.Close();
      }
      return allMessages;
    }

    public List<Message> GetAllUnreadMessages()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE viewed = 0 AND receiver_id = @ReceiverId;", conn);
      cmd.Parameters.AddWithValue("@ReceiverId", this.Id);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<Message> allMessages = new List<Message>{};

      while(rdr.Read())
      {
        int messageId = rdr.GetInt32(0);
        int messageSenderId = rdr.GetInt32(1);
        int messageReceiverId = rdr.GetInt32(2);
        string messageBody = rdr.GetString(3);
        bool messageViewed = rdr.GetBoolean(4);

        Message newMessage = new Message(messageSenderId, messageReceiverId, messageBody, messageViewed, messageId);
        allMessages.Add(newMessage);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(rdr != null)
      {
        conn.Close();
      }
      return allMessages;
    }

    public List<Message> GetAllReadMessages()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE viewed = 1 AND receiver_id = @ReceiverId;", conn);
      cmd.Parameters.AddWithValue("@ReceiverId", this.Id);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<Message> allMessages = new List<Message>{};

      while(rdr.Read())
      {
        int messageId = rdr.GetInt32(0);
        int messageSenderId = rdr.GetInt32(1);
        int messageReceiverId = rdr.GetInt32(2);
        string messageBody = rdr.GetString(3);
        bool messageViewed = rdr.GetBoolean(4);

        Message newMessage = new Message(messageSenderId, messageReceiverId, messageBody, messageViewed, messageId);
        allMessages.Add(newMessage);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(rdr != null)
      {
        conn.Close();
      }
      return allMessages;
    }

    public List<Message> FindMessagesByUserName(string userName)
    {
      List<Message> messageList = new List<Message>{};
      User selectedUser = User.FindByUserName(userName);
      int userId = selectedUser.Id;
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE sender_id = @SenderId AND receiver_id = @ReceiverId; SELECT * FROM messages WHERE receiver_id = @SenderId AND sender_id = @ReceiverId", conn);
      cmd.Parameters.AddWithValue("@SenderId", this.Id.ToString());
      cmd.Parameters.AddWithValue("@ReceiverId", selectedUser.Id.ToString());

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int foundMessageId = rdr.GetInt32(0);
        int foundSenderId = rdr.GetInt32(1);
        int foundReceiverId = rdr.GetInt32(2);
        string foundMessageBody = rdr.GetString(3);
        bool foundViewed = rdr.GetBoolean(4);
        Message foundMessage = new Message(foundSenderId, foundReceiverId, foundMessageBody, foundViewed, foundMessageId);
        messageList.Add(foundMessage);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return messageList;
    }
    public static bool CheckLogin(string userName, string password)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT user_name, password FROM users WHERE user_name = @UserName AND password = @Password;", conn);
      cmd.Parameters.AddWithValue("@UserName", userName);
      cmd.Parameters.AddWithValue("@Password", password);
      SqlDataReader rdr = cmd.ExecuteReader();

      string loginUserName = null;
      string loginPassword = null;

      while(rdr.Read())
      {
        loginUserName = rdr.GetString(0);
        loginPassword = rdr.GetString(1);
      }
      User userLogin = new User(loginUserName, loginPassword);

      if (rdr != null)
      {
        rdr.Close();
      }

      if (conn != null)
      {
        conn.Close();
      }

      if ((loginUserName == userName) && (loginPassword == password))
      {
        return true;
      }
      return false;
    }
    public static bool CheckUserName(string newUserName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT user_name FROM users WHERE user_name = @NewUserName;", conn);
      cmd.Parameters.AddWithValue("@NewUserName", newUserName);
      SqlDataReader rdr = cmd.ExecuteReader();
      string foundUserName = null;
      bool userNameExists = false;
      while(rdr.Read())
      {
        foundUserName = rdr.GetString(0);
        if(foundUserName != null)
        {
          userNameExists = true;
        }
      }
      if (rdr != null)
      {
        rdr.Close();
      }

      if (conn != null)
      {
        conn.Close();
      }
      return userNameExists;
    }
    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE id = @UserId; DELETE FROM state; DELETE FROM messages WHERE sender_id = @UserId OR receiver_id = @UserId", conn);
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
      SqlCommand cmd = new SqlCommand("DELETE FROM users; DELETE FROM state", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
