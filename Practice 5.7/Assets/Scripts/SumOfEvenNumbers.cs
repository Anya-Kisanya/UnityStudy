using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

public class SumOfEvenNumbers : MonoBehaviour
{
    /// <summary>
    /// Метод обработки события OnClick кнопки "Сумма четных чисел заданного диапазона"
    /// </summary>
    public void OnSumEvenNumbersInRange()
    {
        int min = 7;
        int max = 21;
        var want = 98;
        int got = SumEvenNumbersInRange(min, max);
        string message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
        Debug.Log($"Сумма четных чисел в диапазоне от {min} до {max} включительно: {got} - {message}");
    }

    /// <summary>
    /// Метод вычисляет сумму четных чисел в заданноном диапазане 
    /// </summary>
    /// <param name="min">Минимальное значение диапазона</param>
    /// <param name="max">Максимальное значение диапазона</param>
    /// <returns>Сумма чисел четных чисел</returns>
    private int SumEvenNumbersInRange(int min, int max)
    {
       int sum = 0;

       for (int i = min; i < max; i++)

       {
       if (i % 2 == 0)    
         sum = sum + i;
       }
        return sum;
    }

    public void OnSumEvenNumbersInArray()
    {
        int[] array = { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
        int want = 214;
        int got = SumEvenNumbersInArray(array);
        string message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
        Debug.Log($"Сумма четных чисел в заданном массиве: {got} - {message}");
    }

    /// <summary>
    /// Метод вычисляет сумму четных чисел в массиве 
    /// </summary>
    /// <param name="array">Исходный массив чисел</param>
    /// <returns>Сумма чисел четных чисел</returns>
    private int SumEvenNumbersInArray(int[] array)
    {
        int sum = 0;
        foreach (int a in array)

            if (a % 2 == 0)
            {
                sum = sum + a;
            }
        return sum;
    }
}