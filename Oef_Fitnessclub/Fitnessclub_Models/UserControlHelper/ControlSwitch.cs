using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fitnessclub_Models.UserControlHelper
{
    public delegate void FitnessclubDelegate(UserControl usc, string title);
    public delegate void VisibilityEvent(string visibility, string Property);
    public delegate void ImageEvent(string image, string Property);
    public delegate void ContentEvent(string content, string Property);


    public static class ControlSwitch
    {
        public static event FitnessclubDelegate UscEvent;
        public static event VisibilityEvent VisibilityEvent;
        public static event ImageEvent ImageEvent;
        public static event ContentEvent ContentEvent;

        public static void InvokeSwitch(UserControl usc, string title)
        {
            UscEvent?.Invoke(usc, title);
        }


        public static void ChangePropertyVisibility(string visibility, string Property)
        {
            VisibilityEvent?.Invoke(visibility, Property);
        }

        public static void SetImage(string Image, string Property)
        {
            ImageEvent?.Invoke(Image, Property);
        }

        public static void SetContent(string content, string Property)
        {
            ContentEvent?.Invoke(content, Property);
        }
    }
}
