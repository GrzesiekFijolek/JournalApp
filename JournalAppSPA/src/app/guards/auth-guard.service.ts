import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate{

  constructor(private authService: AuthService, private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot) {

    if(this.authService.isLoggegIn()){

    var allowedRoles = route.data['roles'] as Array<string>;

    if(this.authService.checkRoles(allowedRoles)) 
    return true;

    else {
      this.router.navigate(['/e403']);
      console.log('dasdsadas');
      return false;
    }
  }

  else {
    this.router.navigate(['/e403']);
      return false;
  }

  }
}
