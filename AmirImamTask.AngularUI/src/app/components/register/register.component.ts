import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ComponentBase } from 'src/app/models/ComponentBase';
import { Person } from 'src/app/models/Person';
import { ApiCallerService } from 'src/app/services/api-caller.service';
import { UserAccountService } from 'src/app/services/user-account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent extends ComponentBase implements OnInit {

  constructor(private Api: ApiCallerService, private UserAccount: UserAccountService) {
    super();
  }

  public Model = new Person();
  @ViewChild("form")
  public FormRef?: ElementRef;
  ngOnInit(): void {
  }



  public async Submit(): Promise<void> {
    this.Errors = [];
    let form = this.FormRef?.nativeElement as HTMLFormElement;
    // let validationResult = form.checkValidity();
    // if (validationResult == false) {
    //   alert("Please fill all your data");
    //   return;
    // }

    let result = await this.Api.PostAsync<Person>("Person", this.Model);

    if (result.Success == false) {
      this.AssignErrors(result.Errors);
    }
    else {
      this.UserAccount.OnLogged(result.Model as Person);
    }
  }
}
