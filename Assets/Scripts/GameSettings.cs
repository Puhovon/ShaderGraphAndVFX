using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "gameSettings", menuName = "create game settings")]
    public class GameSettings : ScriptableObject
    {
        public int mode;
        public int enemies;
        public int civilians;
        public int raids;
    }
}