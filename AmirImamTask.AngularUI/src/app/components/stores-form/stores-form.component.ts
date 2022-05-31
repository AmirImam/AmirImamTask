import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { ComponentBase } from 'src/app/models/ComponentBase';
import { Person } from 'src/app/models/Person';
import { Store } from 'src/app/models/Store';
import { ApiCallerService } from 'src/app/services/api-caller.service';

@Component({
  selector: 'app-stores-form',
  templateUrl: './stores-form.component.html',
  styleUrls: ['./stores-form.component.css']
})
export class StoresFormComponent extends ComponentBase implements OnInit {

  constructor(private Api: ApiCallerService,
    private Navigator: Router,
    private Path: ActivatedRoute) {
    super();
  }

  public Model = new Store();
  public PersonsList = new Array<Person>();
  public async ngOnInit(): Promise<void> {
    this.PersonsList = await this.Api.GetAllAsync<Person>("Person");
    let id = this.Path.snapshot.params["Id"];
    if (id != null) {
      this.Model = await this.Api.GetByIdAsync<Store>("Store", id);
    }

  }


  public async Submit() {
    let result = this.Model.Id == Guid.EMPTY ? await this.Api.PostAsync<Store>("Store", this.Model)
      : await this.Api.PutAsync<Store>("Store", this.Model);

    if (result.Success == false) {
      this.AssignErrors(result.Errors);
    }
    else {
      this.Navigator.navigate(['/stores']);
    }
  }
}
