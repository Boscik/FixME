using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class playAgainSCript : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button PlayAgainButton, ExitButton;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        PlayAgainButton.onClick.AddListener(PlayAgain);
        ExitButton.onClick.AddListener(Exit);
    }

    void PlayAgain()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene("SampleScene Krystof");
    }

    void Exit()
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked");
        Application.Quit();
    }
}
