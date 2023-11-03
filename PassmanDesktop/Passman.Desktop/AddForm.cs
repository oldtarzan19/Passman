using Passman.Core.dao;

namespace Passman.Desktop;

public partial class AddForm : Form
{
    private MainForm _mainForm;
    public AddForm(MainForm mainForm)
    {
        _mainForm = mainForm;
        InitializeComponent();
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        string username = addUsernameTextBox.Text;
        string password = addPasswordTextBox.Text;
        string website = addWebsiteTextBox.Text;

        Dao dao = new Dao();
        dao.CreateVaultEntry(username, password, website);
        MessageBox.Show("Sikeres mentés!");
        _mainForm.InitializeDataGridView();
        this.Close();
    }
}