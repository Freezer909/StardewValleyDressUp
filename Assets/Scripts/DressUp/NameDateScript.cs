using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameDateScript : MonoBehaviour
{

    private string text;
    private string date;

    private int rand;
    public TMP_InputField NameField;
    public TMP_InputField DateField;
    public TMP_Text TextField;

    private int CalculateAge(DateTime birthDate)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }

    public void CalculateInfo()
    {
        string characterName = NameField.text;
        string dateInput = DateField.text;

        if (DateTime.TryParse(dateInput, out DateTime birthDate))
        {
            int age = CalculateAge(birthDate);

            TextField.text = $"Fermeris "+characterName+" ir "+age+" gadus vecs!";
        }
        else
        {
            TextField.text = "Ievadi derīgu datumu (piem - 20.05.2025)";
        }
    }

}
