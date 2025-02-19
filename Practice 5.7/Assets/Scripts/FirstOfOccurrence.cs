using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows;

public class FirstOfOccurrence : MonoBehaviour
{
    /// <summary>
    /// Метод обработки события OnClick кнопки "Поиск первого вхождения числа в массив"
    /// </summary>
    public void OnFirstOccurrence()
    {
        // Первый тест, число присутсвует в массиве
        int[] array = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        int value = 34;
        int want = 3;
        int got = FirstOccurrence(array, value);
        string message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
        Debug.Log($"Индекс первого вхождения числа {value} в массив: {got} - {message}");

        // Второй тест, число не присутсвует в массиве
        array = new int[] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        value = 55;
        want = -1;
        got = FirstOccurrence(array, value);
        message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
        Debug.Log($"Индекс первого вхождения числа {value} в массив: {got} - {message}");
    }

    /// <summary>
    /// Метод производит поиск первого вхождения числа в массив
    /// </summary>
    /// <param name="array">Исходный массив</param>
    /// <param name="value">Искомое число</param>
    /// <returns>Индекс искомого числа в массиве или -1 если число отсуствует</returns>
    private int FirstOccurrence(int[] array, int value)
    {
        int arrNumber = 0;

        foreach (int a in array)

            if (a != value)
            {
                arrNumber++;
            }
            else break;

        if (arrNumber == 10)

            return -1;

        else return arrNumber;
    }
}
