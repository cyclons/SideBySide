using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text startText = GetComponent<Text>();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(startText.DOFade(1, 1)).AppendInterval(1).Append(startText.DOFade(0, 1));

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
