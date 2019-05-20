import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { GameLibraryComponent } from './games/game-library/game-library.component';
import { UserGameLibraryComponent } from './games/user-game-library/user-game-library.component';
import { ProfileListComponent } from './profiles/profile-list/profile-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { GameDetailComponent } from './games/game-detail/game-detail.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'games', component: GameLibraryComponent },
            { path: 'games/:id', component: GameDetailComponent },
            { path: 'userLibrary', component: UserGameLibraryComponent },
            { path: 'profiles', component: ProfileListComponent }
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full' }
];
