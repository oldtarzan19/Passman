using Microsoft.VisualBasic.ApplicationServices;
using Passman.Core.dao;
using SQLitePCL;

namespace Passman.Desktop;


public partial class Form1 : Form
{
    public static User user;
    private Dao dao;
    public Form1()
    {
        InitializeComponent();
    }

    private void almaButton_Click(object sender, EventArgs e)
    {
        dao = new Dao();
        int id = dao.LoginUser("asdd", "asdd");
        dao.CreateVaultEntry("pogi","pog","pog");
        dao.GetVaultEntries();
        foreach (var VARIABLE in dao.GetVaultEntries())
        {
            MessageBox.Show(VARIABLE.Password);
        }
        
    }
}