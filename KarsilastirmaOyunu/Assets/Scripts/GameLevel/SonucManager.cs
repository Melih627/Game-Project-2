using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dgrText,ynlsText,PuanText;

    int puanSure = 10;
    bool sureBittimi = true;
    int toplam, yazdirilacak, artis;
    void Start()
    {
        sureBittimi = true;
    }
    public void SonucGoster(int dogru,int yanlis,int puan)
    {
        dgrText.text = dogru.ToString();
        ynlsText.text = yanlis.ToString();
        PuanText.text = puan.ToString();
        toplam = puan;
        artis = toplam / 10;

        StartCoroutine(PuaniYazdirRoutine());
    }

    IEnumerator PuaniYazdirRoutine()
    {
        while (sureBittimi)
        {
        
            yield return new WaitForSeconds(0.1f);
            yazdirilacak += artis;
            if (yazdirilacak >= toplam)
            {
                yazdirilacak = toplam;
            }
            PuanText.text = yazdirilacak.ToString();
            if (puanSure <= 0)
            {
                sureBittimi = false;
            }
            puanSure--;
        }
    }

    public void menuDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
