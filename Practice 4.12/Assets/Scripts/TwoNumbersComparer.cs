using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoNumbersComparer : MonoBehaviour
{
    [SerializeField] private InputField FirstInputField;
    [SerializeField] private InputField SecondInputField;
    [SerializeField] private Text outputText;
    [SerializeField] private Text outputSymbol;

    float number;

    public void CompareTwoNumbers()

    {

        if (!float.TryParse(FirstInputField.text, out number))

        {
            Debug.Log("¬ведите число");
        }

        else if (!float.TryParse(SecondInputField.text, out number))

        {
            Debug.Log("¬ведите число");
        }

        else if (float.Parse(FirstInputField.text) == float.Parse(SecondInputField.text))

        {
            outputText.text = "„исла равны";
            outputSymbol.text = "=";
        }

        else if (float.Parse(FirstInputField.text) > float.Parse(SecondInputField.text))

        {
            outputText.text = "ѕервое число больше";
            outputSymbol.text = ">";
        }

        else
        {
            outputText.text = "¬торое число больше";
            outputSymbol.text = "<";
        }

    }
}
