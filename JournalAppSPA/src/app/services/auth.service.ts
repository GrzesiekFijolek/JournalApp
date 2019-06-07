import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  
  apiUrl = environment.apiUrl;
  baseUrl = this.apiUrl + 'auth/';
  decodedToken: any;
  jwtHelper = new JwtHelperService();
  photoUrl = new BehaviorSubject<string>('../../assets/img/user.png');
  photo = this.photoUrl.asObservable();
  user = new BehaviorSubject<string>('');
  username = this.user.asObservable();

  constructor(private http: HttpClient) {

    if(this.isLoggegIn) {
      this.photoUrl.next(localStorage.getItem('photo'));
      this.user.next(localStorage.getItem('username'));
    }
   }
  
  login(model:any) {
    // console.log(this.photo);
    return this.http.post(this.baseUrl + 'login', model).pipe(map((response: any) => {
      
      const user = response;
      if(user) {
        localStorage.setItem('token', user.token);
        localStorage.setItem('username', user.username);
        localStorage.setItem('photo', user.photo);
        this.showUserInfo(response.photo, response.username);
        this.decodedToken = this.jwtHelper.decodeToken(user.token);
      }
    }))
  }

  isLoggegIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'register', model).pipe(map((response: any) => {
      if(response) {
        console.log(response);
      }
    }))
  }

  showUserInfo(photoUrl: string, username: string) {
    this.photoUrl.next(photoUrl);
    this.user.next(username);
  }

  checkRoles(allowedRoles: string[]) {
    var isMatch = false;
    var decodeToken = this.jwtHelper.decodeToken(localStorage.getItem('token'));
    var userRoles = decodeToken.role as Array<string>;
    allowedRoles.forEach(role => {
      if(userRoles.includes(role)) {
        isMatch = true;
        return;
      }
    });

    return isMatch;
  }

}
