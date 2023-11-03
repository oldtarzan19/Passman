using System.ComponentModel;

namespace Passman.Desktop;

partial class AddForm
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
        saveButton = new Button();
        label1 = new Label();
        addWebsiteTextBox = new TextBox();
        label2 = new Label();
        label3 = new Label();
        addPasswordTextBox = new TextBox();
        addUsernameTextBox = new TextBox();
        SuspendLayout();
        // 
        // saveButton
        // 
        saveButton.Location = new Point(186, 452);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(94, 29);
        saveButton.TabIndex = 0;
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += saveButton_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(49, 62);
        label1.Name = "label1";
        label1.Size = new Size(109, 20);
        label1.TabIndex = 1;
        label1.Text = "Felhasznalonev";
        // 
        // addWebsiteTextBox
        // 
        addWebsiteTextBox.Location = new Point(49, 303);
        addWebsiteTextBox.Name = "addWebsiteTextBox";
        addWebsiteTextBox.Size = new Size(125, 27);
        addWebsiteTextBox.TabIndex = 2;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(49, 161);
        label2.Name = "label2";
        label2.Size = new Size(48, 20);
        label2.TabIndex = 3;
        label2.Text = "Jelszo";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(49, 265);
        label3.Name = "label3";
        label3.Size = new Size(73, 20);
        label3.TabIndex = 4;
        label3.Text = "Weboldal";
        // 
        // addPasswordTextBox
        // 
        addPasswordTextBox.Location = new Point(49, 201);
        addPasswordTextBox.Name = "addPasswordTextBox";
        addPasswordTextBox.PasswordChar = '*';
        addPasswordTextBox.Size = new Size(125, 27);
        addPasswordTextBox.TabIndex = 5;
        // 
        // addUsernameTextBox
        // 
        addUsernameTextBox.Location = new Point(49, 102);
        addUsernameTextBox.Name = "addUsernameTextBox";
        addUsernameTextBox.Size = new Size(125, 27);
        addUsernameTextBox.TabIndex = 6;
        // 
        // AddForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(465, 508);
        Controls.Add(addUsernameTextBox);
        Controls.Add(addPasswordTextBox);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(addWebsiteTextBox);
        Controls.Add(label1);
        Controls.Add(saveButton);
        Name = "AddForm";
        Text = "AddForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button saveButton;
    private Label label1;
    private TextBox addWebsiteTextBox;
    private Label label2;
    private Label label3;
    private TextBox addPasswordTextBox;
    private TextBox addUsernameTextBox;
}