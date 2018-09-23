using Assets.Model.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryOutput : MonoBehaviour
{
    public Text output;
    

    void Update()
    {
        output.text = null;
        output.text = "* INVENTORY * \n \n";

        if (GameManager.Instance.GameModel.CurrentPlayer.LstInventory != null)
        {        
            foreach (ClsItem prItem in GameManager.Instance.GameModel.CurrentPlayer.LstInventory)
            {
                output.text = output.text + "\n" + prItem.Name;
            }
        }
        else
        {
            output.text = "Your inventory is empty!";
        }
    }
}
