using Microsoft.VisualBasic.ApplicationServices;
using Passman.Core.dao;
using SQLitePCL;

namespace Passman.Desktop;


public partial class WelcomeForm : Form
{
    public static User user;
    private Dao dao;
    public WelcomeForm()
    {
        InitializeComponent();
    }

    private void almaButton_Click(object sender, EventArgs e)
    {
        Asd asd = new Asd();
        asd.Show();
        // Close the current form
        


    }
}