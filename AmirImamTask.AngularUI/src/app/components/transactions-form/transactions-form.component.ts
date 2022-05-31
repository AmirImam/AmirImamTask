import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';
import { ComponentBase } from 'src/app/models/ComponentBase';
import { Store } from 'src/app/models/Store';
import { Transaction } from 'src/app/models/Transaction';
import { TransactionDetail } from 'src/app/models/TransactionDetail';
import { ApiCallerService } from 'src/app/services/api-caller.service';

@Component({
  selector: 'app-transactions-form',
  templateUrl: './transactions-form.component.html',
  styleUrls: ['./transactions-form.component.css']
})
export class TransactionsFormComponent extends ComponentBase implements OnInit {

  constructor(private Path: ActivatedRoute, private Api: ApiCallerService) {
    super();
  }

  public Model = new Transaction();
  public StoresList = new Array<Store>();
  public ItemsList = new Array<TransactionDetail>();
  public DetailsList = new Array<TransactionDetail>();
  public DetailModel = new TransactionDetail();
  private TransactionType: number = 0;
  public async ngOnInit(): Promise<void> {
    this.Model.TransactionDate = new Date();
    this.TransactionType = this.Path.snapshot.params["Index"];
    this.StoresList = await this.Api.GetAllAsync<Store>("Store");
  }


  public async ItemFinderInputKeyUp(e: Event): Promise<void> {
    let element = e.target as HTMLSelectElement;
    let value = element.value;
    this.ItemsList = await this.Api.GetAllAsync<TransactionDetail>(`TransactionDetail/FindItemsByStoreAsync/${value}`);
    if (this.ItemsList.length > 0) {

      this.DetailModel.Price = this.ItemsList[0].Price;
      this.DetailModel.Quantity = 1;
    }
  }

  public async AddItem(): Promise<void> {
    let item: TransactionDetail = {
      ItemName: this.ItemsList.find(it => it.ItemId == this.DetailModel.ItemId)?.ItemName,
      ItemCode: this.DetailModel.ItemCode,
      ItemDescription: this.DetailModel.ItemDescription,
      Price: this.DetailModel.Price,
      Quantity: this.DetailModel.Quantity,
      Value: 0,
      TransactionFactor: this.TransactionType,
      Id: Guid.EMPTY,
      ItemId: this.DetailModel.ItemId
    };
    item.Value = item.Price * item.Quantity;

    this.DetailsList.push(item);
    this.CalculateTotals();
  }

  public RemoveItem(index: number) {
    this.DetailsList.splice(index, 1);
    this.CalculateTotals();
  }

  public CalculateTotals() {


    this.Model.ItemsCount = this.DetailsList.reduce((accumulator, obj) => {
      return accumulator + obj.Quantity;
    }, 0);
    this.Model.TotalPrices = this.DetailsList.reduce((accumulator, obj) => {
      return accumulator + obj.Price;
    }, 0);
    this.Model.Net = this.DetailsList.reduce((accumulator, obj) => {
      return accumulator + obj.Value;
    }, 0);
  }

  public async Submit(): Promise<void> {
    this.Errors = [];
    this.Model.TransactionDetails = this.DetailsList;
    var result = await this.Api.PostAsync<Transaction>("Transaction", this.Model);
    if (result.Success == true) {
      this.Model = new Transaction();
      this.Model.TransactionDate = new Date();
      this.ItemsList = [];
      this.DetailsList = [];
      this.DetailModel = new TransactionDetail();
    }
    else {
      this.AssignErrors(result.Errors);
    }
  }
}
