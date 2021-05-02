using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.DirectoryServices.AccountManagement;
using System.Diagnostics;

namespace TOEIC_Exam_WinApp
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromiumWebBrowser;
        public Form1()
        {
            InitializeComponent();

            InitilizeChromium();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitilizeChromium()
        {
            string Name = System.Environment.UserName;
            string eMail = UserPrincipal.Current.EmailAddress;

            string url = "http://51.222.85.96:8080";
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(eMail))
            {
                if (Name.Contains("."))
                {
                    string FirstName = Name.Substring(0, Name.IndexOf("."));
                    string LastName = Name.Substring(Name.IndexOf(".") + 1);
                    FirstName = char.ToUpper(FirstName[0]) + FirstName.Substring(1);
                    LastName = char.ToUpper(LastName[0]) + LastName.Substring(1);
                    Name = FirstName + " " + LastName;
                }
                url += "?name=" + Name + "&email=" + eMail;
            }

            CefSettings settings = new CefSettings();

            Cef.Initialize(settings);

            chromiumWebBrowser = new ChromiumWebBrowser(url);

            chromiumWebBrowser.AddressChanged += OnBrowserAddressChanged;

            this.Controls.Add(chromiumWebBrowser);
            chromiumWebBrowser.Dock = DockStyle.Fill;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs e)
        {
            //this.InvokeOnUiThreadIfRequired(() => Text = e.Address);

            if (e.Address.Equals(url + "/finished?closed=true"){
                Application.Exit();
            }
        }
    }
}
