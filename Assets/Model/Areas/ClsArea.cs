using Assets.Model;
using Assets.Model.Items;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public abstract class ClsArea
{
    public ClsArea()
    {
        _timesVisited = 0;
    }

    //------------------------------------------------------------------- VARIABLES ---------------------------------------------------------------------//
    //                                                                                                                                                   //
    //                                                                                                                                                   //

    //### Declare Vars ###

    //protected ClsPlayers _players = new ClsPlayers();     //stores what players are currently in the area?

    private List<Destination> _destinations = new List<Destination>(); //Stores a list of areas that are connected to this area
    protected string _areaName = "areaName placeholder";    //Stores the name of the area  
    protected Dictionary<string, string> _dictAreaText   //Dictionary containing different lines of text
        = new Dictionary<string, string>();              //These lines of text can be added to the _areaText depending on conditions
    protected string _areaText = "";    //Stores the text that will be displayed for this area
    protected List<ClsItem> _lstAreaItems = new List<ClsItem>();
    //?? //protected Dictionary<string, Item> _dictAreaItems = new Dictionary<string, Item>(); //Stores a list of items that are in the area
    protected int _timesVisited;
    protected bool _hasBeenVisited;

    //###---


    //### Properties ### 
    public Dictionary<string, string> DictAreaText
    {
        get
        {
            return _dictAreaText;
        }

        set
        {
            _dictAreaText = value;
        }
    }
    public List<ClsItem> LstAreaItems
    {
        get
        {
            return _lstAreaItems;
        }

        set
        {
            _lstAreaItems = value;
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
    public string DestinationText
    {
        get
        {
            string lcDestText = "\n \n This is where you can go from here: \n";
            foreach (Destination lcDestination in _destinations)
            {
                lcDestText +=  "   " + lcDestination.Direction + "  " + lcDestination.TargetArea.AreaName + "\n";
            } 

            return lcDestText;
        }
    }
    public string AreaText
    {
        get
        {
            return _areaText;
        }

        set
        {
            _areaText = value;
        }
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

    public List<Destination> Destinations
    {
        get
        {
            return _destinations;
        }

        set
        {
            _destinations = value;
        }
    }

    //###---

    //                                                                                                                                                   //
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//



    //------------------------------------------------------------------ METHODS ------------------------------------------------------------------------//
    //                                                                                                                                                   //
    //                                                                                                                                                   //
    public virtual void Arrive(ClsPlayer prPlayer)
    {
        AreaText += DictAreaText["DefaultText"];
        AreaText += DestinationText;
    }

    public virtual void Leave(ClsPlayer prPlayer)
    {
        _timesVisited += 1;
        _areaText = "";
    }  

    public virtual void AddDestination(string prDirection, ClsArea prDestination)
    {
        _destinations.Add(new Destination() { Direction = prDirection, TargetArea = prDestination });
    }
    //                                                                                                                                                   //
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//

}
