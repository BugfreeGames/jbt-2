﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
public class GameManagerUnitTests
{
    [Test]
    public void GameWinTest()
    {
        List<Player> playerList = new List<Player>();
        playerList.Add(new Human(new ResourceGroup(10, 10, 10), "dave", 100));
        playerList.Add(new AI(new ResourceGroup(10, 10, 10), "tim", 100));
        playerList[1].AcquireRoboticon(new Roboticon(new ResourceGroup(1,1,1)));    //A roboticon always adds an amount > 0 to player score so this player should always win.

        GameHandler.CreateNew("test", playerList);
        GameManager gameManager = GameHandler.GetGameManager();

        foreach (Tile tile in gameManager.GetMap().GetTiles())
        {
            tile.SetOwner(playerList[1]);       //Set all tiles to owned so that the game ends
        }

        Player winner = gameManager.GetWinnerIfGameHasEnded();

        Assert.AreEqual(winner, playerList[1]);
    }
        
    public void HumanPlayersGoFirstTest()
    { 
        List<Player> playerList2 = new List<Player>();
        playerList2.Add(new AI(new ResourceGroup(10, 10, 10), "leo", 100));
        playerList2.Add(new Human(new ResourceGroup(10, 10, 10), "dave", 100));
        playerList2.Add(new AI(new ResourceGroup(10, 10, 10), "leo2", 100));
        playerList2.Add(new Human(new ResourceGroup(10, 10, 10), "dave2", 100));
        playerList2.Add(new AI(new ResourceGroup(10, 10, 10), "leo3", 100));
        playerList2.Add(new Human(new ResourceGroup(10, 10, 10), "dave3", 100));
        playerList2.Add(new AI(new ResourceGroup(10, 10, 10), "leo4", 100));
        playerList2.Add(new Human(new ResourceGroup(10, 10, 10), "dave4", 100));

        GameManager gameManager2 = new GameManager("test2", playerList2);

        if(playerList2[0].IsHuman() != true)
        {
            //errorString += "FormatPlayerList does not work for test 3.2.2.1. First player is not a human";
        }
    }
}
