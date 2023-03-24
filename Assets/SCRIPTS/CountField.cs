using System;
using System.Security.Cryptography.X509Certificates;
using Kozel.Signals;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Kozel
{
    public class CountField : MonoBehaviour // IInitializable, IDisposable - не катит

    {
        // ---------------- это выносится в Game Settings Inslaller -----------------
        // ---------- но выдает ошибку "ZenjectException: Unable to resolve
        // 'CountField.Settings' while building object with type 'CountField'. Object graph: CountField

        public enum ColorEnum
        {
            None,
            Pink,
            Blue,
            Green,
            Gray
        }

        public ColorEnum currentColor;
        // --------------------------------------


        private TMP_Text _countfield;
        private GameManager _gameManager;
        private SignalBus _signalBus;

        // -------- для  inject -----------------
            private Settings _settings; 

            [Inject]
            public void Construct(  GameManager gameManager, SignalBus signalBus, Settings settings) //SignalBus signalBus, Settings settings
            {
                _settings = settings;
                _gameManager = gameManager;
                _signalBus = signalBus;
            }


    

        private void Awake()
        {
            
            _signalBus.Subscribe<BtnPressedSignal>(CountUpdate);

            // ДА, ОНО РАБОТАЕТ
            // раскомментить для теста что цвет текста меняется:
            // _countfield.color = Color.magenta;

            SetTxtFieldColor();
        }

    

        private void CountUpdate()
        {
            _countfield = FindObjectOfType<TMP_Text>();
            _countfield.text = _gameManager.meeCount.ToString();
        }


        private void SetTxtFieldColor()
        {
            // ############ ???? #############################
            // настройки в Game Settings Inslaller 
            // УВЫ, перезаписываются настройками в текстовом поле которое на сцене :(


            switch (currentColor)
            {
                case ColorEnum.Pink:
                    _countfield.color = Color.magenta;
                    break;
                case ColorEnum.Blue:
                    _countfield.color = Color.blue;
                    break;
                case ColorEnum.Green:
                    _countfield.color = Color.green;
                    break;
                case ColorEnum.Gray:
                    _countfield.color = Color.gray;
                    break;
            }
        }


        public void Dispose()
        {
            _signalBus.Unsubscribe<BtnPressedSignal>(CountUpdate);
        }



        
         [Serializable]
         public class Settings
         {
             private ColorEnum currentColor;
         }
     
     
    }
}