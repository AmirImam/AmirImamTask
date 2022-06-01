import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ChangePasswordModel } from 'src/app/models/ChangePasswordModel';
import { ComponentBase } from 'src/app/models/ComponentBase';
import { Person } from 'src/app/models/Person';
import { ApiCallerService } from 'src/app/services/api-caller.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent extends ComponentBase implements OnInit {

  constructor(private Api: ApiCallerService, private Navigator: Router) {
    super();
  }

  public email: string = "";
  public isOtpSubmitted = false;
  public showResetPassword = false;
  public otpItems = new Array<string>();
  public id?: string;
  public Model = new ChangePasswordModel();
  ngOnInit(): void {
    this.otpItems.push("");
    this.otpItems.push("");
    this.otpItems.push("");
    this.otpItems.push("");
  }

  public async CreateOtp() {
    let result = await this.Api.PostAsync<Person>(`Person/CreateOtp/${this.email}`, null);
    if (result.Success == false) {
      this.AssignErrors(result.Errors);
    }
    else {
      this.isOtpSubmitted = true;
      this.id = result.Model?.Id;
    }
  }

  public SetOtp(index: number, e: Event) {
    let element = e.target as HTMLInputElement;
    this.otpItems[index] = element.value;
  }
  public async Submit() {
    let otp = `${this.otpItems[0]}${this.otpItems[1]}${this.otpItems[2]}${this.otpItems[3]}`;
    let result = await this.Api.PostAsync<Person>(`Person/SubmitOtp/${this.id}/${otp}`, null);
    if (result.Success == false) {
      this.AssignErrors(result.Errors);
    }
    else {
      this.showResetPassword = true;
    }
  }

  public async SubmitResetPassword() {
    let result = await this.Api.PostAsync<Person>(`Person/ResetPassword/${this.id}`, this.Model);
    if (result.Success == false) {
      this.AssignErrors(result.Errors);
    }
    else {
      this.Navigator.navigate(['/login']);
    }
  }
}
