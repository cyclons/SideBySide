using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsBtn : MonoBehaviour {

	public void DisplaySettingUI()
    {
        transform.Find("SettingsWin").gameObject.SetActive(true);
    }
}
