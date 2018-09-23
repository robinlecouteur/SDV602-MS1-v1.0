using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model.Items
{
    [Serializable]
    public class ClsItem
    {
        public ClsItem()
        {
        }
        private string _name;
        private string _description;
        private string _textOnPickup;
        

        public string Name
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
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }
        public string TextOnPickup
        {
            get
            {
                return _textOnPickup;
            }

            set
            {
                _textOnPickup = value;
            }
        }
    }
}
