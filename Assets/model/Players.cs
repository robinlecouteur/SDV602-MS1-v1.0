using Assets.Model;
using System;
using System.Collections;
using System.Collections.Generic;

using System.IO;

    [Serializable]
    public class ClsPlayers
    { 
	   private List<ClsPlayer> _lstPlayers = new List<ClsPlayer>();

	   public ClsPlayer this[int index] 
	   {
			get
			{ 
				return  _lstPlayers[index];
			} 
			set
			{
				_lstPlayers[index] = value;
			}
	    }

	    public ClsPlayers ()
		{
		
		}
	}


