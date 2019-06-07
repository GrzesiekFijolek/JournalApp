import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable, of } from "rxjs";
import { NewsService } from "../services/news.service";
import { catchError } from "rxjs/operators";
import { DataForNewsDetails } from "../models/data-for-news-details";

@Injectable()

export class NewsDetailsResolver implements Resolve<DataForNewsDetails> {

  constructor(private newsService: NewsService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<DataForNewsDetails> {
    
    return this.newsService.getNewsDetails(route.params['id']).pipe(
      catchError(error => {
        console.log(error);

        return of(null);
      })
    );
  }

}