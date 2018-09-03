using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene
{
    public Scene()
    {
        TimesVisited = 0;
    }
    private Players _players = new Players();
    private Scene[] _connected_scenes = new Scene[4];
  
    private List<string> lstStoryText = new List<string>();
    private List<Item> _lstSceneObjects = new List<Item>();

    private int _timesVisited;



    public Scene North
    {
        get
        {
            return _connected_scenes[(int)GameModel.DIRECTION.North];
        }
        set
        {
            _connected_scenes[(int)GameModel.DIRECTION.North] = value;
        }
    }

    public Scene South
    {
        get
        {
            return _connected_scenes[(int)GameModel.DIRECTION.South];
        }
        set
        {
            _connected_scenes[(int)GameModel.DIRECTION.South] = value;
        }
    }

    public Scene East
    {
        get
        {
            return _connected_scenes[(int)GameModel.DIRECTION.East];
        }
        set
        {
            _connected_scenes[(int)GameModel.DIRECTION.East] = value;
        }
    }

    public Scene West
    {
        get
        {
            return _connected_scenes[(int)GameModel.DIRECTION.West];
        }
        set
        {
            _connected_scenes[(int)GameModel.DIRECTION.West] = value;
        }
    }



    public List<string> LstStoryText
    {
        get
        {
            return lstStoryText;
        }

        set
        {
            lstStoryText = value;
        }
    }

    public List<Item> LstSceneObjects
    {
        get
        {
            return _lstSceneObjects;
        }

        set
        {
            _lstSceneObjects = value;
        }
    }

    public int TimesVisited
    {
        get
        {
            return _timesVisited;
        }

        set
        {
            _timesVisited = value;
        }
    }
}
