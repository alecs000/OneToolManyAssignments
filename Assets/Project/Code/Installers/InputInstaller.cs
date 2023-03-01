using Assets.Project.Code.Input;
using UnityEngine;
using Zenject;

namespace Assets.Project.Code.Installers
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private MouseInput mouseInputPrefab;
        public override void InstallBindings()
        {
            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            {
                BindMouseInput();
            }
        }

        private void BindMouseInput()
        {
            MouseInput mouseInput = Container.InstantiatePrefabForComponent<MouseInput>(mouseInputPrefab);
            Container.
                Bind<IInputService>()
                .To<MouseInput>()
                .FromInstance(mouseInput)
                .AsSingle();
        }
    }
}