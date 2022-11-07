namespace bankapp {
    using System;
    using Terminal.Gui;
    
    public partial class DepositView : Terminal.Gui.Window {

        private Terminal.Gui.Button backButton;
        private Terminal.Gui.Label depositLabel;
        private Terminal.Gui.TextField depositField;
        private Terminal.Gui.Button depositButton;
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
            depositLabel = new Terminal.Gui.Label();
            depositField = new Terminal.Gui.TextField();
            depositButton = new Terminal.Gui.Button();
            errorLabel = new Terminal.Gui.Label();

            backButton.Width = 9;
            backButton.Text = "<- Back";
            backButton.X = 0;
            backButton.Y = 2;

            depositLabel.Width = Dim.Fill();
            depositLabel.X = Pos.Center();
            depositLabel.Y = Pos.Center() - 4;
            depositLabel.Text = "Please enter the amount you want to deposit.";
            depositLabel.TextAlignment = TextAlignment.Centered;

            depositField.Width = 24;
            depositField.Height = 1;
            depositField.X = Pos.Center();
            depositField.Y = Pos.Center() - 1;

            depositButton.Width = 12;
            depositButton.Height = 1;
            depositButton.X = Pos.Center();
            depositButton.Y = Pos.Center() + 1;
            depositButton.Text = "Deposit";

            errorLabel.Width = Dim.Fill();
            errorLabel.Height = 1;
            errorLabel.X = Pos.Center();
            errorLabel.Y = Pos.Center() + 3;

            this.Add(
                backButton,
                depositLabel,
                depositField,
                depositButton,
                errorLabel
            );

        }

    }
}