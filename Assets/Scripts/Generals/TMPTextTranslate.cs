using System;
using TMPro;
using UnityEngine;
using World;

namespace Generals
{
    [Serializable]
    [DisallowMultipleComponent]
    public class TMPTextTranslate : MonoBehaviour
    {
        public string id;

        public void Translate()
        {
            var txt = GetComponent<TMP_Text>();
            if(txt != null)
                txt.text = WorldController.Instance.Translate(id);
        }
        private void Start()
        {
            Translate();
        }
    }
}