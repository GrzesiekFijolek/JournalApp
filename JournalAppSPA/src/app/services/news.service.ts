import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NewsForSection } from '../models/news-for-section';
import { DataForNewsDetails } from '../models/data-for-news-details';
import { DataForHome } from '../models/data-for-home';
import { NewsForCreate } from '../models/news-for-create';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  apiUrl = environment.apiUrl;
  baseUrl = this.apiUrl + 'news/';

  constructor(private http: HttpClient) { }

  getSectionNews(section: string, pageNumber:string, pageSize: string): Observable<NewsForSection[]> {

    var params = new HttpParams().set('section', section).set('pageSize', pageSize).set('pageNumber', pageNumber);

    return this.http.get<NewsForSection[]>(this.baseUrl, {params: params});
  }


  getNewsDetails(id: string): Observable<DataForNewsDetails> {

    return this.http.get<DataForNewsDetails>(this.baseUrl + id);
  }

  getHome() {

    return this.http.get<DataForHome>(this.baseUrl + 'home');
  }
}