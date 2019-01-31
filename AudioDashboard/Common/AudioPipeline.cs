using System;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AudioDashboard
{
    public class AudioPipeline : IDisposable
    {
        private WaveIn _waveInput;
        private WaveOut _waveOutput;
        private BufferedWaveProvider _waveProvider;
        private ISampleProvider _currentSampleProvider;

        public AudioPipeline AddInput(WaveIn waveIn)
        {
            _waveInput = waveIn;
            _waveInput.DataAvailable += WaveInputDataAvailable;
            _waveProvider = new BufferedWaveProvider(_waveInput.WaveFormat);
            _currentSampleProvider = new Pcm16BitToSampleProvider(_waveProvider);

            return this;
        }

        public AudioPipeline AddProvider(Func<ISampleProvider, ISampleProvider> sampleProvider)
        {
            _currentSampleProvider = sampleProvider(_currentSampleProvider);

            return this;
        }

        public AudioPipeline AddOutput(WaveOut waveOut)
        {
            _waveOutput = waveOut;
            
            return this;
        }

        public void Start()
        {
            _waveOutput.Init(_currentSampleProvider);
            _waveOutput.Play();
            _waveInput.StartRecording();
        }

        public void Stop()
        {
            _waveOutput.Stop();
            _waveInput.StopRecording();
        }


        private void WaveInputDataAvailable(object sender, WaveInEventArgs e)
        {
            _waveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        public void Dispose()
        {
            _waveInput?.Dispose();
            _waveOutput?.Dispose();
        }
    }
}