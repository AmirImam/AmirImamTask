import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'ErrorSummary',
  templateUrl: './error-summary.component.html',
  styleUrls: ['./error-summary.component.css']
})
export class ErrorSummaryComponent implements OnInit {

  constructor() { }

  public ngOnInit(): void {
  }
  @Input() public Keys: string[] = new Array<string>();
  @Input() public Errors: Array<{ Key: string, Value: Array<string> }> = new Array<{ Key: string, Value: Array<string> }>();

  public ErrorsContainsKey(key: string): boolean {
    return this.Errors.find(it => it.Key == key) != null;
  }

  public GetErrorsByKey(key: string): { Key: string, Value: Array<string> } {
    let item = this.Errors.find(it => it.Key == key);
    if (item == null) {
      return { Key: "", Value: [] };
    }
    return item;
  }

  public FormatMessage(message: string) {

    let result: string = "";
    let parts: string[] = message.split(' ');
    for (let part of parts) {
      result += part.charAt(0).toUpperCase() + part.slice(1);
    }
    return result.replace('.', '');
  }

}
