import { Guid } from "guid-typescript";

export class TransactionDetail {
    public Id: string = Guid.EMPTY;
    public TransactionId?: string;
    public ItemId?: string;
    public TransactionFactor: number = 0;
    public Quantity: number = 0;
    public Price: number = 0;
    public Value: number = 0;

    public ItemName?: string;
    public ItemCode?: string;
    public ItemDescription?: string;
}