using System;
using TMPro;
using UnityEngine;

public class NameDateScript : MonoBehaviour
{
    public TMP_InputField NameField;
    public TMP_InputField YearField;
    public TMP_Text TextField;

    public void CalculateInfo()
    {
        string characterName = NameField.text;
        string yearInput = YearField.text;

        if (int.TryParse(yearInput, out int birthYear))
        {
            int currentYear = DateTime.Today.Year;

            if (birthYear <= currentYear && birthYear > 1900)
            {
                int age = currentYear - birthYear;
                TextField.text = $"Fermeris {characterName} ir {age} gadus vecs!";
            }
            else
            {
                TextField.text = "Ievadi reālu dzimšanas gadu!";
            }
        }
        else
        {
            TextField.text = "Ievadi gadu kā skaitli (piem. 1995)";
        }
    }
}