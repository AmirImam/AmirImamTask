import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ChangePasswordModel } from 'src/app/models/ChangePasswordModel';
import { ComponentBase } from 'src/app/models/ComponentBase';
import { Person } from 'src/app/models/Person';
import { ApiCallerService } from 'src/app/services/api-caller.service';
import { SessionManagerService } from 'src/app/services/session-manager.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent extends ComponentBase implements OnInit {

  constructor(private Api: ApiCallerService,
    private Session: SessionManagerService,
    private Navigator: Router) {
    super();
  }

  public Model = new ChangePasswordModel();
  ngOnInit(): void {
  }

  public async Submit() {
    this.Errors = [];
    if (this.Model.CurrentPassword == "") {
      this.AssignError("CurrentPassword", "Required");
    }
    if (this.Model.NewPassword == "") {
      this.AssignError("NewPassword", "Required");
    }
    if (this.Model.ConfirmPassword == "") {
      this.AssignError("ConfirmPassword", "Required");
    }
    if (this.Model.NewPassword != this.Model.ConfirmPassword) {
      this.AssignError("ConfirmPassword", "Confirm password dosn't match new password");

    }
    if (this.Errors.length > 0) {
      return;
    }
    this.Model.Email = this.Session.Me?.Email as string;
    let result = await this.Api.PostAsync<Person>("Person/ChangePassword", this.Model);
    if (result.Success == false) {
      this.AssignErrors(result.Errors);
    }
    else {
      this.Navigator.navigate(['/index']);
    }
  }
}
