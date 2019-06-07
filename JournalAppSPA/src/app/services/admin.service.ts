import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserForAdminPanel } from '../models/user-for-admin-panel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  apiUrl = environment.apiUrl;
  baseUrl = this.apiUrl + 'admin/';
  users: UserForAdminPanel[];

  constructor(private http: HttpClient) { }

  getUsers(pageNumber:string, pageSize: string): Observable<UserForAdminPanel[]> {

    var params = new HttpParams().set('pageSize', pageSize).set('pageNumber', pageNumber);

    return this.http.get<UserForAdminPanel[]>(this.baseUrl, {params: params});
  }

  editRoles(model: {}, username: string) {

    return this.http.post(this.baseUrl + 'editroles/'+ username, model);
  }

  deleteUser(username: string) {
    console.log(this.baseUrl + username);
    return this.http.delete(this.baseUrl + username);
  }
}
