using NgMapAnimator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZConsoleApplication
{
    class Program
    {
        public Program()
        {
            var NgMaps = JsonMapClasses.LoadMapJson(@"C:\Users\Mikhail\Documents\GitHub\js\ng-map\map-myselfasiam.json");
            var renderer = new NgMapAnimationRenderer()
            {
                NgMaps = NgMaps,
                FullResImageFolder = @"C:\Users\Mikhail\Documents\GitHub\js\ng-map",
                Commands = @"world
europe
italy
italy-center
toscana
FINISH-POINT:37.6570485519591,26.6666666666667,Pisa",
                FinishImageFilename = @"C:\Users\Mikhail\Documents\GitHub\js\ng-map\pisa.jpg",
                OutputFolder = @"C:\Users\Mikhail\Documents\GitHub\js\ng-map\___animtest",
                OutputWidth = 1280,
                OutputHeight = 720,
                ZoomFactor = 2.5,
                ZoomFactorFinish = 5,
                ZoomToCenter = false,
                FramesEachMap = 20,
                FramesFadeTransition = 10,
                FramesHoldLastImage = 30
            };
            renderer.Render();
        }


        static void Main(string[] args)
        {
            new Program();
        }
    }
}
