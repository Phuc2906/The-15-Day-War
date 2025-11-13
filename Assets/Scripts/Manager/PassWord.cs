using UnityEngine;
using TMPro;

public class PassWord : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject targetObject;
    public GameObject correctCanvas;
    public GameObject wrongCanvas;
    public GameObject InputCanvas;
    public string correctAnswer = "Thành Công";

    void Start()
    {
        if (correctCanvas != null)
            correctCanvas.SetActive(false);
        if (wrongCanvas != null)
            wrongCanvas.SetActive(false);
        if (InputCanvas != null)
            InputCanvas.SetActive(false);
    }

    public void CheckInputButton()
    {
        CheckInput(inputField.text); 
    }
    void CheckInput(string userInput)
    {
        if (userInput == correctAnswer)
        {
            if (targetObject != null)
                targetObject.SetActive(false);
            if (InputCanvas != null)
                InputCanvas.SetActive(false);
            if (correctCanvas != null)
                correctCanvas.SetActive(true);
            if (wrongCanvas != null)
                wrongCanvas.SetActive(false);
        }
        else
        {
            if (wrongCanvas != null)
                wrongCanvas.SetActive(true);
        }
    }
}
