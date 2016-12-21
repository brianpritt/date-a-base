using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DateABase.Objects
{
  public class Message
  {
    public int Id  {get; set;}
    public int SenderId {get; set;}
    public int ReceiverId {get; set;}
    public string MessageBody {get; set;}
    public bool Viewed {get; set;}

    public Message(int senderId, int receiverId, string messageBody, bool viewed = false, int id = 0)
    {
      this.Id = id;
      this.SenderId = senderId;
      this.ReceiverId = receiverId;
      this.MessageBody = messageBody;
      this.Viewed = viewed;
    }
    public override bool Equals(System.Object otherMessage)
    {
      if(!(otherMessage is Message))
      {
        return false;
      }
      else
      {
        Message newMessage = (Message) otherMessage;
        bool idEquality = this.Id == newMessage.Id;
        bool messageBodyEquality = this.MessageBody == newMessage.MessageBody;
        bool viewedEquality = this.Viewed == newMessage.Viewed;
        bool senderIdEquality = this.SenderId == newMessage.SenderId;
        bool receiverIdEquality = this.ReceiverId == newMessage.ReceiverId;

        return (idEquality && messageBodyEquality && viewedEquality && senderIdEquality && receiverIdEquality);
      }
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO messages (sender_id, receiver_id, body, viewed) OUTPUT INSERTED.id VALUES (@SenderId, @ReceiverId, @MessageBody, @Viewed);", conn);

      cmd.Parameters.AddWithValue("@MessageBody", this.MessageBody);
      cmd.Parameters.AddWithValue("@Viewed", this.Viewed);
      cmd.Parameters.AddWithValue("@SenderId", this.SenderId);
      cmd.Parameters.AddWithValue("@ReceiverId", this.ReceiverId);

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

    public static List<Message> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM messages;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<Message> allMessages = new List<Message>{};

      while(rdr.Read())
      {
        int messageId = rdr.GetInt32(0);
        int senderId = rdr.GetInt32(1);
        int receiverId = rdr.GetInt32(2);
        string body = rdr.GetString(3);
        bool viewed = rdr.GetBoolean(4);

        Message newMessage = new Message(senderId, receiverId, body, viewed, messageId);
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
    public void MarkViewed()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE messages SET viewed = @Viewed, OUTPUT INSERTED.viewed WHERE id = @MessageId;", conn);

      cmd.Parameters.AddWithValue("@MessageId", this.Id.ToString());
      cmd.Parameters.AddWithValue("@Viewed", 1);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this.Viewed = rdr.GetBoolean(0);
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

    public static Message Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE id = @MessageId;", conn);
      SqlParameter MessageIdParameter = new SqlParameter("@MessageId", id.ToString());
      cmd.Parameters.Add(MessageIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundMessageId = 0;
      string foundMessageBody = null;
      bool foundViewed = false;
      int foundSenderId = 0;
      int foundReceiverId = 0;

      while(rdr.Read())
      {
        foundMessageId = rdr.GetInt32(0);
        foundSenderId = rdr.GetInt32(1);
        foundReceiverId = rdr.GetInt32(2);
        foundMessageBody = rdr.GetString(3);
        foundViewed = rdr.GetBoolean(4);

      }
      Message foundMessage = new Message(foundSenderId, foundReceiverId, foundMessageBody, foundViewed, foundMessageId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return foundMessage;
    }



    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM messages WHERE id = @MessageId; DELETE FROM state", conn);
      cmd.Parameters.AddWithValue("@MessageId", this.Id.ToString());
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
      SqlCommand cmd = new SqlCommand("DELETE FROM messages; DELETE FROM state", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
