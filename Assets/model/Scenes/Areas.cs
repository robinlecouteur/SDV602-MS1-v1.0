using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.model.Scenes
{
    public class AreaTownCenter : Area
    {     
        public AreaTownCenter()
        {
            _areaName = "Town Center";
            //Town Center (Starting Scene)
            //scnTownCenter.LstActions.Add(new GameAction(scnTownCenter) { Obj1 = scnTownCenter.TimesVisited, Obj2 = 1, Operator = ">=", ActionType = "ShowText", Text = "If this case worked it will only show the the first time you arrive here." });
            DictStoryText.Add("DefaultText", "Town Center");
            //scnTownCenter.LstStoryText.Add("To your South is the Tavern");
            //scnTownCenter.LstStoryText.Add("To your West is the foot of the mountain");
        }
    }
    public class AreaTavern : Area
    {
        public AreaTavern()
        {
            _areaName = "Tavern";
            LstSceneObjects.Add(new Item { Description = "Gold Coin" });
            DictStoryText.Add("DefaultText", "You are in the Tavern.  you see a gold coin on the ground. Type 'pick up' to pick it up.");
            DictStoryText.Add("Returning Text", "You return to the Tavern.");
        }
        public override void Arrive()
        {
            if (_timesVisited == 0)
            { StoryText += DictStoryText["DefaultText"]; }
            else if (_timesVisited >= 1)
            { StoryText += DictStoryText["Returning Text"]; }

            _storyText += Directions;
        }
    }
    public class AreaFootOfMountain : Area
    {
        public AreaFootOfMountain()
        {
            _areaName = "Foot of the mountain";
            DictStoryText.Add("DefaultText", "You are at the foot of the mountain");
        }
    }
    public class AreaHalfUpMountain : Area
    {
        public AreaHalfUpMountain()
        {
            _areaName = "Half way up the Mountain";
            DictStoryText.Add("DefaultText", "Halfway up the mountain");
        }
    }
    public class AreaTopOfMountain : Area
    {
        public AreaTopOfMountain()
        {
            _areaName = "Top of the Mountain";
            DictStoryText.Add("DefaultText", "Top of the mountain");
        }
    }
}
