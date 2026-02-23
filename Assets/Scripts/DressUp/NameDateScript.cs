using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameDateScript : MonoBehaviour
{

    private string text;
    private string date;

    private int rand;
    public GameObject NameField;
    public GameObject DateField;
    public GameObject textField;


    public void getText()
    {
        name = NameField.GetComponent<TMP_InputField>().text;
        date = DateField.GetComponent<TMP_InputField>().text;
        textField.GetComponent<TMP_Text>().text = "Fermeris "+name+" ir "+date+" gadus vecs!";
    }

}
