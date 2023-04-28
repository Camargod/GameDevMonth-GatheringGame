using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundController : MonoBehaviour
{
    [SerializeField] private Slider volumeSound;
     [SerializeField] private Slider volumeSFX;
    [SerializeField] private GameObject plugVolumeMudo; 
    [SerializeField] private GameObject plugVolumeBaixo;
    [SerializeField] private GameObject plugVolumeMedio;
    [SerializeField] private GameObject plugVolumeAlto;
    [SerializeField] private GameObject plugVolumeSFXMudo; 
    [SerializeField] private GameObject plugVolumeSFXBaixo;
    [SerializeField] private GameObject plugVolumeSFXMedio;
    [SerializeField] private GameObject plugVolumeSFXAlto;

    // Start is called before the first frame update
    void Start()
    {
        volumeSound.value = 6;
        volumeSFX.value = 6;
    }

    // Update is called once per frame
    void Update()
    {
      /// Icones Volume Soundtrack
        if (volumeSound.value == 0){
            plugVolumeBaixo.SetActive(false);
            plugVolumeMedio.SetActive(false);
            plugVolumeAlto.SetActive(false);
            plugVolumeMudo.SetActive(true);
        }
         if (volumeSound.value > 0 && volumeSound.value <= 3){
            plugVolumeMudo.SetActive(false);
            plugVolumeMedio.SetActive(false);
            plugVolumeAlto.SetActive(false);
            plugVolumeBaixo.SetActive(true);
        }
        if (volumeSound.value > 3 && volumeSound.value <= 6){
            plugVolumeMudo.SetActive(false);
            plugVolumeBaixo.SetActive(false);
            plugVolumeAlto.SetActive(false);
            plugVolumeMedio.SetActive(true);
        }
        if (volumeSound.value > 6){
            plugVolumeMudo.SetActive(false);
            plugVolumeBaixo.SetActive(false);
            plugVolumeMedio.SetActive(false);
            plugVolumeAlto.SetActive(true);
        }
        
        /// Icones Volume SFX
        if (volumeSFX.value == 0){
            plugVolumeSFXBaixo.SetActive(false);
            plugVolumeSFXMedio.SetActive(false);
            plugVolumeSFXAlto.SetActive(false);
            plugVolumeSFXMudo.SetActive(true);
        }
         if (volumeSFX.value > 0 && volumeSFX.value <= 3){
            plugVolumeSFXMudo.SetActive(false);
            plugVolumeSFXMedio.SetActive(false);
            plugVolumeSFXAlto.SetActive(false);
            plugVolumeSFXBaixo.SetActive(true);
        }
        if (volumeSFX.value > 3 && volumeSFX.value <= 6){
            plugVolumeSFXMudo.SetActive(false);
            plugVolumeSFXBaixo.SetActive(false);
            plugVolumeSFXAlto.SetActive(false);
            plugVolumeSFXMedio.SetActive(true);
        }
        if (volumeSFX.value > 6){
            plugVolumeSFXMudo.SetActive(false);
            plugVolumeSFXBaixo.SetActive(false);
            plugVolumeSFXMedio.SetActive(false);
            plugVolumeSFXAlto.SetActive(true);
        }
          
    }
}
