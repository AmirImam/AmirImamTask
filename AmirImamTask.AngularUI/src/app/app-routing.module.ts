import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChangePasswordComponent } from './components/change-password/change-password.component';
import { HomeComponent } from './components/home/home.component';

import { ItemStoresComponent } from './components/item-stores/item-stores.component';
import { ItemsFormComponent } from './components/items-form/items-form.component';
import { ItemsIndexComponent } from './components/items-index/items-index.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { StartupComponent } from './components/startup/startup.component';
import { StoresFormComponent } from './components/stores-form/stores-form.component';
import { StoresIndexComponent } from './components/stores-index/stores-index.component';
import { TransactionsFormComponent } from './components/transactions-form/transactions-form.component';
import { UsersIndexComponent } from './components/users-index/users-index.component';
import { LoginGuardService } from './services/login-guard.service';

const routes: Routes = [
  { path: "*", component: StartupComponent },
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  { path: "change-password", component: ChangePasswordComponent, canActivate: [LoginGuardService] },
  { path: "change-password/:email", component: ChangePasswordComponent },
  { path: "reset-password", component: ResetPasswordComponent },

  { path: "index", component: HomeComponent, canActivate: [LoginGuardService] },
  { path: "users", component: UsersIndexComponent, canActivate: [LoginGuardService] },

  { path: "stores", component: StoresIndexComponent, canActivate: [LoginGuardService] },
  { path: "stores/create", component: StoresFormComponent, canActivate: [LoginGuardService] },
  { path: "stores/edit/:Id", component: StoresFormComponent, canActivate: [LoginGuardService] },


  { path: "items", component: ItemsIndexComponent, canActivate: [LoginGuardService] },
  { path: "items/create", component: ItemsFormComponent, canActivate: [LoginGuardService] },
  { path: "items/edit/:Id", component: ItemsFormComponent, canActivate: [LoginGuardService] },
  { path: "item-stores/:Id", component: ItemStoresComponent, canActivate: [LoginGuardService] },


  { path: "transactions/:Index", component: TransactionsFormComponent, canActivate: [LoginGuardService] },

  { path: "", redirectTo: "*", pathMatch: "full" },
  { path: "**", redirectTo: "*", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
