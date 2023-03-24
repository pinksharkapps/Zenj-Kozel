using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kozel
{
    public class GuiController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textfield;
        
        // button вынесли в сигналы
        // было: [SerializeField] private Button _kozelBTN;

        
        // возможно, это файл пока не нужен раз в UI больше ничего нет
        private void SetText(int _showMeeCount)
        {
            _textfield.text = _showMeeCount.ToString();
        }
    }
}
