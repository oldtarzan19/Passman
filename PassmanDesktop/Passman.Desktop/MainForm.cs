using Passman.Core.dao;
using Passman.Core.Models;

namespace Passman.Desktop;

public partial class MainForm : Form
{
    private Dao dao;
    public MainForm()
    {
        InitializeComponent();
        InitializeDataGridView();
        dao = new Dao();
        LoadDataIntoComboBox();
    }

    public void InitializeDataGridView()
    {

        dataGridView.AutoGenerateColumns = false;


        Dao dao = new Dao();
        List<VaultEntry> list = dao.GetVaultEntries();
        if (list.Count == 0)
        {
            dataGridView.RowCount = 1;
            dataGridView.ColumnCount = 3;
        }
        else
        {
            dataGridView.RowCount = list.Count;
        }
        for (int i = 0; i < list.Count(); i++)
        {
            dataGridView.Rows[i].Cells["Username"].Value = list[i].Username;
            dataGridView.Rows[i].Cells["Password"].Value = list[i].Password;
            dataGridView.Rows[i].Cells["Website"].Value = list[i].Website;
        }

        dataGridView.Refresh();
    }

    private void exitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        AddForm addForm = new AddForm(this);
        addForm.ShowDialog();
    }

    private void delete_button_Click(object sender, EventArgs e)
    {
        if (comboBox1.SelectedItem != null)
        {
            DialogResult result = MessageBox.Show("Biztos törölni akarod?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dao.DeleteVaultEntryByWebsite(comboBox1.SelectedItem.ToString());
                RefreshComboBox();
            }

            // Frissítsük a ComboBox-ot


        }
    }

    private void RefreshComboBox()
    {
        comboBox1.Items.Clear();
        LoadDataIntoComboBox();
    }

    private void LoadDataIntoComboBox()
    {
        comboBox1.Items.Add("Válassz egy weboldalt!");
        List<VaultEntry> vaultEntries = dao.GetVaultEntries();

        foreach (var VARIABLE in vaultEntries)
        {
            comboBox1.Items.Add(VARIABLE.Website);
        }
    }

    private void update_gridview_Click(object sender, EventArgs e)
    {
        InitializeDataGridView();
    }
}