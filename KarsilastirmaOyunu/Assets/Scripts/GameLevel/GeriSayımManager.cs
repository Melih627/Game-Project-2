using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeriSayımManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GeriSayimObj;

    [SerializeField]
    private Text GeriSayimText;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GeriyeSayRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator GeriyeSayRoutine()
    {
        GeriSayimText.text = "3";
       
        yield return new WaitForSeconds(0.5f);
        GeriSayimObj.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        GeriSayimObj.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);
        
        GeriSayimText.text = "2";

        yield return new WaitForSeconds(0.5f);
        GeriSayimObj.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        GeriSayimObj.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        GeriSayimText.text = "1";

        yield return new WaitForSeconds(0.5f);
        GeriSayimObj.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        GeriSayimObj.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        StopAllCoroutines();
        gameManager.OyunaBasla();
        


    }
}
