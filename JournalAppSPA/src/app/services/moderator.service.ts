import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { NewsForPanel } from '../models/news-for-panel';
import { Observable } from 'rxjs';
import { CommentForCreate } from '../models/comment-for-create';

@Injectable({
  providedIn: 'root'
})
export class ModeratorService {

  apiUrl = environment.apiUrl;
  baseUrl = this.apiUrl + 'moderator/';
  
  constructor(private http: HttpClient) { }

  addNews(news: any) {

    return this.http.post(this.baseUrl + 'add', news).pipe(map((response: any) => {
      if(response) {
      }
    }));
  }

  getNews(section: string, pageNumber:string, pageSize: string): Observable<NewsForPanel[]> {

    var params = new HttpParams().set('section', section).set('pageSize', pageSize).set('pageNumber', pageNumber);

    return this.http.get<NewsForPanel[]>(this.baseUrl, {params: params});
  }

  deleteNews(id: number) {

    return this.http.delete(this.baseUrl + id.toString());
  }

  deleteComment(id: number) {

    return this.http.delete(this.baseUrl + 'comment/' + id.toString());
  }

  getNewsToEdit(i: number) {

    return this.http.get(this.baseUrl + 'newstoedit/' + i.toString());
  }

  editNews(i: number, news: any) {
    return this.http.patch(this.baseUrl + 'edit/' + i, news);
  }

  addComment(comment: CommentForCreate) {

    return this.http.post(this.baseUrl + 'addcomment', comment);
  }
}
