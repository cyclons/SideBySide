using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public GameObject AudioInstance;
    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayQuikly(AudioClip clip)
    {
        InstanceAudio au = Instantiate(AudioInstance).GetComponent<InstanceAudio>();
        au.PlayAu(clip);
    }
}
