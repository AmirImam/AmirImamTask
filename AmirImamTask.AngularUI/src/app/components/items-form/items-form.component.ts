import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { ComponentBase } from 'src/app/models/ComponentBase';
import { Item } from 'src/app/models/Item';
import { ApiCallerService } from 'src/app/services/api-caller.service';

@Component({
  selector: 'app-items-form',
  templateUrl: './items-form.component.html',
  styleUrls: ['./items-form.component.css']
})
export class ItemsFormComponent extends ComponentBase implements OnInit {

  constructor(private Api: ApiCallerService,
    private Navigator: Router,
    private Path: ActivatedRoute) {
    super();
  }

  public Model = new Item();

  public async ngOnInit(): Promise<void> {

    let id = this.Path.snapshot.params["Id"];
    if (id != null) {
      this.Model = await this.Api.GetByIdAsync<Item>("Item", id);
    }

  }


  public async Submit() {
    let result = this.Model.Id == Guid.EMPTY ? await this.Api.PostAsync<Item>("Item", this.Model)
      : await this.Api.PutAsync<Item>("Item", this.Model);

    if (result.Success == false) {
      this.AssignErrors(result.Errors);
    }
    else {
      this.Navigator.navigate(['/item-stores', result.Model?.Id]);
    }
  }
}
