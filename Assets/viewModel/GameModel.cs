using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Assets.Model;
using Assets.Model.Areas;
using Assets.Model.Items;

[Serializable]
public class GameModel
{
    //Areas
    private Dictionary<string, ClsArea> _areas;
   

    private ClsPlayer _currentPlayer;
    public GameModel() //Constructor
    {
        MakeAreas();
    }

    public ClsPlayers PlayersInGame = new ClsPlayers(); 
    public ClsPlayer CurrentPlayer
    {
        get
        {
            return _currentPlayer;
        }
        set
        {
            _currentPlayer = value;
        }

    }




    public void Pickup(ClsItem prItem)
    {
        //Adds prItem to the inventory list of the current player
        CurrentPlayer.LstInventory.Add(prItem);
    }

    public void RemoveItemFromArea(ClsItem prItem)
    {
        //Removes prItem from the list of items in the current area
        CurrentPlayer.CurrentArea.LstAreaItems.Remove(prItem);
    }


    public void MakeAreas()
    { 
        //Instantiate Areas  
        _areas.Add("TownCenter", new ClsAreaTownCenter());
        _areas.Add("Tavern", new ClsAreaTavern());
        _areas.Add("FootOfMountain", new ClsAreaFootOfMountain());
        _areas.Add("HalfUpMountain", new ClsAreaHalfUpMountain());
        _areas.Add("TopOfMountain", new ClsAreaTopOfMountain());


        //Town Center (Starting Area)
        //_areas["TownCenter"].AddDestination("north", null);
        _areas["TownCenter"].AddDestination("south", _areas["Tavern"]);
        //_areas["TownCenter"].AddDestination("east", null);
        //_areas["TownCenter"].AddDestination("west", null);

        //Tavern
        _areas["Tavern"].AddDestination("north", _areas["TownCenter"]);
        _areas["Tavern"].AddDestination("south", _areas["FootOfMountain"]);
        //_areas["Tavern"].AddDestination("east", null);
        //_areas["Tavern"].AddDestination("west", null);

        //areaFootOfMountain
        _areas["FootOfMountain"].AddDestination("north", _areas["Tavern"]);
        //_areas["FootOfMountain"].AddDestination("south", null);
        //_areas["FootOfMountain"].AddDestination("east", null);
        //_areas["FootOfMountain"].AddDestination("west", null);


        //areaHalfUpMountain
        //_areas["HalfUpMountain"].AddDestination("north", null);
        //_areas["HalfUpMountain"].AddDestination("south", null);
        //_areas["HalfUpMountain"].AddDestination("east", null);
        //_areas["HalfUpMountain"].AddDestination("west", null);

        //areaTopOfMountain
        //_areas["TopOfMountain"].AddDestination("north", null);
        //_areas["TopOfMountain"].AddDestination("south", null);
        //_areas["TopOfMountain"].AddDestination("east", null);
        //_areas["TopOfMountain"].AddDestination("west", null);



        ////Town Center (Starting Area)
        //areaTownCenter.Directions["north"] = null;
        //areaTownCenter.Directions["south"] = areaTavern;
        //areaTownCenter.Directions["west"] = areaFootOfMountain;
        //areaTownCenter.Directions["east"] = null;

        ////Tavern
        //areaTavern.Directions["north"] = areaTownCenter;
        //areaTavern.Directions["south"] = areaFootOfMountain;
        //areaTavern.Directions["east"] = null;
        //areaTavern.Directions["west"] = null;

        ////areaFootOfMountain
        //areaFootOfMountain.Directions["north"] = areaTavern;
        //areaFootOfMountain.Directions["south"] = null;
        //areaFootOfMountain.Directions["east"] = null;
        //areaFootOfMountain.Directions["west"] = null;

        ////areaHalfUpMountain
        //areaHalfUpMountain.Directions["north"] = null;
        //areaHalfUpMountain.Directions["south"] = null;
        //areaHalfUpMountain.Directions["east"] = null;
        //areaHalfUpMountain.Directions["west"] = null;

        ////areaTopOfMountain
        //areaTopOfMountain.Directions["north"] = null;
        //areaTopOfMountain.Directions["south"] = null;
        //areaTopOfMountain.Directions["east"] = null;
        //areaTopOfMountain.Directions["west"] = null;//Old Area direction setting


        //Starts player in initial area
        _currentPlayer.CurrentArea = _areas["TownCenter"];
    }
}

