import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { DataForHome } from "../models/data-for-home";
import { NewsService } from "../services/news.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";

@Injectable()

export class HomeResolver implements Resolve<DataForHome> {

  constructor(private newsService: NewsService) {}

  resolve(): Observable <DataForHome> {

    return this.newsService.getHome().pipe(
      catchError(error => {
        console.log(error);

        return of(null);
      })
    );
  }
}

