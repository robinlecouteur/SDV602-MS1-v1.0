using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Text;
using Assets.model;
using Assets.model.Scenes;

public class GameModel
{

    private static Player _player = new Player();
    public enum DIRECTION { North, South, East, West };

    public static Players PlayersInGame = new Players();

    public GameModel()
    {
        MakeScenes();
    }
        
    public static Player CurrentPlayer
    {
        get
        {
            return _player;
        }
        set
        {
            _player = value;
        }

    }
    public static void go(DIRECTION pDirection)
    {
        _player.Move(pDirection);
    }

    public static void Pickup(Item prItem)
    {
        CurrentPlayer.LstInventory.Add(prItem);
    }

    //public static void RemoveItemFromScene(Item prItem)
    //{
    //    CurrentPlayer.CurrentScene.SceneObject = null;
    //}


    public static void MakeScenes()
    { 
        //InstantiateScenes   
        Area areaTownCenter = new AreaTownCenter();
        Area areaTavern = new AreaTavern();
        Area areaFootOfMountain = new AreaFootOfMountain();
        Area areaHalfUpMountain = new AreaHalfUpMountain();
        Area areaTopOfMountain = new AreaTopOfMountain();



        //Town Center (Starting Scene)

        //areaTownCenter.LstActions.Add(new GameAction(areaTownCenter) { Obj1 = areaTownCenter.TimesVisited, Obj2 = 1, Operator = ">=", ActionType = "ShowText", Text = "If this case worked it will only show the the first time you arrive here." });
        // areaTownCenter.LstStoryText.Add("Town Center");
        //areaTownCenter.LstStoryText.Add("To your South is the Tavern");
        //areaTownCenter.LstStoryText.Add("To your West is the foot of the mountain");
        areaTownCenter.North = null;
        areaTownCenter.South = areaTavern;
        areaTownCenter.West = areaFootOfMountain;
        areaTownCenter.East = null;

        //Tavern
        //areaTavern.LstSceneObjects.Add(new Item {Description = "Gold Coin" });
        //areaTavern.LstStoryText.Add("You are in the Tavern.  you see a gold coin on the ground. Type 'pick up' to pick it up.");
        //areaTavern.LstStoryText.Add("YOu return to the Tavern.");
        areaTavern.North = areaTownCenter;
        areaTavern.South = areaFootOfMountain;
        areaTavern.East = null;
        areaTavern.West = null;

        //areaFootOfMountain
        //areaFootOfMountain.LstStoryText.Add("You are at the foot of the mountain");
        areaFootOfMountain.North = areaTavern;
        areaFootOfMountain.South = null;
        areaFootOfMountain.East = null;
        areaFootOfMountain.West = null;

        //areaHalfUpMountain

        //areaHalfUpMountain.LstStoryText.Add("");
        areaHalfUpMountain.North = null;
        areaHalfUpMountain.South = null;
        areaHalfUpMountain.East = null;
        areaHalfUpMountain.West = null;

        //areaTopOfMountain
        //areaTopOfMountain.LstStoryText.Add("");
        areaTopOfMountain.North = null;
        areaTopOfMountain.South = null;
        areaTopOfMountain.East = null;
        areaTopOfMountain.West = null;


        //Starts player in initial scene
        _player.CurrentArea = areaTownCenter;
    }
}

