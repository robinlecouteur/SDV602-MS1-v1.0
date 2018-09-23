using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UManager = UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance; 

    private bool GameRunning;

    public GameModel GameModel;

    public Canvas ActiveCanvas;
    public Canvas CnvGame;
    public Canvas CnvInventory;
    public Canvas CnvMap;
    private Dictionary<string, Canvas> canvases;

    public Dictionary<string, Canvas> Canvases
    {
        get
        {
            return canvases;
        }

        set
        {
            canvases = value;
        }
    }

    public void SetActiveCanvas(string prCnvName)
    {

        if (Canvases.ContainsKey(prCnvName))
        {

            // set all to not active;
            foreach (Canvas prCanvas in Canvases.Values)
            {
                    prCanvas.gameObject.SetActive(false);
                }
            ActiveCanvas = Canvases[prCnvName];
            Debug.Log("I am the active one " + prCnvName);
            ActiveCanvas.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("I can not find " + prCnvName + " to make active.");
        }

        Canvas[] tempCanvases = gameObject.GetComponentsInChildren<Canvas>();

        foreach (Canvas prCanvase in tempCanvases)
        {
            if (prCanvase.name != prCnvName)
            {
                prCanvase.gameObject.SetActive(false);
            }
        }
    }
    public string CurrentUScene()
    {
        return UManager.SceneManager.GetActiveScene().name;
    }

    public void ChangeScene(string prSceneName)
    {
        UManager.SceneManager.LoadScene(prSceneName);
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            GameRunning = true;
            Debug.Log("I am the one");
            GameModel = new GameModel();
        }
        else
        {
            Destroy(gameObject);
        }

        if (Canvases == null)
        {
            Canvases = new Dictionary<string, Canvas>();
            Canvases["cnvGame"] = CnvGame;
            Canvases["cnvMap"] = CnvMap;
            Canvases["cnvInventory"] = CnvInventory;
            
        }
    }

    public bool IsGameRunning()
    {
        return GameRunning;
    }
}
