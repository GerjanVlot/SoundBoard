using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioDashboard.Common;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using SharpDX.DirectSound;

namespace AudioDashboard
{
    public partial class MainForm : Form
    {
        private AudioPipeline _audioPipeline;
        private string[] _files;
        private bool[] _isPlaying;
        private readonly AppConfig _config;
        private bool _initialized;

        public MainForm()
        {
            InitializeComponent();

            Keyboard.Instance.KeyPress += KeyBoard_KeyPress;

            _config = AppConfig.Load("app.json");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < WaveOut.DeviceCount; i++)
            {
                var cap = WaveOut.GetCapabilities(i);
                cmbOutput.Items.Add(cap.ProductName);
            }

            for (var i = 0; i < WaveOut.DeviceCount; i++)
            {
                var cap = WaveOut.GetCapabilities(i);
                cmbSpeaker.Items.Add(cap.ProductName);
            }

            for (var i = 0; i < WaveIn.DeviceCount; i++)
            {
                var cap = WaveIn.GetCapabilities(i);
                cmbInput.Items.Add(cap.ProductName);
            }

            cmbOutput.SelectedIndex = _config.OutputDevice;
            cmbSpeaker.SelectedIndex = _config.SpeakerDevice;
            cmbInput.SelectedIndex = _config.InputDevice;

            cbPlayOnSpeaker.Checked = _config.PlayOnSpeaker;

            _files = Directory.GetFiles("Sounds/");
            _isPlaying = new bool[WaveOut.DeviceCount];

            _initialized = true;
        }

        private void Play(string file, int device = 0)
        {
            if (_isPlaying[device]) return;

            _isPlaying[device] = true;

            var waveProvider = new AudioFileReader(file);

            var waveOut = new WaveOut { DeviceNumber = device };
            waveOut.Init(waveProvider);
            waveOut.Play();

            waveOut.PlaybackStopped += (o, args) =>
            {
                _isPlaying[device] = false;
                waveOut.Dispose();
            };
        }

        private void KeyBoard_KeyPress(object sender, KeyEventArgs e)
        {
            var keyMapping = new Dictionary<Keys, Func<string>>()
            {
                { Keys.NumPad0, () => _files[0] },
                { Keys.NumPad1, () => _files[1] },
                { Keys.NumPad2, () => _files[2] },
                { Keys.NumPad3, () => _files[3] },
                { Keys.NumPad4, () => _files[4] },
                { Keys.NumPad5, () => _files[5] },
                { Keys.NumPad6, () => _files[6] },
                { Keys.NumPad7, () => _files[7] },
                { Keys.NumPad8, () => _files[8] },
                { Keys.NumPad9, () => _files[9] },
            };

            if (!keyMapping.ContainsKey(e.KeyCode)) return;

            Play(keyMapping[e.KeyCode](), _config.OutputDevice);

            if (_config.PlayOnSpeaker)
            {
                Play(keyMapping[e.KeyCode](), _config.SpeakerDevice);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _audioPipeline?.Dispose();

            _audioPipeline = new AudioPipeline()
                .AddInput(new WaveIn() { DeviceNumber = _config.InputDevice })
                .AddProvider(p => new SmbPitchShiftingSampleProvider(p, 1024, 10L, 0.7f))
                .AddProvider(p => new VolumeSampleProvider(p) { Volume = 2f })
                .AddOutput(new WaveOut() { DeviceNumber = _config.OutputDevice });

            _audioPipeline.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _audioPipeline?.Stop();
        }

        #region Change Events

        private void cmbInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _config.InputDevice = cmbOutput.SelectedIndex;
        }

        private void cbPlayOnSpeaker_CheckedChanged(object sender, EventArgs e)
        {
            if (!_initialized) return;
            
            _config.PlayOnSpeaker = !_config.PlayOnSpeaker;
        }

        private void cmbSpeaker_SelectedIndexChanged(object sender, EventArgs e)
        {
            _config.SpeakerDevice = cmbSpeaker.SelectedIndex;
        }

        private void cmbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _config.OutputDevice = cmbOutput.SelectedIndex;
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Keyboard.Instance.Dispose();
            _audioPipeline?.Dispose();
        }
    }
}
