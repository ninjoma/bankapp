namespace bankapp {
    using System;
    using Terminal.Gui;
    
    public partial class MenuView : Terminal.Gui.Window {

        private Terminal.Gui.Button depositButton;
        private Terminal.Gui.Button withdrawButton;
        private Terminal.Gui.Button transButton;
        private Terminal.Gui.Button investButton;
        private Terminal.Gui.Label balanceLabel;

        private void InitializeComponent() {
            
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
            this.Title = "StealGreens Bank SSL - Menu";

            this.depositButton = new Terminal.Gui.Button();
            this.withdrawButton = new Terminal.Gui.Button();
            this.transButton = new Terminal.Gui.Button();
            this.investButton = new Terminal.Gui.Button();
            this.balanceLabel = new Terminal.Gui.Label();

            int margin = 10;

            this.depositButton.Width = 20;
            this.depositButton.X = 0 + margin;
            this.depositButton.Y = Pos.Center() - 2;
            this.depositButton.Text = "Deposit Money";

            this.withdrawButton.Width = 20;
            this.withdrawButton.X = Pos.Right(this) - 21 - margin;
            this.withdrawButton.Y = Pos.Center() - 2;
            this.withdrawButton.Text = "Withdraw Money";

            this.transButton.Width = 20;
            this.transButton.X = 0 + margin;
            this.transButton.Y = Pos.Center() + 2;
            this.transButton.Text = "Transfers History";

            this.investButton.Width = 20;
            this.investButton.X = Pos.Right(this) - 21 - margin;
            this.investButton.Y = Pos.Center() + 2;
            this.investButton.Text = "Invest Money";

            this.balanceLabel.Width = 24;
            this.balanceLabel.X = 0 + margin;
            this.balanceLabel.Y = Pos.Center() - 8;
            this.balanceLabel.Text = "Current Balance: $NaN";

            this.Add(
                depositButton,
                withdrawButton,
                transButton,
                investButton,
                balanceLabel
            );
        }
    }

}