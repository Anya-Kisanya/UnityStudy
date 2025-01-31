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
            Debug.Log("������� �����");
        }

        else if (!float.TryParse(SecondInputField.text, out number))

        {
            Debug.Log("������� �����");
        }

        else if (float.Parse(FirstInputField.text) == float.Parse(SecondInputField.text))

        {
            outputText.text = "����� �����";
            outputSymbol.text = "=";
        }

        else if (float.Parse(FirstInputField.text) > float.Parse(SecondInputField.text))

        {
            outputText.text = "������ ����� ������";
            outputSymbol.text = ">";
        }

        else
        {
            outputText.text = "������ ����� ������";
            outputSymbol.text = "<";
        }

    }
}
