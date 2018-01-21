using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DidzNeil.ChatAPI 
{

    public interface IMessage
    {
       string GetUserName();
        long GetTimestamp();
        DateTime GetDate();
        string GetMessage();
        Platform GetPlatform();
    }
    [System.Serializable]
    public class Message : IMessage
    {
        [SerializeField]
        private string m_userName;

        [SerializeField]
        private string m_message;

        [SerializeField]
        private long m_timestamp;

        [SerializeField]
        private Platform m_platform;

        [SerializeField]
        private string m_command;

        public Message(string userName, string message, long timestamp, Platform platform,CommandIRC command)
        {
            m_userName = userName;
            m_message = message;
            m_timestamp = timestamp;
            m_platform = platform;
            m_command = command.ToString();
        }
        public Message(string userName, string message, long timestamp, Platform platform, string command)
        {
            m_userName = userName;
            m_message = message;
            m_timestamp = timestamp;
            m_platform = platform;
            m_command = command;
        }
        public DateTime GetDate()
        {
            return CreateFromTimestamp(m_timestamp);
        }

        public string GetMessage()
        {
            
            return m_message;

        }

        public Platform GetPlatform()
        {
            return m_platform;
        }
        public string GetCommand()
        {
            return m_command;
        }
       
        public long GetTimestamp()
        {
            return m_timestamp;
        }


        public string GetUserName()
        {
            return m_userName;
        }
        public static DateTime CreateFromTimestamp() {

            return CreateFromTimestamp(GetCurrentTimeUTC());
        }
        public static DateTime CreateFromTimestamp (long timestamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
            return dtDateTime;
        }

        public static long GetCurrentTimeUTC()
        {

            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
          return (long) (DateTime.Now.ToUniversalTime() - unixStart).TotalSeconds;
        }
        



    }

    public enum Platform : int
    {
        Game=-2,
        Unknown = -1,

        Mockup = 0,
        Twitch = 1,
        Facebook = 2,
        Discord=3

    }
    public enum CommandIRC : int
    {
        ADMIN = 1,
        AWAY = 2,
        CONNECT = 3,
        DIE = 4,
        ERROR = 5,
        INFO = 6,
        INVITE = 7,
        ISON = 8,
        JOIN = 9,
        KICK = 10,
        KILL = 11,
        LINKS = 12,
        LIST = 13,
        LUSERS = 14,
        MODE = 15,
        MOTD = 16,
        NAMES = 17,
        NICK = 18,
        NJOIN = 19,
        NOTICE = 20,
        OPER = 21,
        PART = 22,
        PASS = 23,
        PING = 24,
        PONG = 25,
        PRIVMSG = 26,
        QUIT = 27,
        REHASH = 28,
        RESTART = 29,
        SERVER = 30,
        SERVICE = 31,
        SERVLIST = 32,
        SQUERY = 33,
        SQUIRT = 34,
        SQUIT = 35,
        STATS = 36,
        SUMMON = 37,
        TIME = 38,
        TOPIC = 39,
        TRACE = 40,
        USER = 41,
        USERHOST = 42,
        USERS = 43,
        VERSION = 44,
        WALLOPS = 45,
        WHO = 46,
        WHOIS = 47,
        WHOWAS = 48
    }
}