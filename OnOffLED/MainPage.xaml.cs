using Windows.Devices.Gpio;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OnOffLED
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private GpioPin pin;
        private const int LED_PIN = 27;//
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (pin == null)
            {
                var gpio = GpioController.GetDefault();
                pin = gpio.OpenPin(LED_PIN);
                pin.SetDriveMode(GpioPinDriveMode.Output);
            }
            else
            {
                pin.Write(GpioPinValue.High);

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (pin != null)
                pin.Write(GpioPinValue.Low);
        }
    }
}
