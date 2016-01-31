using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NgMapAnimator.Core;

namespace NgMapAnimator
{
    public partial class MapImmitator : UserControl
    {
        // -------- constants ----------
        private const int DotRadius = 20;
        private Pen penBlack = new Pen(Color.Black, 1);
        private Brush brushWhite = new SolidBrush(Color.White);
        private Brush brushRed = new SolidBrush(Color.Red);
        private Brush brushGreen = new SolidBrush(Color.LightGreen);
        private Brush brushBlack = new SolidBrush(Color.Black);
        private Font fontDefault = SystemFonts.DefaultFont;

        // -------- map ----------
        private NgMapObj curMap;
        private Image curMapImage;
        private NgMapObjPoint curPoint;
        private bool isUpHover = false;

        public MapImmitator()
        {
            InitializeComponent();
        }

        public NgMapObj[] NgMaps { get; private set; }
        public string ImageFolderRelativePath { get; set; }

        #region events
        public delegate void MapChanged_Handler(string mapId);
        public event MapChanged_Handler MapChanged;
        #endregion

        #region --------------- events and shit ------------------------

        public void setParticulars(NgMapObj[] maps, string imgFolder)
        {
            NgMaps = maps;
            ImageFolderRelativePath = imgFolder;
            var rootMapId = maps.FirstOrDefault().id;
            gotoMap(rootMapId);
            // ... fire map changed event for the first time
            if (MapChanged != null)
                MapChanged(rootMapId);
            Invalidate();
        }

        #endregion

        #region --------------- events and shit ------------------------

        private void MapImmitator_Load(object sender, EventArgs e)
        {

        }

        private void MapImmitator_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if (curMap == null)
                return;
            g.DrawImage(curMapImage, 0, 0, Width, Height);
            foreach (var point in curMap.points)
            {
                var x = (float)(Width * point.x / 100);
                var y = (float)(Height * point.y / 100);
                g.FillEllipse((point == curPoint) ? brushGreen : brushRed, x - DotRadius, y - DotRadius, DotRadius * 2, DotRadius * 2);
                var labelSize = g.MeasureString(point.label, fontDefault);
                g.FillRectangle(brushWhite, x + DotRadius + 2, y - labelSize.Height / 2, labelSize.Width + 4, labelSize.Height + 4);
                g.DrawRectangle(penBlack, x + DotRadius + 2, y - labelSize.Height / 2 - 2, labelSize.Width + 4, labelSize.Height + 4);
                g.DrawString(point.label, fontDefault, brushBlack, x + DotRadius + 4, y - labelSize.Height / 2);
            }
            g.FillRectangle(isUpHover ? brushGreen : brushBlack, 10, 10, 80, 50);
            g.DrawString("UP", fontDefault, brushWhite, 25, 20);
        }

        private bool gotoMap(string mapId)
        {
            if (NgMaps == null)
            {
                curMap = null;
                curMapImage = null;
                curPoint = null;
                return false;
            }
            var map2b = NgMaps.FirstOrDefault(x => x.id == mapId);
            if (map2b == null)
                return false;
            curMap = map2b;
            var imgPath = Path.Combine(ImageFolderRelativePath, curMap.img);
            curMapImage = Image.FromFile(imgPath);
            return true;
        }

        #endregion

        private void MapImmitator_MouseMove(object sender, MouseEventArgs e)
        {
            if (curMap == null)
                return;
            curPoint = curMap.points.LastOrDefault(p => IntersectsMouse(p, e));
            isUpHover = (e.X < 90 && e.Y < 60);
            Invalidate();
        }

        private bool IntersectsMouse(NgMapObjPoint point, MouseEventArgs e)
        {
            var x = (float)(Width * point.x / 100);
            var y = (float)(Height * point.y / 100);
            return (e.X >= x - DotRadius && e.X <= x + DotRadius &&
                    e.Y >= y - DotRadius && e.Y <= y + DotRadius);
        }

        private void MapImmitator_MouseUp(object sender, MouseEventArgs e)
        {
            string idMapChange = null;
            if (isUpHover)
                idMapChange = curMap.backLink;
            else if (curPoint != null)
                idMapChange = curPoint.href;
            if (idMapChange == null)
                return;
            var mapGoOk = gotoMap(idMapChange);
            if (!mapGoOk)
                idMapChange = String.Format("FINISH-POINT:{0},{1},{2}", curPoint.x, curPoint.y, curPoint.label);
            // ... fire map changed event for all subsequent clicks
            if (MapChanged != null)
                MapChanged(idMapChange);
            curPoint = null;
        }

        private void MapImmitator_MouseLeave(object sender, EventArgs e)
        {
            curPoint = null;

        }

    }
}
