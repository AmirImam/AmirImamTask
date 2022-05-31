import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Item } from 'src/app/models/Item';
import { ApiCallerService } from 'src/app/services/api-caller.service';

@Component({
  selector: 'app-item-stores',
  templateUrl: './item-stores.component.html',
  styleUrls: ['./item-stores.component.css']
})
export class ItemStoresComponent implements OnInit {

  constructor(private Path: ActivatedRoute,
    private Api: ApiCallerService) { }

  public ItemModel = new Item();
  private Id: string = "";
  public async ngOnInit(): Promise<void> {
    this.Id = this.Path.snapshot.params["Id"];
    this.ItemModel = await this.Api.GetByIdAsync<Item>("Item", this.Id);
  }

}
