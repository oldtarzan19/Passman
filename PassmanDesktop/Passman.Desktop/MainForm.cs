using Passman.Core.dao;
using Passman.Core.Models;

namespace Passman.Desktop;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        InitializeDataGridView();
    }

    private void InitializeDataGridView()
    {
        
        dataGridView.AutoGenerateColumns = false;

        
        Dao dao = new Dao();
        List<VaultEntry> list = dao.GetVaultEntries();
        dataGridView.RowCount = list.Count;
        //dataGridView.DataSource = dao.GetVaultEntries();
        
        for (int i = 0; i < list.Count(); i++)
        {
            dataGridView.Rows[i].Cells["Username"].Value = list[i].Username;
            dataGridView.Rows[i].Cells["Password"].Value = list[i].Password;
            dataGridView.Rows[i].Cells["Website"].Value = list[i].Website;
        }
        
        dataGridView.Refresh();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }
}