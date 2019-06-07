import { Injectable } from "@angular/core";
import { NewsForPanel } from "../models/news-for-panel";
import { Resolve, ActivatedRouteSnapshot, Router } from "@angular/router";
import { Observable, of } from "rxjs";
import { ModeratorService } from "../services/moderator.service";
import { catchError } from "rxjs/operators";

@Injectable()

export class ModeratorResolver implements Resolve<NewsForPanel[]>{
  
  constructor(private moderatorService: ModeratorService, private router: Router){}

  resolve(route: ActivatedRouteSnapshot): Observable<NewsForPanel[]> {

    return this.moderatorService.getNews('all', '0', '30').pipe(
      catchError(error => {
        console.log(error);
        return of(null);
      })
    );
  }
}
