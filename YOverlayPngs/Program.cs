using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOverlayPngs
{
    class Program
    {
        public Program()
        {
            //================= settings ==================
            var folder1 = @"C:\Users\Mikhail\Documents\GitHub\js\ng-map\___animtest";
            var folder2 = @"C:\Users\Mikhail\Videos\travel\plane_pngs";
            var folderOut = @"C:\Users\Mikhail\Documents\GitHub\js\ng-map\___animtest2";
            var doOutputUnaffectedImages = true; // set to false, if there are too many images and you don't wanna crap up the system
            var frameStart1 = 102;
            var frameEnd1 = -1; // here 1 takes priority
            var frameStart2 = 35;
            var frameEnd2 = -1;
            double frameRate2RelativeTo1 = 0.5;
            var loop2 = false; // currently not supported
            var destW = 450; // 280
            var destH = destW * 175 / 280; // 175
            var destX = 1280-destW-60;
            var destY = 10;
            

            //================= do the shit ==================
            var files1 = Utils.GetFrameFiles(folder1);
            var files2 = Utils.GetFrameFiles(folder2);
            if (frameEnd1 < 0)
                frameEnd1 = files1.Length - 1;
            if (frameEnd2 < 0)
                frameEnd2 = files2.Length - 1;
            Utils.MakeSureFolderExists(folderOut);

            for (int i = 0; i < frameEnd1; i++)
            {
                var filename1 = Path.GetFileName(files1[i]);
                var outFilename = Path.Combine(folderOut, filename1);
                var i2 = (int)((i - frameStart1) * frameRate2RelativeTo1) + frameStart2;
                
                if (i >= frameStart1 && i <= frameEnd1 && i2 <= frameEnd2)
                {
                    Image img2 = Image.FromFile(files2[i2]);
                    Bitmap image = (Bitmap)Bitmap.FromFile(files1[i]);
                    Graphics ggg = Graphics.FromImage(image);
                    //ggg.DrawImage(img2, rectDest2, rectSrc2.X, rectSrc2.Y, rectSrc2.Width, rectSrc2.Height, GraphicsUnit.Pixel);
                    ggg.DrawImage(img2, destX, destY, destW, destH);
                    image.Save(outFilename, ImageFormat.Jpeg);
                    img2.Dispose();
                    image.Dispose();
                }
                else
                {
                    if (doOutputUnaffectedImages)
                        File.Copy(files1[i], outFilename, true);
                }
            }

            // ... and preview this shit in vdub
            var filesOut = Utils.GetFrameFiles(folderOut);
            Utils.OpenVirtualDubForImgSequence(filesOut.FirstOrDefault());
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
