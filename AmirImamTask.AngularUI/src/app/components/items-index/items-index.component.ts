import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/models/Item';
import { ApiCallerService } from 'src/app/services/api-caller.service';

@Component({
  selector: 'app-items-index',
  templateUrl: './items-index.component.html',
  styleUrls: ['./items-index.component.css']
})
export class ItemsIndexComponent implements OnInit {

  constructor(private Api: ApiCallerService) { }

  public ItemsList = new Array<Item>();
  public async ngOnInit(): Promise<void> {
    this.ItemsList = await this.Api.GetAllAsync<Item>("Item");
  }

}
