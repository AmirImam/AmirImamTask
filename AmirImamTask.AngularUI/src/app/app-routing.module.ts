import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { StartupComponent } from './components/startup/startup.component';
import { LoginGuardService } from './services/login-guard.service';

const routes: Routes = [
  { path: "*", component: StartupComponent },
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },


  { path: "index", component: HomeComponent, canActivate: [LoginGuardService] },


  { path: "", redirectTo: "*", pathMatch: "full" },
  { path: "**", redirectTo: "*", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
