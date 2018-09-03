using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;



using System.Text;

public class GameModel
{

    private static String _name;
    private static Player _player = new Player();
    public enum DIRECTION { North, South, East, West };
    private static Scene _start_scene; // ??
    public static Players PlayersInGame = new Players();

    public GameModel()
    {
        MakeScenes();
    }
        

    public static Scene Start_scene
    {
        get
        {
            return _start_scene;
        }
        set
        {
            _start_scene = value;
        }

    }

    public static string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }

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
        Scene scnTownCenter = new Scene();
        Scene scnTavern = new Scene();
        Scene scnFootOfMountain = new Scene();
        Scene scnHalfUpMountain = new Scene();
        Scene scnTopOfMountain = new Scene();



        //Town Center (Starting Scene)
        scnTownCenter.LstStoryText.Add("You are standing in the Town Center.");
        scnTownCenter.LstStoryText.Add("To your South is the Tavern");
        scnTownCenter.LstStoryText.Add("To your West is the foot of the mountain");
        scnTownCenter.North = null;
        scnTownCenter.South = scnTavern;
        scnTownCenter.West = scnFootOfMountain;
        scnTownCenter.East = null;

        //Tavern
        scnTavern.LstSceneObjects.Add(new Item {Description = "Gold Coin" });
        scnTavern.LstStoryText.Add("You are in the Tavern.  you see a gold coin on the ground. Type 'pick up' to pick it up.");
        scnTavern.LstStoryText.Add("YOu return to the Tavern.");
        scnTavern.North = scnTownCenter;
        scnTavern.South = null;
        scnTavern.East = null;
        scnTavern.West = null;

        //scnFootOfMountain
        scnFootOfMountain.LstStoryText.Add("You are at the foot of the mountain");
        scnFootOfMountain.LstStoryText.Add("");
        scnFootOfMountain.LstStoryText.Add("");
        scnFootOfMountain.North = null;
        scnFootOfMountain.South = null;
        scnFootOfMountain.East = null;
        scnFootOfMountain.West = null;

        //scnHalfUpMountain

        scnHalfUpMountain.LstStoryText.Add("");
        scnHalfUpMountain.North = null;
        scnHalfUpMountain.South = null;
        scnHalfUpMountain.East = null;
        scnHalfUpMountain.West = null;

        //scnTopOfMountain
        scnTopOfMountain.LstStoryText.Add("");
        scnTopOfMountain.North = null;
        scnTopOfMountain.South = null;
        scnTopOfMountain.East = null;
        scnTopOfMountain.West = null;


        //Starts player in initial scene
        _player.CurrentScene = scnTownCenter;
    }
}

