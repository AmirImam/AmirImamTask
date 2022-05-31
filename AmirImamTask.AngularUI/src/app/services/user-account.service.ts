import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Person } from '../models/Person';
import { SessionManagerService } from './session-manager.service';

@Injectable({
  providedIn: 'root'
})
export class UserAccountService {

  constructor(private Session: SessionManagerService,
    private Navigator: Router) { }


  public OnLogged(person: Person) {
    //In real application this will be encrypted
    sessionStorage.setItem("Person", JSON.stringify(person));
    this.Session.Me = person;
    this.Navigator.navigate(["/index"]);
  }

  public DetectLogged() {

    let testItem = sessionStorage.getItem("Person");
    if (testItem != null) {
      let person = JSON.parse(testItem);
      this.Session.Me = person;
    }
  }
}
