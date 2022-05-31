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

  public async GetAllAsync<T>(path: string): Promise<T[]> {
    let response = await fetch(`${this.BaseUrl}${path}`, {
      headers: this.RequestHeaders,
      method: "GET"
    });
    let json = await response.json() as T[];
    return json;
  }

  public async GetByIdAsync<T>(path: string, id: string): Promise<T> {
    let response = await fetch(`${this.BaseUrl}${path}/${id}`, {
      headers: this.RequestHeaders,
      method: "GET"
    });
    let json = await response.json() as T;
    return json;
  }


  public async PostAsync<T>(path: string, model: any): Promise<ResponseResult<T>> {
    return await this.SendAsync<T>(path, "POST", model);
  }

  public async PutAsync<T>(path: string, model: any): Promise<ResponseResult<T>> {
    return await this.SendAsync<T>(path, "PUT", model);
  }

  public async SendAsync<T>(path: string, method: string, model: any): Promise<ResponseResult<T>> {
    let request: RequestInit = {
      body: null,
      method: method,
      headers: this.RequestHeaders
    };
    if (model != null) {
      request.body = JSON.stringify(model);
    }
    let response = await fetch(`${this.BaseUrl}${path}`, request);

    let responseText = await response.text();
    responseText = responseText.replace("errors", "Errors");
    let responseJson = JSON.parse(responseText) as ResponseResult<T>;// (await response.json()) as ResponseResult<T>;// (await firstValueFrom(response));
    responseJson.Success = response.ok;
    console.log(responseJson.Errors);

    return responseJson;
  }
}
