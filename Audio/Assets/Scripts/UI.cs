using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UI : MonoBehaviour
{
    public GameObject ButtonPause, ButtonContinue, PanelSettings;
    [SerializeField] Slider SliderMusic, SliderVFX;
    [SerializeField] AudioMixer AudioMixer;
    [SerializeField] Toggle ToggleMusic, ToggleVFX;
    private void Start()
    {
        
    }
    void Update()
    {

    }
    public void ChangeVFX()
    {
        if (ToggleVFX.isOn == true)
            AudioMixer.SetFloat("VFX", -80);
        else
            AudioMixer.SetFloat("VFX", SliderVFX.value);

    }
    public void ChangeMusic()
    {
        if (ToggleMusic.isOn == true)
            AudioMixer.SetFloat("MainMusic", -80);
        else
            AudioMixer.SetFloat("MainMusic", SliderMusic.value);

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        ButtonPause.SetActive(false);
        ButtonContinue.SetActive(true);
        PanelSettings.SetActive(true);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        ButtonPause.SetActive(true);
        ButtonContinue.SetActive(false);
        PanelSettings.SetActive(false);
    }
}
