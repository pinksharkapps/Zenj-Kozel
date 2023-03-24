using System;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

namespace Kozel
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]

    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        // public KozelSettings TextColor;
        public KozelSettings kozelSettings;
        public GameInstaller.Settings GameInstaller;
        public AudioManager.Settings AudioSettings;
       // public CountField.Settings CountFieldSettings;

        // ----------------------------

        [Serializable]
        public class KozelSettings
        {
            public CountField.ColorEnum Color;
            public KozelController.Settings Settings;
        }


        public override void InstallBindings()
        {
            Container.BindInstance(kozelSettings.Color);
            Container.BindInstance(kozelSettings.Settings);
            //Container.BindInstance(CountField);
            Container.BindInstance(GameInstaller);
            Container.BindInstance(AudioSettings);
        }
        
    }
}