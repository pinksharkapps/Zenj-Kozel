using System;
using System.ComponentModel;
using Kozel.Signals;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;


namespace Kozel
{
    public class GameInstaller : MonoInstaller
    {
        // [Inject] private Settings _settings = null;

        public override void InstallBindings()
        {
            InstallSignals();
            InstallKozel();
            InstallUtils();
        }

        private void InstallKozel()
        {
            Container.BindInterfacesAndSelfTo<KozelController>().AsSingle();
        }


        private void InstallUtils()
        {
            Container.BindInterfacesTo<AudioManager>().AsSingle();
        }


        public void InstallSignals()
        {
            GameSignalsInstaller.Install(Container);
            Container.DeclareSignal<BtnPressedSignal>();
        }

        // сеттинги в гейминсталлере
        [Serializable]
        public class Settings
        {
            public GameObject KozelPrefab;
        }
        
    }
}