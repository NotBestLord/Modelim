

namespace Modelim
{
    internal static class Program
    {
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Window form = new Window();
            form.ShowDialog();
            form.repaint();
        }
    }
}