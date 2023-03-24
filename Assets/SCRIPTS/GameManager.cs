using System;
using Kozel.Signals;
using UnityEngine;
using Zenject;

namespace Kozel
{
    public class GameManager : IInitializable, IDisposable // ITickable, 
    {
        public int meeCount = 0;

        private readonly KozelController _kozel;
        readonly SignalBus _signalBus;

       
        // конструктор

        public GameManager(
            SignalBus signalBus, KozelController kozel)
        {
            _signalBus = signalBus;
            _kozel = kozel;
        }


        public void Initialize()
        {
            _signalBus.Subscribe<BtnPressedSignal>(OnKozBtnPressed);
        }


        private void OnKozBtnPressed()
        {
            Debug.Log(" Signal BtnPressedSignal дошел в GM");
            _kozel.setMee(true);
            OneMoreMeee();
        }


        private void OneMoreMeee()
        {
            meeCount++;
        }


        public void Dispose()
        {
            _signalBus.Unsubscribe<BtnPressedSignal>(OnKozBtnPressed);
        }
    }
}