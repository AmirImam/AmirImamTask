import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { ResponseResult } from '../models/ResponseResult';
import { SessionManagerService } from './session-manager.service';

@Injectable({
  providedIn: 'root'
})
export class ApiCallerService {

  constructor(private Session: SessionManagerService) { }

  private BaseUrl: string = "https://localhost:7231/api/";

  private get RequestHeaders(): Headers {
    let headers: HeadersInit = new Headers();
    headers.set("content-type", "application/json");
    if (this.Session.Me != null) {
      headers.set("Authorization", `bearer ${this.Session.Me.AccessToken}`);
    }
    return headers;
  }

  public async PostAsync<T>(path: string, model: any): Promise<ResponseResult<T>> {
    let response = await fetch(`${this.BaseUrl}${path}`, {
      body: JSON.stringify(model),
      method: "POST",
      headers: this.RequestHeaders
    });

    // if (response.status != 200) {
    //   let text = await response.text();
    //   let errors = JSON.parse(text) as Array<{ Key: string, Value: Array<string> }>;
    //   let result = new ResponseResult<T>();
    //   result.Errors = errors;
    //   return result;
    // }
    let responseText = await response.text();
    responseText = responseText.replace("errors", "Errors");
    let responseJson = JSON.parse(responseText) as ResponseResult<T>;// (await response.json()) as ResponseResult<T>;// (await firstValueFrom(response));
    responseJson.Success = response.ok;
    console.log(responseJson.Errors);

    return responseJson;
  }
}
