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
        dao.RegisterUser("asdd", "asdd", "asd", "asd", "asd");
        int id = dao.LoginUser("asdd", "asdd");
        if (id >= 0)
        {
            MessageBox.Show("Sikerült! Id: "+id);
        }
        else
        {
            MessageBox.Show("Nem sikerült!");
        }
        
    }
}