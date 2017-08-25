using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PerfectPitchWeb
{
    public partial class _Default : Page
    {
        public event EventHandler<SlideEventCalc> SlideEv;

        private float distance;
        private float fdose;
        private float block;
        private float modfactor;
        private float results;
        private float gperiod;
        private string fw;

        //flightCtrl.LandEv += LandEventSent;
        //events.LandEvent strtev = new events.LandEvent(name, DateTime.Now);
        //raise event
        //      NewStart(strtev);
       // public void NewLand(events.LandEvent e)
        
        //    if (LandEv != null)
          //  {
            //    LandEv(this, e);




        protected void Page_Load(object sender, EventArgs e)
        {
            SlideEv += SlideEventSent;
            

        }
       

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DistanceSlide_TextChanged(object sender, EventArgs e)
        {
            GetTextboxVals();
            SlideEventCalc slev = new SlideEventCalc(distance, modfactor, block, fdose, fw);
            NewSlide(slev);

            
            //UpdateResult.Update();
        }

        private void NewSlide(SlideEventCalc e)
        {
            SlideEv(this, e);
        }

        /// <summary>
        /// event for slider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SlideEventSent(object sender, SlideEventCalc e)
        {
            //resultbox.Text = e.Distance.ToString();
            GetTextboxVals();
            if ((fdose <= 0) || (modfactor <= 0))
            {
                GPtext.ForeColor = System.Drawing.Color.Black;
                GPtext.ToolTip = "NaN";
               resultbox.Text = "NaN";
                GPtext.Text = "NaN";

            }
            else if (e.Gp < 12)
            {
                resultbox.Text = e.Pitch.ToString("0.000");
                GPtext.Text = "<12";
                GPtext.ToolTip = "To short gantry period time, \n consider lower modulation factor";
                GPtext.ForeColor = System.Drawing.Color.Red;


            }
            else if((e.Gp > 50) && (e.Gp <= 60))
            {
                resultbox.Text = e.Pitch.ToString("0.000");
                GPtext.Text = e.Gp.ToString("0.0");
                GPtext.ToolTip = "To long gantry period time, \n consider lower modulation factor";
                GPtext.ForeColor = System.Drawing.Color.Red;


            }
            else if (e.Gp > 60)
            {
                resultbox.Text = e.Pitch.ToString("0.000");
                GPtext.Text = ">60";
                GPtext.ToolTip = "To long gantry period time, \n consider lower modulation factor";
                GPtext.ForeColor = System.Drawing.Color.Red;


            }
       

            else
            {
                GPtext.ForeColor = System.Drawing.Color.Black;
                resultbox.Text = e.Pitch.ToString("0.000");
                GPtext.Text = e.Gp.ToString("0.0");
                GPtext.ToolTip = "";
                //resultbox.Text = e.ModulationFactor.ToString();
            }


                }//slideevelsent

        protected void DistanceSlide_BoundControl_TextChanged(object sender, EventArgs e)
        {
            GetTextboxVals();
            SlideEventCalc slev = new SlideEventCalc(distance,modfactor,block,fdose, fw);
            NewSlide(slev);

           
            //UpdateResult.Update();
        }

        private void GetTextboxVals()
        {
            distance= Int32.Parse(DistanceSlide_BoundControl.Text);
            block = float.Parse(BlockingSlide_BoundControl1.Text);
            fdose = float.Parse(DoseSlide_BoundControl0.Text);
            modfactor = float.Parse(MFSlide_BoundControl2.Text);
            fw = RButtonFW.SelectedValue;


    }

        protected void MFSlide_BoundControl2_TextChanged(object sender, EventArgs e)
        {
            //GetTextboxVals();
            //SlideEventCalc slev = new SlideEventCalc(distance, modfactor, block, fdose);
            //NewSlide(slev);
            

        }

        protected void MFSlide_TextChanged(object sender, EventArgs e)
        {
            GetTextboxVals();
            SlideEventCalc slev = new SlideEventCalc(distance, modfactor, block, fdose, fw);
            NewSlide(slev);


        }

        protected void DoseSlide_TextChanged(object sender, EventArgs e)
        {
            GetTextboxVals();
            SlideEventCalc slev = new SlideEventCalc(distance, modfactor, block, fdose, fw);
            NewSlide(slev);


        }

        protected void BlockingSlide_TextChanged(object sender, EventArgs e)
        {
            GetTextboxVals();
            SlideEventCalc slev = new SlideEventCalc(distance, modfactor, block, fdose, fw);
            NewSlide(slev);

        }

        protected void RButtonFW_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTextboxVals();
            SlideEventCalc slev = new SlideEventCalc(distance, modfactor, block, fdose, fw);
            NewSlide(slev);

        }

        //  private void LandEventSent(object sender, events.LandEvent e)

        //    listBoxFlights.Items.Add(e.FlightName + "\t\t" + "LAnded \t\t" + e.LandTime.ToShortTimeString());


    }
}