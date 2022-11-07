namespace bankapp {
    using System;
    using Terminal.Gui;
    
    public partial class TransactionsView : Terminal.Gui.Window {

        private Terminal.Gui.Label listLabel;
        private Terminal.Gui.ListView transListView;
        private Terminal.Gui.Button backButton;
        
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

            listLabel = new Terminal.Gui.Label();
            transListView = new Terminal.Gui.ListView();
            backButton = new Terminal.Gui.Button();

            backButton.Width = 9;
            backButton.Text = "<- Back";
            backButton.X = 0;
            backButton.Y = 2;

            listLabel.Width = 24;
            listLabel.Height = 1;
            listLabel.X = 12;
            listLabel.Y = 2;
            listLabel.Text = $"Total Transactions: { BankAccount.selected.GetTransactionCount() }"; // To Do

            transListView.Width = Dim.Fill(0);
            transListView.Height = Dim.Fill(6);
            transListView.X = 0;
            transListView.Y = 6;
            transListView.SetSource(BankAccount.selected.GetTransactions().ToList());

            this.Add(
                listLabel,
                transListView,
                backButton
            );

        }

    }
}