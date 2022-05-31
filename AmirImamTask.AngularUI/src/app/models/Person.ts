import { Guid } from "guid-typescript";

export class Person {
    public Id: string = Guid.EMPTY;
    public PersonName: string = "";
    public Email: string = "";
    public PhoneNumber: string = "";
    public Locker: string = "";

    public AccessToken?: string = "";
}