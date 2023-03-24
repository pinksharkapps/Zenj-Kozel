using System;
using Kozel.Signals;
using UnityEngine;
using Zenject;

namespace Kozel
{
    public class AudioManager : MonoBehaviour
    {
        private AudioClip _meeSound;
        
        private readonly SignalBus _signalBus;
        private readonly Settings _settings;
        private readonly AudioSource _myAudSource;
        
        
        // стандартный конструктор для сигналбас
        public AudioManager(
            AudioSource myAudSource,
            Settings settings,
            SignalBus signalBus)
        {
            _signalBus = signalBus;
            _settings = settings;
            _myAudSource = myAudSource;
        }
        
        
        public void Initialize()
        {
            _signalBus.Subscribe<BtnPressedSignal>(MeeSound);
        }
        
        
        
        private void MeeSound()
        {
            
            _myAudSource.PlayOneShot(_meeSound);
        }
        
        
        private void MeeOnSignal (BtnPressedSignal signal)
        {
            Debug.Log(" Сработало MeeOnSignal в аудио менеджере ");
            MeeSound();
        }


        private void Dispose()
        {
            _signalBus.Unsubscribe<BtnPressedSignal>(MeeSound);
        }






        [Serializable]
        public class Settings
        {
            public AudioClip _meeSound;
            
            
        }
    }
}