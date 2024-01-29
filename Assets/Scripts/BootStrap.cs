using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class BootStrap : MonoBehaviour
    {
        public GameSettings config;
        [SerializeField] private int integ;

        private void Start()
        {
            print("Selected config: " + config.name);
        }
    }
}