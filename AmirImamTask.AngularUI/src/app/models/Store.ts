import { Guid } from "guid-typescript";

export class Store {
    public Id: string = Guid.EMPTY;
    public StoreName: string = "";
    public PersonId?: string;
    public PersonName: string = "";
}