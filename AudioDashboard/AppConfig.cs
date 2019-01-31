using System.IO;
using Newtonsoft.Json;

namespace AudioDashboard
{
    public class AppConfig
    {
        private string _fileName;

        private int _outputDevice;

        private int _speakerDevice;

        private int _inputDevice;

        private bool _playOnSpeaker;

        private AppConfig(string filename)
        {
            _fileName = filename;
        }

        public int OutputDevice
        {
            get => _outputDevice;
            set
            {
                _outputDevice = value;
                Save();
            }
        }

        public int SpeakerDevice
        {
            get => _speakerDevice;
            set
            {
                _speakerDevice = value;
                Save();
            }
        }
        public int InputDevice
        {
            get => _inputDevice;
            set
            {
                _inputDevice = value;
                Save();
            }
        }

        public bool PlayOnSpeaker
        {
            get => _playOnSpeaker;
            set
            {
                _playOnSpeaker = value;
                Save();
            }
        }

        public static AppConfig Load(string filename)
        {
            var cfg = JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText(filename));
            cfg._fileName = filename;
            return cfg;
        }

        public void Save()
        {
            if(_fileName == null) return;
            
            File.WriteAllText(_fileName, JsonConvert.SerializeObject(this));
        }
    }
}