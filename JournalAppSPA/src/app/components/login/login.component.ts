import { Component, OnInit, Input, HostListener, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserForLogin } from 'src/app/models/user-for-login';
import { HasRoleDirective } from 'src/app/directives/has-role.directive';
import { RoleService } from 'src/app/services/role.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {

  @HostListener('document:click', ['$event']) hidePanel(event) {
    if(this.eRef.nativeElement.contains(event.target)) {
    } else {
      var attr = event.target.attributes.name;
      if(attr) {
        if(attr.nodeValue){
          if(attr.nodeValue != 'user-info'){
            this.hide();
          }
        }
      }
      else {
        this.hide();
      }
    }
  }

  @Input() show: boolean = false;
  @Output() hideLogin = new EventEmitter<void>();

  constructor(private authService: AuthService, private eRef: ElementRef, private roleService: RoleService) { }

  model: UserForLogin;
  error: string = null;
  showLoginPanel: boolean;
  showUserPanel: boolean;

  ngOnInit() {

  }

  login() {
    this.error = null;
    this.authService.login(this.model).subscribe(() => {
      this.error = null;
      this.model = new UserForLogin();
      this.hide();
      this.roleService.emitChange();
    }, error => {
     error = "Unauthorized" ? this.error = "Neepoprawny login lub hasło" : this.error = error;
    });
  }

  logout() {
    this.hide();
    localStorage.removeItem('username');
    localStorage.removeItem('token');
    this.authService.decodedToken = null;
    this.authService.showUserInfo('../../assets/img/user.png', null);  
    this.roleService.emitChange();
  }

  hide() {
    this.hideLogin.emit();
    setTimeout(() => {
      this.showLoginPanel = false;
      this.showUserPanel = false;
    }, 1000);
  }

  isLoggedIn() {
    const token = localStorage.getItem('token');

    return !!token;
  }

  checkStatus() {
    this.isLoggedIn() ? this.showUserPanel = true : this.showUserPanel = false;
    this.isLoggedIn() ? this.showLoginPanel = false : this.showLoginPanel = true;
    this.model = new UserForLogin();
  }
}
