
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using UnityEngine;
using Gui;


namespace World{
    [DisallowMultipleComponent]
    public class WorldController:MonoBehaviour{
        #region Singleton

        private static WorldController _instance;

        private void Awake(){
            if (_instance != null)
                return;
            _instance = this;
            ReadLocalizationFile();
            var ci = CultureInfo.InstalledUICulture;
            _lang = ci.Name;
            if (!_translator.ContainsKey(_lang))
                _lang = "en-US";
            LoadConfig();

        }

        public static WorldController Instance => _instance;
        #endregion

        #region Localization    
        private void ReadLocalizationFile(){
            var lines = System.IO.File.ReadLines(@"./Assets/Resources/Localization/texts.csv");

            using var en = lines.GetEnumerator();
            en.MoveNext();
            var colums = en.Current.Split(",");
            var langs = new List<string>();
            _supportedLanguages = new Dictionary<string, string>();
            _translator = new Dictionary<string, Dictionary<string, string>>();
            for (var i = 1; i < colums.Length; i++){
                _translator.Add(colums[i],new Dictionary<string, string>());
                langs.Add(colums[i]);
            }

            en.MoveNext();
            colums = en.Current.Split(",");
            for (var i = 1; i < colums.Length; i++){
                _supportedLanguages.Add(langs[i-1],colums[i]);
            }
            string identification;
            while (en.MoveNext()){
                colums = en.Current.Split(",");
                identification = colums[0];
                for (var i = 1; i < colums.Length; i++){
                    _translator[langs[i - 1]].Add(identification, colums[i]);
                }
            }
        }
        
        private Dictionary<string, Dictionary<string, string>> _translator;
        private Dictionary<string,string> _supportedLanguages;

        public List<string> SupportedLanguages(){

            return _supportedLanguages.Select(pair => pair.Value).ToList();
        }

        public string GetLocalizationByLang(string lang){
            foreach (var pair in _supportedLanguages.Where(pair => pair.Value.Equals(lang))){
                return pair.Key;
            }
            return "en-US";
        }

        private string _lang;
        public string Translate(string id){
            return _translator[_lang][id];
        }

        public string Translate(string lang, string id)
        {
            return _translator[lang][id];
        }



        public void SetLang(string text)
        {
            _lang = GetLocalizationByLang(text);
            if (!_translator.ContainsKey(_lang))
                _lang = "en-US";
        }

        #endregion

        #region Config

        public float _volumeBGM = 0.5f;
        public float _volumeGUI = 0.5f;
        public float _voluemeVOICE = 0.5f;
        public float _typeSpeed = 0.5f;
        public float _readSpeed = 0.5f;
        public bool _fullWindow = false;

        
        public void SaveConfig(){
            SaveConfig("_volumeBGM",_volumeBGM);
            SaveConfig("_volumeGUI",_volumeGUI);
            SaveConfig("_voluemeVOICE",_voluemeVOICE);
            SaveConfig("_typeSpeed",_typeSpeed);
            SaveConfig("_readSpeed",_readSpeed);
            SaveConfig("_fullWindow",_fullWindow);
        }

        public void LoadConfig(){
            LoadConfig("_volumeBGM",out _volumeBGM);
            LoadConfig("_volumeGUI",out _volumeGUI);
            LoadConfig("_voluemeVOICE",out _voluemeVOICE);
            LoadConfig("_typeSpeed",out _typeSpeed);
            LoadConfig("_readSpeed",out _readSpeed);
            LoadConfig("_fullWindow",out _fullWindow);
        }

        

        public void FullScreen() {}


        #region Private config methods
        private void SaveConfig(string txt, float val){
            PlayerPrefs.SetFloat(txt,val);
        }
        private void SaveConfig(string txt, bool val){
            PlayerPrefs.SetInt(txt,val ? 1:0);
        }
        private void LoadConfig(string txt, out float value){
            if(PlayerPrefs.HasKey(txt))
                value = PlayerPrefs.GetFloat(txt);
            else{
                value = 0.5f;
                SaveConfig(txt,0.5f);
            }
        }
        private void LoadConfig(string txt, out bool value){
            if(PlayerPrefs.HasKey(txt))
                value = PlayerPrefs.GetInt(txt) == 1;
            else{
                value = false;
                SaveConfig(txt,false);
            }
        }
        #endregion
        #endregion
    }
}
