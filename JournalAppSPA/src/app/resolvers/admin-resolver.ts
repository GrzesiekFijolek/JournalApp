import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { UserForAdminPanel } from "../models/user-for-admin-panel";
import { AdminService } from "../services/admin.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";

@Injectable()

export class AdminResolver implements Resolve<UserForAdminPanel[]>{
  
  constructor(private adminService: AdminService, private router: Router) {}

  resolve(route: ActivatedRouteSnapshot): Observable<UserForAdminPanel[]> {

    return this.adminService.getUsers('0', '30').pipe(
      catchError(error => {
        console.log(error);

        return of(null);
      })
    );
  }
}
