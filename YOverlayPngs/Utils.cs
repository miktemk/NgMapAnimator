using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOverlayPngs
{
    public static class Utils
    {
        private static string[] EXT_image = ".jpg|.jpeg|.gif|.bmp|.tiff|.png".Split('|');
        private const string VDUB_SETTINGS = "App_data/vdub-settings.vdscript";
        public const string VirtualDubExecutable = "VirtualDub";


        //==================================================================

        public static string GetFileFromThisAppDirectory(string subpath)
        {
            return Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), subpath);
        }

        public static void MakeSureFolderExists(string dirname)
        {
            if (Directory.Exists(dirname))
                return;
            Directory.CreateDirectory(dirname);
        }
        public static void MakeSureFolderExistsForFile(string filename)
        {
            var dirname = Path.GetDirectoryName(filename);
            MakeSureFolderExists(dirname);
        }
        public static string[] GetFrameFiles(string folder)
        {
            return Directory.GetFiles(folder)
                .Where(f => IsFilenameImage(f))
                .OrderBy(f => f)
                .ToArray();
        }

        private static bool IsFilenameImage(string filename)
        {
            return IsFilenameOneOfThese(filename, EXT_image);
        }
        private static bool IsFilenameOneOfThese(string filename, string[] extensions)
        {
            if (String.IsNullOrEmpty(filename))
                return false;
            var ext = Path.GetExtension(filename).ToLower();
            return extensions.Any(e => String.Equals(e, ext, StringComparison.OrdinalIgnoreCase));
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
