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
        comboBox1 = new ComboBox();
        delete_button = new Button();
        label1 = new Label();
        update_gridview = new Button();
        ((ISupportInitialize)dataGridView).BeginInit();
        SuspendLayout();
        // 
        // dataGridView
        // 
        dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView.Columns.AddRange(new DataGridViewColumn[] { Username, Password, Website });
        dataGridView.Location = new Point(144, 9);
        dataGridView.Margin = new Padding(3, 2, 3, 2);
        dataGridView.Name = "dataGridView";
        dataGridView.RowHeadersWidth = 51;
        dataGridView.RowTemplate.Height = 29;
        dataGridView.Size = new Size(382, 137);
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
        exitButton.Location = new Point(480, 300);
        exitButton.Margin = new Padding(3, 2, 3, 2);
        exitButton.Name = "exitButton";
        exitButton.Size = new Size(82, 22);
        exitButton.TabIndex = 1;
        exitButton.Text = "Exit";
        exitButton.UseVisualStyleBackColor = true;
        exitButton.Click += exitButton_Click;
        // 
        // addButton
        // 
        addButton.Location = new Point(597, 300);
        addButton.Margin = new Padding(3, 2, 3, 2);
        addButton.Name = "addButton";
        addButton.Size = new Size(82, 22);
        addButton.TabIndex = 2;
        addButton.Text = "Add";
        addButton.UseVisualStyleBackColor = true;
        addButton.Click += addButton_Click;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(66, 300);
        comboBox1.Margin = new Padding(3, 2, 3, 2);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(133, 23);
        comboBox1.TabIndex = 3;
        // 
        // delete_button
        // 
        delete_button.Location = new Point(242, 300);
        delete_button.Margin = new Padding(3, 2, 3, 2);
        delete_button.Name = "delete_button";
        delete_button.Size = new Size(82, 22);
        delete_button.TabIndex = 4;
        delete_button.Text = "Delete data";
        delete_button.UseVisualStyleBackColor = true;
        delete_button.Click += delete_button_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(66, 270);
        label1.Name = "label1";
        label1.Size = new Size(161, 15);
        label1.TabIndex = 5;
        label1.Text = "Törlendõ elem weboldal neve";
        // 
        // update_gridview
        // 
        update_gridview.Location = new Point(360, 300);
        update_gridview.Margin = new Padding(3, 2, 3, 2);
        update_gridview.Name = "update_gridview";
        update_gridview.Size = new Size(82, 22);
        update_gridview.TabIndex = 6;
        update_gridview.Text = "Frissítés";
        update_gridview.UseVisualStyleBackColor = true;
        update_gridview.Click += update_gridview_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 338);
        Controls.Add(update_gridview);
        Controls.Add(label1);
        Controls.Add(delete_button);
        Controls.Add(comboBox1);
        Controls.Add(addButton);
        Controls.Add(exitButton);
        Controls.Add(dataGridView);
        Margin = new Padding(3, 2, 3, 2);
        Name = "MainForm";
        Text = "MainForm";
        ((ISupportInitialize)dataGridView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView dataGridView;
    private DataGridViewTextBoxColumn Username;
    private DataGridViewTextBoxColumn Password;
    private DataGridViewTextBoxColumn Website;
    private Button exitButton;
    private Button addButton;
    private ComboBox comboBox1;
    private Button delete_button;
    private Label label1;
    private Button update_gridview;
}