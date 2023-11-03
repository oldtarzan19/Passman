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


    private void loginButton_Click(object sender, EventArgs e)
    {
        string username = userNameTextBox.Text;
        string password = passwordTextBox.Text;

        dao = new Dao();
        int userId = dao.LoginUser(username, password);
        if (userId == -1)
        {
            MessageBox.Show("Hibás felhasználónév vagy jelszó!");
        }
        else
        {
            MessageBox.Show("Sikeres bejelentkezés!");
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }

    private void registerButton_Click(object sender, EventArgs e)
    {
        string username = registerUsernameTextBox.Text;
        string password = registerPasswordTextBox.Text;
        string email = emailTextBox.Text;
        string firstname = firstNameTextBox.Text;
        string lastname = lastNameTextBox.Text;

        dao = new Dao();
        if (dao.RegisterUser(username, password, email, firstname, lastname))
        {
            MessageBox.Show("Sikeres regisztráció!");
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
        else
        {
            MessageBox.Show("Sikertelen regisztráció!");
        }
    }

    private void exitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}