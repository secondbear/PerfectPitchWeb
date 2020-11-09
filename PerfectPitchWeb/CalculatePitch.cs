using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PerfectPitchWeb
{
    public class CalculatePitch
    {
        private float pitch;
        private float distance;
        private float gp;
        private float mf;
        private float block;
        private string fw;
        private float fdose;
        int nearest;
        int secondenearest;

        public float Pitch { get
            {              

                return pitch;
            }


        }
        public float Distance { get; set;}
        public float Gp { get { return gp; } }
        public float Mf { get { return mf; }}
        public float Block { get; set; }
        public string Fw { get; set; }
        public float Fdose { get; set; }
        //tabled value precalc
        List<string> smallFw = new List<string>();
        List<string> largeFW = new List<string>();
        List<string> currentFw = new List<string>();

        Dictionary<int, float> pitchdosenear;
        Dictionary<int, float> pitchdosesec;
        bool endofdist;


        public CalculatePitch(float dist1, float modf, float block1, float fd, string fwidth)
        {
            distance = dist1;
          
            mf = modf;
            block = block1;
            fdose = fd;
            fw = fwidth;

            if (fw == "1.05")
            {
                //calcsmallpitch
                CalcSmallPitch();

            }
            else
            {
                CalcPitch();
            }

        }


        private void CalcSmallPitch()
        {
            pitch = 20 / (mf * (fdose / 4) * 60);
            if (pitch < 0.172) { pitch = (float)0.172; }
            else if (pitch > 0.5) { pitch = (float)0.5; }

            //calc gantry periodGtime = (MF * Pitch * (DosIn / 4)) * 60 in seconds
            float mfactual = (mf > 0.2) ? (mf - (float)0.2) : 0;

            gp = mfactual * pitch * (1 - (block / 100)) * (fdose / 4) * 60;

        }

        /// <summary>
        /// calculates the pitch from user set vals
        /// </summary>
        /// <returns></returns>
        private float CalcPitch() {

            

            AllValues();
            List<int> dist= new List<int> {5,10,15,20 };

            nearest = dist.OrderBy(x => Math.Abs((long)x - distance)).First();
            secondenearest = dist.OrderBy(x => Math.Abs((long)x - distance)).ToList()[1];
            endofdist = false;

            //if at the end of data
            if (Math.Abs(distance - secondenearest) > 5)
            {
                endofdist = true;

            }

            //contaioner for pitch and dose val
            //do a dict
            pitchdosenear = new Dictionary<int, float>();
            pitchdosesec = new Dictionary<int, float>();

            if(fw == "2.5")
            {
                currentFw = smallFw;
            }
            else if(fw == "5.02")
            {
                currentFw = largeFW;
            }

            switch (nearest)
            {

                case 5:
                    calcPitchdose(currentFw, nearest, secondenearest);               
                    break;
                case 10:
                    calcPitchdose(currentFw, nearest, secondenearest);
                    break;
                case 15:
                    calcPitchdose(currentFw, nearest, secondenearest);
                    break;
                case 20:
                    calcPitchdose(currentFw, nearest, secondenearest);
                    break;

            }

            //calculate nearest value



            return 0;
        }//calcpitch

        /// <summary>
        /// reads the pitch and dose value pair for chosen distance
        /// </summary>
        /// <param name="fwstuff"></param>
        /// <param name="neardist"></param>
        private void calcPitchdose(List<string> fwstuff, int neardist, int secdis)
        {

            if (false)
            {
                //extrapolate

            }
            else
            {
                //get the paramter for the earest and second nearest
                foreach (string line in fwstuff)
                {
                    var param = line.Split(',');
                    if (Int32.Parse(param[2]) == neardist)
                    {
                        pitchdosenear[Int32.Parse(param[1])] = Convert.ToSingle(param[0], new CultureInfo("en-US"));
                    }
                    if (Int32.Parse(param[2]) == secdis)
                    {
                        pitchdosesec[Int32.Parse(param[1])] = Convert.ToSingle(param[0], new CultureInfo("en-US"));
                    }

                }//foreach
                Interpolate(fdose);
            }//else
        }
            //interpolate
            private void Interpolate(float dosein )
        {
            int[] dosearr = new int[4] { 2, 3, 5, 10 };
            int nearestdose = dosearr.OrderBy(x => Math.Abs((long)x - dosein)).First();
            //pitchdict [dose] = pitch

            float nearpitch = pitchdosenear[nearestdose];
            float secpitch = pitchdosesec[nearestdose];

            //calc pitch
            pitch = nearpitch + (distance - nearest) * (secpitch - nearpitch) / (secondenearest - nearest);

            if(pitch < 0.172) { pitch = (float)0.172; }
            else if(pitch > 0.5) { pitch = (float)0.5; }

            //calc gantry periodGtime = (MF * Pitch * (DosIn / 4)) * 60 in seconds
            float mfactual = (mf> 0.2) ? (mf - (float)0.2) : 0 ;

            gp = mfactual * pitch *(1-(block / 100)) * (fdose / 4) * 60;

        }



        private void AllValues()
        {
           

            // We can assign with the indexer.
            smallFw.Add("0.446, 2, 5");
            smallFw.Add("0.303, 3, 5");
            smallFw.Add("0.233, 5, 5");
            smallFw.Add("0.233, 10, 5");
            smallFw.Add("0.436, 2, 10");
            smallFw.Add("0.295, 3, 10");
            smallFw.Add("0.225, 5, 10");
            smallFw.Add("0.225, 10, 10");
            smallFw.Add("0.42, 2, 15");
            smallFw.Add("0.282, 3, 15");
            smallFw.Add("0.212, 5, 15");
            smallFw.Add("0.212, 10, 15");
            smallFw.Add("0.397, 2, 20");
            smallFw.Add("0.264, 3, 20");
            smallFw.Add("0.197, 5, 20");
            smallFw.Add("0.197, 10, 20");

            largeFW.Add("0.444,2,5");
            largeFW.Add("0.303,3,5");
            largeFW.Add("0.231,5,5");
            largeFW.Add("0.187,10,5");
            largeFW.Add("0.433,2,10");
            largeFW.Add("0.297,3,10");
            largeFW.Add("0.225,5,10");
            largeFW.Add("0.182,10,10");
            largeFW.Add("0.418,2,15");
            largeFW.Add("0.285,3,15");
            largeFW.Add("0.215,5,15");
            largeFW.Add("0.172,10,15");
            largeFW.Add("0.397,2,20");
            largeFW.Add("0.267,3,20");
            largeFW.Add("0.2,5,20");
            largeFW.Add("0.159,10,20");

        }


    }
}