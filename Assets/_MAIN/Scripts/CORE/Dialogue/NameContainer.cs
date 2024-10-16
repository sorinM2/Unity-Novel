using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Dialogue
{
    [System.Serializable]
    public class NameContainer
    {

        [SerializeField] private GameObject root;
        [SerializeField] private TextMeshProUGUI nameText;
        public void Show(string nameToShow = "")
        {
            root.SetActive(true);

            if (nameToShow != "")
                nameText.text = nameToShow;
        }

        public void Hide()
        {
            root.SetActive(false);
        }
    }
}
