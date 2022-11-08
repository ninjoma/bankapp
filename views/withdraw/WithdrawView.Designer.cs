namespace bankapp {
    using System;
    using Terminal.Gui;
    
    public partial class WithdrawView : Terminal.Gui.Window {

        private Terminal.Gui.Button backButton;
        private Terminal.Gui.Label withdrawLabel;
        private Terminal.Gui.TextField withdrawField;
        private Terminal.Gui.Button withdrawButton;
        private Terminal.Gui.Label errorLabel;
        
        private void InitializeComponent(){

            // Window Settings
            this.Width = Dim.Fill(0);
            this.Height = Dim.Fill(0);
            this.X = 0;
            this.Y = 0;
            this.Modal = false;
            this.Text = "";
            this.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.Border.Effect3D = false;
            this.Border.DrawMarginFrame = true;
            this.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Title = "StealGreens Bank SSL - List of Transactions";

            // Component Declarations

            backButton = new Terminal.Gui.Button();
            withdrawLabel = new Terminal.Gui.Label();
            withdrawField = new Terminal.Gui.TextField();
            withdrawButton = new Terminal.Gui.Button();
            errorLabel = new Terminal.Gui.Label();

            backButton.Width = 9;
            backButton.Text = "<- Back";
            backButton.X = 0;
            backButton.Y = 2;

            withdrawLabel.Width = Dim.Fill();
            withdrawLabel.X = Pos.Center();
            withdrawLabel.Y = Pos.Center() - 4;
            withdrawLabel.Text = "Please enter the amount you want to withdraw.";
            withdrawLabel.TextAlignment = TextAlignment.Centered;

            withdrawField.Width = 24;
            withdrawField.Height = 1;
            withdrawField.X = Pos.Center();
            withdrawField.Y = Pos.Center() - 1;

            withdrawButton.Width = 12;
            withdrawButton.Height = 1;
            withdrawButton.X = Pos.Center();
            withdrawButton.Y = Pos.Center() + 1;
            withdrawButton.Text = "Withdraw";

            errorLabel.Width = Dim.Fill();
            errorLabel.Height = 1;
            errorLabel.X = Pos.Center();
            errorLabel.Y = Pos.Center() + 3;

            this.Add(
                backButton,
                withdrawLabel,
                withdrawField,
                withdrawButton,
                errorLabel
            );

        }

    }
}