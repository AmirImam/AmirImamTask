import { Guid } from "guid-typescript";

export class Item {
    public Id: string = Guid.EMPTY;
    public ItemName: string = "";
    public ItemDescription?: string;
    public Price: number = 0;
}