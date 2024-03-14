using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Shutdown_Timer
{
    public partial class ShutdownForm : Form
    {
        public ShutdownForm()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (nudHours.Value != 0 | nudMinutes.Value != 0 | nudSeconds.Value != 0)
            {
                int total = Convert.ToInt32((nudHours.Value * 3600) + (nudMinutes.Value * 60) + nudSeconds.Value);

                Cmd($"-s -t { total }");

                MessageBox.Show($"Компьютер выключиться через:\n{ nudHours.Value } час., { nudMinutes.Value } мин. и { nudSeconds.Value } сек.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Значение не введено.\nТаймер не будет запущен.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cmd("-a");
            MessageBox.Show("Таймер отменен.\nКомпьютер не завершит работу.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Cmd(string line)
        {
            Process.Start(new ProcessStartInfo
            { 
                FileName = "cmd",
                Arguments = $"/C shutdown { line }",
                WindowStyle = ProcessWindowStyle.Hidden 
            });
        }
    }
}
