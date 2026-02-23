using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TēluApraksts : MonoBehaviour
{
    public TMP_Dropdown mansDropdown;
    public TMP_Text aprakstaTeksts;

    void Start()
    {
        mansDropdown.ClearOptions();

        List<string> vardi = new List<string>();
        vardi.Add("Stardew Farmer");
        vardi.Add("Mayor Lewis");
        vardi.Add("Benjamin Netanyahu");

        mansDropdown.AddOptions(vardi);

        MainitAprakstu(0);

        mansDropdown.onValueChanged.AddListener(delegate {
            MainitAprakstu(mansDropdown.value);
        });
    }

    public void MainitAprakstu(int index)
    {
        if (index == 0)
        {
            aprakstaTeksts.text = "Plikais zemnieks ieradas sava opja farma lai audzētu dārzeņus un augļus, nav ne jausmas kapec, bet vins ir nedaudz pliks";
        }
        else if (index == 1)
        {
            aprakstaTeksts.text = "Mērs Lewis, ciemata mērs zaudējas savus violetos shortus un vinam ir noslēptās attiecības ar ciemata sieviti ;)";
        }
        else if (index == 2)
        {
            aprakstaTeksts.text = "Bibi Netanyahu es nezinu ko vins seit dara bet man piespieda vinu pielikt ja nē tad bombardētu Liepaju";
        }
    }
}