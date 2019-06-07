import { Routes } from '@angular/router';
import { SectionResolver } from './resolvers/section-resolver';
import { SectionComponent } from './components/section/section.component';
import { NewsDetailsComponent } from './components/news-details/news-details.component';
import { NewsDetailsResolver } from './resolvers/news-details-resolver';
import { HomeComponent } from './components/home/home.component';
import { HomeResolver } from './resolvers/home-resolver';
import { AddNewsComponent } from './components/add-news/add-news.component';
import { RegisterComponent } from './components/register/register.component';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { AdminResolver } from './resolvers/admin-resolver';
import { NewsPanelComponent } from './components/news-panel/news-panel.component';
import { ModeratorResolver } from './resolvers/moderator-resolver';
import { NewsEditResolver } from './resolvers/news-edit-resolver';
import { EditNewsComponent } from './components/edit-news/edit-news.component';
import { AuthGuardService } from './guards/auth-guard.service';
import { E403Component } from './components/e403/e403.component';


export const appRoutes: Routes = [
  {path: 'register', component: RegisterComponent},

  {path: 'admin-panel', runGuardsAndResolvers: 'always', canActivate: [AuthGuardService],
  component: AdminPanelComponent, resolve: {users: AdminResolver}, data: {roles: ['Admin']} },

  {path: 'news-panel', runGuardsAndResolvers: 'always', canActivate: [AuthGuardService],
  component: NewsPanelComponent, resolve: {news: ModeratorResolver}, data: {roles: ['Moderator']} },

  {path: 'edit/:id', runGuardsAndResolvers: 'always', canActivate: [AuthGuardService],
  component: EditNewsComponent, resolve: {news: NewsEditResolver}, data: {roles: ['Moderator']} },

  {path: 'add', runGuardsAndResolvers: 'always', canActivate: [AuthGuardService],
  component: AddNewsComponent, data: {roles: ['Moderator']}},

  {path: 'e403', component: E403Component },
  {path: 'poland', component: SectionComponent, resolve: {news: SectionResolver}, data: {section: "poland"}},
  {path: 'sport', component: SectionComponent, resolve: {news: SectionResolver}, data: {section: "sport"}},
  {path: 'world', component: SectionComponent, resolve: {news: SectionResolver}, data: {section: "world"}},
  {path: 'business', component: SectionComponent, resolve: {news: SectionResolver}, data: {section: "business"}},
  {path: 'policy', component: SectionComponent, resolve: {news: SectionResolver}, data: {section: "policy"}},
  {path: ':id', component: NewsDetailsComponent, resolve: {data: NewsDetailsResolver} },
  {path: '', component: HomeComponent, resolve: {news: HomeResolver} },
  {path:'**', component: HomeComponent, pathMatch: 'full' }
];