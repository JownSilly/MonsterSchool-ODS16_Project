using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundController : MonoBehaviour
{
    [SerializeField] Slider volumeSom;
    [SerializeField] AudioSource soundMaster;
    // Start is called before the first frame update
    void Start()
    {
        volumeSom.value = StateEndGame.volume;
    }

    // Update is called once per frame
    void Update()
    {
        soundMaster.GetComponent<AudioSource>().volume = volumeSom.value;
        StateEndGame.volume = volumeSom.value;
    }
}
