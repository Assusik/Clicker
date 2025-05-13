using System;
using UnityEngine;

namespace Skripts
{
    [Serializable]
    public struct SpellsData
    {
        public float CastTime;
        public Sprite Sprite;
        public float FearPerCast;
        public float CoolDown;
        public bool IsInterruptible;


    }
}
