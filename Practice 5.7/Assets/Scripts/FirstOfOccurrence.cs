using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows;

public class FirstOfOccurrence : MonoBehaviour
{
    /// <summary>
    /// ����� ��������� ������� OnClick ������ "����� ������� ��������� ����� � ������"
    /// </summary>
    public void OnFirstOccurrence()
    {
        // ������ ����, ����� ����������� � �������
        int[] array = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        int value = 34;
        int want = 3;
        int got = FirstOccurrence(array, value);
        string message = want == got ? "��������� ������" : $"��������� �� ������, ��������� {want}";
        Debug.Log($"������ ������� ��������� ����� {value} � ������: {got} - {message}");

        // ������ ����, ����� �� ����������� � �������
        array = new int[] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        value = 55;
        want = -1;
        got = FirstOccurrence(array, value);
        message = want == got ? "��������� ������" : $"��������� �� ������, ��������� {want}";
        Debug.Log($"������ ������� ��������� ����� {value} � ������: {got} - {message}");
    }

    /// <summary>
    /// ����� ���������� ����� ������� ��������� ����� � ������
    /// </summary>
    /// <param name="array">�������� ������</param>
    /// <param name="value">������� �����</param>
    /// <returns>������ �������� ����� � ������� ��� -1 ���� ����� ����������</returns>
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
