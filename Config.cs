using System;

namespace XamarinLearnins
{
    public class Config
    {
        public Color BladeColor { get; set; }
        public List<Color> ClashColors { get; set; }
        public Sound HumSound { get; set; }
        public List<Sound> SwingSounds { get; set; }
        public List<Sound> ClashSounds { get; set; }
    }

    public class Color
    {
        public string Name { get; set; }
        public string RGBCode { get; set; }
    }

    public class Sound
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public byte[] SoundBytes { get; set; }
    }
}