import { Injectable } from '@angular/core';
import { Person } from '../models/Person';

@Injectable({
  providedIn: 'root'
})
export class SessionManagerService {

  constructor() { }

  public Me?: Person;
}
