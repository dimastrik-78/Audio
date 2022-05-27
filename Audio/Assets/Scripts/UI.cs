using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject ButtonPause, ButtonContinue, ButtonReset, PanelSettings, PanelLose;
    [SerializeField] Slider SliderMusic, SliderVFX;
    [SerializeField] AudioMixer AudioMixer;
    [SerializeField] Toggle ToggleMusic, ToggleVFX;
    public Text HealText;
    public Weapon Player;
    public bool CanShoot;

    private const string PATH = @"Assets\Resources\VolumSettings.txt";
    AudioSetting audioSetting;
    private void Start()
    {
        audioSetting = new AudioSetting();

        if (File.Exists(PATH) == false)
        {
            File.Create(PATH);
            SaveVolToJSON();
        }
        else
        {
            LoadVolFromJSON();
        }
    }
    void Update()
    {
        HealText.text = $"Heal {Player._heal}/3";
        if (Player._heal == 0)
        {
            LosePanel();
        }
    }
    public void LosePanel()
    {
        Time.timeScale = 0;
        ButtonPause.SetActive(false);
        PanelLose.SetActive(true);
    }
    public void ChangeVFX()
    {
        if (ToggleVFX.isOn == false)
            AudioMixer.SetFloat("VFX", -80);
        else
            AudioMixer.SetFloat("VFX", SliderVFX.value);
    }
    public void ChangeMusic()
    {
        if (ToggleMusic.isOn == false)
            AudioMixer.SetFloat("MainMusic", -80);
        else
            AudioMixer.SetFloat("MainMusic", SliderMusic.value);
    }
    public void ResetLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        CanShoot = false;
        ButtonPause.SetActive(false);
        ButtonContinue.SetActive(true);
        PanelSettings.SetActive(true);
    }
    public void ContinueGame()
    {
        CanShoot = true;
        ButtonPause.SetActive(true);
        ButtonContinue.SetActive(false);
        PanelSettings.SetActive(false);
        Time.timeScale = 1;
    }
    public void LoadVolFromJSON()
    {
        string jsonStr = File.ReadAllText(PATH);
        audioSetting = JsonUtility.FromJson<AudioSetting>(jsonStr);

        AudioMixer.SetFloat("MainMusic", audioSetting.MusicVolum);
        AudioMixer.SetFloat("VFX", audioSetting.FVXVolum);

        SliderMusic.value = audioSetting.MusicVolum;
        SliderVFX.value = audioSetting.FVXVolum;

        ToggleMusic.isOn = audioSetting.ToggleMusic;
        ToggleVFX.isOn = audioSetting.ToggleVFX;
    }

    public void SaveVolToJSON()
    {
        audioSetting.MusicVolum = SliderMusic.value;
        audioSetting.FVXVolum = SliderVFX.value;

        audioSetting.ToggleMusic = ToggleMusic.isOn;
        audioSetting.ToggleVFX = ToggleVFX.isOn;

        string volumeStr = JsonUtility.ToJson(audioSetting);
        File.WriteAllText(PATH, volumeStr);
    }
}

public class AudioSetting
{
    public float MusicVolum, FVXVolum;
    public bool ToggleMusic, ToggleVFX;
}