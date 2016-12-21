// using System;
// using System.Collections.Generic;
// using System.Data.SqlClient;
//
// namespace DateABase.Objects
// {
//   public class Message
//   {
//     public int Id  {get; set;}
//     public int SenderId {get; set;}
//     public int ReceiverId {get; set;}
//     public string MessageMessageBody {get; set;}
//     public bool Viewed {get; set;}
//
//     public Message(int senderId, int receiverId, string messageBody, bool viewed = 0, int id = 0)
//     {
//       this.Id = id;
//       this.SenderId = senderId;
//       this.ReceiverId = receiverId;
//       this.MessageBody = messageBody;
//       this.Viewed = viewed;
//     }
//     public override bool Equals(System.Object otherMessage)
//     {
//       if(!(otherMessage is Message))
//       {
//         return false;
//       }
//       else
//       {
//         Message newMessage = (Message) otherMessage;
//         bool idEquality = this.Id == newMessage.Id;
//         bool messageBodyEquality = this.MessageBody == newMessage.MessageBody;
//         bool viewedEquality = this.Viewed == newMessage.Viewed;
//         bool senderIdEquality = this.SenderId == newMessage.SenderId;
//         bool receiverIdEquality = this.ReceiverId == newMessage.ReceiverId;
//
//         return (idEquality && messageBodyEquality && viewedEquality && senderIdEquality && receiverIdEquality);
//       }
//     }
//     public void Save()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//
//       SqlCommand cmd = new SqlCommand("INSERT INTO messages (sender_id, receiver_id, body, viewed) OUTPUT INSERTED.id VALUES (@MessageBody, @Viewed, @SenderId, @ReceiverId);", conn);
//
//       cmd.Parameters.AddWithValue("@MessageBody", this.MessageBody);
//       cmd.Parameters.AddWithValue("@Viewed", this.Viewed);
//       cmd.Parameters.AddWithValue("@SenderId", this.SenderId);
//       cmd.Parameters.AddWithValue("@ReceiverId", this.ReceiverId);
//
//       SqlDataReader rdr = cmd.ExecuteReader();
//
//       while(rdr.Read())
//       {
//         this.Id = rdr.GetInt32(0);
//       }
//       if (rdr != null)
//       {
//         rdr.Close();
//       }
//       if (conn != null)
//       {
//         conn.Close();
//       }
//     }
//
//     public void MarkViewed()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//
//       SqlCommand cmd = new SqlCommand("UPDATE messages SET viewed = @Viewed, OUTPUT INSERTED.viewed WHERE id = @MessageId;", conn);
//
//       cmd.Parameters.AddWithValue("@MessageId", this.Id.ToString());
//       cmd.Parameters.AddWithValue("@Viewed", 1);
//
//       SqlDataReader rdr = cmd.ExecuteReader();
//
//       while(rdr.Read())
//       {
//         this.Viewed = rdr.GetString(0);
//       }
//       if (rdr != null)
//       {
//         rdr.Close();
//       }
//       if (conn != null)
//       {
//         conn.Close();
//       }
//     }
//
//     }
//     public static List<Message> GetAllReceivedMessages()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//       SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE receiver_id = @ReceiverId;", conn);
//       cmd.Parameters.AddWithValue("@ReceiverId", this.Id);
//       SqlDataReader rdr = cmd.ExecuteReader();
//       List<Message> allMessages = new List<Message>{};
//
//       while(rdr.Read())
//       {
//         int messageId = rdr.GetInt32(0);
//         string messageSenderId = rdr.GetString(1);
//         string messageReceiverId = rdr.GetString(2);
//         string messageBody = rdr.GetString(3);
//         string messageViewed = rdr.GetString(4);
//
//         Message newMessage = new Message(messageSenderId, messageReceiverId, messageMessageBody, messageViewed, messageId);
//         allMessages.Add(newMessage);
//       }
//       if(rdr != null)
//       {
//         rdr.Close();
//       }
//       if(rdr != null)
//       {
//         conn.Close();
//       }
//       return allMessages;
//     }
//
//     public static List<Message> GetAllSentMessages()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//       SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE sender_id = @SenderId;", conn);
//       cmd.Parameters.AddWithValue("@SenderId", this.Id);
//       SqlDataReader rdr = cmd.ExecuteReader();
//       List<Message> allMessages = new List<Message>{};
//
//       while(rdr.Read())
//       {
//         int messageId = rdr.GetInt32(0);
//         string messageSenderId = rdr.GetString(1);
//         string messageReceiverId = rdr.GetString(2);
//         string messageBody = rdr.GetString(3);
//         string messageViewed = rdr.GetString(4);
//
//         Message newMessage = new Message(messageSenderId, messageReceiverId, messageMessageBody, messageViewed, messageId);
//         allMessages.Add(newMessage);
//       }
//       if(rdr != null)
//       {
//         rdr.Close();
//       }
//       if(rdr != null)
//       {
//         conn.Close();
//       }
//       return allMessages;
//     }
//
//     public static List<Message> GetMessagesFromDater()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//       SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE sender_id = @SenderId AND receiver_id = @ReceiverId;", conn);
//       cmd.Parameters.AddWithValue("@ReceiverId", this.Id);
//       SqlDataReader rdr = cmd.ExecuteReader();
//       List<Message> allMessages = new List<Message>{};
//
//       while(rdr.Read())
//       {
//         int messageId = rdr.GetInt32(0);
//         string messageSenderId = rdr.GetString(1);
//         string messageReceiverId = rdr.GetString(2);
//         string messageBody = rdr.GetString(3);
//         string messageViewed = rdr.GetString(4);
//
//         Message newMessage = new Message(messageSenderId, messageReceiverId, messageMessageBody, messageViewed, messageId);
//         allMessages.Add(newMessage);
//       }
//       if(rdr != null)
//       {
//         rdr.Close();
//       }
//       if(rdr != null)
//       {
//         conn.Close();
//       }
//       return allMessages;
//     }
//
//     public static List<Message> GetAllViewedMessages()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//       SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE viewed = 1 AND receiver_id = @ReceiverId;", conn);
//       cmd.Parameters.AddWithValue("@ReceiverId", this.Id);
//       SqlDataReader rdr = cmd.ExecuteReader();
//       List<Message> allMessages = new List<Message>{};
//
//       while(rdr.Read())
//       {
//         int messageId = rdr.GetInt32(0);
//         string messageSenderId = rdr.GetString(1);
//         string messageReceiverId = rdr.GetString(2);
//         string messageBody = rdr.GetString(3);
//         string messageViewed = rdr.GetString(4);
//
//         Message newMessage = new Message(messageSenderId, messageReceiverId, messageMessageBody, messageViewed, messageId);
//         allMessages.Add(newMessage);
//       }
//       if(rdr != null)
//       {
//         rdr.Close();
//       }
//       if(rdr != null)
//       {
//         conn.Close();
//       }
//       return allMessages;
//     }
//
//     public static Message Find(int id)
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//
//       SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE id = @MessageId;", conn);
//       SqlParameter MessageIdParameter = new SqlParameter("@MessageId", id.ToString());
//       cmd.Parameters.Add(MessageIdParameter);
//       SqlDataReader rdr = cmd.ExecuteReader();
//
//       int foundMessageId = 0;
//       string foundMessageBody = null;
//       string foundViewed = null;
//       string foundZipCode = null;
//       string foundPhoneNumber = null;
//       string foundAboutMe = null;
//       string foundEmail = null;
//       string foundTagLine = null;
//       string foundSenderId = null;
//       string foundReceiverId = null;
//
//       while(rdr.Read())
//       {
//         foundMessageId = rdr.GetInt32(0);
//         foundMessageBody = rdr.GetString(1);
//         foundViewed = rdr.GetString(2);
//         foundZipCode = rdr.GetString(3);
//         foundPhoneNumber = rdr.GetString(4);
//         foundAboutMe = rdr.GetString(5);
//         foundEmail = rdr.GetString(6);
//         foundTagLine = rdr.GetString(7);
//         foundSenderId = rdr.GetString(8);
//         foundReceiverId = rdr.GetString(9);
//
//       }
//       Message foundMessage = new Message(foundSenderId, foundReceiverId, foundMessageBody, foundViewed, foundZipCode, foundEmail, foundTagLine, foundPhoneNumber, foundAboutMe, foundMessageId);
//
//       if (rdr != null)
//       {
//         rdr.Close();
//       }
//       if (conn != null)
//       {
//         conn.Close();
//       }
//
//       return foundMessage;
//     }
//
//     public static Message GetCurrentMessage()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//
//       SqlCommand cmd = new SqlCommand("SELECT message_id FROM state;", conn);
//       SqlDataReader rdr = cmd.ExecuteReader();
//
//       int messageId = 0;
//
//       while(rdr.Read())
//       {
//         messageId = rdr.GetInt32(0);
//       }
//       Message currentMessage = Message.Find(messageId);
//
//       if(rdr!=null)
//       {
//         rdr.Close();
//       }
//       if(conn!=null)
//       {
//         conn.Close();
//       }
//       return currentMessage;
//     }
//     public static void SetCurrentMessage(Message selectedMessage)
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//
//       SqlCommand cmd = new SqlCommand("INSERT INTO state (message_id) VALUES (@MessageId);", conn);
//
//       cmd.Parameters.AddWithValue("@MessageId", selectedMessage.Id.ToString());
//       cmd.ExecuteNonQuery();
//
//
//       if(conn!=null)
//       {
//         conn.Close();
//       }
//     }
//     public static void ChangeCurrentMessage(Message selectedMessage)
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//
//       SqlCommand cmd = new SqlCommand("UPDATE state SET message_id = @MessageId;", conn);
//
//       cmd.Parameters.AddWithValue("@MessageId", selectedMessage.Id.ToString());
//       cmd.ExecuteNonQuery();
//
//       if(conn!=null)
//       {
//         conn.Close();
//       }
//     }
//
//     public static Message FindBySenderId(string messageName)
//     {
//       Message foundMessage = new Message("", "");
//       return foundMessage;
//     }
//     public static bool CheckLogin(string messageName, string receiverId)
//     {
//       return false;
//     }
//     public void Delete()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//       SqlCommand cmd = new SqlCommand("DELETE FROM messages WHERE id = @MessageId; DELETE FROM state", conn);
//       cmd.Parameters.AddWithValue("@MessageId", this.Id.ToString());
//       cmd.ExecuteNonQuery();
//
//       if(conn!=null)
//       {
//         conn.Close();
//       }
//     }
//     public static void DeleteAll()
//     {
//       SqlConnection conn = DB.Connection();
//       conn.Open();
//       SqlCommand cmd = new SqlCommand("DELETE FROM messages; DELETE FROM state", conn);
//       cmd.ExecuteNonQuery();
//       conn.Close();
//     }
//   }
// }
