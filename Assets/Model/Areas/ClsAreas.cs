using Assets.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model.Areas
{
    //------------------------------------------------------------------- Cliff -------------------------------------------------------------------------//
    //                                                                                                                                                   //
    [Serializable]
    public class ClsAreaCliff : ClsArea
    {
        public ClsAreaCliff()
        {
            _areaName = "Cliff";
            _dictAreaText.Add("DefaultText", "You fell off the cliff!");
        }

        public override void Arrive(ClsPlayer prPlayer)
        {
            _areaText += _dictAreaText["DefaultText"];
        }
    }
    
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//



    //---------------------------------------------------------------- Town Center ----------------------------------------------------------------------//
    //                                                                                                                                                   //
    [Serializable]
    public class ClsAreaTownCenter : ClsArea
    {     
        public ClsAreaTownCenter()
        {
            _areaName = "Town Center";         
            _dictAreaText.Add("DefaultText", "Town Center");
        }
    }
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//




    //------------------------------------------------------------------ Tavern -------------------------------------------------------------------------//
    //                                                                                                                                                   //

    [Serializable]
    public class ClsAreaTavern : ClsArea
    {
        public ClsAreaTavern()
        {
            _areaName = "Tavern";
            _lstAreaItems.Add(new ClsItem {Name = "goldcoin", Description = "A shiny gold coin", TextOnPickup  = "You quickly pocket the coin of precious gold" });

            //*** Add Text ***//
            _dictAreaText.Add("DefaultText", "You arrive at the Tavern.");
            _dictAreaText.Add("GoldCoinText", "you see a GoldCoin on the ground. Type 'pick up goldcoin' to pick it up.");
            _dictAreaText.Add("ReturningText", "You return to the Tavern.");
            //***   ***   *** //
        }

        public override void Arrive(ClsPlayer prPlayer)
        {
            if (_timesVisited == 0)
            { _areaText += _dictAreaText["DefaultText"] + "\n"; }
            else if (_timesVisited >= 1)
            { _areaText += _dictAreaText["ReturningText"]; }



            foreach (ClsItem prItem in _lstAreaItems)
            {
                if (prItem.Name == "goldcoin") { _areaText += _dictAreaText["GoldCoinText"] + "\n";}
            }


            _areaText += DestinationText;
        }
    }
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//




    //-------------------------------------------------------------- Foot of Mountain -------------------------------------------------------------------//
    //                                                                                                                                                   //

    [Serializable]
    public class ClsAreaFootOfMountain : ClsArea
    {
        public ClsAreaFootOfMountain()
        {
            _areaName = "Foot of the mountain";
            _dictAreaText.Add("DefaultText", "You are at the foot of the mountain");
        }
    }
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//




    //------------------------------------------------------------- Half Up Mountain --------------------------------------------------------------------//
    //                                                                                                                                                   //

    [Serializable]
    public class ClsAreaHalfUpMountain : ClsArea
    {
        public ClsAreaHalfUpMountain()
        {
            _areaName = "Half way up the Mountain";
            _dictAreaText.Add("DefaultText", "Halfway up the mountain");
        }
    }
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//




    //-------------------------------------------------------------- Top of Mountain --------------------------------------------------------------------//
    //                                                                                                                                                   //

    [Serializable]
    public class ClsAreaTopOfMountain : ClsArea
    {
        public ClsAreaTopOfMountain()
        {
            _areaName = "Top of the Mountain";
            _dictAreaText.Add("DefaultText", "Top of the mountain");
        }
    }
    //                                                                                                                                                   //
    //---------------------------------------------------------------------------------------------------------------------------------------------------//
}
