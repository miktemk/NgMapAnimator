using NgMapAnimator.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NgMapAnimator
{
    public partial class AnimatorWindow : Form
    {
        private AnimSettings config;

        public AnimatorWindow()
        {
            config = new AnimSettings
            {
                DebugJsonFile = @"C:\Users\Mikhail\Documents\GitHub\js\ng-map\map-myselfasiam.json",
                FullResImageFolder = @"C:\Users\Mikhail\Pictures\map\3-painted",
                Commands = @"europe
italy
italy-center
toscana
toscana-maremma
FINISH-POINT:45,30,Orbetello",
                //FinishImageFilename = @"C:\Users\Mikhail\Pictures\2015_04_20_italy_south_trip\204_0512-barumini\barumini-drawing-signed.jpg",
                FinishImageFilename = @"C:\Users\Mikhail\Pictures\2015_02_italia\.vidkacompile\frame-99f80d0d3f1e4988a00219fcdf064e77.jpg",
                OutputFolder = @"C:\Users\Mikhail\Documents\GitHub\js\ng-map\___animtest",
                OutputWidth = 1280,
                OutputHeight = 720,
                ZoomFactor = 3,
                ZoomFactorFinish = 8,
                ZoomToCenter = false,
                FramesEachMap = 20,
                FramesFadeTransition = 10,
                FramesHoldLastImage = 60,
                OffsetX = 2,
                OffsetY = 1,
            };
            InitializeComponent();
        }

        public NgMapObj[] NgMaps { get; set; }
        public string FinishImageFilename { get; private set; }

        #region ---------------- events and shit --------------------

        private void Form1_Load(object sender, EventArgs e)
        {
            mapImmitatorControl.MapChanged += mapImmitatorControl_MapChanged;
            if (!String.IsNullOrEmpty(config.DebugJsonFile))
                LoadJsonFile(config.DebugJsonFile);
            FinishImageFilename = config.FinishImageFilename;
            pictureBoxFinishing.ImageLocation = config.FinishImageFilename;
            txtOutputFolder.Text = config.OutputFolder;

            WinformUtils.BindTextArea(txtCommands,
                () => { return config.Commands; },
                (sss) => { config.Commands = sss.Trim(); });
            WinformUtils.BindTextField(txtFolderFullRes,
                () => { return config.FullResImageFolder; },
                (sss) => { config.FullResImageFolder = sss; });
            WinformUtils.MakeTextFieldNumeric(txtZoomF);
            WinformUtils.BindTextField(txtZoomF,
                () => { return config.ZoomFactor; },
                (sss) => { config.ZoomFactor = Utils.ParseThisDouble(sss, 2); });
            WinformUtils.MakeTextFieldNumeric(txtZoomFinish);
            WinformUtils.BindTextField(txtZoomFinish,
                () => { return config.ZoomFactorFinish; },
                (sss) => { config.ZoomFactorFinish = Utils.ParseThisDouble(sss, 2); });
            WinformUtils.MakeTextFieldNumeric(txtOffsetX);
            WinformUtils.BindTextField(txtOffsetX,
                () => { return config.OffsetX; },
                (sss) => { config.OffsetX = Utils.ParseThisDouble(sss, 0); });
            WinformUtils.MakeTextFieldNumeric(txtOffsetY);
            WinformUtils.BindTextField(txtOffsetY,
                () => { return config.OffsetY; },
                (sss) => { config.OffsetY = Utils.ParseThisDouble(sss, 0); });
            WinformUtils.MakeTextFieldNumeric(txtHoldFirst);
            WinformUtils.BindTextField(txtHoldFirst,
                () => { return config.FramesHoldFirstFrame; },
                (sss) => { config.FramesHoldFirstFrame = Utils.ParseThisInt(sss, 0); });
            WinformUtils.MakeTextFieldNumeric(txtHoldLast);
            WinformUtils.BindTextField(txtHoldLast,
                () => { return config.FramesHoldLastImage; },
                (sss) => { config.FramesHoldLastImage = Utils.ParseThisInt(sss, 0); });
        }

        private void mapImmitatorControl_MapChanged(string mapId)
        {
            txtCommands.AppendText(mapId + "\n");
        }

        private void txtFolder_TextChanged(object sender, EventArgs e)
        {
            mapImmitatorControl.ImageFolderRelativePath = txtFolder.Text;
            txtFolderFullRes.Text = txtFolder.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filename = LoadWithDialog("JSON files (*.json)|*.json");
            if (filename != null)
                LoadJsonFile(filename);
        }

        private void LoadJsonFile(string jsonFilename)
        {
            lblJsonFile.Text = Path.GetFileName(jsonFilename);
            NgMaps = JsonMapClasses.LoadMapJson(jsonFilename);
            txtFolder.Text = Path.GetDirectoryName(jsonFilename);
            mapImmitatorControl.setParticulars(NgMaps, txtFolder.Text);
            mapImmitatorControl.Invalidate();
        }

        private void btnLoadFinishImage_Click(object sender, EventArgs e)
        {
            var filename = LoadWithDialog("Image files|*.jpg;*.png;*.gif;*.bpm");
            if (filename != null)
            {
                FinishImageFilename = filename;
                pictureBoxFinishing.ImageLocation = filename;
            }
        }

        private void chkReverse_CheckedChanged(object sender, EventArgs e)
        {
            config.Reverse = chkReverse.Checked;
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            var renderer = new NgMapAnimationRenderer()
            {
                NgMaps = NgMaps,
                FullResImageFolder = config.FullResImageFolder,
                Commands = config.Commands,
                FinishImageFilename = FinishImageFilename,
                OutputFolder = txtOutputFolder.Text,
                OutputWidth = config.OutputWidth,
                OutputHeight = config.OutputHeight,
                ZoomFactor = config.ZoomFactor,
                ZoomFactorFinish = config.ZoomFactorFinish,
                ZoomToCenter = config.ZoomToCenter,
                FramesEachMap = config.FramesEachMap,
                FramesFadeTransition = config.FramesFadeTransition,
                FramesHoldFirstFrame = config.FramesHoldFirstFrame,
                FramesHoldLastImage = config.FramesHoldLastImage,
                OffsetX = config.OffsetX,
                OffsetY = config.OffsetY,
                Reverse = config.Reverse,
            };
            renderer.OnProgress += (status) =>
            {
                InvokeOrNot_IDontGiveAShit_JustDoIt(() =>
                {
                    lblStatus.Text = status;
                });
            };
            new Thread(() =>
            {
                renderer.Render();
                ProgUtils.OpenVirtualDubForImgSequence(renderer.FirstFrameFilename);
            }).Start();
        }

        #endregion

        #region ---------------- helpers --------------------

        private string LoadWithDialog(string filter)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = filter;
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK)
                return null;
            return dialog.FileName;
        }

        private void InvokeOrNot_IDontGiveAShit_JustDoIt(Action func)
        {
            if (InvokeRequired)
            {
                if (IsDisposed)
                    return;
                Invoke(new MethodInvoker(func));
                return;
            }
            func();
        }

        #endregion

    }
}
