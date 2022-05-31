export class ResponseResult<T>{
    public Success: boolean = false;
    public Model?: T;
    public Errors?: Array<{ Key: string, Value: Array<string> }>;
}