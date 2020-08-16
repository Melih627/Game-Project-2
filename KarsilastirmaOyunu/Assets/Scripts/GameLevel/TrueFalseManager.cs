using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrueFalseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trueIcon,falseIcon;

    // Start is called before the first frame update
    void Start()
    {
        scaleDegerKapat();
    }

    public void TrueFalseScaleAc(bool dogruYanlis)
    {
        if (dogruYanlis)
        {
            trueIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
            Invoke("scaleDegerKapat", 0.4f);

        }
        else
        {
            falseIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
            Invoke("scaleDegerKapat", 0.4f);
        }
    }
    void scaleDegerKapat()
    {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
