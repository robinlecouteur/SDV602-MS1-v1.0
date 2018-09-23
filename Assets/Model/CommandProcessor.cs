using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.Model;
using Assets.Model.Items;

public class ClsCommandProcessor
{
    public ClsCommandProcessor()
    {
    }

    public string[] Parse(String prCmdInput)
    {
        String lcDebugText = "";
        String lcOutputText = "Do not understand";
        ClsArea lcCurrentArea = GameManager.Instance.GameModel.CurrentPlayer.CurrentArea;

        char[] charSeparators = new char[] { ' ' };
        prCmdInput = prCmdInput.ToLower();
        String[] parts = prCmdInput.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries); // tokenise the command

        if (parts.Length > 0)
        {


            // process the tokens
            switch (parts[0])
            {
                case "pick":
                    if (parts[1] == "up")
                    {
                        lcDebugText = ("Got Pick up");
                        if (GameManager.Instance.GameModel.CurrentPlayer.CurrentArea.LstAreaItems.Count != 0)
                        {
                            foreach (ClsItem prItem in GameManager.Instance.GameModel.CurrentPlayer.CurrentArea.LstAreaItems)
                            {
                                if (parts[2] == prItem.Name)
                                {
                                    GameManager.Instance.GameModel.Pickup(prItem);
                                     GameManager.Instance.GameModel.RemoveItemFromArea(prItem);
                                    lcOutputText = prItem.TextOnPickup;
                                    break;
                                } 
                            }
                            
                        }
                        else
                        {
                            lcOutputText = "There is nothing to pick up";
                        }

                        if (parts.Length == 3)
                        {
                            String param = parts[2];
                        }// do pick up command
                    }
                    break;
                case "go":
                    if (parts[1] == "north"  || parts[1] == "south" || parts[1] == "east" || parts[1] == "west")
                    {
                        string lcDirection = parts[1];
                        lcDebugText = ("Got go" + lcDirection);
                        lcCurrentArea.Leave(GameManager.Instance.GameModel.CurrentPlayer);
                        GameManager.Instance.GameModel.CurrentPlayer.Move(lcDirection); 
                        lcOutputText = Arrive(lcCurrentArea, lcOutputText);
                    }
                    else
                    {
                        lcDebugText = (" do not know how to go there");
                        lcOutputText = "Do not know how to go there";
                    }
                   break;

                case "show":
                    switch (parts[1])
                    {
                        case "game":
                            GameManager.Instance.SetActiveCanvas("cnvGame");
                            break;
                        case "inventory":
                            GameManager.Instance.SetActiveCanvas("cnvInventory");
                            break;
                        case "map":
                            GameManager.Instance.SetActiveCanvas("cnvMap");
                            break;
                    }

   
                    break;

                case "game":
                    switch (parts[1])
                    {
                        case "save":
                            ClsSaveLoad.Save(GameManager.Instance.GameModel);
                            break;
                        case "load":
                            ClsSaveLoad.Load(GameManager.Instance.GameModel);
                            lcOutputText = GameManager.Instance.GameModel.CurrentPlayer.CurrentArea.AreaText;
                            break;
                    }


                    break;
                default:
                    lcDebugText = ("Do not understand");
                    lcOutputText = "Do not understand";
                    break;

            }// end switch
        }

        String[] lcOutputArray = { lcOutputText, lcDebugText };
         return lcOutputArray;

    }// Parse

    private static string Arrive(ClsArea lcCurrentArea,string prOutputText)
    {
        lcCurrentArea = GameManager.Instance.GameModel.CurrentPlayer.CurrentArea;

        lcCurrentArea.Arrive(GameManager.Instance.GameModel.CurrentPlayer);
        prOutputText = lcCurrentArea.AreaText;
        return prOutputText;
    }

    private static void GoDirection(ClsArea lcCurrentArea, string lcDirection)
    {      
        
    }



}


