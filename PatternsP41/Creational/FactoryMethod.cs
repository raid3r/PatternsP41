using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP41.Creational;


public class ExampleClientCode
{
    
    public void SendMessage(IMessageSenderCreator creator, string message)
    {
        var sender = creator.CreateMessageSender();
        sender.SendMessage(message);
    }



    public void Run()
    {
        var messageType = "email"; // Це може бути "sms" або "email", залежно від потреб
        IMessageSenderCreator creator = messageType switch
        {
            "email" => new EmailMessageSenderCreator("smtp.example.com", 587),
            "sms" => new SmsMessageSenderCreator("sms.gateway.com", "+1234567890"),
            "push" => new PushMessageSenderCreator("push.key.example.com"),
            _ => throw new NotSupportedException("Unsupported message type.")
        };

        SendMessage(creator, "I am a message to be sent!");
    }
}

public interface IMessageSender
{
    void SendMessage(string message);
}

public interface IMessageSenderCreator
{
    IMessageSender CreateMessageSender();
}

class PushMessageSenderCreator : IMessageSenderCreator
{
    private string _key;
    public PushMessageSenderCreator(string key)
    {
        _key = key;
    }
    public IMessageSender CreateMessageSender()
    {
        return new PushSender(_key);
    }
}

class EmailMessageSenderCreator : IMessageSenderCreator
{
    private string _smtpServer;
    private int _port;
    public EmailMessageSenderCreator(string smtpServer, int port)
    {
        _smtpServer = smtpServer;
        _port = port;
    }
    public IMessageSender CreateMessageSender()
    {
        return new EmailSender(_smtpServer, _port);
    }
}


class SmsMessageSenderCreator : IMessageSenderCreator
{
    private string _smsGateway;
    private string _phone;
    public SmsMessageSenderCreator(string smsGateway, string phone)
    {
        _smsGateway = smsGateway;
        _phone = phone;
    }
    public IMessageSender CreateMessageSender()
    {
        return new SmsSender(_smsGateway, _phone);
    }
}

public class EmailSender : IMessageSender
{
    private string _smtpServer;
    private int _port;

    public EmailSender(string smtpServer, int port)
    {
        _smtpServer = smtpServer;
        _port = port;
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending email via SMTP server {_smtpServer}:{_port} with message: {message}");
    }
}

public class SmsSender: IMessageSender
{
    private string _smsGateway;
    private string _phone;
    public SmsSender(string smsGateway, string phone)
    {
        _smsGateway = smsGateway;
        _phone = phone;
    }
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending SMS via gateway {_smsGateway} to phone {_phone} with message: {message}");
    }
}

public class  PushSender: IMessageSender
{
    private string _key;
    public PushSender(string key)
    {
        _key = key;
    }
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending PUSH {_key} with message: {message}");
    }
}

