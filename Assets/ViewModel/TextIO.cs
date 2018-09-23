using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextIO : MonoBehaviour {
	private InputField _input;
    private InputField.SubmitEvent _subEvent;
	public Text Output;


    // Use this for initialization
    void Start () {
		_input = this.GetComponent<InputField>(); //Refers to input field specified in Unity
		_subEvent = new InputField.SubmitEvent();
		_subEvent.AddListener(SubmitInput);

		_input.onEndEdit = _subEvent;
        GameManager.Instance.GameModel.CurrentPlayer.CurrentArea.Arrive(GameManager.Instance.GameModel.CurrentPlayer);
        PushOutput(GameManager.Instance.GameModel.CurrentPlayer.CurrentArea.AreaText);
    }

	private void SubmitInput(string prCmdInput)
    {
        ClsCommandProcessor lcCmdProcessor = new ClsCommandProcessor(); //Instantiate a command processor
        

        string[] lcOutputArray; //Will store the output text and debug text

        lcOutputArray = lcCmdProcessor.Parse(prCmdInput); //pass the Inputted command and the vars for the outputs into the command processor to parse

        string lcOutputText = lcOutputArray[0];
        string lcDebugText = lcOutputArray[1];

        lcOutputText = "\n \n ---------------------------------------------------------------  \n" + lcOutputText; // Format the output text 
        PushOutput(lcOutputText);//Push output text to the display

        PushDebugText(lcDebugText);


        //Reset Input field and input text
        ResetInputField();
    }

    public static void PushDebugText(string lcDebugText)
    {
        Debug.Log(lcDebugText);
    }

    private void PushOutput(string prOutputText)
    {
        Output.text += prOutputText;
    }
    private void ResetInputField()
    {
        _input.text = "";
        _input.ActivateInputField();
    }
}
