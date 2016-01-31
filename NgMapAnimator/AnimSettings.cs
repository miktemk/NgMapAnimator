using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgMapAnimator
{
    public class AnimSettings
    {
        public string FullResImageFolder { get; set; }
        public string Commands { get; set; }
        public string FinishImageFilename { get; set; }
        public int ArgbBackgroundColor { get; set; }
        public string OutputFolder { get; set; }
        public int OutputWidth { get; set; }
        public int OutputHeight { get; set; }
        public double ZoomFactor { get; set; }
        public double ZoomFactorFinish { get; set; }
        public bool ZoomToCenter { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
        public int FramesEachMap { get; set; }
        public int FramesFadeTransition { get; set; }
        public int FramesHoldFirstFrame { get; set; }
        public int FramesHoldLastImage { get; set; }
        public string DebugJsonFile { get; set; }
        public bool Reverse { get; set; }
    }
}
