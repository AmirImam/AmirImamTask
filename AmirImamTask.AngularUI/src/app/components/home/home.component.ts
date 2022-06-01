import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  public TasksList = new Array<{ Title: string, State: boolean, Notes?: string }>();
  ngOnInit(): void {
    this.TasksList = [
      { Title: "Use angular", State: true },
      { Title: "Use bootstrap", State: true },
      { Title: "Register & Login", State: true },
      { Title: "Change password", State: true },
      { Title: "Reset password", State: false, Notes: "It needs active email credentials, and for security reasons, I can't provide mine. But you can test it by getting OTP from database" },
      { Title: "Define Master Data", State: true },
      { Title: "Transactions", State: true },
      { Title: "Report for Item Balances", State: true },
      { Title: "EF Code first", State: true },
      { Title: "Layer for Data Access and Layer for Business Logic", State: true },
      { Title: "REST APIs for Cruds utilizing DI", State: true },
      { Title: "Login through JWT tokens", State: true },
      { Title: "Unit Test using XUnit", State: true },
    ]
  }

}
