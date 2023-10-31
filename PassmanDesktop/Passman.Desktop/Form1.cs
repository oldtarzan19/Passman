using Passman.Core;

namespace Passman.Desktop;


public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void almaButton_Click(object sender, EventArgs e)
    {
        var alma = new Apple("red", "fuji", "large");
        MessageBox.Show(alma.GetDescription());
    }
}