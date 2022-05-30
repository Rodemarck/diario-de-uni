
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using UnityEngine;

namespace World{
    [DisallowMultipleComponent]
    public class WorldController:MonoBehaviour{
        #region Singleton

        private static WorldController _instance;

        private void Awake()
        {
            Debug.Log("awake???");
            if (_instance != null)
                return;
            Debug.Log("awake!!!");
            ReadLocalizationFile();
            var ci = CultureInfo.InstalledUICulture;
            _lang = ci.Name;
            if (!_translator.ContainsKey(_lang))
                _lang = "en-US";
            _instance = this;
        }

        public static WorldController Instance => _instance;
        #endregion

        #region Localization    
        private void ReadLocalizationFile(){
            var lines = System.IO.File.ReadLines(@"./Assets/Localization/texts.csv");
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
            for (var i = 1; i < colums.Length; i++)
            {
                _supportedLanguages.Add(langs[i-1],colums[i]);
            }
            string identification;
            while (en.MoveNext())
            {
                colums = en.Current.Split(",");
                identification = colums[0];
                for (var i = 1; i < colums.Length; i++)
                {
                    _translator[langs[i - 1]].Add(identification, colums[i]);
                }
            }
        }
        
        private Dictionary<string, Dictionary<string, string>> _translator;
        private Dictionary<string,string> _supportedLanguages;

        public List<string> SupportedLanguages()
        {
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

        #endregion

        public void SetLang(string text)
        {
            _lang = GetLocalizationByLang(text);
            if (!_translator.ContainsKey(_lang))
                _lang = "en-US";
        }
    }
}
