import { Routes } from '@angular/router';
import { BowlerComponent } from './components/bowler/bowler.component';
import { BowlerLeagueComboComponent } from './components/bowler-league-combo/bowler-league-combo.component';
import { DtoComponent } from './components/dto/dto.component';
import { SeriesComponent } from './components/series/series.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { HomepageComponent } from './components/homepage/homepage.component';

export const routes: Routes = [
    {path: '', redirectTo: 'login', pathMatch: 'full'},
    {path: 'login', component: LoginComponent, pathMatch: 'full'},
    {path: 'signup', component: SignupComponent, pathMatch: 'full'},
    {path: 'homepage', component: HomepageComponent, pathMatch: 'full'},
    {path: 'league-details', component: DtoComponent, pathMatch: 'full'},
    {path: 'bowler', component: BowlerComponent, pathMatch: 'full'},
    {path: 'bowler-league-combo', component: BowlerLeagueComboComponent, pathMatch: 'full'},
    {path: 'series', component: SeriesComponent, pathMatch: 'full'}
];
