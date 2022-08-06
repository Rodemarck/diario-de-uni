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
    [Serializable]
    [DisallowMultipleComponent]
    public class MenuOpcao : MonoBehaviour
    {
        private float _volumeBGM;
        public float VolumeBGM{
            get => _volumeBGM;
            set{
                _volumeBGM = value;
                if (SliderGBM.value == value) return;
                SliderGBM.value = value;
            }
        }
        private float _volumeGUI;
        public float VolumeGUI
        {
            get => _volumeGUI;
            set
            {
                _volumeGUI = value;
                if (SliderGUI.value == value) return;
                SliderGUI.value = value;
            }
        }
        private float _voluemeVOZ;
        public float VolumeVoz
        {
            get => _voluemeVOZ;
            set
            {
                _voluemeVOZ = value;
                if (SliderVoice.value == value) return;
                SliderVoice.value = value;
            }
        }
        private float _typeSpeed;
        public float TypeSpeed
        {
            get => _typeSpeed;
            set
            {
                _typeSpeed = value;
                if (SliderTypeSpeed.value == value) return;
                SliderTypeSpeed.value = value;
            }
        }
        private float _readSpeed;
        public float ReadSpeed
        {
            get => _readSpeed;
            set
            {
                _readSpeed = value;
                if (SliderReadSpeed.value == value) return;
                SliderReadSpeed.value = value;
            }
        }
        private bool FullWindow = false;

        public Slider SliderGBM;
        public Slider SliderGUI;
        public Slider SliderVoice;
        public Slider SliderTypeSpeed;
        public Slider SliderReadSpeed;
        public TMP_Dropdown DropdownLang;
        public void MenuPrincipal(){
        }

        public void LangChange(int op)
        {
            WorldController.Instance.SetLang(DropdownLang.options[DropdownLang.value].text);
            foreach (var tmt in FindObjectsOfType<TMPTextTranslate>( ))
                tmt.Translate();
            
        }

        public void Creditos(){
            SceneManager.LoadScene("Creditos");
        }

        private void Start()
        {
            DropdownLang.ClearOptions();
            var options = WorldController.Instance.SupportedLanguages();
            DropdownLang.AddOptions(options);
        }
    }
}