public class Transaction {
    private string senderID;
    private string receiverID;
    private double Amount;

    public Transaction(string IDsender, string IDreceiver, double Amount){
        this.senderID = IDsender;
        this.receiverID = IDreceiver;
        this.Amount = Amount;
    }

    
    public override string ToString(){
        return $" {this.senderID} -> {this.receiverID} (Amount: ${this.Amount})";
    }

    public dynamic Save(){
        return new {
            senderID = this.senderID,
            receiverID = this.receiverID,
            Amount = this.Amount,
        };
    }
}