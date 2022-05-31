import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { StartupComponent } from './components/startup/startup.component';
import { HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './components/register/register.component';
import { FormsModule } from '@angular/forms';
import { ErrorSummaryComponent } from './components/error-summary/error-summary.component';
import { UsersIndexComponent } from './components/users-index/users-index.component';
import { StoresIndexComponent } from './components/stores-index/stores-index.component';
import { StoresFormComponent } from './components/stores-form/stores-form.component';
import { FormContainerComponent } from './components/form-container/form-container.component';
import { ItemsIndexComponent } from './components/items-index/items-index.component';
import { ItemsFormComponent } from './components/items-form/items-form.component';
import { ItemStoresComponent } from './components/item-stores/item-stores.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    StartupComponent,
    RegisterComponent,
    ErrorSummaryComponent,
    UsersIndexComponent,
    StoresIndexComponent,
    StoresFormComponent,
    FormContainerComponent,
    ItemsIndexComponent,
    ItemsFormComponent,
    ItemStoresComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
