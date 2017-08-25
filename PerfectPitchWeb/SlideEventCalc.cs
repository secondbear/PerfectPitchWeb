using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerfectPitchWeb
{
    /// <summary>
    /// Eventhandler for sliders
    /// </summary>
    public class SlideEventCalc:EventArgs
    {
        private float distance;
        private float pitch;
        private float modulationfactor;
        private float gp;
        private string fw;
        //calculate class
        CalculatePitch calcPitch;

        public SlideEventCalc(float dist, float mfact, float block, float dose, string fwidth)
        {
            distance = dist;
            calcPitch = new CalculatePitch(distance, mfact, block, dose, fwidth);
            pitch = calcPitch.Pitch;
            modulationfactor = calcPitch.Mf;
            gp = calcPitch.Gp;
            fw = fwidth;

        }


        public float Distance { get { return distance; } }
        public float Pitch { get { return pitch; } }
        public float ModulationFactor { get { return modulationfactor; } }
        public float Gp { get { return gp; } }
    }
}