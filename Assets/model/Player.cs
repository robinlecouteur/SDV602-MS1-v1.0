using Assets.Model.Items;
using System;
using System.Collections.Generic;

namespace Assets.Model
{

    [Serializable]
    public class ClsPlayer
    {
        public ClsPlayer() //Constructor
        {
        }

        // Class
        private static int _playerNum = 0;

        // Instance
        private int _number = (ClsPlayer._playerNum++);
        private string _name = "Robin(Default)";

        private List<ClsItem> _lstInventory = new List<ClsItem>();   
        private ClsArea _currentArea;
        private Boolean _drunk = false;
        private int _experience = 0;
        private int _health = 10;

        //Properties
        public ClsArea CurrentArea
        {
            get
            {
                return _currentArea;
            }
            set
            {
                _currentArea = value;
            }
        }
        public String Name
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
        public bool Drunk
        {
            get
            {
                return _drunk;
            }

            set
            {
                _drunk = value;
            }
        }
        public List<ClsItem> LstInventory
        {
            get
            {
                return _lstInventory;
            }

            set
            {
                _lstInventory = value;
            }
        }


        //Methods
        public void Move(string prDirection)
        {

            foreach (Destination lcDestination in _currentArea.Destinations)
            {
                if (lcDestination.Direction == prDirection)
                {
                    _currentArea = lcDestination.TargetArea;
                }
            }
        }

        public void AddExperience(int prXPtoAdd)
        {
            _experience += prXPtoAdd;
        }
        public void Die()
        {
            _health = 0;
        }
    }
}


