import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { NewsForCreate } from "../models/news-for-create";
import { Observable, of } from "rxjs";
import { ModeratorService } from "../services/moderator.service";
import { catchError } from "rxjs/operators";

@Injectable()

export class NewsEditResolver implements Resolve<NewsForCreate>{

  constructor(private moderatorService: ModeratorService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<NewsForCreate> {

    return this.moderatorService.getNewsToEdit(route.params['id']).pipe(
      catchError(error => {
        console.log(error);

        return of(null);
      })
    )
  }
}
