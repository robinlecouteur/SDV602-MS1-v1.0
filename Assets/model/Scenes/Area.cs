using Assets.model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area
{
    public Area()
    {
        TimesVisited = 0;
    }
    protected Players _players = new Players();
    protected Area[] _connected_scenes = new Area[4];
    protected string _areaName = "areaName placeholder";

    protected Dictionary<string, string> lstStoryText = new Dictionary<string, string>();
    protected string _storyText = "";

    protected List<Item> _lstSceneObjects = new List<Item>();
    protected List<GameAction> _lstActions = new List<GameAction>();
    protected int _timesVisited;
    protected bool _hasBeenVisited;


    public Area North
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
    public Area South
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
    public Area East
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
    public Area West
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

    public Dictionary<string, string> DictStoryText
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

    public List<GameAction> LstActions
    {
        get
        {
            return _lstActions;
        }

        set
        {
            _lstActions = value;
        }
    }

    public string Directions
    {
        
      
        get
        {
            string lcDirections = "\n \n This is where you can go from here: \n";
            if (North != null){ lcDirections +=  "   North: " + North.AreaName + "\n"; }
            if (South != null) { lcDirections += "   South: " + South.AreaName + "\n"; }
            if (East != null) { lcDirections +=  "   East:  " + East.AreaName + "\n"; }
            if (West != null) { lcDirections +=  "   West:  " + West.AreaName + "\n"; }


            return lcDirections;
        }
    }
    public virtual void Arrive()
    {
        StoryText += DictStoryText["DefaultText"];
        StoryText += Directions;
    }

    public virtual void Leave()
    {
        _timesVisited += 1;
        _storyText = "";
    }

    public string AreaName
    {
        get
        {
            return _areaName;
        }

        set
        {
            _areaName = value;
        }
    }

    public string StoryText
    {
        get
        {
            return _storyText;
        }

        set
        {
            _storyText = value;
        }
    }
}
 