using UnityEngine;
using UnityEngine.UI;

using static UnityEngine.Rendering.DebugUI;

public class Calculator : MonoBehaviour
{

    [SerializeField] private InputField FirstInputField;
    [SerializeField] private InputField SecondInputField;
    [SerializeField] private Text outputText;
    float number;

    public void AddNumders()

    {
       
        if (!float.TryParse(FirstInputField.text, out number))

        {
            Debug.Log("¬ведите число");
        }

        else if (!float.TryParse(SecondInputField.text, out number))

        {
            Debug.Log("¬ведите число");
        }

        else

        {

            float firstNumber = float.Parse(FirstInputField.text);
            float secondNumber = float.Parse(SecondInputField.text);
            float result = firstNumber + secondNumber;

            outputText.text = result.ToString();
        }


    }

    public void SubtractNumders()

    {

        if (!float.TryParse(FirstInputField.text, out number))

        {
            Debug.Log("¬ведите число");
        }

        else if (!float.TryParse(SecondInputField.text, out number))

        {
            Debug.Log("¬ведите число");
        }

        else

        {
            float firstNumber = float.Parse(FirstInputField.text);
            float secondNumber = float.Parse(SecondInputField.text);

            float result = firstNumber - secondNumber;

            outputText.text = result.ToString();
        }
    }

    public void MultiplyNumders()

    {

        if (!float.TryParse(FirstInputField.text, out number))

        {
            Debug.Log("¬ведите число");
        }

        else if (!float.TryParse(SecondInputField.text, out number))

        {
            Debug.Log("¬ведите число");
        }

        else
        {
            float firstNumber = float.Parse(FirstInputField.text);
            float secondNumber = float.Parse(SecondInputField.text);

            float result = firstNumber * secondNumber;

            outputText.text = result.ToString();
        }

    }

    public void DivideNumders()

    {
        if (!float.TryParse(FirstInputField.text, out number))

        {
            Debug.Log("¬ведите число");
        }

        else if (!float.TryParse(SecondInputField.text, out number))

        {
            Debug.Log("¬ведите число");
        }

        else

        {
            float firstNumber = float.Parse(FirstInputField.text);
            float secondNumber = float.Parse(SecondInputField.text);

            float result = firstNumber / secondNumber;

            outputText.text = result.ToString(); 
        }
    }
}
