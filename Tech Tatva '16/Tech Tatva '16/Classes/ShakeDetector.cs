using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Sensors;

namespace Tech_Tatva__16.Classes
{
    class ShakeDetector
    {
        public event EventHandler Shaken;
        Timer _timer;
        protected static ShakeDetector _instance = new ShakeDetector();
        double _lastX;
        double _lastY;
        double _lastZ;
        double _currentX;
        double _currentY;
        double _currentZ;

        bool _bFirstUpdate;
        bool _bShake;

        protected void OnShaken(EventArgs e)
        {

            if (Shaken != null)
            {
                Shaken(this, e);
            }
        }

        protected ShakeDetector()
        {
            Interval = 200;
            Threshold = 3.00f;
            _bShake = false;
            _bFirstUpdate = true;
        }

        public static ShakeDetector Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Interval that we will use for shake.  Should probably not be > 200ms
        /// </summary>
        public int Interval { get; set; }
        /// <summary>
        /// Force threshold to trigger Shaken event off of 
        /// </summary>
        public double Threshold { get; set; }

        /// <summary>
        /// Called to start monitoring for Shake Events.  Attach an event handler to shaken event before calling
        /// </summary>
        public void Start()
        {
            //  Set up timer for interval
            _timer = new Timer(IntervalTimer_Task, null, 0, Interval);


        }

        /// <summary>
        /// Called to stop monitoring and Firing Shake Events.
        /// </summary>
        public void Stop()
        {
            //  Stop the timer
            _timer.Dispose();
            _timer = null;

            _bFirstUpdate = true;
        }

        private void UpdateAccelerometerValues(double x, double y, double z)
        {
            if (_bFirstUpdate)
            {
                _lastX = x;
                _lastY = y;
                _lastZ = z;
                _bFirstUpdate = false;
            }
            else
            {
                _lastX = _currentX;
                _lastY = _currentY;
                _lastZ = _currentZ;
            }

            _currentX = x;
            _currentY = y;
            _currentZ = z;

        }

        private bool CheckAccelerationChanged()
        {
            double xChange = Math.Abs(_lastX - _currentX);
            double yChange = Math.Abs(_lastY - _currentY);
            double zChange = Math.Abs(_lastZ - _currentZ);

            // Debug.WriteLine("Accel: {0}", xChange+yChange+zChange);

            if (xChange + yChange + zChange > Threshold)
                return true;

            return false;

        }

        private void IntervalTimer_Task(object state)
        {
            AccelerometerReading current = Accelerometer.GetDefault().GetCurrentReading();
            DateTimeOffset now = current.Timestamp;

            UpdateAccelerometerValues(current.AccelerationX, current.AccelerationY, current.AccelerationZ);

            //   Check and raise Shake
            if ((!_bShake) && CheckAccelerationChanged())
            {
                _bShake = true;
            }
            else if ((_bShake) && CheckAccelerationChanged())
            {
                _bFirstUpdate = true;  //  Reset Detection
                OnShaken(new EventArgs());
            }
            else if ((_bShake) && (!CheckAccelerationChanged()))
            {
                _bShake = false;
            }

        }

    }
}
