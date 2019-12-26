using System;
using System.Collections.Generic;

namespace XamarinLearnins
{
    public class Config
    {
        public ColorModel BladeColor { get; set; }
        public List<ColorModel> ClashColors { get; set; }
        public Sound HumSound { get; set; }
        public List<Sound> SwingSounds { get; set; }
        public List<Sound> ClashSounds { get; set; }
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