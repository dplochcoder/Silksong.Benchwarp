using UnityEngine;
using UnityEngine.UI;

namespace Benchwarp.Components
{
    [RequireComponent(typeof(Text))]
    public class AutoLocalizeModdedText : MonoBehaviour
    {
        public string? Key
        {
            get;
            set
            {
                field = value;
                RefreshText();
            }
        }
        public Text? text;

        private void Awake()
        {
            if (!text) text = GetComponent<Text>();
        }

        private void Start()
        {
            GameManager.instance.RefreshLanguageText += RefreshText;
        }

        private void OnDestroy()
        {
            GameManager.instance.RefreshLanguageText -= RefreshText;
        }

        private void RefreshText()
        {
            if (text && !string.IsNullOrEmpty(Key)) text.text = Key.GetLanguageString();
        }

    }
}
