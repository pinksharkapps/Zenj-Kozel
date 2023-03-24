using System;
using System.Collections;
using System.Collections.Generic;
using Kozel.Signals;
using UnityEngine;
using Zenject;

namespace Kozel
{
    
    public class KozelController : MonoBehaviour
    {
        // -----------------------------
        
        [SerializeField] private GameObject _meeeeee;
        
        private Settings _settings; // убрала readonly
        // private readonly SignalBus _signalBus;
        
       
        
        // было: public KozelController( Settings settings, SignalBus signalBus)
        // но нельзя наследоваться от монобеха и иметь конструктор?
        [Inject]
        public void Construct( Settings settings)//SignalBus signalBus
        {
            _settings = settings;
        }
        
        
        public bool isShownMee = false;
        // -----------------------------

        private void Awake()
        {
            setMee(false);

            // РАБОТАЕТ - раскомментить для проверки, что скейл вообще работает:
            // transform.localScale = transform.localScale * 0.5f;
            
            scaleKozel();
        }

        
        //------------ берет скейл козла и скейлит относительно сеттингов
        private void scaleKozel()
        {

            var settingScale = _settings.kozelScale; // получаем скейл из сеттингов
            Debug.Log( $" Получили сеттинг скейла козла - {settingScale}");

            transform.localScale =  transform.localScale * settingScale; // умножаем сеттинги на что есть
        }



        private void OnBtnClick(BtnPressedSignal signal)
        {
            setMee(true);
        }
        
        

        //---- изящное вкл/выкл меее
        public void setMee(bool isShownMee)
        {
            Debug.Log(" Сработало setMee в KozelController ");
            _meeeeee.SetActive(isShownMee);
        }
        

        [Serializable]
        public class Settings
        {
            public float kozelScale;
        }
        
    }
}