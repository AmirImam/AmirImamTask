import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Item } from 'src/app/models/Item';
import { ItemStore } from 'src/app/models/ItemStore';
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
  public ItemStoresList = new Array<ItemStore>();
  private Id: string = "";
  public async ngOnInit(): Promise<void> {
    this.Id = this.Path.snapshot.params["Id"];
    this.ItemModel = await this.Api.GetByIdAsync<Item>("Item", this.Id);
    this.ItemStoresList = await this.Api.GetAllAsync<ItemStore>(`ItemStore/GetItemStoresByItem/${this.Id}`);
  }

  public async AddItemToStore(context: ItemStore) {
    let itemStore = {
      ItemId: this.Id,
      StoreId: context.StoreId
    };

    let result = await this.Api.PostAsync<{ Id: string }>("ItemStore", itemStore);
    if (result.Success == true) {
      context.ItemStoreId = result.Model?.Id as string;
      context.Quantity = 0;
      context.ItemId = this.Id;

    }
  }
}
