namespace Passman.Desktop;

partial class WelcomeForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        loginButton = new Button();
        registerButton = new Button();
        userNameTextBox = new TextBox();
        passwordTextBox = new TextBox();
        label1 = new Label();
        label2 = new Label();
        registerPasswordTextBox = new TextBox();
        emailTextBox = new TextBox();
        firstNameTextBox = new TextBox();
        lastNameTextBox = new TextBox();
        registerUsernameTextBox = new TextBox();
        label3 = new Label();
        label4 = new Label();
        label5 = new Label();
        label6 = new Label();
        label7 = new Label();
        SuspendLayout();
        // 
        // loginButton
        // 
        loginButton.Location = new Point(134, 471);
        loginButton.Name = "loginButton";
        loginButton.Size = new Size(127, 29);
        loginButton.TabIndex = 0;
        loginButton.Text = "Bejelentkezés";
        loginButton.UseVisualStyleBackColor = true;
        loginButton.Click += loginButton_Click;
        // 
        // registerButton
        // 
        registerButton.Location = new Point(595, 471);
        registerButton.Name = "registerButton";
        registerButton.Size = new Size(118, 29);
        registerButton.TabIndex = 1;
        registerButton.Text = "Regisztráció";
        registerButton.UseVisualStyleBackColor = true;
        registerButton.Click += registerButton_Click;
        // 
        // userNameTextBox
        // 
        userNameTextBox.Location = new Point(86, 206);
        userNameTextBox.Name = "userNameTextBox";
        userNameTextBox.Size = new Size(228, 27);
        userNameTextBox.TabIndex = 2;
        // 
        // passwordTextBox
        // 
        passwordTextBox.Location = new Point(86, 317);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.PasswordChar = '*';
        passwordTextBox.Size = new Size(228, 27);
        passwordTextBox.TabIndex = 3;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(86, 183);
        label1.Name = "label1";
        label1.Size = new Size(109, 20);
        label1.TabIndex = 4;
        label1.Text = "Felhasználónév";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(86, 294);
        label2.Name = "label2";
        label2.Size = new Size(48, 20);
        label2.TabIndex = 5;
        label2.Text = "Jelszó";
        // 
        // registerPasswordTextBox
        // 
        registerPasswordTextBox.Location = new Point(548, 125);
        registerPasswordTextBox.Name = "registerPasswordTextBox";
        registerPasswordTextBox.Size = new Size(228, 27);
        registerPasswordTextBox.TabIndex = 6;
        // 
        // emailTextBox
        // 
        emailTextBox.Location = new Point(548, 206);
        emailTextBox.Name = "emailTextBox";
        emailTextBox.Size = new Size(228, 27);
        emailTextBox.TabIndex = 7;
        // 
        // firstNameTextBox
        // 
        firstNameTextBox.Location = new Point(548, 305);
        firstNameTextBox.Name = "firstNameTextBox";
        firstNameTextBox.Size = new Size(228, 27);
        firstNameTextBox.TabIndex = 8;
        // 
        // lastNameTextBox
        // 
        lastNameTextBox.Location = new Point(548, 394);
        lastNameTextBox.Name = "lastNameTextBox";
        lastNameTextBox.Size = new Size(228, 27);
        lastNameTextBox.TabIndex = 9;
        // 
        // registerUsernameTextBox
        // 
        registerUsernameTextBox.Location = new Point(548, 54);
        registerUsernameTextBox.Name = "registerUsernameTextBox";
        registerUsernameTextBox.Size = new Size(228, 27);
        registerUsernameTextBox.TabIndex = 10;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(548, 31);
        label3.Name = "label3";
        label3.Size = new Size(109, 20);
        label3.TabIndex = 11;
        label3.Text = "Felhasználónév";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(548, 102);
        label4.Name = "label4";
        label4.Size = new Size(48, 20);
        label4.TabIndex = 12;
        label4.Text = "Jelszó";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(548, 183);
        label5.Name = "label5";
        label5.Size = new Size(46, 20);
        label5.TabIndex = 13;
        label5.Text = "Email";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(548, 282);
        label6.Name = "label6";
        label6.Size = new Size(84, 20);
        label6.TabIndex = 14;
        label6.Text = "Kereszt név";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(548, 371);
        label7.Name = "label7";
        label7.Size = new Size(87, 20);
        label7.TabIndex = 15;
        label7.Text = "Vezeték név";
        // 
        // WelcomeForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(914, 600);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(registerUsernameTextBox);
        Controls.Add(lastNameTextBox);
        Controls.Add(firstNameTextBox);
        Controls.Add(emailTextBox);
        Controls.Add(registerPasswordTextBox);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(passwordTextBox);
        Controls.Add(userNameTextBox);
        Controls.Add(registerButton);
        Controls.Add(loginButton);
        Margin = new Padding(3, 4, 3, 4);
        Name = "WelcomeForm";
        Text = "PassMan";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button loginButton;
    private Button registerButton;
    private TextBox userNameTextBox;
    private TextBox passwordTextBox;
    private Label label1;
    private Label label2;
    private TextBox registerPasswordTextBox;
    private TextBox emailTextBox;
    private TextBox firstNameTextBox;
    private TextBox lastNameTextBox;
    private TextBox registerUsernameTextBox;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
}