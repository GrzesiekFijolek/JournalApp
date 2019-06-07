import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, Router } from "@angular/router";
import { Observable, of } from "rxjs";
import { NewsService } from "../services/news.service";
import { catchError } from "rxjs/operators";
import { NewsForSection } from "../models/news-for-section";

@Injectable()

export class SectionResolver implements Resolve<NewsForSection> {

  constructor(private newsService: NewsService, private router: Router) {}

  resolve(route: ActivatedRouteSnapshot): Observable<NewsForSection> {

    return this.newsService.getSectionNews(route.data['section'], '0', '16').pipe(
      catchError(error => {
        console.log(error);

        return of(null);
      })
    );
  }

}