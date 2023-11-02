using Microsoft.VisualBasic.ApplicationServices;
using Passman.Core.dao;
using SQLitePCL;

namespace Passman.Desktop;


public partial class Form1 : Form
{
    Dao dao = new Dao();
    public Form1()
    {
        InitializeComponent();
    }

    private void almaButton_Click(object sender, EventArgs e)
    {
        
        Dao dao = new Dao();
        if (dao.LoginUser("asd", "asdd"))
        {
            MessageBox.Show("Sikerült!");
        }
        else
        {
            MessageBox.Show("Nem sikerült!");
        }
        
    }
}