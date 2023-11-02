using Microsoft.VisualBasic.ApplicationServices;
using Passman.Core.dao;
using SQLitePCL;

namespace Passman.Desktop;


public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void almaButton_Click(object sender, EventArgs e)
    {
        
        Dao dao = new Dao();
        dao.RegisterUser("alma", "alma", "alma", "alma", "alma");
        MessageBox.Show("Sikerült!");
    }
}