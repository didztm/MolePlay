using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DidzNeil.ChatAPI;
using System.Text.RegularExpressions;
public class ListenToTwitchIRC : MonoBehaviour {


    public TwitchIRC m_ircManager;


    // Use this for initialization
	void Start () {

        m_ircManager.messageRecievedEvent.AddListener(MessageReceived);
        m_ircManager.serverMessageRecievedEvent.AddListener(ServerMessageReceived);
	}

    private void ServerMessageReceived(string str)
    {
        Debug.Log(str + "<----------------server");
        string command = str.Split(' ')[1];

        string pseudo = "";
        string msg = "";
       // Message message = FormatStringToMessage(str);
       // ChatAPI.NotifyNewMessageToListeners(message);

    }

    private void MessageReceived(string str)
    {
        Debug.Log(str + "<----------------");
        string command = str.Split(' ')[1];
        string pseudo = "";
        string msg = "";
        int indexOfstrStart = str.IndexOf("PRIVMSG #");
        //NOT RESPECTING TWITCH STANDARD
        if (indexOfstrStart < 0) return ;
        int pseudoStart = str.IndexOf('!') + 1;
        int pseudoEnd = str.IndexOf('@');
        pseudo = str.Substring(pseudoStart, pseudoEnd - pseudoStart);
        string userstrRaw = str.Substring(indexOfstrStart + 9);
        string[] tokens = userstrRaw.Split(':');
        //NOT MESSSAGE DETECTED
        if (tokens.Length < 2) return ;
        string channel = tokens[0];
        if (string.IsNullOrEmpty(pseudo))
            return;
        msg = userstrRaw.Substring(channel.Length + 1);
        if (string.IsNullOrEmpty(msg))
            return ;
        Message message = new Message(pseudo, msg, GetTime(), Platform.Twitch, command);
        ChatAPI.NotifyNewMessageToListeners(message);
    }
    private long GetTime()
    {
        return Message.GetCurrentTimeUTC();
    }

}
