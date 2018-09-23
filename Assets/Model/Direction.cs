using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model
{
    public class Destination
    {
        //--- Vars ---//
        private ClsArea _targetArea;
        private string _direction;


        //--- Properties ---//
        public ClsArea TargetArea
        {
            get
            {
                return _targetArea;
            }

            set
            {
                _targetArea = value;
            }
        }
        public string Direction
        {
            get
            {
                return _direction;
            }

            set
            {
                _direction = value;
            }
        }
    }
}
