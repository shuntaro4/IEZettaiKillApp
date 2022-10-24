using IEZettaiKillApp.Core.Infrastructure.Interfaces;

namespace IEZettaiKillApp.Core.Infrastructure
{
    public class SystemSound : ISystemSound
    {
        public enum MessageBeepType : int
        {
            SimpleBeep = -1,
            MB_OK = 0x00,
            MB_ICONHAND = 0x10,
            MB_ICONQUESTION = 0x20,
            MB_ICONEXCLAMATION = 0x30,
            MB_ICONASTERISK = 0x40,
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int MessageBeep(MessageBeepType uType);
        public void Beep()
        {
            try
            {
                _ = MessageBeep(MessageBeepType.MB_ICONHAND);
            }
            catch
            {
                // 無視
            }
        }
    }
}
