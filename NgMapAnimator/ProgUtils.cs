using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NgMapAnimator
{
    public class ProgUtils
    {
        private const string VDUB_SETTINGS = "App_data/vdub-settings.vdscript";
        public const string VirtualDubExecutable = "VirtualDub";

        public static string GetFileFromThisAppDirectory(string subpath)
        {
            return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), subpath);
        }

        public static void OpenVirtualDubForImgSequence(string firstFrameJpg)
        {
            var settingsScriptPath = GetFileFromThisAppDirectory(VDUB_SETTINGS);
            Process process = new Process();
            process.StartInfo.FileName = VirtualDubExecutable;
            process.StartInfo.Arguments = String.Format("/s \"{0}\" \"{1}\"", settingsScriptPath, firstFrameJpg);
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start();
        }
    }
}
