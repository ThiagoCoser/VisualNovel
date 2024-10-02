using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceCanvas : MonoBehaviour
{

    public GameObject PlayerAvatar;

    public Button BTN_A;
    public Button BTN_B;

    void OnEnable()
    {


        BTN_A.onClick.AddListener(BTN_A_CLICK);
        BTN_B.onClick.AddListener(BTN_B_CLICK);
    }

    void OnDisable()
    {
        BTN_A.onClick.RemoveListener(BTN_A_CLICK);
        BTN_B.onClick.RemoveListener(BTN_B_CLICK);
    }


    void BTN_A_CLICK()
    {
        if (GameData.ChoiceState == 0)
        {
            GameData.goodKarma += 1;
            gameObject.SetActive(false);
            PlayerAvatar.SetActive(true);

        }

    }

    void BTN_B_CLICK()
    {
        if (GameData.ChoiceState == 0)
        {
            GameData.badKarma += 1;
            gameObject.SetActive(false);
            PlayerAvatar.SetActive(true);
        }

    }

}
