namespace bankapp {
    using System;
    using Terminal.Gui;
    
    public partial class TransactionsView : Terminal.Gui.Window {

        private Terminal.Gui.Label listLabel;
        private Terminal.Gui.ListView transListView;
        
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
            

            listLabel.Width = 24;
            listLabel.Height = 1;
            listLabel.X = 10;
            listLabel.Y = 2;
            listLabel.Text = "Total Transactions: NaN"; // To Do

            transListView.Width = Dim.Fill(0);
            transListView.Height = Dim.Fill(6);
            transListView.X = 0;
            transListView.Y = 6;
            transListView.SetSource(BankAccount.selected.GetTransactions().ToList());

            this.Add(
                listLabel,
                transListView
            );

        }

    }
}