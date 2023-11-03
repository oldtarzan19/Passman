using System.ComponentModel;

namespace Passman.Desktop;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        dataGridView = new DataGridView();
        Username = new DataGridViewTextBoxColumn();
        Password = new DataGridViewTextBoxColumn();
        Website = new DataGridViewTextBoxColumn();
        exitButton = new Button();
        addButton = new Button();
        ((ISupportInitialize)dataGridView).BeginInit();
        SuspendLayout();
        // 
        // dataGridView
        // 
        dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView.Columns.AddRange(new DataGridViewColumn[] { Username, Password, Website });
        dataGridView.Location = new Point(165, 12);
        dataGridView.Name = "dataGridView";
        dataGridView.RowHeadersWidth = 51;
        dataGridView.RowTemplate.Height = 29;
        dataGridView.Size = new Size(428, 183);
        dataGridView.TabIndex = 0;
        // 
        // Username
        // 
        Username.HeaderText = "Felhasznalonev";
        Username.MinimumWidth = 6;
        Username.Name = "Username";
        Username.ReadOnly = true;
        Username.Width = 125;
        // 
        // Password
        // 
        Password.HeaderText = "Jelszo";
        Password.MinimumWidth = 6;
        Password.Name = "Password";
        Password.ReadOnly = true;
        Password.Width = 125;
        // 
        // Website
        // 
        Website.HeaderText = "Weboldal";
        Website.MinimumWidth = 6;
        Website.Name = "Website";
        Website.ReadOnly = true;
        Website.Width = 125;
        // 
        // exitButton
        // 
        exitButton.Location = new Point(549, 400);
        exitButton.Name = "exitButton";
        exitButton.Size = new Size(94, 29);
        exitButton.TabIndex = 1;
        exitButton.Text = "Exit";
        exitButton.UseVisualStyleBackColor = true;
        exitButton.Click += exitButton_Click;
        // 
        // addButton
        // 
        addButton.Location = new Point(682, 400);
        addButton.Name = "addButton";
        addButton.Size = new Size(94, 29);
        addButton.TabIndex = 2;
        addButton.Text = "Add";
        addButton.UseVisualStyleBackColor = true;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(addButton);
        Controls.Add(exitButton);
        Controls.Add(dataGridView);
        Name = "MainForm";
        Text = "MainForm";
        ((ISupportInitialize)dataGridView).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dataGridView;
    private DataGridViewTextBoxColumn Username;
    private DataGridViewTextBoxColumn Password;
    private DataGridViewTextBoxColumn Website;
    private Button exitButton;
    private Button addButton;
}