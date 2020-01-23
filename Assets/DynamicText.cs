using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DynamicText : MonoBehaviour {
    public RectTransform panelRectTrans;
    [TextArea]
    public string shownString = "";
    // Use this for initialization
    void Start () {
        string s = GetComponent<Text>().text;
        GetComponent<Text>().text = "";
        //panelRectTrans.sizeDelta = new Vector2(90, (s.Length / 8 +1)* 11);
        panelRectTrans.DOSizeDelta(new Vector2(90, (s.Length / 8 + 1) * 11+10), 0.5f);
        GetComponent<Text>().DOText(s, 0.1f * s.Length, true).SetEase(Ease.Linear);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    [ContextMenu("show text")]
    void ShowText()
    {
        GetComponent<Text>().text = "";
        panelRectTrans.DOSizeDelta(new Vector2(90, (shownString.Length / 8 + 1) * 12+15), 1);
        GetComponent<Text>().DOText(shownString, 0.1f * shownString.Length,true).SetEase(Ease.Linear);

    }
}
