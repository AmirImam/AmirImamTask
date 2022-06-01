import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiCallerService } from './services/api-caller.service';
import { SessionManagerService } from './services/session-manager.service';
import { UserAccountService } from './services/user-account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'AmirImamTask.AngularUI';
  constructor(public Session: SessionManagerService,
    public Api: ApiCallerService,
    private navigator: Router,
    private UserAccount: UserAccountService) {

  }
  ngOnInit(): void {
    this.UserAccount.DetectLogged();
    if (this.Session.Me != null) {
      //this.navigator.navigate(["/index"]);
    }
    else {
      this.navigator.navigate(["/login"]);
    }
  }
}
