import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ComponentBase } from 'src/app/models/ComponentBase';
import { LoginModel } from 'src/app/models/LoginModel';
import { Person } from 'src/app/models/Person';
import { ApiCallerService } from 'src/app/services/api-caller.service';
import { SessionManagerService } from 'src/app/services/session-manager.service';
import { UserAccountService } from 'src/app/services/user-account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent extends ComponentBase implements OnInit {

  constructor(private Session: SessionManagerService,
    private Navigator: Router,
    private UserAccount: UserAccountService,
    private Api: ApiCallerService) { super(); }
  public Model = new LoginModel();
  ngOnInit(): void {
    if (this.Session.Me != null) {
      this.Navigator.navigate(["/home"]);
    }
  }

  public async LoginSubmit(): Promise<void> {
    this.Errors = [];
    let result = await this.Api.PostAsync<Person>("Person/Login", this.Model);
    if (result.Success == false) {
      this.AssignErrors(result.Errors);
    }
    else {
      this.UserAccount.OnLogged(result.Model as Person);
    }
  }
}
