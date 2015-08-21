namespace Log4NetTest
{
    using System;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MainForm()
        {
            this.InitializeComponent();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            Log.Debug("Application started");
        }

        private void ButtonRunTest_Click(object sender, EventArgs e)
        {
            Log.Debug("Debug logging");
            Log.Info("Info logging");
            Log.Warn("Warn logging");
            Log.Error("Error logging");
            Log.Fatal("Fatal logging");

            LogTester.TestLogger();

            try
            {
                MessageBox.Show("You can find this log in mylogfile.txt");
            }
            catch (Exception ex)
            {
                Log.Debug("Debug error logging", ex);
                Log.Info("Info error logging", ex);
                Log.Warn("Warn error logging", ex);
                Log.Error("Error error logging", ex);
                Log.Fatal("Fatal error logging", ex);
            }
        }
    }
}
