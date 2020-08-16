using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text SureText;
    int kalanSure;
    bool SureSaysinmi= true;

    [SerializeField]
    GameManager gameManager;

   

  
    
  

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        kalanSure = 90;
        SureSaysinmi = true;
        

    }
    public void SureyiBaslat()
    {
        
        StartCoroutine(SureTimerRoutine());

    }
    IEnumerator SureTimerRoutine()
    {
        while (SureSaysinmi)
        {
            
            yield return new WaitForSeconds(1f);
            
            if (kalanSure < 10)
            {
                
                SureText.text = "0" + kalanSure.ToString();
            }else
            {
                SureText.text = kalanSure.ToString();
            }
            if (kalanSure <= 0)
            {
                SureSaysinmi = false;
                SureText.text = "";
                gameManager.OyunBitir();
                
            }
            
            kalanSure--;
        }
    }
   

 
}
