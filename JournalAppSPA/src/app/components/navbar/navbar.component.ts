import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { LoginComponent } from '../login/login.component';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  showPanel: boolean = false;
  showPanelChanged: Subject<boolean> = new Subject<boolean>();
  photo: string;
  username: string;
  @ViewChild(LoginComponent) loginComponent: LoginComponent;

  constructor(private authService: AuthService) {
    this.showPanelChanged.pipe(
      debounceTime(700)).subscribe(show => this.showPanel =show);
   }

  ngOnInit() {
    this.username = localStorage.getItem('username');
    this.authService.photo.subscribe(p => this.photo = p);
    this.authService.username.subscribe(u => this.username = u);
  }

  get state() {
    return this.showPanel ? 'show' : 'hide';
  }

  toogleUserPanel() {
    this.showPanelChanged.next(!this.showPanel);
    this.loginComponent.checkStatus();
  }

  hideUserPanel() {
    this.showPanel = false;
  }

  isLoggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

}
