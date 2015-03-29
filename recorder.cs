using Microsoft.Kinect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SignLanguageTranslator_Record_2D
{
    /// <summary>
    /// This class is used to write the 2D body Joints in the .txt file
    /// </summary>
    class Recorder
    {
        public string[] array0 = new string[0];
        private Body[] bodies = null;
        /// <summary>
        /// This function reads the body cordinates from Kinect and normalizes the coordinates
        /// </summary>
        /// <param name="textLines">Joint cordinates which is provided by Kinect</param>
        /// <returns>Normalized coordinates in 2D</returns>
        public ArrayList readfiles(string[] textLines)
        {
            ArrayList pointsList = new ArrayList();
            JointsExtractor sd = new JointsExtractor();
            ArrayList refpoints = sd.normalisationcordinates(textLines);
            foreach (Point[] refpoint in refpoints)
            {
                JointsCoordEventArgs converter = new JointsCoordEventArgs(refpoint);
                double[] gesturecapturedbykinect = converter.GetCoordinates();
                pointsList.Add(gesturecapturedbykinect);
            }
            return pointsList;
        }
        /// <summary>
        /// This function is used to write 2D body Joints in the txt file for DTW dataset
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public string implode_array(double[] arr, string delimiter)
        {
            string returnString = String.Empty;
            foreach (double el in arr)
            {
                returnString += el.ToString() + delimiter;
            }
            return returnString.Substring(0, returnString.Length - 1);
        }
       
    }
}
