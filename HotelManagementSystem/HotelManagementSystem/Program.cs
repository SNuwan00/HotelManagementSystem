using System.Windows.Forms;

namespace HotelManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EnterUserInformation());
        }
    }
}
