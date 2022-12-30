using WindowsInput.Native;

namespace OnDeathReplay
{
    public class OnDeathReplayConfiguration
    {
        public string LogFilePath { get; set; }
        public int Delay_ms { get; set; }
        public VirtualKeyCode[] KeyModifiers { get; set; }
        public VirtualKeyCode[] Keys { get; set; }
    }
}
