using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


using GameManager;
using DidzNeil.ChatAPI;


public class FakeInput : IInput
{
    public void SendFeedback(ICommand command)
    {
        Debug.LogWarning("Command Feedback: " + command.response);
    }
}


public class GameManager12 : MonoBehaviour
{
    #region Public Members
    public IGameEngine m_gameEngine;

    public IInput m_input = new FakeInput();

    public ICommandManager m_commandManager;

    private Queue<ICommand> m_commandQueue = new Queue<ICommand>();
    private List<Player> playerList;

    #endregion

    #region Public void

    #endregion

    #region System

    protected void Awake()
    {
        m_commandManager = GetComponent<CommandManager>();
        m_gameEngine = GetComponent<TerritoryManager>();
    }

#if UNITY_EDITOR
    [MenuItem("GDL-Twitch12/Stun Neil %t")]
    public static void test()
    {
        Item item = new Item();
        item.Player = new Player() { Name = "0 Neil" };
        item.ItemType = Item.e_itemType.PARCHEMENT;
        ItemEvent.NotifyNewItem(item);

        string ticks = "?";
        try
        {
            ticks = GameObject.Find("PManager").GetComponent<CommandManager>().stunMult.ToString();
        }
        catch(Exception)
        {

        }

        Debug.LogWarning("Stunning Neil for " +  ticks + " ticks!");
    }
#endif


    protected void Start()
    {
        ChatAPI.AddListener(HandleMessage);
        ItemEvent.AddListener(HandleEvent);


        
    }

    private void HandleEvent(Item item)
    {
        string[] userInfo = item.Player.Name.Split(new char[] { ' ' }, 2);


        DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        long timestamp = (DateTime.Now.ToUniversalTime() - unixStart).Ticks;


        string state = "";

        switch (item.ItemType)
        {
            case Item.e_itemType.PEBBLE:
                break;
            case Item.e_itemType.COINCHEST:
                break;
            case Item.e_itemType.GRENADES:
                break;
            case Item.e_itemType.SHOVEL:
                break;
            case Item.e_itemType.PARCHEMENT:
                state = "STUN";
                break;
            case Item.e_itemType.STRAIN:
                state = "STRAIN";
                break;
            case Item.e_itemType.GLASSES:
                break;
            default:
                break;
        }

        state = ((CommandManager)m_commandManager).firstStateCharacter + state;




        m_commandManager.Parse(userInfo[1], Int32.Parse(userInfo[0]), state, timestamp);
    }

    private void HandleMessage(Message message)
    {
        
    
        ICommand command = m_commandManager.Parse(
            message.GetUserName(),
            (int)message.GetPlatform(),
            message.GetMessage(),
            message.GetTimestamp()
        );
        
        if (command == null)
            return;

        if (command.feedbackUser)
        {
            m_input.SendFeedback(command);

            Message msg = new Message("Game Admin", command.response, Message.GetCurrentTimeUTC(), Platform.Game,CommandIRC.PRIVMSG);

            //ChatAPI.SendMessageToEveryUsers(msg);
            ChatAPI.SendMessageToUser(message.GetUserName(), message.GetPlatform(), msg);
        }
        else
        {
            if (command.response == "!START")
            {
                Player player = new Player
                {
                    name = message.GetUserName()
                };
                AddPlayer(player);
                m_gameEngine.AssignFactionToPlayers(playerList);
            }

            string userId = (int)message.GetPlatform() + " " + message.GetUserName();
            string formattedCommand = command.response.Substring(1).ToUpper();

            m_gameEngine.GetCommandFromPlayer(userId, formattedCommand);
        }
    }
    private void AddPlayer(Player player) {
        foreach (Player p in playerList){
            if (p.name == player.name)
            {
                return;
            }
        }
        playerList.Add(player);
    }
    private void RemovePlayer(Player player)
    {
        foreach (Player p in playerList)
        {
            if (p.name == player.name)
            {
                return;
            }
        }
        playerList.Remove(player);
    }
    private void Update()
    {

    }

    #endregion

    #region Class Methods

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    #endregion
}

