﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DidzNeil.ChatAPI;
using System;
[RequireComponent(typeof(AutoConnectTwitchIRC))]
public class SendToTwitchIRC : MonoBehaviour {
    public bool debug=false; 
    [SerializeField]
    private BotSendMessageControl botMessage;
    public AutoConnectTwitchIRC m_autoConnectManager;
    private TwitchIRC irc;
    private void Awake()
    {
        m_autoConnectManager = gameObject.GetComponent<AutoConnectTwitchIRC>();
        
    }
    void Start()
    {
        irc = m_autoConnectManager.GetIRC();
        botMessage._twitchIRC = irc;
        ChatAPI.AddGameToServerListener(SendMessage);
        ChatAPI.AddGameToServerListener(SendMessageToAll);
        
        if (debug)
        {
            StartCoroutine(Test());
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
    // Use this for initialization
    IEnumerator Test()
    {
        while (true) { 

        yield return new WaitForSeconds(5);

        ChatAPI.SendMessageToUser("drnd93", Platform.Twitch, new Message("GameMaster", "Bonjour toi", Message.GetCurrentTimeUTC(), Platform.Game,CommandIRC.PRIVMSG));
        //ChatAPI.SendMessageToEveryUsers(new Message("GameMaster", "T:"+ Message.GetCurrentTimeUTC(), Message.GetCurrentTimeUTC(),Platform.Game,CommandIRC.PRIVMSG));
        }

    }
    
    private void SendMessage(string user, Platform platform, Message message)
    {
        botMessage.ToTheAttentionOf(user, message.GetMessage());
        botMessage.Whisper(user, message.GetMessage());
    }

    private void SendMessageToAll(Message message)
    {
        botMessage.SendMessageToIRC(message.GetMessage());
    }
  
    
}
