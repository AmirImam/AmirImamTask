import { Component, OnInit } from '@angular/core';
import { Store } from 'src/app/models/Store';
import { ApiCallerService } from 'src/app/services/api-caller.service';

@Component({
  selector: 'app-stores-index',
  templateUrl: './stores-index.component.html',
  styleUrls: ['./stores-index.component.css']
})
export class StoresIndexComponent implements OnInit {

  constructor(private Api: ApiCallerService) { }

  public StoresList = new Array<Store>();
  public async ngOnInit(): Promise<void> {
    this.StoresList = await this.Api.GetAllAsync<Store>("Store");
  }

}
