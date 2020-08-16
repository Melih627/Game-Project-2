using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DairelerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] daireDizi; 
    // Start is called before the first frame update
    void Start()
    {
        DaireScaleKapat();
    }
    public void DaireScaleKapat()
    {
        foreach (GameObject daire in daireDizi)
        {
            daire.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }

    
    public void DaireninScaleAc(int hangidaire)
    {
        daireDizi[hangidaire].GetComponent<RectTransform>().DOScale(1, 0.3f);
        if (hangidaire % 5 == 0)
        {
            DaireScaleKapat();
        }
    }
}
