using DiscoLedCracker.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiscoLedCracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LicenceGenerator licenceGenerator = new LicenceGenerator();

            LicenseData licenseData = new LicenseData();

            List<LicenseDevice> devices = new List<LicenseDevice>();

            LicenseDevice deviceNumberOne = new LicenseDevice();
            deviceNumberOne.HasIndividualDate = false;
            deviceNumberOne.StartDate = Convert.ToDateTime("01/01/0001");
            deviceNumberOne.EndDate = Convert.ToDateTime("01/01/0001");
            deviceNumberOne.RemainingRunTime = TimeSpan.Zero;
            deviceNumberOne.ConnectorName = "USB 1";
            deviceNumberOne.DeviceName = UsbOneName.Text;
            deviceNumberOne.LockDeviceName = UsbOneLockedName.Text;
            deviceNumberOne.Locked = (LockedOne.IsChecked == true) ? true : false; ;


            LicenseDevice deviceNumberTwo = new LicenseDevice();
            deviceNumberTwo.HasIndividualDate = false;
            deviceNumberTwo.StartDate = Convert.ToDateTime("01/01/0001");
            deviceNumberTwo.EndDate = Convert.ToDateTime("01/01/0001");
            deviceNumberTwo.RemainingRunTime = TimeSpan.Zero;
            deviceNumberTwo.ConnectorName = "USB 2";
            deviceNumberTwo.DeviceName = UsbTwoName.Text;
            deviceNumberTwo.LockDeviceName = UsbTwoLockedName.Text;
            deviceNumberTwo.Locked = (LockedTwo.IsChecked == true) ? true : false;


            licenseData.Data = null;
            licenseData.Version = 1;
            licenseData.StartDate = Convert.ToDateTime(DateCreate.SelectedDate);
            licenseData.EndDate = Convert.ToDateTime(DateEnd.SelectedDate);
            licenseData.LastRunDate = Convert.ToDateTime(LastUse.SelectedDate);
            licenseData.RemainingRunTime = TimeSpan.Zero;
            licenseData.LicenseDevices = devices;

            devices.Add(deviceNumberOne);
            devices.Add(deviceNumberTwo);

            Byte[] license;
            license = licenceGenerator.SaveToBytes(licenseData);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\license.lic";
            string licenseNewFile = desktopPath += filename;

            using (StreamWriter streamWriter = new StreamWriter(licenseNewFile))
                streamWriter.Write(Convert.ToBase64String(license));

            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();

            ProgressBar.Value = 100;
        }

        private void LockedOne_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void LockedTwo_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void UsbTwoCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            UsbTwoName.IsEnabled = true;
            UsbTwoLockedName.IsEnabled = true;
            LockedTwo.IsEnabled = true;
        }

        private void usbOneCheckbox(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("kupa");
        }

        private void UsbTwoCheckbox_UnChecked(object sender, RoutedEventArgs e)
        {
            UsbTwoName.IsEnabled = false;
            UsbTwoLockedName.IsEnabled = false;
            LockedTwo.IsEnabled = false;
        }

        private void UsbOneCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            UsbOneName.IsEnabled = true;
            UsbOneLockedName.IsEnabled = true;
            LockedOne.IsEnabled = true;
        }

        private void UsbOneCheckbox_UnChecked(object sender, RoutedEventArgs e)
        {
            UsbOneName.IsEnabled = false;
            UsbOneLockedName.IsEnabled = false;
            LockedOne.IsEnabled = false;
        }
    }
}

