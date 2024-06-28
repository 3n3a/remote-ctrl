using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace remote_ctrl
{
    public class MediaCtrl
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void keybd_event(uint bVk, uint bScan, uint dwFlags, uint dwExtraInfo);

        private const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        private const int VK_MEDIA_NEXT_TRACK = 0xB0;
        private const int VK_MEDIA_PREV_TRACK = 0xB1;
        private const int VK_MEDIA_STOP = 0xB2;

        private const int VK_VOLUME_DOWN = 0xAE;
        private const int VK_VOLUME_MUTE = 0xAD;
        private const int VK_VOLUME_UP = 0xAF;

        public static void PlayPause()
        {
            keybd_event(VK_MEDIA_PLAY_PAUSE, 0, 0, 0);
        }

        public static void Stop()
        {
            keybd_event(VK_MEDIA_STOP, 0, 0, 0);
        }

        public static void PreviousTrack()
        {
            keybd_event(VK_MEDIA_PREV_TRACK, 0, 0, 0);
        }

        public static void NextTrack()
        {
            keybd_event(VK_MEDIA_NEXT_TRACK, 0, 0, 0);
        }

        public static void VolumeDown()
        {
            keybd_event(VK_VOLUME_DOWN, 0, 0, 0);
        }

        public static void VolumeMute()
        {
            keybd_event(VK_VOLUME_MUTE, 0, 0, 0);
        }

        public static void VolumeUp()
        {
            keybd_event(VK_VOLUME_UP, 0, 0, 0);
        }

    }
}
