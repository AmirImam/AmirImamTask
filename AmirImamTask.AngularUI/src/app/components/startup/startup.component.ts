import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SessionManagerService } from 'src/app/services/session-manager.service';
import { UserAccountService } from 'src/app/services/user-account.service';

@Component({
  selector: 'app-startup',
  templateUrl: './startup.component.html',
  styleUrls: ['./startup.component.css']
})
export class StartupComponent implements OnInit {

  constructor(private navigator: Router, private Session: SessionManagerService, private UserAccount: UserAccountService) {


  }

  ngOnInit() {

    this.UserAccount.DetectLogged();

    if (this.Session.Me != null) {
      this.navigator.navigate(["/index"]);
    }
    else {
      this.navigator.navigate(["/login"]);
    }
  }

}
