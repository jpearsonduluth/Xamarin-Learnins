using System;
using System.Collections.Generic;

namespace XamarinLearnins
{
    public class Config
    {
        public string Name { get; set; }
        public ColorModel BladeColor { get; set; }
        public IEnumerable<ColorModel> ClashColors { get; set; }
        public Sound HumSound { get; set; }
        public IEnumerable<Sound> SwingSounds { get; set; }
        public IEnumerable<Sound> ClashSounds { get; set; }
    }

    public class ColorModel
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
    }

    public class Sound
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public byte[] SoundBytes { get; set; }
    }
}