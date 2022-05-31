import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/models/Person';
import { ApiCallerService } from 'src/app/services/api-caller.service';

@Component({
  selector: 'app-users-index',
  templateUrl: './users-index.component.html',
  styleUrls: ['./users-index.component.css']
})
export class UsersIndexComponent implements OnInit {

  constructor(private Api: ApiCallerService) { }

  public UsersList = new Array<Person>();
  public async ngOnInit(): Promise<void> {
    this.UsersList = await this.Api.GetAllAsync<Person>("Person");
  }

}
