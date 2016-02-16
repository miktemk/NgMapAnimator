using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Miktemk;

namespace NgMapAnimator.Core
{
    public class NgMapAnimationRenderer
    {
        public NgMapAnimationRenderer()
        { }

        public NgMapObj[] NgMaps { get; set; }
        public string FullResImageFolder { get; set; }
        public string Commands { get; set; }
        public string FinishImageFilename { get; set; }
        public int ArgbBackgroundColor { get; set; }
        public string OutputFolder { get; set; }
        public int OutputWidth { get; set; }
        public int OutputHeight { get; set; }
        public double ZoomFactor { get; set; }
        public double ZoomFactorFinish { get; set; }
        public int FramesEachMap { get; set; }
        public int FramesFadeTransition { get; set; }
        public int FramesHoldFirstFrame { get; set; }
        public int FramesHoldLastImage { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
        public bool Reverse { get; set; }

        /// <summary>
        /// if true: we go into rect and it is centered at (x, y)
        /// if false: we go into rect and (x, y) takes on the same relative position as within the parent rect
        /// </summary>
        public bool ZoomToCenter { get; set; }
        private long totalFrames;
        private long curFrame;

        #region events
        public delegate void OnProgress_Handler(string status);
        public event OnProgress_Handler OnProgress;
        #endregion

        public void Render()
        {
            if (OnProgress != null)
                OnProgress("Render starts...");
            var mapsIds = Commands.Split(new [] {"\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Where(x => !String.IsNullOrEmpty(x))
                .ToArray();
            totalFrames = (mapsIds.Length - 1) * FramesEachMap + FramesHoldLastImage + FramesHoldFirstFrame;
            curFrame = 0;
            var mapFirst = NgMaps.FirstOrDefault(x => x.id == mapsIds[0]);
            var imgFirstFilename = GetImageFileForMap(mapFirst);
            GenerateHoldImage(imgFirstFilename, FramesHoldFirstFrame);
            for (int i = 0; i < mapsIds.Length-1; i++)
            {
                var map1 = NgMaps.FirstOrDefault(x => x.id == mapsIds[i]);
                var imgPath = GetImageFileForMap(map1);
                var id2 = mapsIds[i + 1];
                if (id2.StartsWith("FINISH-POINT"))
                {
                    Regex parseFinishPoint = new Regex("FINISH-POINT:(\\d*\\.?\\d+),(\\d*\\.?\\d+)");
                    var matchZoomPoint = parseFinishPoint.Match(id2);
                    if (!matchZoomPoint.Success)
                        throw new Exception("Cannot parse finish point: " + id2);
                    var x = matchZoomPoint.Groups[1].Value.ParseDoubleOrDefault();
                    var y = matchZoomPoint.Groups[2].Value.ParseDoubleOrDefault();
                    GenerateTransition(imgPath, FinishImageFilename, FramesEachMap, FramesFadeTransition, x, y, ZoomFactorFinish);
                }
                else
                {
                    var map2 = NgMaps.FirstOrDefault(x => x.id == id2);
                    var imgPath2 = GetImageFileForMap(map2);
                    var pointOnMap1 = map1.points.FirstOrDefault(x => x.href == id2);
                    GenerateTransition(imgPath, imgPath2, FramesEachMap, FramesFadeTransition, pointOnMap1.x, pointOnMap1.y, ZoomFactor);
                }
            }
            // ... hold last image ???
            var lastId = mapsIds.LastOrDefault();
            var lastImgFilename = lastId.StartsWith("FINISH-POINT")
                ? FinishImageFilename
                : Path.Combine(FullResImageFolder, NgMaps.FirstOrDefault(x => x.id == lastId).img);
            GenerateHoldImage(lastImgFilename, FramesHoldLastImage);
            if (OnProgress != null)
                OnProgress("Render complete.");
        }

        private void GenerateHoldImage(string imgHoldFilename, int howManyFrames)
        {
            if (howManyFrames == 0)
                return;
            var imgHold = Image.FromFile(imgHoldFilename);
            Rectangle rectSrc1 = new Rectangle(0, 0, imgHold.Width, imgHold.Height);
            Rectangle rectDest1 = new Rectangle(0, 0, OutputWidth, OutputHeight);
            for (int frame = 0; frame < howManyFrames; frame++)
            {
                Bitmap image = new Bitmap(OutputWidth, OutputHeight);
                Graphics ggg = Graphics.FromImage(image);
                ggg.FillRectangle(new SolidBrush(Color.FromArgb(ArgbBackgroundColor)), 0, 0, OutputWidth, OutputHeight);
                ggg.DrawImage(imgHold, rectDest1, rectSrc1, GraphicsUnit.Pixel);
                curFrame++;
                var outFilename = GetOutFilename(curFrame);
                if (OnProgress != null)
                    OnProgress("saving frame " + curFrame);
                image.Save(outFilename, ImageFormat.Jpeg);
            }
        }

        private string GetImageFileForMap(NgMapObj map)
        {
            return Path.Combine(FullResImageFolder, Path.GetFileName(map.img));
        }

        private void GenerateTransition(string imgPath, string imgPath2, int framesTotal, int framesImg2, double x, double y, double zoomFactor)
        {
            // .. adjustr (x,y) with offsets

            x += OffsetX;
            y += OffsetY;
            var img1 = Image.FromFile(imgPath);
            var img2 = Image.FromFile(imgPath2);

            Rectangle rectSrc1 = new Rectangle(0, 0, img1.Width, img1.Height);
            Rectangle rectDest1 = new Rectangle(0, 0, OutputWidth, OutputHeight);
            Rectangle rectSrc2 = new Rectangle(0, 0, img2.Width, img2.Height);
            Rectangle rectDest2 = new Rectangle(0, 0, OutputWidth, OutputHeight);
            // ... finishing rect for dest1
            var rectDest1_w2 = zoomFactor * rectDest1.Width;
            var rectDest1_h2 = zoomFactor * rectDest1.Height;
            var rectDest1_x2 = (1 - zoomFactor) * x * rectDest1.Width / 100;
            var rectDest1_y2 = (1 - zoomFactor) * y * rectDest1.Height / 100;
            // ... starting rect for dest2
            var rectDest2_w1 = rectDest2.Width / zoomFactor;
            var rectDest2_h1 = rectDest2.Height / zoomFactor;
            double rectDest2_x1, rectDest2_y1;
            if (ZoomToCenter)
            {
                // ... option 1: we go into rect and it is centered at (x, y)
                rectDest2_x1 = x * rectDest2.Width / 100 - rectDest2_w1 / 2;
                rectDest2_y1 = y * rectDest2.Height / 100 - rectDest2_h1 / 2;
            }
            else
            {
                // ... option 2: we go into rect and (x, y) takes on the same relative position as within the parent rect
                rectDest2_x1 = (1 - 1/zoomFactor) * x * rectDest2.Width / 100;
                rectDest2_y1 = (1 - 1/zoomFactor) * y * rectDest2.Height / 100;
            }
            
            ColorMatrix cm = new ColorMatrix();
            cm.Matrix33 = 0.55f;
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm);

            for (int frame = 0; frame < framesTotal; frame++)
            {
                float progressTotal = (float)frame / framesTotal;
                float progressImg2 = (float)(frame - framesTotal + framesImg2) / framesImg2;

                rectDest1.X = (int)UtilsMath.LinearX(0, rectDest1_x2, progressTotal);
                rectDest1.Y = (int)UtilsMath.LinearX(0, rectDest1_y2, progressTotal);
                rectDest1.Width = (int)UtilsMath.LinearX(OutputWidth, rectDest1_w2, progressTotal);
                rectDest1.Height = (int)UtilsMath.LinearX(OutputHeight, rectDest1_h2, progressTotal);

                rectDest2.X = (int)UtilsMath.LinearX(rectDest2_x1, 0, progressTotal);
                rectDest2.Y = (int)UtilsMath.LinearX(rectDest2_y1, 0, progressTotal);
                rectDest2.Width = (int)UtilsMath.LinearX(rectDest2_w1, OutputWidth, progressTotal);
                rectDest2.Height = (int)UtilsMath.LinearX(rectDest2_h1, OutputHeight, progressTotal);

                Bitmap image = new Bitmap(OutputWidth, OutputHeight);
                Graphics ggg = Graphics.FromImage(image);
                ggg.FillRectangle(new SolidBrush(Color.FromArgb(ArgbBackgroundColor)), 0, 0, OutputWidth, OutputHeight);

                ggg.DrawImage(img1, rectDest1, rectSrc1, GraphicsUnit.Pixel);
                if (progressImg2 >= 0)
                {
                    cm.Matrix33 = progressImg2;
                    ia.SetColorMatrix(cm);
                    ggg.DrawImage(img2, rectDest2, rectSrc2.X, rectSrc2.Y, rectSrc2.Width, rectSrc2.Height, GraphicsUnit.Pixel, ia);
                }
                curFrame++;
                var outFilename = GetOutFilename(curFrame);
                if (OnProgress != null)
                    OnProgress("saving frame " + curFrame);
                image.Save(outFilename, ImageFormat.Jpeg);
            }
        }

        private string GetOutFilename(long frame)
        {
            var frameInFilename = Reverse ? totalFrames - frame + 1 : frame;
            return GetFrameFilename(frameInFilename);
        }

        private string GetFrameFilename(long frame)
        {
            return Path.Combine(OutputFolder, String.Format("frame_{0:D4}.jpg", frame));
        }


        public string FirstFrameFilename {
            get { return GetFrameFilename(1); }
        }
    }
}
