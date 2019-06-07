import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { BoxComponent } from './components/box/box.component';
import { SectionHeaderComponent } from './components/section-header/section-header.component';
import { OthersNewsComponent } from './components/others-news/others-news.component';
import { OthersNewsItemComponent } from './components/others-news-item/others-news-item.component';
import { NewsDetailsComponent } from './components/news-details/news-details.component';
import { LoginComponent } from './components/login/login.component';
import { UserPanelComponent } from './components/user-panel/user-panel.component';
import { HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './components/register/register.component';
import { ErrorInterceptorProvide } from './services/error.interceptor';
import { appRoutes } from './routes';
import { AuthService } from './services/auth.service';
import { NewsService } from './services/news.service';
import { SectionResolver } from './resolvers/section-resolver';
import { SectionComponent } from './components/section/section.component';
import { NewsDetailsResolver } from './resolvers/news-details-resolver';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { HomeComponent } from './components/home/home.component';
import { HomeResolver } from './resolvers/home-resolver';
import { LatestNewsComponent } from './components/latest-news/latest-news.component';
import { LatestNewsItemComponent } from './components/latest-news-item/latest-news-item.component';
import { AddNewsComponent } from './components/add-news/add-news.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { AdminResolver } from './resolvers/admin-resolver';
import { ModalModule } from 'angular-custom-modal';
import { EditRoleComponent } from './components/edit-role/edit-role.component';
import { NewsPanelComponent } from './components/news-panel/news-panel.component';
import { ModeratorResolver } from './resolvers/moderator-resolver';
import { NewsEditResolver } from './resolvers/news-edit-resolver';
import { EditNewsComponent } from './components/edit-news/edit-news.component';
import { HasRoleDirective } from './directives/has-role.directive';
import { E403Component } from './components/e403/e403.component';
import { CommentComponent } from './components/comment/comment.component';
import { FooterComponent } from './components/footer/footer.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    BoxComponent,
    SectionHeaderComponent,
    OthersNewsComponent,
    OthersNewsItemComponent,
    NewsDetailsComponent,
    LoginComponent,
    UserPanelComponent,
    RegisterComponent,
    SectionComponent,
    HomeComponent,
    LatestNewsComponent,
    LatestNewsItemComponent,
    AddNewsComponent,
    AdminPanelComponent,
    EditRoleComponent,
    NewsPanelComponent,
    EditNewsComponent,
    HasRoleDirective,
    E403Component,
    CommentComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ModalModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    InfiniteScrollModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:5001'],
        blacklistedRoutes: ['localhost:5001/api/auth']
      }
    })
  ],
  providers: [ErrorInterceptorProvide, FormBuilder, AuthService, NewsService, 
    SectionResolver, NewsDetailsResolver, HomeResolver, AdminResolver, ModeratorResolver, NewsEditResolver],
  bootstrap: [AppComponent]
})
export class AppModule { }
