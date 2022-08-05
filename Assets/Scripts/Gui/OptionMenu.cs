using System;
using System.Linq;
using Generals;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using World;

namespace Gui{
    [DisallowMultipleComponent]
    public class OptionMenu : MonoBehaviour
    {
        #region Setters
        public float VolumeBGM{
            get => WorldController.Instance._volumeBGM;
            set{
                WorldController.Instance._volumeBGM = value;
                if (SliderGBM.value == value) return;
                SliderGBM.value = value;
            }
        }     
        public float VolumeGUI
        {
            get => WorldController.Instance._volumeGUI;
            set
            {
                WorldController.Instance._volumeGUI = value;
                if (SliderGUI.value == value) return;
                SliderGUI.value = value;
            }
        }
        public bool Fullscreen
        {
            get => WorldController.Instance._fullWindow;
            set
            {
                WorldController.Instance._fullWindow = value;
                WorldController.Instance.FullScreen();
                if (ToggleFullScreen.isOn == value) return;
                ToggleFullScreen.isOn = value;
            }
        }

        public float VolumeVoz
        {
            get => WorldController.Instance._voluemeVOICE;
            set
            {
                WorldController.Instance._voluemeVOICE = value;
                if (SliderVoice.value == value) return;
                SliderVoice.value = value;
            }
        }
      
        public float TypeSpeed
        {
            get => WorldController.Instance._typeSpeed;
            set
            {
                WorldController.Instance._typeSpeed = value;
                if (SliderTypeSpeed.value == value) return;
                SliderTypeSpeed.value = value;
            }
        }
        
        public float ReadSpeed
        {
            get => WorldController.Instance._readSpeed;
            set
            {
                WorldController.Instance._readSpeed = value;
                if (SliderReadSpeed.value == value) return;
                SliderReadSpeed.value = value;
            }
        }
        #endregion

        public Slider SliderGBM;
        public Slider SliderGUI;
        public Slider SliderVoice;
        public Slider SliderTypeSpeed;
        public Slider SliderReadSpeed;
        public TMP_Dropdown DropdownLang;
        public Toggle ToggleFullScreen;



        public void DefaultConfig(){}
        public void LangChange(int op) { 
            WorldController.Instance.SetLang(DropdownLang.options[DropdownLang.value].text);
            WorldController.Instance.LangChange();  
        }

        public void Credits(){
            SceneManager.LoadScene("Credits");
        }

        public void Save(){
            WorldController.Instance.SaveConfig();
        }
        
        public void Exit(){
            
            SceneManager.LoadScene("MainMenu");
        }
        private void LoadConfig(){
            SliderGBM.value = WorldController.Instance._volumeBGM;
            SliderGUI.value = WorldController.Instance._volumeGUI;
            SliderVoice.value = WorldController.Instance._voluemeVOICE;
            SliderReadSpeed.value = WorldController.Instance._readSpeed;
            SliderTypeSpeed.value = WorldController.Instance._typeSpeed;
            ToggleFullScreen.isOn = (bool)WorldController.Instance._fullWindow;
        }

        private void Start()
        {
            DropdownLang.ClearOptions();
            var options = WorldController.Instance.SupportedLanguages();
            DropdownLang.AddOptions(options);
            WorldController.Instance.LoadConfig();
            this.LoadConfig();
        }
    }
}