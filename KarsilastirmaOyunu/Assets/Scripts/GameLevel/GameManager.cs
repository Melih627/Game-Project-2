using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Threading;
using System.Runtime.InteropServices.ComTypes;


public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject puanSurePaneli,PausePanel,sonucPanel;

    [SerializeField]
    private GameObject puankiKap,BuyukSayiSec;

    [SerializeField]
    private GameObject ustDikd;

    [SerializeField]
    private GameObject altDikd;

    [SerializeField]
    private Text ustText, altText,skorText;

    int dogru, yanlis;

    private AudioSource audioSrc;
    [SerializeField]
    private AudioClip baslangicS, dogruS, yanlisS, bitisS;

    SonucManager sonucManager;
    TimerManager timerManager;
    DairelerManager dairelerManager;
    TrueFalseManager truefalseManager;
    int oyunSayac, kacinciOyun,UstDeger,AltDeger;
    int buyukDeger,butonDeger;
    int toplamPuan,artisPuan;
    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        timerManager = Object.FindObjectOfType<TimerManager>();
        dairelerManager = Object.FindObjectOfType<DairelerManager>();
        truefalseManager = Object.FindObjectOfType<TrueFalseManager>();
    }
    void Start()
    {
        dogru = 0;
        yanlis = 0;
        kacinciOyun = 0;
        oyunSayac = 0;
        ustText.text = "";
        altText.text = "";
        skorText.text = "0";
        toplamPuan = 0;

        SahneEkranıGuncelle();
        
    }
    void SahneEkranıGuncelle()
    {
        puanSurePaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        puankiKap.GetComponent<CanvasGroup>().DOFade(1, 1f);
        ustDikd.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);
        altDikd.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);

        OyunaBasla();
    }
   
    public void OyunaBasla()
    {
        audioSrc.PlayOneShot(baslangicS);     
        puankiKap.GetComponent<CanvasGroup>().DOFade(0, 1f);
        BuyukSayiSec.GetComponent<CanvasGroup>().DOFade(1, 1f);
        KacinciOyun();
        timerManager.SureyiBaslat();
        
    }
    void KacinciOyun()

    {
        if (oyunSayac < 5)
        {
            kacinciOyun = 1;
            artisPuan = 25;
        }else if (oyunSayac >= 5 && oyunSayac<10)
        {
            kacinciOyun = 2;
                artisPuan=50;
        } else if (oyunSayac >= 10 && oyunSayac < 15)
        {
            artisPuan = 75;
            kacinciOyun = 3;
        }
        else if (oyunSayac >= 15 && oyunSayac < 20)
        {
            artisPuan = 100;
            kacinciOyun = 4;
        }
        else if (oyunSayac >= 20 && oyunSayac < 25)
        {
            artisPuan = 125;
            kacinciOyun = 5;
        }
        else
        {
            kacinciOyun =Random.Range(1,6);
            artisPuan = 150;
        }

        switch (kacinciOyun)
        {
            case 1:
                BirinciFonks();
                break;
            case 2:
                ikinciFonk();
                break;
            case 3:
                ucuncuFonk();
                break;
            case 4:
                dorduncuFonk();
                break;
            case 5:
                besinciFonk();
                break;


        }

    }
    void besinciFonk()
    {
        int bolen1 = Random.Range(2, 10);
        UstDeger = Random.Range(2, 10);
        int bolunen1 = bolen1 * UstDeger;

        int bolen2 = Random.Range(2, 10);
        AltDeger = Random.Range(2, 10);
        int bolunen2 = bolen2 * AltDeger;

        if (UstDeger > AltDeger)
        {
            buyukDeger = UstDeger;
        }
        else if (AltDeger > UstDeger)
        {
            buyukDeger = AltDeger;
        }
        if (UstDeger == AltDeger)
        {
            besinciFonk();
            return;
        }
        ustText.text = bolunen1 + " / " + bolen1;
        altText.text = bolunen2 + " / " + bolen2;

    }

    void dorduncuFonk()
    {
        int sayi1 = Random.Range(1, 10);
        int sayi2 = Random.Range(1, 10);
        int sayi3 = Random.Range(1, 10);
        int sayi4 = Random.Range(1, 10);

        UstDeger = sayi1 * sayi2;
        AltDeger = sayi3 * sayi4;

        if (UstDeger > AltDeger)
        {
            buyukDeger = UstDeger;
        }
        else if (AltDeger > UstDeger)
        {
            buyukDeger = AltDeger;
        }
        if (UstDeger == AltDeger)
        {
            dorduncuFonk();
            return;
        }
        ustText.text = sayi1 + " x " + sayi2;
        altText.text = sayi3 + " x " + sayi4;
    }

    void ucuncuFonk()
    {
        int sayi1 = Random.Range(11, 30);
        int sayi2 = Random.Range(1, 11);
        int sayi3 = Random.Range(11, 40);
        int sayi4 = Random.Range(1, 11);

        UstDeger = sayi1 - sayi2;
        AltDeger = sayi3 - sayi4;

        if (UstDeger > AltDeger)
        {
            buyukDeger = UstDeger;
        }
        else if (AltDeger > UstDeger)
        {
            buyukDeger = AltDeger;
        }
        if (UstDeger == AltDeger)
        {
            ucuncuFonk();
            return;
        }
        ustText.text = sayi1 + "-" + sayi2;
        altText.text = sayi3 + "-" + sayi4;
    }
    void ikinciFonk()
    {
        int sayi1 = Random.Range(1, 10);
        int sayi2 = Random.Range(1, 20);
        int sayi3 = Random.Range(1, 10);
        int sayi4 = Random.Range(1, 20);

        UstDeger = sayi1 + sayi2;
        AltDeger = sayi3 + sayi4;

        if (UstDeger > AltDeger)
        {
            buyukDeger = UstDeger;
        }else if (AltDeger > UstDeger)
        {
            buyukDeger = AltDeger;
        }
        if (UstDeger == AltDeger)
        {
            ikinciFonk();
            return;
        }
        ustText.text = sayi1 + "+" + sayi2;
        altText.text = sayi3 + "+" + sayi4;
    }

    void BirinciFonks()
    {
        int rastgeleDeger = Random.Range(1, 50);
        if (rastgeleDeger <= 25)
        {
            UstDeger = Random.Range(2, 50);
            AltDeger = UstDeger + Random.Range(1, 15);  
        }
        else
        {
            UstDeger = Random.Range(2, 50);
            AltDeger = Mathf.Abs(UstDeger - Random.Range(1, 15));
        }
        if (UstDeger > AltDeger)
        {
            buyukDeger = UstDeger;
        }
        else if(AltDeger> UstDeger)
        {
            buyukDeger = AltDeger;
        }

        if (UstDeger == AltDeger)
        {
            BirinciFonks();
            return;
        }
        ustText.text = UstDeger.ToString();
        altText.text = AltDeger.ToString();
        

    }

    public void ButonDegeriniBelirle(string butonadi)
    {
        if (butonadi == "ustButon")
        {
            butonDeger = UstDeger;
        }
        else if( butonadi=="altButon")
        {
            butonDeger = AltDeger;
        }

        if (butonDeger == buyukDeger)
        {
            truefalseManager.TrueFalseScaleAc(true);
            dairelerManager.DaireninScaleAc(oyunSayac % 5);
            oyunSayac++;
            toplamPuan += artisPuan;
            skorText.text = toplamPuan.ToString();
            dogru++;
            audioSrc.PlayOneShot(dogruS);
            KacinciOyun();

        }
        else
        {
            truefalseManager.TrueFalseScaleAc(false);
            HataSayacıAzalt();
            yanlis++;
            audioSrc.PlayOneShot(yanlisS);
            KacinciOyun();
        }
    }


    void HataSayacıAzalt()
    {
        oyunSayac = oyunSayac - (oyunSayac % 5 + 5);
        if (oyunSayac < 0)
        {
            oyunSayac = 0;
        }
        dairelerManager.DaireScaleKapat();  
    }
    public void pausePanelAc()
    {
        PausePanel.SetActive(true);
    }

    public void OyunBitir()
    {
        audioSrc.PlayOneShot(bitisS);
        sonucPanel.SetActive(true);
        sonucManager = Object.FindObjectOfType<SonucManager>();
        sonucManager.SonucGoster(dogru, yanlis, toplamPuan);
    }
    
   
}
