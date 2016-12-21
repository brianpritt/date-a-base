using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using DateABase.Objects;

namespace  DateABase
{
  public class MessageTest : IDisposable
  {
    public void MessageInputTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=date_a_base_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void GetAll_ReturnsEmpty_zero()
    {
      Message newMessage = new Message(0, 0, "hello there! I'd like to byte your bits...");
      int result = Message.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
    public void Save_SavesCorrectMessage_true()
    {
      Message newMessage = new Message(0, 0, "hello there! I'd like to byte your bits...");
      newMessage.Save();
      List<Message> allMessages = Message.GetAll();
      Message actualMessage = allMessages[0];
      Assert.Equal(newMessage, actualMessage);
    }
    [Fact]
    public void GetAllReceivedMessages_GetsRecievedMessages_true()
    {
      User user1 = new User("mammaBear", "honey");
      user1.Save();
      Message newMessage = new Message(1, user1.Id, "hello there! I'd like to byte your bits...");
      newMessage.Save();
      Message anotherMessage = new Message(1, 6, "hello there! Wanna finger my keys?");
      anotherMessage.Save();
      List<Message> allRecievedMessages = user1.GetAllReceivedMessages();
      Assert.Equal(1, allRecievedMessages.Count);
    }
    [Fact]
    public void GetAllSentMessages_GetsSentMessages_true()
    {
      User user1 = new User("mammaBear", "honey");
      user1.Save();
      Message newMessage = new Message(user1.Id, 1, "hello there! I'd like to byte your bits...");
      newMessage.Save();
      Message anotherMessage = new Message(6, 1, "hello there! Wanna finger my keys?");
      anotherMessage.Save();
      List<Message> allSentMessages = user1.GetAllSentMessages();
      Assert.Equal(1, allSentMessages.Count);
    }
    [Fact]
    public void GetAllUnreadMessages_GetsUnreadMessages_true()
    {
      User user1 = new User("mammaBear", "honey");
      user1.Save();
      Message newMessage = new Message(1,user1.Id, "hello there! I'm a backend man!", true);
      newMessage.Save();
      Message anotherMessage = new Message(1, user1.Id, "hello there! Wanna finger my keys?", false);
      anotherMessage.Save();
      List<Message> allSentMessages = user1.GetAllUnreadMessages();
      Assert.Equal(1, allSentMessages.Count);
    }
    [Fact]
    public void GetAllReadMessages_GetsReadMessages_true()
    {
      User user1 = new User("mammaBear", "honey");
      user1.Save();
      Message newMessage = new Message(1,user1.Id, "hello there! I'm a backend man!", true);
      newMessage.Save();
      Message anotherMessage = new Message(1, user1.Id, "hello there! Wanna finger my keys?", false);
      anotherMessage.Save();
      List<Message> allSentMessages = user1.GetAllReadMessages();
      Assert.Equal(1, allSentMessages.Count);
    }

    [Fact]
    public void GetCorrespondenceFromDater_GetsCorrespondenceFromSpecificDater_true()
    {
      User user1 = new User("mammaBear", "honey");
      user1.Save();
      User user2 = new User("papabear", "salmon");
      user2.Save();
      Message newMessage = new Message(user2.Id,user1.Id, "hello there! I'm a backend man!", false);
      newMessage.Save();
      Message anotherMessage = new Message(user1.Id, user2.Id, "hello there! Wanna finger my keys?", false);
      anotherMessage.Save();
      List<Message> allSentMessages = user1.GetCorrespondenceFromDater(user2);
      Assert.Equal(2, allSentMessages.Count);
    }
    [Fact]
    public void Delete_DeletsMessageFromDB_true()
    {
      Message newMessage = new Message(0, 0, "hello there! I'd like to byte your bits...");
      newMessage.Save();
      newMessage.Delete();
      List<Message> allMessages = Message.GetAll();
      Assert.Equal(0, allMessages.Count);
    }

    public void Dispose()
    {
      Message.DeleteAll();
      User.DeleteAll();
    }
  }
}
