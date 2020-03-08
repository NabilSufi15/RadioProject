using System;
using System.IO;
using System.Media;
using System.Windows.Media;
using Newtonsoft.Json;

namespace RadioWPFApp
{
    public class Radio
    {
        private int _channel = 1;
        private bool _on = false;
        private double _volume = 0.5;
        MediaPlayer _player = new MediaPlayer();
        private string path = @"C:\Users\Tech-W148Bir\source\repos\RadioWPF\Channel.json";

        public int Channel
        {
            get { return _channel; }
            set
            {
                if (value >= 1 && value <= 4 && _on == true)
                {
                    _channel = value;
                }
            }
        }
        
        public int StoreChannel
        {
            get { return _channel; }
            set {
                if (value >= 1 && value <= 4)
                {
                    _channel = value;
                }
            }
        }
        
        public double Volume
        {

            get { return _player.Volume = _volume; }
            set
            {
                if (value >= 0.0 && value <= 1.0)
                {
                    _volume = value;
                }
            }
        }


        public string Play()
        {
            string r = "";

            if (_on == true)
            {
                r = $"Playing channel {_channel}";
            }
            else if (_on == false)
            {
                r = "Radio is off";
            }
            return r;
        }

        public void TurnOff()
        {
            _on = false;
            Console.WriteLine("Radio is off");
        }

        public void TurnOn()
        {
            _on = true;
            Console.WriteLine("Radio is on");
        }
        
        public void Write()
        {
            _channel = StoreChannel;
            _volume = Volume;
            //_on = RadioState;
            string output = JsonConvert.SerializeObject(this);

            File.WriteAllText(path, output);

            Console.WriteLine(output);
        }
        
        public void Read()
        {
            string radioFile = File.ReadAllText(path);
            Radio deserializedRadio = JsonConvert.DeserializeObject<Radio>(radioFile);

            StoreChannel = deserializedRadio.StoreChannel;
            Volume = deserializedRadio.Volume;
            //RadioState = deserializedRadio.RadioState;
        } 

        public void Clip1()
        {
            if(_on == true)
            { 
                _player.Open(new Uri(@"http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1_mf_p", UriKind.RelativeOrAbsolute));
                //_player.Volume = Volume;
                _player.Play();
            }
            
        }

        public void Clip2()
        {
            if (_on == true)
            {
                _player.Open(new Uri(@"http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio2_mf_p", UriKind.RelativeOrAbsolute));
                _player.Play();
            }
        }

        public void Clip3()
        {
            if (_on == true)
            {
                _player.Open(new Uri(@"http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio4fm_mf_p", UriKind.RelativeOrAbsolute));
                _player.Play();
            }
        }

        public void Clip4()
        {
            _player.Open(new Uri(@"C:/Users/Tech-W148Bir/source/repos/RadioWPF/RadioWPFApp/Assets/", UriKind.RelativeOrAbsolute));
            _player.Play();
        }

        public void StopRadio()
        {
            _player.Stop();
        }
    }
    // implement a class Radio that corresponds to the Class diagram 
    //   and specification in the INSTRUCTIONS document in this solution   
}