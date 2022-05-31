import { Guid } from "guid-typescript";
import { TransactionDetail } from "./TransactionDetail";

export class Transaction {
    public Id: string = Guid.EMPTY;
    public TransactionDate: Date = new Date();
    public StoreId?: string;
    public ItemsCount: number = 0;
    public TotalPrices: number = 0;
    public Net: number = 0;

    public TransactionDetails?: TransactionDetail[];
}