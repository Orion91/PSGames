import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BsDropdownModule } from 'ngx-bootstrap';
import { JwtModule } from '@auth0/angular-jwt';


import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { UserGameLibraryComponent } from './games/user-game-library/user-game-library.component';
import { GameLibraryComponent } from './games/game-library/game-library.component';
import { ProfileListComponent } from './profiles/profile-list/profile-list.component';
import { appRoutes } from './routes';
import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/user.service';
import { ProfileCardComponent } from './profiles/profile-card/profile-card.component';
import { GameCardComponent } from './games/game-card/game-card.component';
import { GameService } from './_services/game.service';

export function tokenGetter () {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      UserGameLibraryComponent,
      GameLibraryComponent,
      GameCardComponent,
      ProfileListComponent,
      ProfileCardComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      })
   ],
   providers: [
      AuthService,
      AuthGuard,
      UserService,
      GameService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
